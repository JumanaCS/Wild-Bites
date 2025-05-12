using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DraggableObject : MonoBehaviour
{
    private Vector3 originalPosition;
    Vector3 offset;
    Collider2D collider2d;
    public Animator pouring; 
    public string destinationTag = "DropArea"; 
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer potRenderer;
    public Sprite potTransform;
    public Sprite emptySprite;
    // public GameObject[] foodSprites;
    public ParticleSystem foodParticles;
    private AudioSource audioSource;

    // public Animator transition;
    // public float transitionTime = 3f;

    Scene secondScene;
    string sceneName;
    string thirdScene;


    void Start()
    {
        secondScene = SceneManager.GetActiveScene();
        sceneName = secondScene.name;
        audioSource = GetComponent<AudioSource>();
        originalPosition = transform.position;
    }
    
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
            StartCoroutine(PourFood());
        }

        collider2d.enabled = true; 
    }

    IEnumerator PourFood()
    {
        pouring.SetTrigger("Pour");
        audioSource.Play();
        // foodParticles.Play();
        yield return new WaitForSeconds(2.5f);
        spriteRenderer.sprite = emptySprite;
        potRenderer.sprite = potTransform;
        // HideFoodSprites();
        ResetPosition();
        yield return new WaitForSeconds(4f);
    }

    // Convert mouse screen position to world position

    // private void HideFoodSprites()
    // {
    //     foreach (GameObject food in foodSprites)
    //     {
    //         food.SetActive(false);
    //     }
    // }

    private void ResetPosition()
    {
        transform.position = originalPosition;
        collider2d.enabled = false;
    }
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z; // Preserve the Z position
        return Camera.main.ScreenToWorldPoint(mouseScreenPos); // Convert to world space
    }

    public void LoadNextLevel()
    {   
        thirdScene = sceneName + "_1";
        SceneManager.LoadScene(thirdScene);
        // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +  1));
    }

    // IEnumerator LoadLevel(int levelIndex)
    // {
    //     if (transition != null)
    //     {
    //     transition.SetTrigger("Start");
    //     yield return new WaitForSeconds(transitionTime);
    //     }

    //     SceneManager.LoadScene(levelIndex);
    // }

    public void PouringParticles()
    {
        if (foodParticles != null)
        {
            foodParticles.Play();
        }
    }
}
