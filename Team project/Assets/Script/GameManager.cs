using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

[System.Serializable]
public class TowerData
{
    public GameObject[] columns;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public StageWaveData stageWaveData;

    public float stateTimer;
    public float spawnTimer;
    public bool isWaveDone;
    public bool isAllWaveDone;

    public int stageWaveCount;
    public int[] stageWaveMenberMax;

    public int stageWaveCursor;
    public int[] stageWaveMenberCursor;

    public GameObject gameClearUI;
    public GameObject gameOverUI;

    public enum GAMESTATE
    {
        GAMESTART,
        WAVESTART,
        DOWAVE,
        WAVEDONE,
        STOP,
        END
    }

    public TowerData[] TowerArray = new TowerData[5];

    public int coin;
    float coinTimer;
    public Text text;
    bool isBuy = false;

    public GAMESTATE gamestate;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gamestate = GAMESTATE.GAMESTART;
        stateTimer = 1.0f;
        WaveDataInit();

        coinTimer = 1.0f;  //코인시스템
        coin = 20;
    }

     void Update()
    {
        stateTimer -= Time.deltaTime;
        coinTimer -= Time.deltaTime;

        Coin(coinTimer);
        text.text = string.Format("{0:#,#}", coin);

        switch (gamestate)
        {
            case GAMESTATE.GAMESTART:
                GameStart();
                break;

            case GAMESTATE.WAVESTART:
                WaveStart();
                break;

            case GAMESTATE.DOWAVE:
                DoWave();
                break;

            case GAMESTATE.WAVEDONE:
                WaveDone();
                break;

            case GAMESTATE.STOP:               
                break;

            case GAMESTATE.END:
                EndGame();
                break;
        }
    }

    public void WaveDataInit()
    {
        stageWaveCount = stageWaveData.waveRound.Length;
        stageWaveMenberMax = new int[stageWaveCount];
        stageWaveMenberCursor = new int[stageWaveCount];

        for (int i = 0; i < stageWaveCount; i++)
        {
            stageWaveMenberMax[i] = stageWaveData.waveRound[i].columns.Length;
        }
    }

    private void ChangeGameState(GAMESTATE newState , float time)
    {
        gamestate = newState;
        stateTimer = time;
    }

    public void GameStart()
    {


        if(stateTimer <= 0.0f)
        {
            ChangeGameState(GAMESTATE.WAVESTART, 1);
        }
    }

    public void GameClear()        // 게임 클리어 조건안에서 호출할 함수
    {
        PauseGame();
        // 스테이지 클리어 UI 띄워줌
        // 확인 버튼을 누르거나 일정 시간이 지나면 아래 코드가 실행되도록
        //UnlockNewStage();                             // 선택 씬 해금
        //SceneManager.LoadScene("StageSelection");     // 스테이지 선택 씬 로드
    }

    public void Gameover()
    {
        Debug.Log("게임 오버");
        PauseGame();

        /*if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }*/
    }

    public void WaveStart()
    {
        if (stateTimer <= 0.0f)
        {
            ChangeGameState(GAMESTATE.DOWAVE, stageWaveData.WaveTimer);
            spawnTimer = 0.0f;
            isWaveDone = false;
        }
    }

    public void DoWave()
    {
        spawnTimer += Time.deltaTime;


        if (spawnTimer >= stageWaveData.SpawnTimer && !isWaveDone && !isAllWaveDone)
        {
            GameObject temp = stageWaveData.waveRound[stageWaveCursor].columns[stageWaveMenberCursor[stageWaveCursor]];
            stageWaveMenberCursor[stageWaveCursor] += 1;
            Instantiate(temp, StageManager.Instance.startPoint.position, Quaternion.identity);

            if(stageWaveMenberCursor[stageWaveCursor] >= stageWaveMenberMax[stageWaveCursor])
            {
                stageWaveMenberCursor[stageWaveCursor] = 0;
                stageWaveCursor += 1;               
                isWaveDone = true;
            }

            if(stageWaveCursor >= stageWaveCount)
            {
                stageWaveCursor = 0;
                isAllWaveDone = true;
            }
            spawnTimer = 0.0f;   
        }      

        if (stateTimer <= 0.0f)
        {
            ChangeGameState(GAMESTATE.WAVEDONE, 1);
        }
    }

    public void WaveDone()
    {
        if (stateTimer <= 0.0f && isAllWaveDone)
        {
            ChangeGameState(GAMESTATE.END, 1);
        }
        else if (stateTimer <= 0.0f && !isAllWaveDone)
        {
            ChangeGameState(GAMESTATE.WAVESTART, 1);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // 게임을 일시정지
    }

    public void EndGame()
    {
        if (stateTimer <= 0.0f)
        {

        }
    }
    void Coin(float Timer)
    {
        if (Timer <= 0.0f && isBuy == false)
        {
            coin += 3;
            coinTimer = 1f;
        }

    }
    public void BuyCard(int cardValue)
    {
        isBuy = true;
        if (isBuy == true)
        {
            coin -= cardValue;
            isBuy = false;
        }
    }

}
