using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class BurgerPlatingFinal : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;

    public string destinationTag2 = "PlateArea";

    public SpriteRenderer ingredientRenderer;
    public SpriteRenderer burgerRenderer;
    public Sprite burgerTransform;

    public Sprite bunSprite;
    public Sprite fullBox;

    [SerializeField] private string nextSceneName = ""; 
    [SerializeField] private int currencyToAdd = 1; 
    
    private AudioSource audioSource;


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

        StartCoroutine(FinalTransform());
            
    }

    private IEnumerator FinalTransform()
    {
        yield return new WaitForSeconds(2f);
        burgerRenderer.sprite = bunSprite;

        yield return new WaitForSeconds(2f);
        burgerRenderer.sprite = fullBox;
        LoadNextLevel();
    }

    Vector3 MouseWorldPosition2()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z; // Preserve the Z position
        return Camera.main.ScreenToWorldPoint(mouseScreenPos); // Convert to world space
    }

    public void LoadNextLevel()
    {
       CurrencyManager.Instance?.AddCurrency(currencyToAdd);
       SceneManager.LoadScene(nextSceneName);
    }

}
