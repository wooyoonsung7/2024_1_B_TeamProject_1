using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// using DG.Tweening;         //DoTween을 사용하기 위해 DoTweening 설치후 진행


public class Enemy : MonoBehaviour
{
    public int EnemyHp = 10;
    //DoTween

   // Tween tween;                    //트윗 선언
   // Sequence Sequence;              // 시퀸스 선언


    void Start()
    {
        // transform.DOMoveX(5, 0.5f); // 적이 1번 포인트로 5초 동안 간다.
    }


    void Update()
    {
        //Sequence.Kill();    //해당 시퀀스를 종료한다.
        //Tween.kill();     //해당 트윈을 종료한다.
    }

    private void Dil()
    {
        pirnt("적 사망");
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point1")   // 만약 1번 포인트에 충돌하면
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90도 회전하고
            // transform.DOMoveX(3, 0.5f);  //5초 동안 2번 포인트로 이동해라 
        }

        if(collision.gameObject.tag == "Point2")    // 만약 2번 포인트에 충돌하면
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90도 회전하고
            // transform.DOMoveX(3, 0.5f);  //5초 동안 3번 포인트로 이동해라 
        }

        if (collision.gameObject.tag == "Point3")   // 만약 3번 포인트에 충돌하면
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90도 회전하고
            // transform.DOMoveX(3, 0.5f);  //5초 동안 4번 포인트로 이동해라 
        }

        if (collision.gameObject.tag == "Point4")   // 만약 4번 포인트에 충돌하면
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90도 회전하고
            // transform.DOMoveX(3, 0.5f);  //5초 동안 5번 포인트로 이동해라 
        }

        if (collision.gameObject.tag == "FinshPoint")   // 만약 5번 포인트에 도착하면
        {
            Destroy(gameObject);        // 적을 없에라
        }
    }
}
