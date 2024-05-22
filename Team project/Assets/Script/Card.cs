using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject[] cardlist =  new GameObject[4];
    public bool isDrag;


    private RectTransform rectTransform; // RectTransform으로 일반 Transform 대체

    private void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();

        isDrag = false;
    }

    private void Update()
    {
        // isDrag가 true 가 되는 조건 추후 작성 

        if (isDrag == true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                rectTransform.position = Input.mousePosition; //rectTransform.position를 마우스 를 따라 다니게 하라  // mousePosition 클릭 좌표
            }
        }     
    }
}
