using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour
{
    //part of the body to be customized
    public SpriteRenderer bodyPart;
    //list of sprites. There is also an array commented out if needed to swap. This stores all of the 
    //items used to custimize character. The items are added to the list(or array) by first dragging
    //the script onto an object. After that in the button script section on the right, Drag the part you want to customize onto the bodypart
    //section, then drag the multiple types of that item to the options list section.
    public List<Sprite> options = new List<Sprite>();
    //public Sprite[] options;
    private int current = 0;
    //code for array
    /*
    public void update{
        for(i = 0; i < options.length; i++){
            if(i = current){
                bodypart.sprite = options[i];
            }
        
        }
    
    }
    public void next(){
        if(current < options.length - 1){
            current = current + 1;
        }else{
            current = 0;
        }
    }

    public void back(){
        if(current > 0){
            current = current - 1;
        }
    
    }
    
    */
    //code for list
    //moves forward through the list. For this button, add the script to the onclick section for the button, then in the
    //on click section, select the next function through the tab next to runtime only
    public void next(){
        current = current + 1;
        if(current >= options.Count){
            current = 0;
        }
        bodyPart.sprite = options[current];
    }
    //moves backwards. same steps as before, just select the back function
    public void back(){
        current = current - 1;
        if(current <= 0){
            
            current = options.Count - 1;
        }

        bodyPart.sprite = options[current];
    }
   
    
}
