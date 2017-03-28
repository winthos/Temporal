using UnityEngine;

public class QuitLogic : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas confirmationCanvas;
    public bool confirmQuitOn = true;
    bool showConfirm;

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

    public void ToggleConfirmation()
    {
        showConfirm = !showConfirm;

        if (showConfirm)
            ShowConfirmQuit();
        else
            HideConfirm();
    }

    public void QuitWithConfirmation()
    {
        if (confirmQuitOn && confirmationCanvas != null)
            ToggleConfirmation();
        else
            QuitGame();
    }

    public void ShowConfirmQuit()
    {
        // disable main menu
        mainMenuCanvas.enabled = false;
        // enable confirm screen
        confirmationCanvas.enabled = true;

        showConfirm = true;
    }

    public void HideConfirm()
    {
        // disable main menu
        mainMenuCanvas.enabled = true;
        // enable confirm screen
        confirmationCanvas.enabled = false;

        showConfirm = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}