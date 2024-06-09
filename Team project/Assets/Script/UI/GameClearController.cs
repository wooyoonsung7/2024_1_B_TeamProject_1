using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour
{
    public int totalEnemies; // 총 적의 수
    private int enemiesDefeated; // 물리친 적의 수

    void Update()
    {
        if (enemiesDefeated >= totalEnemies)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++; // 적이 물리쳐질 때 호출
    }

}
