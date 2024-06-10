using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float coinTimer;

    public GAMESTATE gamestate;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gamestate = GAMESTATE.GAMESTART;
        stateTimer = 1.0f;
        Time.timeScale = 1.0f;      // 게임 오버, 클리어 시 timeScale=0 된 것을 풀기 위해서 시작할 때 다시 timeScale을 1.0으로 초기화.
        // 돌아가긴 하는데 뭔가 timeScale로 이렇게 하면 안 될 것 같음 근데 어떻게 해야할지 모르겠어요
        WaveDataInit();
    }

     void Update()
    {
        stateTimer -= Time.deltaTime;

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
        stageWaveCount = stageWaveData.waveRound.Length;    // 계속 받아오기 번거로우니까 stageWaveCount에 할당
        stageWaveMenberMax = new int[stageWaveCount];       // stageWaveCount만큼의 int형 배열 선언
        stageWaveMenberCursor = new int[stageWaveCount];    // stageWaveCount만큼의 int형 배열 선언

        for (int i = 0; i < stageWaveCount; i++)
        {
            stageWaveMenberMax[i] = stageWaveData.waveRound[i].columns.Length;
            // int 0. 즉, 첫 번째 웨이브일 때 첫 번째 웨이브의 몬스터 배열 길이 (몬스터 수)를 받아와서 stageWaveMenberMax[0]에 저장.
            // 이런식으로 웨이브 수 만큼 반복하여 각각의 웨이브에 몬스터가 몇 마리 나올 것인지 stageWaveMenberMax 배열에 받아옴
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
        coinTimer += Time.deltaTime;

        if (coinTimer >= 1.0f)
        {
            coin += 3;
            coinTimer = 0.0f;
        }

        if (spawnTimer >= stageWaveData.SpawnTimer && !isWaveDone && !isAllWaveDone)
        {
            GameObject temp = stageWaveData.waveRound[stageWaveCursor].columns[stageWaveMenberCursor[stageWaveCursor]];
            // stageWaveCursor는 0이므로 0번째 웨이브의 0번째 몬스터를 temp에 받아옴
            stageWaveMenberCursor[stageWaveCursor] += 1;
            // stageWaveMenberCursor int 배열의 0번째에 1을 증가 시킴 (= 소환된 몬스터 수. 배열의 순서는 웨이브 순서)
            Instantiate(temp, StageManager.Instance.startPoint.position, Quaternion.identity);
            // 받아온 temp 몬스터를 소환

            if (stageWaveMenberCursor[stageWaveCursor] >= stageWaveMenberMax[stageWaveCursor])  // 소환된 몬스터 수(stageWaveMenberCursor)가 소환될 몬스터 수(stageWaveMenberMax)보다 크거나 같으면 초기화하고 다음 웨이브로 넘어감
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
            CoinSystem.Instance.EndCoin();
        }
    }

}
