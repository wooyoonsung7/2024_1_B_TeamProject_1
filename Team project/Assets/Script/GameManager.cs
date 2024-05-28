using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // ������ �̶�� ���ִ°� �ʰ� ���ϴ� ���� ������
    public GameObject[] MapBlock = new GameObject[10];

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
        totalMonsters = GameObject.FindGameObjectsWithTag("Monster").Length;
        // ���� ���� �� �ʱ�ȭ
        deadMonsters = 0;
        // Ŭ���� �� ���� ���� UI ��Ȱ��ȭ
        clearUI.SetActive(false);
        gameOverUI.SetActive(false);
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
            ShowClearUI();
        }
    }

    // �÷��̾ ���� �� ȣ��Ǵ� �޼���
    public void PlayerDied()
    {
        // ���� ���� UI ǥ��
        ShowGameOverUI();
    }

    // Ŭ���� UI�� ǥ���ϴ� �޼���
    void ShowClearUI()
    {
        clearUI.SetActive(true);
    }

    // ���� ���� UI�� ǥ���ϴ� �޼���
    void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    // ���� ���� ��ư�� Ŭ������ �� ȣ��Ǵ� �޼���
    public void OnNextLevelButton()
    {
        // ���� ���� �ε�
        SceneManager.LoadScene(TestSceneTwo);
    }

    // ��õ� ��ư�� Ŭ������ �� ȣ��Ǵ� �޼���
    public void OnRetryButton()
    {
        // ���� ���� �ٽ� �ε�
        SceneManager.LoadScene("TestScene");
    }

    // ���� �޴� ��ư�� Ŭ������ �� ȣ��Ǵ� �޼���
    public void OnMainMenuButton()
    {
        // ���� �޴� ���� �ε�
        SceneManager.LoadScene(MainScene);
    }
}


