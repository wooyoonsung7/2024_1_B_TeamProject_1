using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowEnemy : MonoBehaviour
{
    public Transform enemy;          // HP바가 따라다닐 몬스터
    public Vector3 offset;           // 위치값 보정
    public Slider hp;                // 따라다닐 슬라이더 UI

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && hp != null)
        {
            // 3D 오브젝트의 위치를 화면 좌표로 변환함
            Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.position + offset);

            // 화면 좌표를 Canvas 좌표로 변환
            RectTransform canvasRect = hp.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            // Slider UI 위치를 업데이트
            hp.transform.localPosition = canvasPos;
        }
    }
}
