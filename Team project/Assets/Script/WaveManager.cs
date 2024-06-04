using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    public GameObject monsterPrefab; // 몬스터 프리팹
    public Transform spawnPoint; // 생성 지점
    private int waveIndex = 0; // 현재 웨이브 인덱스
    public Text waveText;


    public void StartWaveImmediately()         // 웨이브를 시작하는 메소드
    {
        StartCoroutine(SpawnWave());
    }



    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SummonMonster();
            yield return new WaitForSeconds(0.5f); // 몬스터 소환 간 시간 간격
        }

        waveText.text = "Wave " + waveIndex;
    }


    void SummonMonster()
    {
      
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);       // 몬스터 소환
    }


}
