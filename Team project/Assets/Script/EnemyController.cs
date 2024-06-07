using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Hp = 10f;
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
        if (Hp == 0) Die();
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
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
