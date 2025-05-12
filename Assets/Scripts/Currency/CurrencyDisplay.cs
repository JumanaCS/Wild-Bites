using UnityEngine;
using TMPro; 

public class CurrencyDisplay : MonoBehaviour
{
    public TMP_Text currencyText; 

    void Update()
    {
        if (CurrencyManager.Instance != null && currencyText != null)
        {
            currencyText.text = $"{CurrencyManager.Instance.currentCurrency}";
        }
    }
}