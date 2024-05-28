using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;         


public class EnemyMove : MonoBehaviour
{
    public float EnemyHp = 10f;
    // DoTween
    Tween tween;                    //트윗 선언
    Vector3[] pos = new Vector3[10];
  /*Vector3 pos1;
    Vector3 pos2;
    Vector3 pos3;
    Vector3 pos4;*/
    public GameObject[] point = new GameObject[10];
  /*public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;*/
    public float moveTime = 6;
    //public Transform point1;
    //public float moveSpeed = 1;


    void Start()
    {
        for(int i =0; i<10; i++)
        {
            if (point[i] != null)
            {
                pos[i] = point[i].transform.position;
            }
        }
        /*  pos1 = point1.transform.position;
            pos2 = point2.transform.position;
            pos3 = point3.transform.position;
            if(point4 != null)
            {
                pos4 = point4.transform.position;
            }*/
        transform.DOMove(pos[0], moveTime); // 적이 1번 포인트로 6초 동안 간다.
    }

    void Update()
    {
        if (gameObject.transform.position == pos[0])
        {
            transform.DOMove(pos[1], moveTime);
        }
        else if (gameObject.transform.position == pos[1])
        {
            transform.DOMove(pos[2], moveTime);
        }
        else if (gameObject.transform.position == pos[2])
        {
            transform.DOMove(pos[3], moveTime);
        }
        if (EnemyHp <= 0) Die();
    }
    void Die()
    {
        gameObject.SetActive(false);
        print("적사망");
        // Tween.kill();     //해당 트윈을 종료한다. // 문제 해결후 사용
    }


}
