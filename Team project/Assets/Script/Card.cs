using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject[] cardlist =  new GameObject[4];
    public bool isDrag;


    private RectTransform rectTransform; // RectTransform���� �Ϲ� Transform ��ü

    private void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();

        isDrag = false;
    }

    private void Update()
    {
        // isDrag�� true �� �Ǵ� ���� ���� �ۼ� 

        if (isDrag == true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                rectTransform.position = Input.mousePosition; //rectTransform.position�� ���콺 �� ���� �ٴϰ� �϶�  // mousePosition Ŭ�� ��ǥ
            }
        }     
    }
}
