using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    StageWaveData stageWaveData;

    public Text wave;
    public Text nextWaveTimer;
    private int stageWave;
    private int currentWave;
    private float stateTimer;

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
        if (GameManager.Instance.isAllWaveDone)
            return;

        if (currentWave != stageWave)
        {
            currentWave = GameManager.Instance.stageWaveCursor + 1;     // 현재 웨이브 수를 받아옴
            wave.text = currentWave + " / " + stageWave;
        }

        if (currentWave == stageWave)
            wave.text = stageWave + " / " + stageWave;

        stateTimer = GameManager.Instance.stateTimer;
        if (stateTimer > 1.0f)
        {
            nextWaveTimer.text = stateTimer.ToString("0.0") + " 초 남음";
        }
        else if(stateTimer <= 1.0f)
        {
            nextWaveTimer.text = currentWave + " 웨이브 진행 중";
        }
    }
}
