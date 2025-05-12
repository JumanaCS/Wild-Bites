using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;
    private TMP_Text introText;
    private string[] messages;
    private int currentMessageIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        introText = GetComponent<TMP_Text>();
        messages = new string[]
        {
            "Welcome to Wild Bites, the most paws-itively delightful restaurant in town, where your customers aren’t just picky eaters, they’re animals with tastes as wild as their origins! Your mission? Decode their quirky clues to serve the perfect dish. A chatty Shiba might crave something meaty! A monkey could pine for tropical treats? It is up to YOU to match ingredients (what animal they are) with meals (where the animal is from) to keep these critters howling for more!",
            "First, you’ll meet your customers, then choose their meals in the Menu Screen (page one: pick their favorite ingredient, page two: choose a dish from their homeland). Lastly you will whip up those meals with the ingredient you chose and receive the customer’s rating!",
            "Ready to embark on this flavor-filled adventure? Grab your apron: it’s time to customize your chef on the next screen!"
        };
        StartCoroutine(TypeText(messages[currentMessageIndex]));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            currentMessageIndex++;
            if (currentMessageIndex < messages.Length)
            {
                StartCoroutine(TypeText(messages[currentMessageIndex]));
            }
            else
            {
                SceneManager.LoadScene("Chef");
            }
        }
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        introText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            introText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}