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


    void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        Updatehealth();
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

    public void TakeDamage()    // �̰� ��������Ʈ�� ���� �Լ��� �̵��Ұ���
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.Gameover();
        }
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
