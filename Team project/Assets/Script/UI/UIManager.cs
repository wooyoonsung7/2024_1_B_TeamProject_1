using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

                                                                                // 클리어 및 게임 오버 UI 오브젝트
    public GameObject clearUI;
    public GameObject gameOverUI;
                                                                                // 다음 씬 및 메인 메뉴 씬 이름
    public string TestSceneTwo;
    public string MainScene;
    public int totalWaves = 3;                                                  // 총 웨이브 수
    private int currentWave = 0;                                                // 현재 웨이브 
    //private ClearUIManager clearUIManager;                                      // 클리어 UI를 관리하는 ClearUIManager를 연결
    private int totalMonsters;
    private int deadMonsters;

    public GameObject clearPanel;                                               // 클리어 UI 패널을 연결

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
                                                                                // "Monster" 태그를 가진 모든 게임 오브젝트의 수를 세어 totalMonsters에 저장
        totalMonsters = GameObject.FindGameObjectsWithTag("Enemy").Length;
                                                                                // 죽은 몬스터 수 초기화
        deadMonsters = 0;
                                                                                // 클리어 및 게임 오버 UI 비활성화
        //clearUI.SetActive(false);
        //gameOverUI.SetActive(false);
        //clearUIManager = FindObjectOfType<ClearUIManager>();                    // ClearUIManager 찾기
        StartNextWave();                                                        // 첫 번째 웨이브 시작
        clearUI.SetActive(false);
        gameOverUI.SetActive(false);
        clearUI = GameObject.Find("GameClearUI");                               // 여기서 "YourClearUIObjectName"은 실제 clearUI GameObject의 이름입니다.
        gameOverUI = GameObject.Find("GameOverUI");
    }

    void StartNextWave()
    {
        totalMonsters = GameObject.FindGameObjectsWithTag("Monster").Length;    // 현재 웨이브의 몬스터 수 초기화
        deadMonsters = 0;
    }
    public void MonsterDied()
    {
        deadMonsters++;
        if (deadMonsters >= totalMonsters)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWave++;
        if (currentWave >= totalWaves)
        {
                                                                // 클리어 UI 표시
            ShowClearUI();                                      // 추가된 부분 주석 처리
        }
        else
        {
            StartNextWave();                                     // 다음 웨이브 시작
        }
    }

                                                                  // 게임 오버 처리
    public void GameOver()
    {
        gameOverUI.SetActive(true);                               // 게임 오버 UI 활성화

        Time.timeScale = 0f;                                      // 게임을 멈추기 위해 Time.timeScale을 0으로 설정
        Debug.Log("Game Over!");
    }
                                                                  // 클리어 처리
    public void CheckClear()
    {
        deadMonsters++;                                           // 죽은 몬스터 수 증가
        if (deadMonsters >= totalMonsters)                        // 모든 몬스터가 죽었는지 확인
        {
            clearUI.SetActive(true);                              // 클리어 UI 활성화

            Time.timeScale = 0f;                                  // 게임을 멈추기 위해 Time.timeScale을 0으로 설정                        
            Debug.Log("Clear!");
        }
    }

    public void OnNextLevelButton()                               // 다음 레벨 버튼을 클릭했을 때 호출되는 메서드
    {
        SceneManager.LoadScene(TestSceneTwo);                     // 다음 씬을 로드
    }

    public void GoToMainScene()                                   // 메인 씬으로 이동하는 메서드
    {
        SceneManager.LoadScene("MainScene");                      // 메인 씬을 로드
    }

    public void RestartGame()                                     // 게임을 재시작하는 메서드
    { 
        Time.timeScale = 1f;                                      // Time.timeScale을 1로 설정하여 게임을 다시 시작
        SceneManager.LoadScene("TestScene");                      // "TestScene" 씬을 로드
    }

    public void GoToGame()                                        //메인씬으로 가는 메서드
    {
        SceneManager.LoadScene("TestScene");

    }

    public void Quit()                                           //게임을 나갈 때의 메서드
    {

#if UNITY_EDITOR                                                 //에디터에서 실행 중일 떄
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();              //빌드된 게임에서 실행 중일떄
#endif
    }

    // 클리어 UI를 활성화하는 메서드
    public void ShowClearUI()
    {
        clearPanel.SetActive(true);
        clearUI.SetActive(true);
    }

    // 클리어 UI를 비활성화하는 메서드
    public void HideClearUI()
    {
        clearPanel.SetActive(false);
    }
}

