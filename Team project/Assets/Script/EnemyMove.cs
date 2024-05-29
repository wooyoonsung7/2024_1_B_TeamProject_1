using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;         


public class EnemyMove : MonoBehaviour
{
    public float EnemyHp = 10f;

    public float speed;
    public Transform[] target;
    int a;

    void Start()
    {

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

        //transform.position = Vector3.MoveTowards(transform.position, target[3].position, step);
        }
  

        if (EnemyHp == 0) Die();
    }
    void Die()
    {
        gameObject.SetActive(false);
        print("적사망");
        // Tween.kill();     //해당 트윈을 종료한다. // 문제 해결후 사용
    }


}
