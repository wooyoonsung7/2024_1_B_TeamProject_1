using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnDestroy()
    {
        // 적이 파괴될 때 GameClearController의 EnemyDefeated 메소드 호출
        FindObjectOfType<GameClearController>().EnemyDefeated();
    }
}
