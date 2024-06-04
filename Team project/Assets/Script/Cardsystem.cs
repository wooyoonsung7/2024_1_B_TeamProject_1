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
    public bool _cardTowerPointCake;


    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        _cardTowerPointCake = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        rectTransform.position = Input.mousePosition;
        Debug.Log(gameObject);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject == Cardlist[0]) this.transform.position = new Vector3(602, 123);

        if (gameObject == Cardlist[1]) this.transform.position = new Vector3(791, 123);

        if (gameObject == Cardlist[2]) this.transform.position = new Vector3(980, 123);

        if (gameObject == Cardlist[3]) this.transform.position = new Vector3(1169, 123);

        if (gameObject == Cardlist[4]) this.transform.position = new Vector3(1358, 123);

    }

    public void CardPointTower()
    {
        if (gameObject == Cardlist[0] && _cardTowerPoint[0].GetComponent<TowerController>().coinValue <= GameManager.Instance.coin)
        {
            _cardTowerPoint[0].SetActive(true); _cardTowerPointCake = true;
            GameManager.Instance.coin -= _cardTowerPoint[0].GetComponent<TowerController>().coinValue;
        }

        if (gameObject == Cardlist[1] && _cardTowerPoint[1].GetComponent<TowerController>().coinValue <= GameManager.Instance.coin)
        {
            _cardTowerPoint[1].SetActive(true); _cardTowerPointCake = true;
            GameManager.Instance.coin -= _cardTowerPoint[1].GetComponent<TowerController>().coinValue;
        }

        if (gameObject == Cardlist[2] && _cardTowerPoint[2].GetComponent<TowerController>().coinValue <= GameManager.Instance.coin) 
        { 
            _cardTowerPoint[2].SetActive(true); _cardTowerPointCake = true;
            GameManager.Instance.coin -= _cardTowerPoint[2].GetComponent<TowerController>().coinValue;
        }

        if (gameObject == Cardlist[3] && _cardTowerPoint[3].GetComponent<TowerController>().coinValue <= GameManager.Instance.coin)
        {
            _cardTowerPoint[3].SetActive(true); _cardTowerPointCake = true;
            GameManager.Instance.coin -= _cardTowerPoint[3].GetComponent<TowerController>().coinValue;
        }

        if (gameObject == Cardlist[4] && _cardTowerPoint[4].GetComponent<TowerController>().coinValue <= GameManager.Instance.coin)
        {
            _cardTowerPoint[4].SetActive(true); _cardTowerPointCake = true;
            GameManager.Instance.coin -= _cardTowerPoint[4].GetComponent<TowerController>().coinValue;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (true)
        {
            if (_cardTowerPointCake == true)
            {
                Debug.Log("이미 아군이 존재합니다.");
                
                break;
            }
            else
            {
                if (collision.gameObject.tag == "CardPont01")
                {
                    if (gameObject == Cardlist[0]) CardPointTower(); 

                    if (gameObject == Cardlist[1]) CardPointTower(); 

                    if (gameObject == Cardlist[2]) CardPointTower(); 

                    if (gameObject == Cardlist[3]) CardPointTower(); 

                    if (gameObject == Cardlist[4]) CardPointTower();

                    break;
                }
            }
            break;
        }
    }
}
