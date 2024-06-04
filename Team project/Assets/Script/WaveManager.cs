using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    public GameObject monsterPrefab; // ���� ������
    public Transform spawnPoint; // ���� ����
    private int waveIndex = 0; // ���� ���̺� �ε���
    public Text waveText;


    public void StartWaveImmediately()         // ���̺긦 �����ϴ� �޼ҵ�
    {
        StartCoroutine(SpawnWave());
    }



    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SummonMonster();
            yield return new WaitForSeconds(0.5f); // ���� ��ȯ �� �ð� ����
        }

        waveText.text = "Wave " + waveIndex;
    }


    void SummonMonster()
    {
      
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);       // ���� ��ȯ
    }


}
