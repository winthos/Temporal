using UnityEngine;

public class QuitLogic : MonoBehaviour
{
    public bool confirmQuitOn = true;
    public Canvas confirmationCanvas;

    [SerializeField]
    KeyCode quit = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyUp(quit))
            QuitWithConfirmation();
    }

    public void QuitWithConfirmation()
    {
        if (confirmQuitOn && confirmationCanvas != null)
            ShowConfirmQuit();
        else
            QuitGame();
    }

    void ShowConfirmQuit()
    {
        CanvasGroup mainGroup = gameObject.GetComponent<CanvasGroup>();
        mainGroup.alpha = 0.5f;
        mainGroup.interactable = false;

        // enable confirm screen
        confirmationCanvas.enabled = true;
    }

    void HideConfirm()
    {
        CanvasGroup mainGroup = gameObject.GetComponent<CanvasGroup>();
        mainGroup.alpha = 1f;
        mainGroup.interactable = true;

        // disable confirm screen
        confirmationCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}