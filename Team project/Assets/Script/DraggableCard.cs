using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    public int cardIndex = 0;
    public int CoinValue = 0;  //코인값지정

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition; // 드래그 시작 시 원래 위치 저장
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {     

        // 드래그 종료 시 3D 객체에 영향을 주는 로직 호출        
        Affect3DObject();       
        rectTransform.anchoredPosition = originalPosition;
    }

    private void Affect3DObject()
    {
        // UI 카드의 화면 위치를 기준으로 레이캐스트를 수행하여 3D 객체 감지
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
            GameManager.Instance.coin -= CoinValue;
            GameObject gameObject = Instantiate(GameManager.Instance.TowerArray[cardIndex].columns[0]);
            gameObject.transform.position = obj.transform.position;
        }
        else
        {
            //사운드로 배치가 안된다는 정보전달
        }
    }
}
