using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int health = 5;     // 최대 체력 (=하트 개수)
    public int currentHealth;   // 현재 체력

    public Image[] hearts;  // 하트 이미지 배열 최대 체력이 5라면 5
    public Sprite fullHeart;  // 채워진 하트 스프라이트
    public Sprite emptyHeart; // 빈 하트 스프라이트

    void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        Updatehealth();
    }

    void Updatehealth()     // 하트를 그려주는 함수
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

    void Gameover()
    {
        Debug.Log("게임 오버");
        // 게임 오버 UI 키는거 작성해야함
        // 게임 오버했을 때 현재 게임을 일시정지하는거 어떻게 하지?
    }
}
