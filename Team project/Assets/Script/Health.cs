using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health = 5;     // �ִ� ü�� (=��Ʈ ����)
    public int currentHealth;   // ���� ü��

    public Image[] hearts;  // ��Ʈ �̹��� �迭 �ִ� ü���� 5��� 5
    public Sprite fullHeart;  // ä���� ��Ʈ ��������Ʈ
    public Sprite emptyHeart; // �� ��Ʈ ��������Ʈ
    GameManager gamemanager;
    public GameObject gameOverUI;

    void Start()
    {
        currentHealth = health;
        gamemanager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Updatehealth();
        
        /*if (currentHealth <= 0)
        {
            Gameover();
        }*/
    }

    void Updatehealth()     // ��Ʈ�� �׷��ִ� �Լ�
    {
        if (currentHealth > health)
        {
            currentHealth = health;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Gameover();
        }
    }

    void GameClear()
    {
        PauseGame();
        // �������� Ŭ���� UI �����
        // Ȯ�� ��ư�� �����ų� ���� �ð��� ������ �Ʒ� �ڵ尡 ����ǵ���
        //UnlockNewStage();                             // ���� �� �ر�
        //SceneManager.LoadScene("StageSelection");     // �������� ���� �� �ε�
    }

    void Gameover()
    {
        Debug.Log("���� ����");
        gamemanager.gameObject.SetActive(false);
        //CoinSystem.Instance.EndCoin();
      
        PauseGame();

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // ������ �Ͻ�����
    }

    void UnlockNewStage()   // �������� ���൵�� ���� �������� ����ȭ�鿡�� unlock �ϴ� �Լ� | ����Ǹ� buildIndex + 1�� ������� �ϹǷ� Ŭ���� ���ǿ� �־����
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
