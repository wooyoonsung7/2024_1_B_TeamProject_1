using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void TakeDamage()    // 이거 엔드포인트에 넣을 함수로 이동할거임
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.Gameover();
        }
    }

    void UnlockNewStage()   // 스테이지 진행도에 따라 스테이지 선택화면에서 unlock 하는 함수 | 실행되면 buildIndex + 1을 잠금해제 하므로 클리어 조건에 넣어야함
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
