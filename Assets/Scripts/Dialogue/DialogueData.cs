using UnityEngine;

[System.Serializable]
public class DialogueNode 
{
    [TextArea] public string bubbleText;
    public string choiceAText;
    public string choiceBText;
    public int nextNodeA;
    public int nextNodeB;
    
    [Space(10)]
    public bool isExitNode;
    
    // This will always show, but we'll make it more obvious
    [Header("Exit Settings")]
    [Tooltip("Scene to load when exiting")]
    public string exitSceneName = "Menu";
}

public class DialogueData : MonoBehaviour 
{
    public DialogueNode[] nodes;
}
