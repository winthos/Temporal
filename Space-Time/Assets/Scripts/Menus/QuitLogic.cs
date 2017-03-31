////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;

public class QuitLogic : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas confirmationCanvas;
    //public bool confirmQuitOn = true;
    bool showConfirm;

    [SerializeField]
    KeyCode quit = KeyCode.Escape;

    void Awake()
    {
        HideConfirm();
    }

    public void HideConfirm()
    {
        // disable main menu
        mainMenuCanvas.enabled = true;
        // enable confirm screen
        confirmationCanvas.enabled = false;

        showConfirm = false;
    }

    public void ShowConfirmQuit()
    {
        // disable main menu
        mainMenuCanvas.enabled = false;
        // enable confirm screen
        confirmationCanvas.enabled = true;

        showConfirm = true;
    }
    
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    /*
    public void QuitWithConfirmation()
    {
        if (confirmQuitOn && confirmationCanvas != null)
            ToggleConfirmation();
        else
            QuitGame();
    }
    */



    // quit key
    void Update()
    {
        if (Input.GetKeyUp(quit))
            ToggleConfirmation();
    }

    public void ToggleConfirmation()
    {
        showConfirm = !showConfirm;

        if (showConfirm)
            ShowConfirmQuit();
        else
            HideConfirm();
    }
}