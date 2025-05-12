using UnityEngine;
using System.Collections;

public class BurgerPlating : MonoBehaviour
{
    private AudioSource audioSource;

    Vector3 offset;
    Collider2D collider2d;

    public string destinationTag2 = "PlateArea";

    public SpriteRenderer ingredientRenderer;
    public SpriteRenderer burgerRenderer;
    public Sprite burgerTransform;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        collider2d = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition2(); 
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition2() + offset; 
    }

    void OnMouseUp()
    {
        collider2d.enabled = false; 


        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition2() - Camera.main.transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);

        if (hitInfo.collider != null && hitInfo.transform.CompareTag(destinationTag2))
        {
            PlateFood();
    
        }

        collider2d.enabled = true; 
    }

    // Convert mouse screen position to world position

    private void PlateFood()
    {
        Destroy(ingredientRenderer);
        audioSource.Play();
        burgerRenderer.sprite = burgerTransform;    
    }

    Vector3 MouseWorldPosition2()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z; // Preserve the Z position
        return Camera.main.ScreenToWorldPoint(mouseScreenPos); // Convert to world space
    }
}
