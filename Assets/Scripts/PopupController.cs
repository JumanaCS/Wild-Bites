using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour
{
    [Header("Main References")]
    public GameObject popupPanel; // Parent object containing BOTH image and close button
    public Button openButton;      // Button that opens the popup

    [Header("Close Button")]
    public Button closeButton;    // The close button (child of popupPanel)

    void Start()
    {
        // Setup button listeners
        openButton.onClick.AddListener(ShowPopup);
        closeButton.onClick.AddListener(HidePopup);

        // Initialize hidden state
        popupPanel.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    void ShowPopup()
    {
        popupPanel.SetActive(true);
        closeButton.gameObject.SetActive(true);
        popupPanel.transform.SetAsLastSibling(); // Bring to front
    }

    void HidePopup()
    {
        popupPanel.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    // Optional: Close with Escape key
    void Update()
    {
        if (popupPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            HidePopup();
        }
    }
}