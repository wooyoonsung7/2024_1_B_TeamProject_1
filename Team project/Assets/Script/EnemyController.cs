using System;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int EnemyHp = 10;
    public float speed = 2.0f;

    private Transform[] wayPoints;
    private int currentWayPointIndex = 0;
    private Transform endPoint;
    private bool reachedEndPoint = false;

    void Start()
    {
        wayPoints = StageManager.Instance.wayPoint;
        transform.position = StageManager.Instance.startPoint.position;
        endPoint = StageManager.Instance.endPoint;
    }

    void Update()
    {
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

    //생긴 것
    private void OnTriggerEnter(Collider other) // 부딛힌 총알의 정보를 가져오는데 사용할 수 있음.
    {
        if (other.tag == "Bullet")
        {
            OnDamage(other.gameObject);
            Destroy(other.gameObject);
        }

        else if (other.tag == "EndPoint")
        {
            Health health = other.GetComponent<Health>();   // Health스크립트를 받아옴
            if (health != null)                             // 받아오는걸 성공했을 때
            {
                health.TakeDamage();                        // TakeDamage를 실행함
            }
        }
    }
    public void OnDamage(GameObject temp)
    {
        EnemyHp -= temp.GetComponent<Bullet>().attackValue;
        Debug.Log(EnemyHp); 

        if (EnemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
