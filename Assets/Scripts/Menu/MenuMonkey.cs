using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMonkey : MonoBehaviour
{
    private int leftSelection = 0;
    private int rightSelection = 0;
    
    public void SelectLeftButton(int buttonNumber)
    {
        leftSelection = buttonNumber;
        CheckSelections();
    }
    
    public void SelectRightButton(int buttonNumber)
    {
        rightSelection = buttonNumber;
        CheckSelections();
    }
    
    private void CheckSelections()
    {
        if (leftSelection != 0 && rightSelection != 0)
        {
            string sceneName = "SceneM" + leftSelection + "_" + rightSelection;
            SceneManager.LoadScene(sceneName);
        }
    }
}
