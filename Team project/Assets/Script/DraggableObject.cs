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
        originalPosition = transform.position; // �巡�� ���� �� ���� ��ġ ����
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

        // �巡�� ���� �� �ٸ� ��ü���� �浹 �˻� �� ��ü ���� ȣ��
        bool merged = CheckForMerge();

        if (!merged)
        {
            // ��ü���� ������ ���� ��ġ�� ���ư���
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
                    return true; // ��ü�� �����ϸ� true ��ȯ
                }
            }
        }
        return false; // ��ü�� �����ϸ� false ��ȯ
    }

    private bool MergeObjects(GameObject otherObject)
    {
        DraggableObject otherDraggable = otherObject.GetComponent<DraggableObject>();

        if (otherDraggable != null && otherDraggable.objectIndex == this.objectIndex && objectLevel < 2)
        {
            // �巡�� ���� ��ü�� �浹�� ��ü�� ��ġ�� �̵�
            transform.position = otherObject.transform.position;

            Destroy(otherObject);
            Destroy(gameObject);

          
            GameObject newObject = Instantiate(GameManager.Instance.TowerArray[arrayIndex].columns[objectLevel + 1]
                , otherObject.transform.position, Quaternion.identity);

            return true; // ��ü�� ���������� �˸�
        }
        return false; // ��ü�� ���������� �˸�
    }

    void BulletchekingPoint()
    {
        if (isDragging == true)
        {
            Bullet._instance.Bulletcheking();
        }
    }
}
