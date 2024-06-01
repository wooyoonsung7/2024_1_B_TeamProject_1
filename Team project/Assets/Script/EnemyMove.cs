using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    public static EnemyMove Instance;
    public GameObject towerController;
    public int damage = 1; // 몬스터가 입구에 도달했을 때 입히는 데미지

    public string EnemyName;
    public int EnemyHp = 10;
    public float speed = 5f;
    public Transform[] target;
    int a;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == target[0].position) a = 1;

        if (transform.position == target[1].position) a = 2;

        if (transform.position == target[2].position) a = 3;

        if (transform.position == target[3].position) Debug.Log("완료");

        switch (a)
        {
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, target[1].position, speed * Time.deltaTime);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, target[2].position, step);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, target[3].position, step);
                break;
        }
    }
    public void OnDamage()
    {
        Debug.Log("된다");
        EnemyHp -= towerController.GetComponent<TowerController>().attackValue;

        if (EnemyHp == 0)
        {
            Debug.Log("된다2");
            Destroy(gameObject);
        }
    }

    // 플레이어의 트리거 영역에 들어왔을 때 호출되는 메서드
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();  // 충돌한 대상이 플레이어인지 확인.
            if (playerHealth != null)                                        // 충돌한 대상으로부터 PlayerHealth 컴포넌트를 가져옴.
            {
                playerHealth.TakeDamage(damage);                             // 플레이어의 체력을 몬스터의 데미지만큼 감소.
                Destroy(gameObject);                                        // 몬스터를 파괴.
            }
        }
        //else if (other.CompareTag("Entrance"))
        //{
        //    GameManager gameManager = FindObjectOfType<GameManager>(); // GameManager 인스턴스 찾기
        //    if (gameManager != null)
        //    {
        //        gameManager.CheckClear(); // 클리어 조건 확인
        //    }
        //    Destroy(gameObject); // 몬스터를 파괴.
        //}
    }

}
