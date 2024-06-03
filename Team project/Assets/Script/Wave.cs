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
            if(i < monster.Length - 1)
            i++;
        }
    }
    public void Instance()
    {
        Instantiate(monster[i], transform.position, Quaternion.identity);
    }
}
