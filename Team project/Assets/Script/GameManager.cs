using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform[] point = new Transform[5];                 // �̵�����Ʈ�迭
    public GameObject[] monster = new GameObject[1];             //������ ��������
    public float[] spawnTime = new float[1];                     //���� ���ͻ��� ��, ���� ������������� �ð�
    float Timer = 0;
    int i = 0;

    void Awake()
    {
        if (Instance == null)
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


   


