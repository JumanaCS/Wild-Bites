using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RecipeManager : MonoBehaviour
{
    public string destinationTag = "DropArea"; 
    public List<GameObject> ingredients; 
    public int currentStep = 0;
    
    void Start()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            Collider2D col = ingredients[i].GetComponent<Collider2D>();
            col.enabled = false;
        }

        ingredients[0].GetComponent<Collider2D>().enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
    
                if (hit.collider.gameObject == ingredients[currentStep])
                {
                    ingredients[currentStep].GetComponent<Collider2D>().enabled = false;

                    currentStep++;

                    if (currentStep < ingredients.Count)
                    {
                        ingredients[currentStep].GetComponent<Collider2D>().enabled = true;
                    }
                }
            }
        }
}
}