using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Transform objectToDrag;
    private Vector3 originalPosition;

    void Update()
    {
        // Nhấn chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            // Tạo ray từ vị trí của chuột trên màn hình
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Kiểm tra nếu ray trúng một collider 2D
            if (hit.collider != null)
            {
                isDragging = true;
                objectToDrag = hit.transform;

                // Tính offset giữa vị trí của đối tượng và vị trí của chuột
                offset = objectToDrag.position - (Vector3)mousePosition;
            }
        }

        // Thả chuột trái
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Nếu đang kéo
        if (isDragging && objectToDrag != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectToDrag.position = mousePosition + (Vector2)offset;
        }
    }
}