using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu1 : MonoBehaviour
{
    public GameObject settingsPanel;
    /*public Button continueButton; // ���� ����ϱ� ��ư
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
            Time.timeScale = 5f;       // �������� �ӵ�
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
            Time.timeScale = 0f; // ���� �ð� �簳
        }
        Paused = true;
    }

    public void CloseSettingsMenu()
    {
        settingsPanel.SetActive(false);
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // ���� �ð� �簳
        }
        Paused = false;
    }

    public void CloseSettingsMenuButton()       // ���� �������� �Ȱ��� ��������� �� �Լ� 2���� ����
    {
        SoundManager.instance.PlaySound("Click");
        settingsPanel.SetActive(false);
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // ���� �ð� �簳
        }
        Paused = false;
    }

    /*public void ContinueGame()
    {
        // ���� �޴��� ��Ȱ��ȭ�ϰ� ������ �簳
        CloseSettingsMenu();
    }*/
    // ��¥�� CloseSettingsMenu() �� ����� �Ȱ����ٵ� ���Ϸ� �Լ��� �� �������? �̸� ���̷���? �ϴ� �ּ�ó�� �ص�

    public void RestartGame()
    {
        SoundManager.instance.PlaySound("Click");
        // ���� �� �ٽ� �ε�
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // ���� �ð� �簳
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SoundManager.instance.PlaySound("Click");
        SoundManager.instance.StopSound("GameBGM");
        SoundManager.instance.StopSound("FeverBGM");
        // ���� �޴��� �̵�
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f; // ���� �ð� �簳
        }
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound("Click");
        SoundManager.instance.StopSound("GameBGM");
        SoundManager.instance.StopSound("FeverBGM");
        // ���� ����
        Application.Quit();
    }
}
