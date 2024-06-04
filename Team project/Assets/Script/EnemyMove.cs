using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{    
    public GameObject bulletPf;
    public int damage = 1; // 몬스터가 입구에 도달했을 때 입히는 데미지

    public string EnemyName;
    public int EnemyHp = 10;
    public float speed = 5f;
    public Transform[] target = new Transform[5];
    public float step;
    int a;

    void Start() 
    {
        GameManager gameManager = GameManager.Instance;

        for(int i = 0; i < 5; i++)
        {
            target[i] = gameManager.point[i];
        }
        a = 1;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == target[0].position) a = 2;

        if (transform.position == target[1].position) a = 3;

        if (transform.position == target[2].position) a = 4;

        if (transform.position == target[3].position) a = 5;

        if (transform.position == target[4].position) 
            Destroy(gameObject);

        switch (a)
        {
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, target[0].position, step);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, target[1].position, step);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, target[2].position, step);
                break;
            case 4:
                transform.position = Vector3.MoveTowards(transform.position, target[3].position, step);
                break;
            case 5:
                transform.position = Vector3.MoveTowards(transform.position, target[4].position, step);
                break;
        }
        //if (transform.position == target[2].position) a = 4;
        //변환되는 것(행동의 바뀌는 것은 메서드를 사용하는 것이 좋다), Vector3.MoveTowards는 Update()안에서만 쓸 수 있는 것 같다.
    }
    private void OnTriggerEnter(Collider other) // 부딛힌 총알의 정보를 가져오는데 사용할 수 있음.
    {
        if (other.tag == "Bullet")
        {
            OnDamage(other.gameObject);
            Destroy(other.gameObject);
        }

        // 플레이어의 트리거 영역에 들어왔을 때 호출되는 메서드
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();  // 충돌한 대상이 플레이어인지 확인.
            if (playerHealth != null)                                        // 충돌한 대상으로부터 PlayerHealth 컴포넌트를 가져옴.
            {
                //OnDamage(other.gameObject);                             // 플레이어의 체력을 몬스터의 데미지만큼 감소.
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
    public void OnDamage(GameObject temp)
    {
        EnemyHp -= temp.GetComponent<Bullet>().attackValue;
        Debug.Log("적 : " + temp.GetComponent<Bullet>().attackValue);

        if (EnemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
