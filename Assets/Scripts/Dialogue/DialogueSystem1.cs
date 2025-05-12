using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogueSystem1 : MonoBehaviour 
{
    public GameObject dialogueBox;
    public TMP_Text bubbleText;
    public Button choiceA, choiceB;
    public DialogueData dialogueData;
    public float typingSpeed = 0.05f; // Speed of typing (lower = faster)

    private int currentNode = 0;
    private bool isTyping = false;

    void Start() 
    {
        // Hide choices initially
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);
        
        ShowNode(0);
    }

    void ShowNode(int index) 
    {
        currentNode = index;
        DialogueNode node = dialogueData.nodes[index];
        
        // Start typing effect
        StartCoroutine(TypeText(node.bubbleText, node));
    }

    IEnumerator TypeText(string fullText, DialogueNode node) 
    {
        isTyping = true;
        bubbleText.text = ""; // Clear existing text
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        // Type out each character
        foreach (char letter in fullText.ToCharArray()) 
        {
            bubbleText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        
        // Show choices after typing completes
        choiceA.GetComponentInChildren<TMP_Text>().text = node.choiceAText;
        choiceB.GetComponentInChildren<TMP_Text>().text = node.choiceBText;
        choiceA.gameObject.SetActive(true);
        choiceB.gameObject.SetActive(true);

        // Set up button listeners
        choiceA.onClick.RemoveAllListeners();
        choiceB.onClick.RemoveAllListeners();

        if (node.isExitNode) 
        {
            choiceA.onClick.AddListener(() => SceneManager.LoadScene("IntroMonkey"));
            choiceB.onClick.AddListener(() => SceneManager.LoadScene("IntroMonkey"));
        }
        else 
        {
            choiceA.onClick.AddListener(() => ShowNode(node.nextNodeA));
            choiceB.onClick.AddListener(() => ShowNode(node.nextNodeB));
        }
    }

}
