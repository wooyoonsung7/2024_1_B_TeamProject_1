using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform[] point = new Transform[5];                 // 이동포인트배열
    public GameObject[] monster = new GameObject[1];             //생성할 몬스터지정
    public float[] spawnTime = new float[1];                     //이전 몬스터생성 후, 다음 몬스토생성까지의 시간
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
            else Destroy(gameObject);  //더 이상 소환안되게 하는 장치
        }
    }
    public void Spawn()
    {
        Instantiate(monster[i], transform.position, Quaternion.identity);
    }
}


   


