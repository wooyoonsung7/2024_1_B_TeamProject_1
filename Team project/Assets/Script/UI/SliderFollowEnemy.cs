using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowEnemy : MonoBehaviour
{
    public Transform enemy;          // HP�ٰ� ����ٴ� ����
    public Vector3 offset;           // ��ġ�� ����
    public Slider hp;                // ����ٴ� �����̴� UI

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && hp != null)
        {
            // 3D ������Ʈ�� ��ġ�� ȭ�� ��ǥ�� ��ȯ��
            Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.position + offset);

            // ȭ�� ��ǥ�� Canvas ��ǥ�� ��ȯ
            RectTransform canvasRect = hp.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            // Slider UI ��ġ�� ������Ʈ
            hp.transform.localPosition = canvasPos;
        }
    }
}
