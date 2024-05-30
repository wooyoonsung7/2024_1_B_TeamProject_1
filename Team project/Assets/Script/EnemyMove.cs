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

    public string EnemyName;
    public int EnemyHp = 10;
    public float speed = 5f;
    public Transform[] target;
    int a;

    private void Awake()
    {
        if(Instance == null)
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

}
