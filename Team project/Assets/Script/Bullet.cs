using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 1;
    public int AttackVelue = 1;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            EnemyMove enemyMove = GetComponent<EnemyMove>();

            if(enemyMove != null)
            {
                enemyMove.EnemyHp -= AttackVelue;
            }
        }
    }
}
