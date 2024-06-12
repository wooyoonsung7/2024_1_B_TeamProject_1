using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransform : MonoBehaviour
{
    public float MoveSpeed;

    private void Update()
    {
        this.gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime * MoveSpeed;

        if (gameObject.transform.position.x < -720)       //x�� ��ǥ�� -1540�̸����� ������ ��
        {
            gameObject.transform.position += new Vector3(2880.0f, 0.0f, 0.0f);        //���������� x�� 1200��ŭ �̵�
        }
    }
}
