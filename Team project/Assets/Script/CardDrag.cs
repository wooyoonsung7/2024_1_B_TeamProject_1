using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject[] Cardlist;
    public bool isDrag;
    public bool isDrop;
  
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData) 
    {
        rectTransform.position = Input.mousePosition;
        if (gameObject == Cardlist[0]) print(Cardlist[0]);
        if (gameObject == Cardlist[1]) print(Cardlist[1]);
        if (gameObject == Cardlist[2]) print(Cardlist[2]);
        if (gameObject == Cardlist[3]) print(Cardlist[3]);
        if (gameObject == Cardlist[4]) print(Cardlist[4]);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(gameObject == Cardlist[0]) this.transform.position = new Vector3(450, 110);

        if (gameObject == Cardlist[1]) this.transform.position = new Vector3(699.5701f, 110);

        if (gameObject == Cardlist[2]) this.transform.position = new Vector3(949.27f, 110);

        if (gameObject == Cardlist[3]) this.transform.position = new Vector3(1198.87f, 110);

        if (gameObject == Cardlist[4]) this.transform.position = new Vector3(1452, 110);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CardUIPoint") Debug.Log(gameObject + "충돌되었습니다.");
    }
}
