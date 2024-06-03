using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static GameManager Instance;

    // 클리어 및 게임 오버 UI 오브젝트
    public GameObject clearUI;
    public GameObject gameOverUI;
    // 다음 씬 및 메인 메뉴 씬 이름
    public string TestSceneTwo;
    public string MainScene;
    public int totalWaves = 3; // 총 웨이브 수
    private int currentWave = 0; // 현재 웨이브 
    public Transform[] point = new Transform[5]; // 포인트배열
    public Transform[] monster = new Transform[6];

    private ClearUIManager clearUIManager; // 클리어 UI를 관리하는 ClearUIManager를 연결
    private int totalMonsters;
    private int deadMonsters;


    // Awake 메서드 - 싱글톤 패턴 구현
    void Awake()
    {
        if (Instance == null)
        {
            // 현재 인스턴스를 Instance에 할당
            Instance = this;
        }
        else
        {
            // 이미 인스턴스가 존재하면 현재 오브젝트를 파괴
            Destroy(gameObject);
        }
    }

    // Start 메서드 - 초기 설정
    void Start()
    {
        // "Monster" 태그를 가진 모든 게임 오브젝트의 수를 세어 totalMonsters에 저장
        totalMonsters = GameObject.FindGameObjectsWithTag("Enemy").Length;
        // 죽은 몬스터 수 초기화
        deadMonsters = 0;
        // 클리어 및 게임 오버 UI 비활성화
        //clearUI.SetActive(false);
        //gameOverUI.SetActive(false);
        clearUIManager = FindObjectOfType<ClearUIManager>(); // ClearUIManager 찾기
        StartNextWave();          // 첫 번째 웨이브 시작
        clearUI.SetActive(false);
        gameOverUI.SetActive(false);
        clearUI = GameObject.Find("GameClearUI"); // 여기서 "YourClearUIObjectName"은 실제 clearUI GameObject의 이름입니다.
        gameOverUI = GameObject.Find("GameOverUI");
    }

    void StartNextWave()
    {
        // 현재 웨이브의 몬스터 수 초기화
        totalMonsters = GameObject.FindGameObjectsWithTag("Monster").Length;
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
            ShowClearUI(); // 추가된 부분 주석 처리
        }
        else
        {
            // 다음 웨이브 시작
            StartNextWave();
        }
    }

    void ShowClearUI()
    {
        clearUI.SetActive(true);
    }



   



    // 게임 오버 처리
    public void GameOver()
    {
        // 게임 오버 UI 활성화
        gameOverUI.SetActive(true);
        // 게임을 멈추기 위해 Time.timeScale을 0으로 설정
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }



    // 클리어 처리
    public void CheckClear()
    {
        deadMonsters++; // 죽은 몬스터 수 증가
        // 모든 몬스터가 죽었는지 확인
        if (deadMonsters >= totalMonsters)
        {
            // 클리어 UI 활성화
            clearUI.SetActive(true);
            // 게임을 멈추기 위해 Time.timeScale을 0으로 설정
            Time.timeScale = 0f;
            Debug.Log("Clear!");
        }
    }



    // 다음 레벨 버튼을 클릭했을 때 호출되는 메서드
    public void OnNextLevelButton()
    {
        // 다음 씬을 로드
        SceneManager.LoadScene(TestSceneTwo);
    }

    // 메인 씬으로 이동하는 메서드
    public void GoToMainScene()
    {
        // 메인 씬을 로드
        SceneManager.LoadScene("MainScene");
    }

    // 게임을 재시작하는 메서드
    public void RestartGame()
    {
        // Time.timeScale을 1로 설정하여 게임을 다시 시작
        Time.timeScale = 1f;
        // "TestScene" 씬을 로드
        SceneManager.LoadScene("TestScene");
    }
}


