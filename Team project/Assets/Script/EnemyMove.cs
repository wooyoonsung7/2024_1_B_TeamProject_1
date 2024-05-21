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
    public Transform point1;   //이것을 지정해서 이 위치로 이동시킬 예정
    public Transform point2;
    public Transform point3;
    public Transform point4;

    
    void Start()
    {
        print("본 Project는 A Team Game Project를 위한 프로토 타입 으로 Enemy는 Point 2에서 사망하게 코딩 했습니다.");
        transform.DOMoveX(4, 6f); // 적이 1번 포인트로 6초 동안 간다.
    }

    void Update()
    {
        if (EnemyHp <= 0) Die();
    }
    void Die()
    {
        gameObject.SetActive(false);
        print("적사망");
        // Tween.kill();     //해당 트윈을 종료한다. // 문제 해결후 사용
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
            EnemyHp -= 10;
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
            print("플레이어 hp -1");
            print("5번 포인트 도착");
            Destroy(gameObject);        // 적을 없에라
            /* 추후 Player Hp에 영향을 주는 GameObject 생성후 Script와 연결*/
        }

       


    }
    
}
