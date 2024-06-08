using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
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
    }

    public void OnEndDrag(PointerEventData eventData)
    {     

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
        if (CoinSystem.Instance.coin >= CoinValue)
        {
            CoinSystem.Instance.coin -= CoinValue;
            GameObject gameObject = Instantiate(GameManager.Instance.TowerArray[cardIndex].columns[0]);
            gameObject.transform.position = obj.transform.position;
        }
        else
        {
            //����� ��ġ�� �ȵȴٴ� ��������
        }
    }
}
