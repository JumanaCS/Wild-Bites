using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoneButton : MonoBehaviour
{
    public int currencyToAdd = 1;

    public string sceneToLoad = ""; 

    public void OnDoneButtonClick()
    {
        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.AddCurrency(currencyToAdd);
        }
        else
        {
            Debug.LogWarning("CurrencyManager instance not found!");
        }

        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene name is empty!");
        }
    }
}