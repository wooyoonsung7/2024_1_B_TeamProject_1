using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

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
    public bool isGameOver;

    public int stageWaveCount;
    public int[] stageWaveMenberMax;

    public int stageWaveCursor;
    public int[] stageWaveMenberCursor;

    public GameObject ClearUI;
    public GameObject OverUI;

    private const string StarCountKeyPrefs = "StarCount_";
    // 클리어 때 주어질 별의 개수를 저장할 PlayerPrefs 키 디폴트 이름

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
        isGameOver = false;

        ClearUI.SetActive(false);
        OverUI.SetActive(false);
    }

    void Start()
    {
        gamestate = GAMESTATE.GAMESTART;
        stateTimer = 1.0f;
        Time.timeScale = 1.0f;      // 게임 오버, 클리어 시 timeScale=0 된 것을 풀기 위해서 시작할 때 다시 timeScale을 1.0으로 초기화.
        // 돌아가긴 하는데 뭔가 timeScale로 이렇게 하면 안 될 것 같음 근데 어떻게 해야할지 모르겠어요
        WaveDataInit();

        coinTimer = 1.0f;  //코인시스템
        coin = 20;
    }

     void Update()
    {
        stateTimer -= Time.deltaTime;
        coinTimer -= Time.deltaTime;

        if (isAllWaveDone == true)      // 모든 웨이브가 다 끝났을 때
        {
            GameObject[] gameObjects;       // 남아있는 몬스터를 받아올 배열
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");   // 태그가 Enemy인 오브젝트를 배열로 받아옴 (마지막 웨이브 몬스터를 받아올것임)
            if (gameObjects.Length == 0)    // 배열의 길이가 0이면. 즉, 씬에 Enemy가 존재하지 않으면
            {
                Health health = FindObjectOfType<Health>();
                int currentHealth = health.currentHealth;       // 현재 체력값을 currentHealth로 받아옴

                if (currentHealth > 0) // 현재 체력이 0 초과이면
                {
                    GameClear();        // 게임 클리어
                    UnlockNewStage();
                }
            }
        }

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

    private void UnlockNewStage()   // 스테이지 진행도에 따라 해금시켜주는 함수
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedStage")) // 현재 활성화 되어있는 씬의 buildSetting번호 (우리 게임은 이 번호와 스테이지 번호가 같음)
        {   // 씬 번호가 ReachedIndex 보다 크거나 같으면 아래 코드 실행. (ReachedIndex 키는 존재하지 않기 때문에 처음에는 0을 반환함
            // 그렇기 때문에 1 >= 0으로 처음(1스테이지)에는 무조건 실행됨.
            // PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);   // ReachedIndex 키에 현재 씬 번호 + 1 을 할당함
            PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1) + 1);    // UnlockedStage(현재 스테이지 수) 키에 + 1 을 할당함
            PlayerPrefs.Save();     // 혹시 모르니 (+ 게임을 껐다가 켜도 해금 스테이지 유지) UnlockedStage 키를 저장

            // 우리 게임은 buildindex와 스테이지 번호가 같음 그래서 buildindex를 받아오는 키는 없어도 됨
        }
    }

    public int StarCount()      // 현재 체력값에 따라 별의 개수를 반환하는 함수
    {
        Health health = FindObjectOfType<Health>();
        int currentHealth = health.currentHealth;

        if (currentHealth >= 5)
        {
            return 3;
        }
        else if (currentHealth >= 2)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public void SaveStarCount()     // StarCount에서 계산한 별 개수를 저장하는 함수
    {   // StarCountKeyPrefs은 "StarCount_" 임
        // 현재 스테이지 번호와 현재 별 개수를 매칭시켜서 저장해야함
        int starCount = StarCount();    // 별의 개수를 계산하여 starCount에 할당

        // "StarCount_씬번호" 라는 키에 starCount가 저장됨. 각 스테이지 마다 별 개수를 저장할 수 있음
        PlayerPrefs.SetInt(StarCountKeyPrefs + SceneManager.GetActiveScene().buildIndex, starCount);
        PlayerPrefs.Save();
    }

    public void GoToSelection()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void GameClear()     
    {
        PauseGame();
        UnlockNewStage();
        SaveStarCount();
        if (ClearUI != null)
        {
            ClearUI.SetActive(true);
        }
    }

    public void Gameover()
    {
        isGameOver = true;
        Debug.Log("게임 오버");
        PauseGame();

        if (OverUI != null)
        {
            OverUI.SetActive(true);
        }
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

    /*public void GameSpeedButton()
    {
        float currentTimeScale = Time.timeScale;

        if (currentTimeScale == 1.0f)
        {
            Time.timeScale = 2.0f;
        }
        else if (currentTimeScale == 2.0f)
        {
            Time.timeScale = 1.0f;
        }
    }*/
}
