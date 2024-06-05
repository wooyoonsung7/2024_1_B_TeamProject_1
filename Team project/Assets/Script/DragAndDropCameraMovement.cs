using UnityEngine;

public class DragAndDropCameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public LayerMask groundLayer;

    public float zoomSpeed = 5f;
    public float minZoom = 10f;
    public float maxZoom = 50f;

    private Camera mainCamera;
    private bool isDragging;
    private Vector3 dragStartPosition;
    private Vector3 cameraStartPosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ���콺 ������ ��ư ����
        {
            StartDrag();
        }
        if (Input.GetMouseButton(1)) // ���콺 ������ ��ư �巡��
        {
            DragCamera();
        }
        if (Input.GetMouseButtonUp(1)) // ���콺 ������ ��ư ��
        {
            EndDrag();
        }

        ZoomCamera();
    }

    void StartDrag()
    {
        isDragging = true;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            dragStartPosition = hit.point;
            cameraStartPosition = transform.position;
        }
    }

    void DragCamera()
    {
        if (!isDragging) return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 currentDragPosition = hit.point;
            Vector3 dragOffset = currentDragPosition - dragStartPosition;
            Vector3 targetPosition = cameraStartPosition - new Vector3(dragOffset.x, 0, dragOffset.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void EndDrag()
    {
        isDragging = false;
    }

    void ZoomCamera()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        if (scrollData != 0.0f)
        {
            float newCameraHeight = transform.position.y - scrollData * zoomSpeed;
            newCameraHeight = Mathf.Clamp(newCameraHeight, minZoom, maxZoom);
            transform.position = new Vector3(transform.position.x, newCameraHeight, transform.position.z);
        }
    }
}
