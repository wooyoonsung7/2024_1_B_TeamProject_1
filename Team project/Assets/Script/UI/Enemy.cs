using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnDestroy()
    {
        // ���� �ı��� �� GameClearController�� EnemyDefeated �޼ҵ� ȣ��
        FindObjectOfType<GameClearController>().EnemyDefeated();
    }
}
