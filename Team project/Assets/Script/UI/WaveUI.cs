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
        stageWave = stageWaveData.waveRound.Length;     // �� ���̺� �� �Ҵ�
        //nextWaveTimer.text = "1 ���̺� ���� ��";
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���̺� ���� �˷��ִ� UI
        if (GameManager.Instance.isAllWaveDone)
        {
            enemyNum.text = "���̺� ����";
            return;
        }

        if (currentWave != stageWave)
        {
            currentWave = GameManager.Instance.stageWaveCursor + 1;     // ���� ���̺� ���� �޾ƿ�
            wave.text = currentWave + " / " + stageWave;
        }

        if (currentWave == stageWave)
            wave.text = stageWave + " / " + stageWave;


        // ���� ���̺���� �ð� �˷��ִ� UI
        stateTimer = GameManager.Instance.stateTimer;
        if (stateTimer > 1.0f)
        {
            nextWaveTimer.text = stateTimer.ToString("0.0") + " �� ����";
        }
        else if (0.0 < stateTimer && stateTimer < 1.0f)
        {
            nextWaveTimer.text = "�غ� ��";
        }
        else if(stateTimer <= 0.0f)
        {
            nextWaveTimer.text = currentWave + " ���̺� ���� ��";
        }


        // ���̺� ���� ���� �� �˷��ִ� UI
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
                enemyNum.text = "���̺� ����";
            }
        }
        
    }
}
