using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// using DG.Tweening;         //DoTween�� ����ϱ� ���� DoTweening ��ġ�� ����


public class Enemy : MonoBehaviour
{
    public int EnemyHp = 10;
    public float Enemyspeed = 0.5f;


    //DoTween

   // Tween tween;                    //Ʈ�� ����
   // Sequence Sequence;              // ������ ����





    void Start()
    {
        // transform.DOMoveX(5, 0.5f); // ���� 1�� ����Ʈ�� 5�� ���� ����.
    }


    void Update()
    {
        //Sequence.Kill();    //�ش� �������� �����Ѵ�.
        //Tween.kill();     //�ش� Ʈ���� �����Ѵ�.
    }

    private void Dil()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point1")   // ���� 1�� ����Ʈ�� �浹�ϸ�
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90�� ȸ���ϰ�
            // transform.DOMoveX(3, 0.5f);  //5�� ���� 2�� ����Ʈ�� �̵��ض� 
        }

        if(collision.gameObject.tag == "Point2")    // ���� 2�� ����Ʈ�� �浹�ϸ�
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90�� ȸ���ϰ�
            // transform.DOMoveX(3, 0.5f);  //5�� ���� 3�� ����Ʈ�� �̵��ض� 
        }

        if (collision.gameObject.tag == "Point3")   // ���� 3�� ����Ʈ�� �浹�ϸ�
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90�� ȸ���ϰ�
            // transform.DOMoveX(3, 0.5f);  //5�� ���� 4�� ����Ʈ�� �̵��ض� 
        }

        if (collision.gameObject.tag == "Point4")   // ���� 4�� ����Ʈ�� �浹�ϸ�
        {
            // transform.DORotate(new Vector3(0, 0, 90), 0.3f); // 90�� ȸ���ϰ�
            // transform.DOMoveX(3, 0.5f);  //5�� ���� 5�� ����Ʈ�� �̵��ض� 
        }

        if (collision.gameObject.tag == "FinshPoint")   // ���� 5�� ����Ʈ�� �����ϸ�
        {
            Destroy(gameObject);        // ���� ������
        }
    }
}
