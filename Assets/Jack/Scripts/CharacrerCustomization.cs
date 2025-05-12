using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterCustomization : MonoBehaviour
{
    public SpriteRenderer optionsRenderer;
    public List<Sprite> options = new List<Sprite>();


    private int currentOption = 0;

    public void NextOption()
    {
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }

        optionsRenderer.sprite = options[currentOption];
    }

    public void PreviousOption()
    {
        currentOption--;
        if(currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }

        optionsRenderer.sprite = options[currentOption];
    }
}
