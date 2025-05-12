using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class Plating : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;

    public string destinationTag = "ScoopArea"; 
    public string destinationTag2 = "PlateArea";

    public SpriteRenderer potRenderer;
    public SpriteRenderer trayRenderer;
    public SpriteRenderer ladleRenderer;

    public Sprite[] potSprites;
    public Sprite[] traySprites;

    public Sprite fullBox;
    public Sprite fullLadle;
    public Sprite emptyLadle;

    bool isScooped = false; 
    bool isPlated = false;

    private int potIndex = -1;
    private int boxIndex = -1;
    private int pourCount = 0;

    [SerializeField] private string nextSceneName = ""; 
    [SerializeField] private int currencyToAdd = 1; 

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition(); 
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset; 
    }

    void OnMouseUp()
    {
        collider2d.enabled = false; 


        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);


        if (hitInfo.collider != null && hitInfo.transform.CompareTag(destinationTag))
        {
            isScooped = true;
            ladleRenderer.sprite = fullLadle;
            
            if (isScooped){
                HideFoodSprites();
            }
        }

        if (hitInfo.collider != null && isScooped == true && hitInfo.transform.CompareTag(destinationTag2))
        {
            isPlated = true;
            ladleRenderer.sprite = emptyLadle;
            if (isPlated){
                PlateFood();
            }
        }

        collider2d.enabled = true; 
    }

    // Convert mouse screen position to world position

    private void HideFoodSprites()
    {
        // if (potIndex == 2)
        // {
        //     potRenderer.sprite = emptyPot;
        // }

        potIndex = (potIndex + 1);
        potRenderer.sprite = potSprites[potIndex];
    }

    private void PlateFood()
    {
        boxIndex = (boxIndex + 1);
        trayRenderer.sprite = traySprites[boxIndex];
        isPlated = false;
        isScooped = false;

        if (boxIndex == 2)
        {
            StartCoroutine(FinalTransform());
            
        }
    }

    private IEnumerator FinalTransform()
    {
        yield return new WaitForSeconds(2f);
        trayRenderer.sprite = fullBox;
        LoadNextLevel();
    }


    Vector3 MouseWorldPosition()
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
