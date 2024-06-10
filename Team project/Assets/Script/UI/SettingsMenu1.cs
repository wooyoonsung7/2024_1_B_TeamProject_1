using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu1 : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button continueButton; // 게임 계속하기 버튼
    public Button restartButton;
    public Button mainMenuButton;
    public Button quitButton;
    public bool Paused = false;

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)   // 메뉴가 열려있으면
            {
                CloseSettingsMenu();
            }
            else
            {
                OpenSettingsMenu();
            }
        }
    }

    public void OpenSettingsMenu()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f; // 게임 일시 정지
        Paused = true;
    }

    public void CloseSettingsMenu()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
        Paused = false;
    }

    public void ContinueGame()
    {
        // 설정 메뉴를 비활성화하고 게임을 재개
        CloseSettingsMenu();
    }

    public void RestartGame()
    {
        // 현재 씬 다시 로드
        Time.timeScale = 1f; // 게임 시간 재개
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        // 메인 메뉴로 이동
        Time.timeScale = 1f; // 게임 시간 재개
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        // 게임 종료
        Application.Quit();
    }
}
