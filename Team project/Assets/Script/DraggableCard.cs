using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    public int cardIndex = 0;

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
            GameObject hitObject = hit.collider.gameObject;

            // ������ 3D ��ü�� ��ȣ�ۿ��ϴ� ����
            InteractWith3DObject(hitObject);
        }
    }

    private void InteractWith3DObject(GameObject obj)
    {
        GameObject gameObject = Instantiate(GameManager.Instance.TowerArray[cardIndex].columns[0]);
        gameObject.transform.position = obj.transform.position;
    }
}
