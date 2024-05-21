using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadTowerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float AttackInterval = 3f;
    private float AttackTimer;
    private Transform target;
    void Start()
    {
        AttackTimer = 0;
        target = FindObjectOfType<EnemyMove>().transform;
    }

    void Update()
    {
        AttackTimer += Time.deltaTime;
        if (AttackTimer >= AttackInterval)
        {
            AttackTimer = 0;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
        }
    }
}
