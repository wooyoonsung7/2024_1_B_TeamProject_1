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

    void GameClear()
    {
        PauseGame();
        // 스테이지 클리어 UI 띄워줌
        // 확인 버튼을 누르거나 일정 시간이 지나면 아래 코드가 실행되도록
        //UnlockNewStage();                             // 선택 씬 해금
        //SceneManager.LoadScene("StageSelection");     // 스테이지 선택 씬 로드
    }

    void Gameover()
    {
        Debug.Log("게임 오버");
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
        Time.timeScale = 0f; // 게임을 일시정지
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
