using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // 윤성아 이라고 되있는거 너가 원하는 데로 지정해
    public GameObject[] MapBlock = new GameObject[10];

    // 싱글톤 인스턴스
    public static GameManager Instance;

    // 클리어 및 게임 오버 UI 오브젝트
    public GameObject clearUI;
    public GameObject gameOverUI;
    // 다음 씬 및 메인 메뉴 씬 이름
    public string TestSceneTwo;
    public string MainScene;

    // 몬스터의 총 수 및 죽은 몬스터 수
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
        totalMonsters = GameObject.FindGameObjectsWithTag("Monster").Length;
        // 죽은 몬스터 수 초기화
        deadMonsters = 0;
        // 클리어 및 게임 오버 UI 비활성화
        clearUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    // 몬스터가 죽을 때 호출되는 메서드
    public void MonsterDied()
    {
        // 죽은 몬스터 수 증가
        deadMonsters++;
        // 모든 몬스터가 죽었는지 확인
        if (deadMonsters >= totalMonsters)
        {
            // 클리어 UI 표시
            ShowClearUI();
        }
    }

    // 플레이어가 죽을 때 호출되는 메서드
    public void PlayerDied()
    {
        // 게임 오버 UI 표시
        ShowGameOverUI();
    }

    // 클리어 UI를 표시하는 메서드
    void ShowClearUI()
    {
        clearUI.SetActive(true);
    }

    // 게임 오버 UI를 표시하는 메서드
    void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    // 다음 레벨 버튼을 클릭했을 때 호출되는 메서드
    public void OnNextLevelButton()
    {
        // 다음 씬을 로드
        SceneManager.LoadScene(TestSceneTwo);
    }

    // 재시도 버튼을 클릭했을 때 호출되는 메서드
    public void OnRetryButton()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene("TestScene");
    }

    // 메인 메뉴 버튼을 클릭했을 때 호출되는 메서드
    public void OnMainMenuButton()
    {
        // 메인 메뉴 씬을 로드
        SceneManager.LoadScene(MainScene);
    }
}


