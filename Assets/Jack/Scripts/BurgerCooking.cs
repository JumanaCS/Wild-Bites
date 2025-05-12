using UnityEngine;
using System.Collections;

public class BurgerCooking : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;

    public string destinationTag2 = "PlateArea";

    public SpriteRenderer ingredientRenderer;
    public SpriteRenderer butterRenderer;
    public SpriteRenderer panRenderer;

    public Sprite nextStep;
    public Sprite finalStep;
    public Sprite newButter;

    private AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        collider2d = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition3(); 
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition3() + offset; 
    }

    void OnMouseUp()
    {
        collider2d.enabled = false; 


        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition3() - Camera.main.transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);

        if (hitInfo.collider != null && hitInfo.transform.CompareTag(destinationTag2))
        {
            panRenderer.sprite = nextStep;
            audioSource.Play();
            Destroy(ingredientRenderer);
            butterRenderer.sprite = newButter;
            StartCoroutine(FinalTransform2());    
        }

        collider2d.enabled = true; 
    }

    private IEnumerator FinalTransform2()
    {
        yield return new WaitForSeconds(3f);
        panRenderer.sprite = finalStep;
    }


    Vector3 MouseWorldPosition3()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z; // Preserve the Z position
        return Camera.main.ScreenToWorldPoint(mouseScreenPos); // Convert to world space
    }
}
