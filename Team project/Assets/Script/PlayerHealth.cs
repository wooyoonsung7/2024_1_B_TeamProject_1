using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText; // UI Text 요소를 연결
    public int maxHealth = 5; // 최대 체력 값
    private int currentHealth; // 현재 체력 값
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth; // 초기 체력을 최대 체력으로 설정
        gameManager = FindObjectOfType<GameManager>(); // GameManager 찾기
        UpdateHealthUI();
    }

    // 데미지를 입었을 때 호출되는 메서드
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();

        // 체력이 0이 되었을 때 처리
        if (currentHealth == 0)
        {
            gameManager.GameOver();
        }
    }

    // 체력 UI 업데이트
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth;
    }

}
