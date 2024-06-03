using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] monster;
    public float[] spawnTime;
    float Timer = 0;
    int i = 0;

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= spawnTime[i])
        {
            Instance();
            Timer = 0;
            if (i < monster.Length - 1) i++;
            else Destroy(gameObject);  //더 이상 소환안되게 하는 장치
        }
    }
    public void Instance()
    {
        Instantiate(monster[i], transform.position, Quaternion.identity);
    }
}
