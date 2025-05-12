using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    Scene firstScene;
    string sceneName;
    string secondScene;

    void Start(){
        firstScene = SceneManager.GetActiveScene();
        sceneName = firstScene.name;
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(5f);
        secondScene = sceneName + "_1";
        SceneManager.LoadScene(secondScene);
    }

}
