using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
/*using DG.Tweening;  */    // 추후 미세 요소 개발시 사용

public class Cardsystem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject[] Cardlist;
    public GameObject[] _cardTowerPoint;
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
        Debug.Log(gameObject);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject == Cardlist[0]) this.transform.position = new Vector3(450, 110);

        if (gameObject == Cardlist[1]) this.transform.position = new Vector3(699.5701f, 110);

        if (gameObject == Cardlist[2]) this.transform.position = new Vector3(949.27f, 110);

        if (gameObject == Cardlist[3]) this.transform.position = new Vector3(1198.87f, 110);

        if (gameObject == Cardlist[4]) this.transform.position = new Vector3(1452, 110);

    }

    public void CardPointTower()
    {
        if(gameObject == Cardlist[0]) _cardTowerPoint[0].SetActive(true);

        if(gameObject == Cardlist[1]) _cardTowerPoint[1].SetActive(true);

        if(gameObject == Cardlist[2]) _cardTowerPoint[2].SetActive(true);

        if (gameObject == Cardlist[3]) _cardTowerPoint[3].SetActive(true);

        if(gameObject == Cardlist[4]) _cardTowerPoint[4].SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CardPont01") 
        {
            if (gameObject == Cardlist[0]) CardPointTower();
                                           
            if (gameObject == Cardlist[1]) CardPointTower();
                                           
            if (gameObject == Cardlist[2]) CardPointTower();
                                           
            if (gameObject == Cardlist[3]) CardPointTower();
                                           
            if (gameObject == Cardlist[4]) CardPointTower();
        }

        if (collision.gameObject.tag == "CardPont02")
        {
            if (gameObject == Cardlist[0]) CardPointTower();

            if (gameObject == Cardlist[1]) CardPointTower();

            if (gameObject == Cardlist[2]) CardPointTower();

            if (gameObject == Cardlist[3]) CardPointTower();

            if (gameObject == Cardlist[4]) CardPointTower();
        }

        if (collision.gameObject.tag == "CardPont03")
        {
            if (gameObject == Cardlist[0]) CardPointTower();

            if (gameObject == Cardlist[1]) CardPointTower();

            if (gameObject == Cardlist[2]) CardPointTower();

            if (gameObject == Cardlist[3]) CardPointTower();

            if (gameObject == Cardlist[4]) CardPointTower();
        }
    }
}
