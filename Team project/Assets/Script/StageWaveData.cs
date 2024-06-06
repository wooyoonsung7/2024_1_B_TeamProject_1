using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public GameObject[] columns;
}

public class StageWaveData : MonoBehaviour
{
    public WaveData[] waveRound;
    public float WaveTimer = 30.0f;
    public float SpawnTimer = 1.0f;

}
