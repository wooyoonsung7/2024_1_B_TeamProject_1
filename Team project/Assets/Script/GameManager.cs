using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    // �̱��� �ν��Ͻ�
    public static GameManager Instance;

    // Ŭ���� �� ���� ���� UI ������Ʈ
    public GameObject clearUI;
    public GameObject gameOverUI;
    // ���� �� �� ���� �޴� �� �̸�
    public string TestSceneTwo;
    public string MainScene;

    // ������ �� �� �� ���� ���� ��
    private int totalMonsters;
    private int deadMonsters;

    private ClearUIManager clearUIManager; // Ŭ���� UI�� �����ϴ� ClearUIManager�� ����




    // Awake �޼��� - �̱��� ���� ����
    void Awake()
    {
        if (Instance == null)
        {
            // ���� �ν��Ͻ��� Instance�� �Ҵ�
            Instance = this;
        }
        else
        {
            // �̹� �ν��Ͻ��� �����ϸ� ���� ������Ʈ�� �ı�
            Destroy(gameObject);
        }
    }

    // Start �޼��� - �ʱ� ����
    void Start()
    {
        // "Monster" �±׸� ���� ��� ���� ������Ʈ�� ���� ���� totalMonsters�� ����
        totalMonsters = GameObject.FindGameObjectsWithTag("Enemy").Length;
        // ���� ���� �� �ʱ�ȭ
        deadMonsters = 0;
        // Ŭ���� �� ���� ���� UI ��Ȱ��ȭ
        //clearUI.SetActive(false);
        //gameOverUI.SetActive(false);
        clearUIManager = FindObjectOfType<ClearUIManager>(); // ClearUIManager ã��
    }

    // ���Ͱ� ���� �� ȣ��Ǵ� �޼���
    public void MonsterDied()
    {
        // ���� ���� �� ����
        deadMonsters++;
        // ��� ���Ͱ� �׾����� Ȯ��
        if (deadMonsters >= totalMonsters)
        {
            // Ŭ���� UI ǥ��
            clearUIManager.ShowClearUI();
            print("Clear");
        }
    }

    // ���� ���� ó��
    public void GameOver()
    {
        // ���� ���� UI Ȱ��ȭ
        gameOverUI.SetActive(true);
        // ������ ���߱� ���� Time.timeScale�� 0���� ����
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }



    // Ŭ���� ó��
    public void CheckClear()
    {
        deadMonsters++; // ���� ���� �� ����
        // ��� ���Ͱ� �׾����� Ȯ��
        if (deadMonsters >= totalMonsters)
        {
            // Ŭ���� UI Ȱ��ȭ
            clearUI.SetActive(true);
            // ������ ���߱� ���� Time.timeScale�� 0���� ����
            Time.timeScale = 0f;
            Debug.Log("Clear!");
        }
    }



    // ���� ���� ��ư�� Ŭ������ �� ȣ��Ǵ� �޼���
    public void OnNextLevelButton()
    {
        // ���� ���� �ε�
        SceneManager.LoadScene(TestSceneTwo);
    }

    // ���� ������ �̵��ϴ� �޼���
    public void GoToMainScene()
    {
        // ���� ���� �ε�
        SceneManager.LoadScene("MainScene");
    }

    // ������ ������ϴ� �޼���
    public void RestartGame()
    {
        // Time.timeScale�� 1�� �����Ͽ� ������ �ٽ� ����
        Time.timeScale = 1f;
        // "TestScene" ���� �ε�
        SceneManager.LoadScene("TestScene");
    }
}


