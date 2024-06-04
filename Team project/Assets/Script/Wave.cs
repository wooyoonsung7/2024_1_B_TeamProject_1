using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] monster = new GameObject[1];             //������ ��������
    public float[] spawnTime = new float[1];                     //���� ���ͻ��� ��, ���� ������������� �ð�
    float Timer = 0;
    int i = 0;

    void Update()
    {

        Timer += Time.deltaTime;
        if (Timer >= spawnTime[i])
        {
            Spawn();
            Timer = 0;
            if (i < monster.Length - 1) i++;
            else Destroy(gameObject);  //�� �̻� ��ȯ�ȵǰ� �ϴ� ��ġ
        }
    }
    public void Spawn()
    {
        Instantiate(monster[i], transform.position, Quaternion.identity);
    }
}
