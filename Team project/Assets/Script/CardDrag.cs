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
            this.transform.position = new Vector3(450, 110);
        }
       if (gameObject == Cardlist[1])
        {
            this.transform.position = new Vector3(699.5701f, 110);
        }
       if (gameObject == Cardlist[2])
        {
            this.transform.position = new Vector3(949.27f, 110);
        }
       if (gameObject == Cardlist[3])
        {
            this.transform.position = new Vector3(1198.87f, 110);
        }
       if (gameObject == Cardlist[4])
        {
            this.transform.position = new Vector3(1452, 110);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")  // 타일
        { 
           // 추후 포탑을 생성하는 코드 추가
        }
        else
        {
            if (gameObject == Cardlist[0])
            {
                this.transform.position = new Vector3(450, 110);
            }
            if (gameObject == Cardlist[1])
            {
                this.transform.position = new Vector3(699.5701f, 110);
            }
            if (gameObject == Cardlist[2])
            {
                this.transform.position = new Vector3(949.27f, 110);
            }
            if (gameObject == Cardlist[3])
            {
                this.transform.position = new Vector3(1198.87f, 110);
            }
            if (gameObject == Cardlist[4])
            {
                this.transform.position = new Vector3(1452, 110);
            }
        }
    }


}
