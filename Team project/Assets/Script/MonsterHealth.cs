using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class MonsterHealth : MonoBehaviour
{

    public Slider healthSlider; // ü�� �� �����̴�
    public int maxHealth = 200; // �ִ� ü��
    private int currentHealth; // ���� ü��

    
        

    void Start()
    {
        currentHealth = maxHealth; // ���� ü���� �ִ� ü������ �ʱ�ȭ�մϴ�.
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth; // �����̴��� �ִ밪�� �����մϴ�.
            healthSlider.value = currentHealth; // �����̴��� ���簪�� �����մϴ�.
        }
        else
        {
            Debug.LogWarning("HealthSlider is not assigned!");
        }
    }

    // ���Ͱ� ���ظ� �Ծ��� �� ȣ��˴ϴ�.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ���ظ�ŭ ü���� ���ҽ�ŵ�ϴ�.
        if (currentHealth < 0) currentHealth = 0; // ü���� ������ ���� �ʵ��� �մϴ�.

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; // �����̴��� ���� �����մϴ�.
        }

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ������ ��� ��� ó���մϴ�.
        }
    }

    // ���� ��� �� ȣ��˴ϴ�.
    void Die()
    {
        // ���⿡ ���� ��� ó�� �ڵ带 �ۼ��մϴ�.
        Debug.Log("Monster died!");
        Destroy(gameObject); // ���� ������Ʈ�� �ı��մϴ�.
    }
}

