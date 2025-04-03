using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadSceneAsync("Restaurant");
    }

    public void Customization(){
        SceneManager.LoadSceneAsync("CharacterCustomization");
    }

    public void ReturnToMenu(){
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
