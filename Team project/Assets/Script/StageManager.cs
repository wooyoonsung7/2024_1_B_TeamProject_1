using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public Transform startPoint;
    public Transform[] wayPoint = new Transform[6];
    public Transform endPoint;

    [SerializeField]
    private Color gizmoColor = Color.red; // 기즈모 색상

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        if (startPoint != null)
        {
            Vector3 previousPoint = startPoint.position;

            // Waypoints를 순서대로 연결
            foreach (Transform point in wayPoint)
            {
                if (point != null)
                {
                    Gizmos.DrawLine(previousPoint, point.position);
                    previousPoint = point.position;
                }
            }

            // EndPoint와 연결
            if (endPoint != null)
            {
                Gizmos.DrawLine(previousPoint, endPoint.position);
            }
        }
    }

    void Awake()
    {
        Instance = this;
    }

}
