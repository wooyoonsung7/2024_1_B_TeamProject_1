using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private RectTransform rectTransform; // RectTransform���� �Ϲ� Transform ��ü

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

   
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;
        Debug.Log("�巹��");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       Debug.Log("�巹�� ����");
  
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")  // Ÿ��
        {

            // ���� ��ž�� �����ض� �ڵ� �ۼ�

            if(gameObject !=  null) //���� ������Ʈ�� ������ ���
            {
                return; // �������
            }
        }
    }

   
}
