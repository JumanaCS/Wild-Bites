using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class KnifeChopController : MonoBehaviour
{
    private List<GameObject> currentSpriteInstances = new List<GameObject>();
    private AudioSource audioSource;

    public Animator knifeAnimator;

    public float movementSpeed;
    public float moveDistance = 1f;

    public GameObject[] spritePrefabs; 
    public GameObject[] foodList;
    public Transform[] foodSpawnPositions;

    public Sprite[] fullBowls;
    public SpriteRenderer transformBowls;

    public int maxHealth = 100;
    private int currentHealth;
    public Transform spawnPoint; 
    private GameObject ingredient;

    public BoxCollider2D spawnArea;
    private int currentIndex = 0;

    Scene firstScene;
    string sceneName;
    string secondScene;


    void Start()
    {   
        firstScene = SceneManager.GetActiveScene();
        sceneName = firstScene.name;
        audioSource = GetComponent<AudioSource>();

        if (foodList.Length > 0)
        {
            ingredient = Instantiate(foodList[0], foodSpawnPositions[0].position, Quaternion.identity);

        }
        currentHealth = maxHealth;
        // Get the Animator component if not assigned in the Inspector
        if (knifeAnimator == null)
        {
            knifeAnimator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Trigger the chop animation on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {   

            knifeAnimator.SetTrigger("Chop");  // Trigger the "Chop" animation
            audioSource.Play();
            if(ingredient != null)
            {
                currentHealth -= 25;                
                ingredient.transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
                SpawnSprite();
            }

            if(currentHealth <= 0)
            {
                ingredient.SetActive(false);
                foreach (GameObject piece in currentSpriteInstances)
                {
                    if(piece != null)
                        Destroy(piece);
                }

                currentSpriteInstances.Clear();
                transformBowls.sprite = fullBowls[currentIndex];

                currentIndex += 1;
                if(currentIndex >= foodList.Length)
                {
                StartCoroutine(LoadNextLevel());
                return;
                }

                ingredient = Instantiate(foodList[currentIndex], foodSpawnPositions[currentIndex].position, Quaternion.identity);
                currentHealth = maxHealth;

            }

        }
    }

    void SpawnSprite()
    {
        Vector2 randomPosition = new Vector2(
        Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
        Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y));

        GameObject newPiece  = Instantiate(spritePrefabs[currentIndex], randomPosition, Quaternion.identity);
        currentSpriteInstances.Add(newPiece);
    }

    IEnumerator LoadNextLevel()
    {
        knifeAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        secondScene = sceneName + "_1";
        SceneManager.LoadScene(secondScene);
    }
}
