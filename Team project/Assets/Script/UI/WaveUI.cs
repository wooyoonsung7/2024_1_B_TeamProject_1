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
    public Text enemyNum;
    private int stageWave;
    private int currentWave;
    private float stateTimer;
    private int enemyMax;
    private int enemyCursor;

    // Start is called before the first frame update
    void Start()
    {
        stageWaveData = FindObjectOfType<StageWaveData>();
        //StageWaveData stageWaveData = FindObjectOfType<StageWaveData>();
        stageWave = stageWaveData.waveRound.Length;     // 총 웨이브 수 할당
        //nextWaveTimer.text = "1 웨이브 진행 중";
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 웨이브 숫자 알려주는 UI
        if (GameManager.Instance.isAllWaveDone)
        {
            enemyNum.text = "웨이브 종료";
            return;
        }

        if (currentWave != stageWave)
        {
            currentWave = GameManager.Instance.stageWaveCursor + 1;     // 현재 웨이브 수를 받아옴
            wave.text = currentWave + " / " + stageWave;
        }

        if (currentWave == stageWave)
            wave.text = stageWave + " / " + stageWave;


        // 다음 웨이브까지 시간 알려주는 UI
        stateTimer = GameManager.Instance.stateTimer;
        if (stateTimer > 1.0f)
        {
            nextWaveTimer.text = stateTimer.ToString("0.0") + " 초 남음";
        }
        else if (0.0 < stateTimer && stateTimer < 1.0f)
        {
            nextWaveTimer.text = "준비 중";
        }
        else if(stateTimer <= 0.0f)
        {
            nextWaveTimer.text = currentWave + " 웨이브 진행 중";
        }


        // 웨이브 마다 몬스터 수 알려주는 UI
        if (currentWave == 1)
        {
            enemyMax = GameManager.Instance.stageWaveMenberMax[0];
            enemyCursor = GameManager.Instance.stageWaveMenberCursor[0];

            enemyNum.text = enemyCursor + " / " + enemyMax;
        }
        else if (currentWave == 2)
        {
            enemyMax = GameManager.Instance.stageWaveMenberMax[1];
            enemyCursor = GameManager.Instance.stageWaveMenberCursor[1];

            enemyNum.text = enemyCursor + " / " + enemyMax;
        }
        else if (currentWave == 3)
        {
            enemyMax = GameManager.Instance.stageWaveMenberMax[2];
            enemyCursor = GameManager.Instance.stageWaveMenberCursor[2];

            enemyNum.text = enemyCursor + " / " + enemyMax;
        }
        else if (currentWave == 4)
        {
            enemyMax = GameManager.Instance.stageWaveMenberMax[3];
            enemyCursor = GameManager.Instance.stageWaveMenberCursor[3];

            enemyNum.text = enemyCursor + " / " + enemyMax;
        }
        else if (currentWave == 5)
        {
            enemyMax = GameManager.Instance.stageWaveMenberMax[4];
            enemyCursor = GameManager.Instance.stageWaveMenberCursor[4];

            enemyNum.text = enemyCursor + " / " + enemyMax;
        }
        else if (currentWave == 0)
        {
            if (GameManager.Instance.isAllWaveDone == true)
            {
                enemyNum.text = "웨이브 종료";
            }
        }
        
    }
}
