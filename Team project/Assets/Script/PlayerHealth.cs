using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBarFillImage; // 체력 바의 Fill 이미지
    public int maxHealth = 5; // 최대 체력 값
    private int currentHealth; // 현재 체력 값
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth; // 현재 체력을 최대 체력으로 초기화.
        UpdateHealthBar(); // 초기 체력 바를 업데이트.
    }

    // 데미지를 입었을 때 호출되는 메서드
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();

        // 체력이 0이 되었을 때 처리
        if (currentHealth == 0)
        {
            gameManager.GameOver();
        }
    }

    void UpdateHealthBar()
    {
        // 체력 비율을 계산하여 체력 바의 Fill Amount를 설정합니다.
        float healthRatio = (float)currentHealth / maxHealth;
        healthBarFillImage.fillAmount = healthRatio;
    }

}
