using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject[] Cardlist = new GameObject[5];
    public bool isDrag;
    public bool isDrop;
  
    private RectTransform rectTransform; // RectTransform으로 일반 Transform 대체

    private void Start()
    {
        isDrag = false;
        isDrop = false;

        rectTransform = GetComponent<RectTransform>();

        Debug.Log(Cardlist[0]);
        Debug.Log(Cardlist[1]);
        Debug.Log(Cardlist[2]);
        Debug.Log(Cardlist[3]);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("드레그");
        rectTransform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       Debug.Log("드레그 종료");
       if(gameObject == Cardlist[0])
        {
            this.transform.position = new Vector3(579, 150);
        }
       if (gameObject == Cardlist[1])
        {
            this.transform.position = new Vector3(828.5701f, 150);
        }
       if (gameObject == Cardlist[2])
        {
            this.transform.position = new Vector3(1078.27f, 150);
        }
       if (gameObject == Cardlist[3])
        {
            this.transform.position = new Vector3(1327.87f, 150);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")  // 타일
        { 
           // 추후 포탑을 생성하는 코드 추가
        }
    }


}
