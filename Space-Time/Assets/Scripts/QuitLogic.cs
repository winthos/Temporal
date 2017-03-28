using UnityEngine;

public class QuitLogic : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas confirmationCanvas;
    public bool confirmQuitOn = true;

    [SerializeField]
    KeyCode quit = KeyCode.Escape;

    void Awake()
    {
        HideConfirm();
    }

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
        /*
        CanvasGroup mainGroup = mainMenuCanvas.GetComponent<CanvasGroup>();
        mainGroup.alpha = 0.5f;
        mainGroup.interactable = false;
        */

        // disable main menu
        mainMenuCanvas.enabled = false;
        // enable confirm screen
        confirmationCanvas.enabled = true;
    }

    void HideConfirm()
    {
        // disable main menu
        mainMenuCanvas.enabled = true;
        // enable confirm screen
        confirmationCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}