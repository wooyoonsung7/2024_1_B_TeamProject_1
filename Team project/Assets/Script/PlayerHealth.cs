using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText; // UI Text ��Ҹ� ����
    public int maxHealth = 5; // �ִ� ü�� ��
    private int currentHealth; // ���� ü�� ��
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth; // �ʱ� ü���� �ִ� ü������ ����
        gameManager = FindObjectOfType<GameManager>(); // GameManager ã��
        UpdateHealthUI();
    }

    // �������� �Ծ��� �� ȣ��Ǵ� �޼���
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();

        // ü���� 0�� �Ǿ��� �� ó��
        if (currentHealth == 0)
        {
            gameManager.GameOver();
        }
    }

    // ü�� UI ������Ʈ
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth;
    }

}
