using UnityEngine;

public class GizmoLabel : MonoBehaviour
{
    public string label;

    [SerializeField]
    private Color gizmoColor = Color.white; // �ν����� â���� ���� ���� ����

    private void OnDrawGizmos()
    {
        if (!string.IsNullOrEmpty(label))
        {
            Gizmos.color = gizmoColor;
            DrawLabel();
        }
    }

    private void DrawLabel()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = gizmoColor;
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 12;
        style.fontStyle = FontStyle.Bold;

        Vector3 position = transform.position + Vector3.up * 2;
        //UnityEditor.Handles.Label(position, label, style);
    }
}
