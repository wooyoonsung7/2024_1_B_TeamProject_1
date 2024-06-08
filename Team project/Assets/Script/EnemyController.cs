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

    //���� ��
    private void OnTriggerEnter(Collider other) // �ε��� �Ѿ��� ������ �������µ� ����� �� ����.
    {
        if (other.tag == "Bullet")
        {
            OnDamage(other.gameObject);
            Destroy(other.gameObject);
        }

        else if (other.tag == "EndPoint")
        {
            Health health = other.GetComponent<Health>();   // Health��ũ��Ʈ�� �޾ƿ�
            if (health != null)                             // �޾ƿ��°� �������� ��
            {
                health.TakeDamage();                        // TakeDamage�� ������
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
