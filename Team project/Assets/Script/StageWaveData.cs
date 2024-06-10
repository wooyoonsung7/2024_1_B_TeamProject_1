using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public GameObject[] columns;        // 생성시킬 몬스터 프리팹 배열
}

public class StageWaveData : MonoBehaviour
{
    public WaveData[] waveRound;    // 몬스터 프리팹 배열을 배열로 = 웨이브 수
    public float WaveTimer = 30.0f;
    public float SpawnTimer = 1.0f;

}
