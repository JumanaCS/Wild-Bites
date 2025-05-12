using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.02f;

    [TextArea(3, 5)] public string[] messages = new string[]
    {
        "Crawfish",
        "Intro", 
        "bye"
    };
    public string nextSceneName = "Crawfish";

    private TMP_Text introText;
    private int currentMessageIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        introText = GetComponent<TMP_Text>();
        StartCoroutine(TypeText(messages[currentMessageIndex]));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Fixed the missing parenthesis here
        {
            if (isTyping)
            {
                // Skip typing animation if still typing
                StopAllCoroutines();
                introText.text = messages[currentMessageIndex];
                isTyping = false;
            }
            else
            {
                currentMessageIndex++;
                if (currentMessageIndex < messages.Length)
                {
                    StartCoroutine(TypeText(messages[currentMessageIndex]));
                }
                else
                {
                    // Load the specified scene
                    SceneManager.LoadScene(nextSceneName);
                }
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