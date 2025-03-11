using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
   [SerializeField] private RectTransform choiceBox;
   [SerializeField] private RectTransform choiceTemp;
   [SerializeField] private RectTransform choiceContainer;

   private DialogueText dialogueText;

   private List<GameObject> tempChoiceButton = new List<GameObject>();

   public void Start(){
      dialogueText = GetComponent<DialogueText>();

   }

    public void ShowChoices(Choice[] choices){

        float choiceBoxHeight = 0;

        foreach(Choice choice in choices){
            GameObject choiceButton = Instantiate(choiceTemp.gameObject, choiceContainer);
            choiceButton.gameObject.SetActive(true);
            choiceButton.GetComponent<TMP_Text>().text = choice.ChoiceText;
            choiceButton.GetComponent<Button>().onClick.AddListener(() => OnPickedChoice(choice));
            choiceBoxHeight += choiceTemp.sizeDelta.y;

            tempChoiceButton.Add(choiceButton);
        
        }

        choiceBox.sizeDelta = new Vector2(choiceBox.sizeDelta.x, choiceBoxHeight);
        choiceBox.gameObject.SetActive(true);

    }

    private void OnPickedChoice(Choice choice){
        choiceBox.gameObject.SetActive(false);
        //dialogueText.ShowDialogue(choice.DialogueObject);
    
        foreach(GameObject button in tempChoiceButton){
            Destroy(button);
        }
        tempChoiceButton.Clear();
        
        if(choice.DialogueObject){
            dialogueText.ShowDialogue(choice.DialogueObject);
        }else{
            dialogueText.closeDialogue();
        }
    
    }






}





