using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBarFillImage; // ü�� ���� Fill �̹���
    public int maxHealth = 5; // �ִ� ü�� ��
    private int currentHealth; // ���� ü�� ��
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth; // ���� ü���� �ִ� ü������ �ʱ�ȭ.
        UpdateHealthBar(); // �ʱ� ü�� �ٸ� ������Ʈ.
    }

    // �������� �Ծ��� �� ȣ��Ǵ� �޼���
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();

        // ü���� 0�� �Ǿ��� �� ó��
        if (currentHealth == 0)
        {
            gameManager.GameOver();
        }
    }

    void UpdateHealthBar()
    {
        // ü�� ������ ����Ͽ� ü�� ���� Fill Amount�� �����մϴ�.
        float healthRatio = (float)currentHealth / maxHealth;
        healthBarFillImage.fillAmount = healthRatio;
    }

}
