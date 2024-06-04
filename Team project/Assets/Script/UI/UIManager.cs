using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

                                                                                // Ŭ���� �� ���� ���� UI ������Ʈ
    public GameObject clearUI;
    public GameObject gameOverUI;
                                                                                // ���� �� �� ���� �޴� �� �̸�
    public string TestSceneTwo;
    public string MainScene;
    public int totalWaves = 3;                                                  // �� ���̺� ��
    private int currentWave = 0;                                                // ���� ���̺� 
    //private ClearUIManager clearUIManager;                                      // Ŭ���� UI�� �����ϴ� ClearUIManager�� ����
    private int totalMonsters;
    private int deadMonsters;

    public GameObject clearPanel;                                               // Ŭ���� UI �г��� ����

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
                                                                                // "Monster" �±׸� ���� ��� ���� ������Ʈ�� ���� ���� totalMonsters�� ����
        totalMonsters = GameObject.FindGameObjectsWithTag("Enemy").Length;
                                                                                // ���� ���� �� �ʱ�ȭ
        deadMonsters = 0;
                                                                                // Ŭ���� �� ���� ���� UI ��Ȱ��ȭ
        //clearUI.SetActive(false);
        //gameOverUI.SetActive(false);
        //clearUIManager = FindObjectOfType<ClearUIManager>();                    // ClearUIManager ã��
        StartNextWave();                                                        // ù ��° ���̺� ����
        clearUI.SetActive(false);
        gameOverUI.SetActive(false);
        clearUI = GameObject.Find("GameClearUI");                               // ���⼭ "YourClearUIObjectName"�� ���� clearUI GameObject�� �̸��Դϴ�.
        gameOverUI = GameObject.Find("GameOverUI");
    }

    void StartNextWave()
    {
        totalMonsters = GameObject.FindGameObjectsWithTag("Monster").Length;    // ���� ���̺��� ���� �� �ʱ�ȭ
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
                                                                // Ŭ���� UI ǥ��
            ShowClearUI();                                      // �߰��� �κ� �ּ� ó��
        }
        else
        {
            StartNextWave();                                     // ���� ���̺� ����
        }
    }

                                                                  // ���� ���� ó��
    public void GameOver()
    {
        gameOverUI.SetActive(true);                               // ���� ���� UI Ȱ��ȭ

        Time.timeScale = 0f;                                      // ������ ���߱� ���� Time.timeScale�� 0���� ����
        Debug.Log("Game Over!");
    }
                                                                  // Ŭ���� ó��
    public void CheckClear()
    {
        deadMonsters++;                                           // ���� ���� �� ����
        if (deadMonsters >= totalMonsters)                        // ��� ���Ͱ� �׾����� Ȯ��
        {
            clearUI.SetActive(true);                              // Ŭ���� UI Ȱ��ȭ

            Time.timeScale = 0f;                                  // ������ ���߱� ���� Time.timeScale�� 0���� ����                        
            Debug.Log("Clear!");
        }
    }

    public void OnNextLevelButton()                               // ���� ���� ��ư�� Ŭ������ �� ȣ��Ǵ� �޼���
    {
        SceneManager.LoadScene(TestSceneTwo);                     // ���� ���� �ε�
    }

    public void GoToMainScene()                                   // ���� ������ �̵��ϴ� �޼���
    {
        SceneManager.LoadScene("MainScene");                      // ���� ���� �ε�
    }

    public void RestartGame()                                     // ������ ������ϴ� �޼���
    { 
        Time.timeScale = 1f;                                      // Time.timeScale�� 1�� �����Ͽ� ������ �ٽ� ����
        SceneManager.LoadScene("TestScene");                      // "TestScene" ���� �ε�
    }

    public void GoToGame()                                        //���ξ����� ���� �޼���
    {
        SceneManager.LoadScene("TestScene");

    }

    public void Quit()                                           //������ ���� ���� �޼���
    {

#if UNITY_EDITOR                                                 //�����Ϳ��� ���� ���� ��
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();              //����� ���ӿ��� ���� ���ϋ�
#endif
    }

    // Ŭ���� UI�� Ȱ��ȭ�ϴ� �޼���
    public void ShowClearUI()
    {
        clearPanel.SetActive(true);
        clearUI.SetActive(true);
    }

    // Ŭ���� UI�� ��Ȱ��ȭ�ϴ� �޼���
    public void HideClearUI()
    {
        clearPanel.SetActive(false);
    }
}

