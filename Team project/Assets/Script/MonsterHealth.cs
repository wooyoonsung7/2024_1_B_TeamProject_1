using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class MonsterHealth : MonoBehaviour
{

    public Slider healthSlider; // 체력 바 슬라이더
    public int maxHealth = 200; // 최대 체력
    private int currentHealth; // 현재 체력

    
        

    void Start()
    {
        currentHealth = maxHealth; // 현재 체력을 최대 체력으로 초기화합니다.
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth; // 슬라이더의 최대값을 설정합니다.
            healthSlider.value = currentHealth; // 슬라이더의 현재값을 설정합니다.
        }
        else
        {
            Debug.LogWarning("HealthSlider is not assigned!");
        }
    }

    // 몬스터가 피해를 입었을 때 호출됩니다.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 피해만큼 체력을 감소시킵니다.
        if (currentHealth < 0) currentHealth = 0; // 체력이 음수가 되지 않도록 합니다.

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; // 슬라이더의 값을 갱신합니다.
        }

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하일 경우 사망 처리합니다.
        }
    }

    // 몬스터 사망 시 호출됩니다.
    void Die()
    {
        // 여기에 몬스터 사망 처리 코드를 작성합니다.
        Debug.Log("Monster died!");
        Destroy(gameObject); // 몬스터 오브젝트를 파괴합니다.
    }
}

