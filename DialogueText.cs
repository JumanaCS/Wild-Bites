using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject test;
    [SerializeField] private GameObject dialogueBox;

    private ChoiceManager choiceManager;
    private TypeEffect typeEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        typeEffect = GetComponent<TypeEffect>();
        choiceManager = GetComponent<ChoiceManager>();
        closeDialogue();
        ShowDialogue(test);
        
    }

    public void ShowDialogue(DialogueObject dialogueObject){

        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){
        foreach(string dialogue in dialogueObject.Dialogue){
            yield return typeEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        for(int i = 0; i < dialogueObject.Dialogue.Length; i++){
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeEffect.Run(dialogue, textLabel);
            
            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasChoices) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            
        }

        if(dialogueObject.HasChoices){
            choiceManager.ShowChoices(dialogueObject.Choices);
        }else{
            closeDialogue();
        }

        
    }

    public void closeDialogue(){
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
    
}
