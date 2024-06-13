using DG.Tweening.Core.Easing;
using Microsoft.Unity.VisualStudio.Editor;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    public UnityEngine.UI.Image image;
    public UnityEngine.Color possibleColor;
    public UnityEngine.Color impossibleColor;
    public int cardIndex = 0;
    public int CoinValue = 0;  //���ΰ�����

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition; // �巡�� ���� �� ���� ��ġ ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        /*Vector2 screenPosition = rectTransform.position;              // �ϴ� ��Ȱ��ȭ �ص� (Null ��������.. ���߿� ī�� ���ҽ� ������ �� �Ѱ� ���� �����������)
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))                  // ī�尡 ��ġ ����
        {
            if (hit.collider.tag == "TowerBase")
            {
                if (GameManager.Instance.coin < CoinValue)
                {
                    if (image.color == impossibleColor)
                        return;
                    image.color = impossibleColor;
                }
                else
                {
                    if (image.color == possibleColor)
                        return;
                    image.color = possibleColor;
                }
            }
            else
            {
                if (image.color == UnityEngine.Color.white)
                    return;
                image.color = UnityEngine.Color.white;
            }
        }*/
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = UnityEngine.Color.white;
        // �巡�� ���� �� 3D ��ü�� ������ �ִ� ���� ȣ��        
        Affect3DObject();       
        rectTransform.anchoredPosition = originalPosition;
    }

    private void Affect3DObject()
    {
        // UI ī���� ȭ�� ��ġ�� �������� ����ĳ��Ʈ�� �����Ͽ� 3D ��ü ����
        Vector2 screenPosition = rectTransform.position;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "TowerBase")
            {
                InteractWith3DObject(hit.collider.gameObject);
            }
        }
    }

    private void InteractWith3DObject(GameObject obj)
    {
        if (GameManager.Instance.coin >= CoinValue)
        {
            GameManager.Instance.BuyCard(CoinValue);
            GameObject gameObject = Instantiate(GameManager.Instance.TowerArray[cardIndex].columns[0]);
            gameObject.transform.position = obj.transform.position;
        }
        else
        {
            //����� ��ġ�� �ȵȴٴ� ��������
        }
    }
}
