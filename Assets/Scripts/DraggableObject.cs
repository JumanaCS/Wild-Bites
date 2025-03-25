using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public Animator pouring; // Animator to trigger the pouring animation
    public string destinationTag = "DropArea"; // Tag for the target drop area (like the pot)
    
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    // Called when mouse is pressed on the object
    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition(); // Calculate offset from mouse position to object
    }

    // Called while dragging the object
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset; // Update the object's position based on mouse
    }

    // Called when mouse is released
    void OnMouseUp()
    {
        collider2d.enabled = false; // Temporarily disable collider to prevent interfering with raycast

        // Cast a ray from the camera to the mouse position in the world
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);

        // Check if the raycast hit something, and if it's tagged as the destination tag (DropArea)
        if (hitInfo.collider != null && hitInfo.transform.CompareTag(destinationTag))
        {
            // Trigger the pouring animation
            pouring.SetTrigger("Pour");

            // Optional: Position the object at the drop area
            // transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f); 
        }

        collider2d.enabled = true; // Re-enable collider after raycast
    }

    // Convert mouse screen position to world position
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z; // Preserve the Z position
        return Camera.main.ScreenToWorldPoint(mouseScreenPos); // Convert to world space
    }
}
