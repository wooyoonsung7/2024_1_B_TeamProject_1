using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public Button continueButton; // ���� ����ϱ� ��ư
    public Button quitButton;
    public GameObject settingsPanel;
    public Button restartButton;
    public Button mainMenuButton;

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
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
        Time.timeScale = 0f; // ���� �Ͻ� ����
    }

    public void CloseSettingsMenu()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
    }

    public void ContinueGame()
    {
        // ���� �޴��� ��Ȱ��ȭ�ϰ� ������ �簳
        CloseSettingsMenu();
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }

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
}
