using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour
{
    public int totalEnemies; // �� ���� ��
    private int enemiesDefeated; // ����ģ ���� ��

    void Update()
    {
        if (enemiesDefeated >= totalEnemies)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++; // ���� �������� �� ȣ��
    }

}
