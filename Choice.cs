using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Choice
{
    [SerializeField] private string choiceText;
    [SerializeField] private DialogueObject dialogueObject;

    public string ChoiceText => choiceText;

    public DialogueObject DialogueObject => dialogueObject;
}
