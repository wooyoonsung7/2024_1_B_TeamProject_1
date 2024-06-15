using System;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public int EnemyHp = 10;
    public float speed = 2.0f;
    public int coinValue = 0;

    private Transform[] wayPoints;
    private int currentWayPointIndex = 0;
    private Transform endPoint;
    private bool reachedEndPoint = false;
    private bool Hit = false;
    float Timer = 0;

    void Start()
    {
        wayPoints = StageManager.Instance.wayPoint;
        transform.position = StageManager.Instance.startPoint.position;
        endPoint = StageManager.Instance.endPoint;
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (!reachedEndPoint)
        {
            MoveAlongPath();
        }
    }

    void MoveAlongPath()
    {
        if (currentWayPointIndex < wayPoints.Length)
        {
            Transform targetWayPoint = wayPoints[currentWayPointIndex];
            if (targetWayPoint != null)
            {
                MoveToPoint(targetWayPoint.position);
                if (Vector3.Distance(transform.position, targetWayPoint.position) <= 0.1f)
                {
                    currentWayPointIndex++;
                }
            }
            else
            {
                currentWayPointIndex++;
            }
        }
        else
        {
            MoveToPoint(endPoint.position);
            if (Vector3.Distance(transform.position, endPoint.position) <= 0.1f)
            {
                reachedEndPoint = true;
            }
        }
    }

    void MoveToPoint(Vector3 targetPosition)
    {
        transform.LookAt(targetPosition);
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) // 부딛힌 총알의 정보를 가져오는데 사용할 수 있음.
    {
        if (other.tag == "Bullet")
        {
            OnDamage(other.gameObject);
            Destroy(other.gameObject);
            if (!Hit && Timer >= 3.5f)
            {
                Hit = true;
                Timer = 0;
                transform.DOShakePosition(0.5f, 0.5f, 10, 90f, false);

                DOVirtual.DelayedCall(0.5f, () => Hit = false);
            }

        }

        else if (other.tag == "EndPoint")       // Enemy가 끝까지 도착하면 HP를 깎음
        {
            SoundManager.instance.PlaySound("Attacked");
            Health health = FindObjectOfType<Health>();
            if (health != null)
            {
                health.currentHealth--;
                if (health.currentHealth <= 0)
                {
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    if (gameManager != null)
                    {
                        gameManager.Gameover();
                    }
                    // 참조랑 if문 너무 많은데 이게 맞나;;
                }
            }
            Destroy(gameObject);
        }
    }
    public void OnDamage(GameObject temp)
    {
        EnemyHp -= temp.GetComponent<Bullet>().attackValue;

        if (EnemyHp <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.getcoin = coinValue;
        }
        
    }

}
