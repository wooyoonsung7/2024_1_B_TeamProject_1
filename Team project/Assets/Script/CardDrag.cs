using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private RectTransform rectTransform; // RectTransform으로 일반 Transform 대체

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

   
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;
        Debug.Log("드레그");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       Debug.Log("드레그 종료");
  
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")  // 타일
        {

            // 추후 포탑을 생성해라 코드 작성

            if(gameObject !=  null) //게임 오브젝트가 존재할 경우
            {
                return; // 돌려줘라
            }
        }
    }

   
}
