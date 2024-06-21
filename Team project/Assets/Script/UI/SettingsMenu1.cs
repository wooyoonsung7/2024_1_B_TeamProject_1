using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu1 : MonoBehaviour
{
    public GameObject settingsPanel;
    /*public Button continueButton; // 게임 계속하기 버튼
    public Button restartButton;
    public Button mainMenuButton;
    public Button quitButton;*/
    public bool Paused = false;
    bool isquick = false;

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;
        if (Input.GetKey(KeyCode.F))
        {
            isquick = true;
            Time.timeScale = 5f;       // 빨리감기 속도
        }
        else
        {
            if (isquick == true)
            {
                Time.timeScale = 1f;
                isquick = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == true)
            {
                CloseSettingsMenu();
            }
            else
            {
                OpenSettingsMenu();
            }
        }

        //Debug.Log(Time.timeScale);
    }

    public void OpenSettingsMenu()
    {
        settingsPanel.SetActive(true);
        if (Time.timeScale != 0f)
        {
            Time.timeScale = 0f; // 게임 시간 재개
        }
        Paused = true;
    }

    public void CloseSettingsMenu()
    {
        settingsPanel.SetActive(false);
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // 게임 시간 재개
        }
        Paused = false;
    }

    public void CloseSettingsMenuButton()       // 사운드 넣으려고 똑같은 기능이지만 걍 함수 2개로 나눔
    {
        SoundManager.instance.PlaySound("Click");
        settingsPanel.SetActive(false);
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // 게임 시간 재개
        }
        Paused = false;
    }

    /*public void ContinueGame()
    {
        // 설정 메뉴를 비활성화하고 게임을 재개
        CloseSettingsMenu();
    }*/
    // 어짜피 CloseSettingsMenu() 와 기능이 똑같을텐데 뭐하러 함수를 또 만든거지? 이름 붙이려고? 일단 주석처리 해둠

    public void RestartGame()
    {
        SoundManager.instance.PlaySound("Click");
        // 현재 씬 다시 로드
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // 게임 시간 재개
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SoundManager.instance.PlaySound("Click");
        SoundManager.instance.StopSound("GameBGM");
        SoundManager.instance.StopSound("FeverBGM");
        // 메인 메뉴로 이동
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // 게임 시간 재개
        }
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound("Click");
        SoundManager.instance.StopSound("GameBGM");
        SoundManager.instance.StopSound("FeverBGM");
        // 게임 종료
        Application.Quit();
    }
}
