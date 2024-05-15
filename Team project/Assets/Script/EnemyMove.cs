using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;         //DoTween을 사용하기 위해 DoTweening 설치후 진행


public class EnemyMove : MonoBehaviour
{
    // DoTween
    Tween tween;                    //트윗 선언

    void Start()
    {
        transform.DOMoveX(4, 6f); // 적이 1번 포인트로 6초 동안 간다.
    }


    private void Dil()
    {
        print("적 사망");
        gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point1")   // 만약 1번 포인트에 충돌하면
        {
            print("1번 포인트 도착");
            transform.DORotate(new Vector3(0, 90, 0), 0.3f); // 90도 회전
            transform.DOMoveZ(-0.3f, 6f);
        }

        if(collision.gameObject.tag == "Point2")    // 만약 2번 포인트에 충돌하면
        {
            print("2번 포인트 도착");
            transform.DORotate(new Vector3(0, 180, 0), 0.3f);
            transform.DOMoveX(-4f, 6f);
        }

        if (collision.gameObject.tag == "Point3")   // 만약 3번 포인트에 충돌하면
        {
            print("3번 포인트 도착");
            transform.DORotate(new Vector3(0, 90, 0), 0.3f);
            transform.DOMoveZ(-4.3f, 6f);
        }

        if (collision.gameObject.tag == "Point4")   // 만약 4번 포인트에 충돌하면
        {
            print("4번 포인트 도착");
            transform.DORotate(new Vector3(0, 0, 0), 0.3f);
            transform.DOMoveX(4f, 6f);
        }

        if (collision.gameObject.tag == "FinshPoint")   // 만약 5번 포인트에 도착하면
        {
            print("5번 포인트 도착");
            Destroy(gameObject);        // 적을 없에라
            /* 추후 Player Hp에 영향을 주는 GameObject 생성후 Script와 연결*/
        }

        void Update()
        {
            // Tween.kill();     //해당 트윈을 종료한다. // 문제 해결후 사용
        }
    }
    
}
