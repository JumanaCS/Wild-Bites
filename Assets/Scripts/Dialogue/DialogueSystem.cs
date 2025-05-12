using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogueSystem : MonoBehaviour 
{
    [Header("UI References")]
    public GameObject dialogueBox;
    public TMP_Text bubbleText;
    public Button choiceA;
    public Button choiceB;
    
    [Header("Dialogue Data")]
    public DialogueData dialogueData;
    
    [Header("Settings")]
    [Tooltip("Lower values = faster typing")] 
    public float typingSpeed = 0.05f;

    private int currentNode = 0;
    private bool isTyping = false;

    void Start() 
    {
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);
        
        ShowNode(0);
    }

    void ShowNode(int index) 
    {
        currentNode = index;
        DialogueNode node = dialogueData.nodes[index];
        
        StartCoroutine(TypeText(node.bubbleText, node));
    }

    IEnumerator TypeText(string fullText, DialogueNode node) 
    {
        isTyping = true;
        bubbleText.text = "";
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        foreach (char letter in fullText.ToCharArray()) 
        {
            bubbleText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        
        SetupChoices(node);
    }

    void SetupChoices(DialogueNode node)
    {
        choiceA.GetComponentInChildren<TMP_Text>().text = node.choiceAText;
        choiceB.GetComponentInChildren<TMP_Text>().text = node.choiceBText;
        
        choiceA.gameObject.SetActive(true);
        choiceB.gameObject.SetActive(true);

        choiceA.onClick.RemoveAllListeners();
        choiceB.onClick.RemoveAllListeners();

        if (node.isExitNode) 
        {
            string sceneName = string.IsNullOrEmpty(node.exitSceneName) ? "Menu" : node.exitSceneName;
            choiceA.onClick.AddListener(() => SceneManager.LoadScene(sceneName));
            choiceB.onClick.AddListener(() => SceneManager.LoadScene(sceneName));
        }
        else 
        {
            choiceA.onClick.AddListener(() => ShowNode(node.nextNodeA));
            choiceB.onClick.AddListener(() => ShowNode(node.nextNodeB));
        }
    }
}