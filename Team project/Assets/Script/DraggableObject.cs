using System.Diagnostics.Tracing;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{

    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging;
    private Vector3 originalPosition;
    public int objectIndex;
    public int arrayIndex;
    public int objectLevel;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        BulletchekingPoint();
    }

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
        originalPosition = transform.position; // 드래그 시작 시 원래 위치 저장
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // 드래그 종료 시 다른 객체와의 충돌 검사 및 합체 로직 호출
        bool merged = CheckForMerge();

        if (!merged)
        {
            // 합체되지 않으면 원래 위치로 돌아가기
            transform.position = originalPosition;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private bool CheckForMerge()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != gameObject)
            {
                if (MergeObjects(hitCollider.gameObject))
                {
                    return true; // 합체가 성공하면 true 반환
                }
            }
        }
        return false; // 합체가 실패하면 false 반환
    }

    private bool MergeObjects(GameObject otherObject)
    {
        DraggableObject otherDraggable = otherObject.GetComponent<DraggableObject>();

        if (otherDraggable != null && otherDraggable.objectIndex == this.objectIndex && objectLevel < 2)
        {
            // 드래그 중인 객체를 충돌된 객체의 위치로 이동
            transform.position = otherObject.transform.position;

            Destroy(otherObject);
            Destroy(gameObject);

          
            GameObject newObject = Instantiate(GameManager.Instance.TowerArray[arrayIndex].columns[objectLevel + 1]
                , otherObject.transform.position, Quaternion.identity);

            return true; // 합체가 성공했음을 알림
        }
        return false; // 합체가 실패했음을 알림
    }

    void BulletchekingPoint()
    {
        if (isDragging == true)
        {
            Bullet._instance.Bulletcheking();
        }
    }
}
