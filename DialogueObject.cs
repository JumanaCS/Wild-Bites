using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{

    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Choice[] choices;
    public string[] Dialogue => dialogue;
    public Choice[] Choices => choices;

    public bool HasChoices => Choices != null && Choices.Length > 0;
    

}
