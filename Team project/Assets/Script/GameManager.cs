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
    // Ŭ���� �� �־��� ���� ������ ������ PlayerPrefs Ű ����Ʈ �̸�

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
    public int getcoin = 0;  //���͸� ���� ��, ���� ���ΰ�

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
        Time.timeScale = 1.0f;      // ���� ����, Ŭ���� �� timeScale=0 �� ���� Ǯ�� ���ؼ� ������ �� �ٽ� timeScale�� 1.0���� �ʱ�ȭ.
        // ���ư��� �ϴµ� ���� timeScale�� �̷��� �ϸ� �� �� �� ���� �ٵ� ��� �ؾ����� �𸣰ھ��
        WaveDataInit();

        coinTimer = 1.0f;  //���νý���
        coin = 20;
    }

     void Update()
    {
        stateTimer -= Time.deltaTime;
        coinTimer -= Time.deltaTime;

        if (isAllWaveDone == true)      // ��� ���̺갡 �� ������ ��
        {
            GameObject[] gameObjects;       // �����ִ� ���͸� �޾ƿ� �迭
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");   // �±װ� Enemy�� ������Ʈ�� �迭�� �޾ƿ� (������ ���̺� ���͸� �޾ƿð���)
            if (gameObjects.Length == 0)    // �迭�� ���̰� 0�̸�. ��, ���� Enemy�� �������� ������
            {
                Health health = FindObjectOfType<Health>();
                int currentHealth = health.currentHealth;       // ���� ü�°��� currentHealth�� �޾ƿ�

                if (currentHealth > 0) // ���� ü���� 0 �ʰ��̸�
                {
                    GameClear();        // ���� Ŭ����
                    UnlockNewStage();
                }
            }
        }
        if (coinTimer <= 0.0f || getcoin != 0)
        {
            Coin(coinTimer, getcoin);
        }
        //text.text = string.Format("{0:#,#}", coin);  // ������ 0�� ��, �ؽ�Ʈ�� 0�� ������ ����
        text.text = "" + coin + "";

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
        stageWaveCount = stageWaveData.waveRound.Length;    // ��� �޾ƿ��� ���ŷο�ϱ� stageWaveCount�� �Ҵ�
        stageWaveMenberMax = new int[stageWaveCount];       // stageWaveCount��ŭ�� int�� �迭 ����
        stageWaveMenberCursor = new int[stageWaveCount];    // stageWaveCount��ŭ�� int�� �迭 ����

        for (int i = 0; i < stageWaveCount; i++)
        {
            stageWaveMenberMax[i] = stageWaveData.waveRound[i].columns.Length;
            // int 0. ��, ù ��° ���̺��� �� ù ��° ���̺��� ���� �迭 ���� (���� ��)�� �޾ƿͼ� stageWaveMenberMax[0]�� ����.
            // �̷������� ���̺� �� ��ŭ �ݺ��Ͽ� ������ ���̺꿡 ���Ͱ� �� ���� ���� ������ stageWaveMenberMax �迭�� �޾ƿ�
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

    private void UnlockNewStage()   // �������� ���൵�� ���� �رݽ����ִ� �Լ�
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedStage")) // ���� Ȱ��ȭ �Ǿ��ִ� ���� buildSetting��ȣ (�츮 ������ �� ��ȣ�� �������� ��ȣ�� ����)
        {   // �� ��ȣ�� ReachedIndex ���� ũ�ų� ������ �Ʒ� �ڵ� ����. (ReachedIndex Ű�� �������� �ʱ� ������ ó������ 0�� ��ȯ��
            // �׷��� ������ 1 >= 0���� ó��(1��������)���� ������ �����.
            // PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);   // ReachedIndex Ű�� ���� �� ��ȣ + 1 �� �Ҵ���
            PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1) + 1);    // UnlockedStage(���� �������� ��) Ű�� + 1 �� �Ҵ���
            PlayerPrefs.Save();     // Ȥ�� �𸣴� (+ ������ ���ٰ� �ѵ� �ر� �������� ����) UnlockedStage Ű�� ����

            // �츮 ������ buildindex�� �������� ��ȣ�� ���� �׷��� buildindex�� �޾ƿ��� Ű�� ��� ��
        }
    }

    public int StarCount()      // ���� ü�°��� ���� ���� ������ ��ȯ�ϴ� �Լ�
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

    public void SaveStarCount()     // StarCount���� ����� �� ������ �����ϴ� �Լ�
    {   // StarCountKeyPrefs�� "StarCount_" ��
        // ���� �������� ��ȣ�� ���� �� ������ ��Ī���Ѽ� �����ؾ���
        int starCount = StarCount();    // ���� ������ ����Ͽ� starCount�� �Ҵ�

        int bestStars = PlayerPrefs.GetInt(StarCountKeyPrefs + SceneManager.GetActiveScene().buildIndex);

        if (starCount >= bestStars)
        {
            bestStars = starCount;
        }

        // "StarCount_����ȣ" ��� Ű�� starCount�� �����. �� �������� ���� �� ������ ������ �� ����
        PlayerPrefs.SetInt(StarCountKeyPrefs + SceneManager.GetActiveScene().buildIndex, bestStars);
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
        Debug.Log("���� ����");
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
            // stageWaveCursor�� 0�̹Ƿ� 0��° ���̺��� 0��° ���͸� temp�� �޾ƿ�
            stageWaveMenberCursor[stageWaveCursor] += 1;
            // stageWaveMenberCursor int �迭�� 0��°�� 1�� ���� ��Ŵ (= ��ȯ�� ���� ��. �迭�� ������ ���̺� ����)
            Instantiate(temp, StageManager.Instance.startPoint.position, Quaternion.identity);
            // �޾ƿ� temp ���͸� ��ȯ

            if (stageWaveMenberCursor[stageWaveCursor] >= stageWaveMenberMax[stageWaveCursor])  // ��ȯ�� ���� ��(stageWaveMenberCursor)�� ��ȯ�� ���� ��(stageWaveMenberMax)���� ũ�ų� ������ �ʱ�ȭ�ϰ� ���� ���̺�� �Ѿ
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
        Time.timeScale = 0f; // ������ �Ͻ�����
    }

    public void EndGame()
    {
        if (stateTimer <= 0.0f)
        {

        }
    }
    void Coin(float Timer, int getCoin)
    {
        if (Timer <= 0.0f && isBuy == false)
        {
            coin += 2;
            coinTimer = 1f;
        }
        if (getCoin != 0)
        {
            coin += getCoin;
            getcoin = 0;
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
