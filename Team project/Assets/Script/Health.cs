using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void TakeDamage()
    {
        //void OnTriggerEnter(Collider other)
        {
            //if (other.tag == "Enemy")
            {
                //Debug.Log("�浹");
                currentHealth--;
                if (currentHealth <= 0)
                {
                    Gameover();
                }
            }
        }
    }

    void Gameover()
    {
        Debug.Log("���� ����");
        // ���� ���� UI Ű�°� �ۼ��ؾ���
        // ���� �������� �� ���� ������ �Ͻ������ϴ°� ��� ����?
    }
}