using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public GameObject[] columns;        // ������ų ���� ������ �迭
}

public class StageWaveData : MonoBehaviour
{
    public WaveData[] waveRound;    // ���� ������ �迭�� �迭�� = ���̺� ��
    public float WaveTimer = 30.0f;
    public float SpawnTimer = 1.0f;

}
