using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu1 : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button continueButton; // ���� ����ϱ� ��ư
    public Button restartButton;
    public Button mainMenuButton;
    public Button quitButton;
    public bool Paused = false;
    bool isquick = false;

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            isquick = true;
            Time.timeScale = 2f;
        }
        else if(isquick == true)
{
            Time.timeScale = 1f;
            isquick = false;
        }

        if (Input.GetKey(KeyCode.F))
        {
            isquick = true;
            Time.timeScale = 2f;
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
        Time.timeScale = 0f; // ���� �Ͻ� ����
        Paused = true;
    }

    public void CloseSettingsMenu()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
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
        // ���� �� �ٽ� �ε�
        Time.timeScale = 1f; // ���� �ð� �簳
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        // ���� �޴��� �̵�
        Time.timeScale = 1f; // ���� �ð� �簳
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }
}
