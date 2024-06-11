using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    StageWaveData stageWaveData;

    public Text wave;
    private int stageWave;
    private int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        stageWaveData = FindObjectOfType<StageWaveData>();
        //StageWaveData stageWaveData = FindObjectOfType<StageWaveData>();
        stageWave = stageWaveData.waveRound.Length;     // 총 웨이브 수 할당
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = GameManager.Instance.stageWaveCursor + 1;     // 현재 웨이브 수를 받아옴
        wave.text = currentWave + " / " + stageWave;
    }
}
