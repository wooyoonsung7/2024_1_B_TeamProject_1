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
  //  public Transform point1;   //이것을 지정해서 이 위치로 이동시킬 예정
   // public Transform point2;
   // public Transform point3;
   // public Transform point4;

    
    void Start()
    {
        transform.DOMoveX(6, 6f); // 적이 1번 포인트로 6초 동안 간다.
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
}
