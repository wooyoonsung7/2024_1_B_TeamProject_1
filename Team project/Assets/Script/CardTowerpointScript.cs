using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTowerpointScript : MonoBehaviour
{
    public GameObject[] _cardTowerPoint;
    void Start()
    {
        for(int i = 0 ; i < _cardTowerPoint.Length ; i++) 
        {
            Debug.Log(_cardTowerPoint);
            _cardTowerPoint[i].SetActive(false);
        }
    }

    void CardPointTower()
    {
        _cardTowerPoint[0].SetActive(true);
        //_cardTowerPoint[1].SetActive(true);
        //_cardTowerPoint[2].SetActive(true);
        //_cardTowerPoint[3].SetActive(true);
        //_cardTowerPoint[4].SetActive(true);
    }
}
