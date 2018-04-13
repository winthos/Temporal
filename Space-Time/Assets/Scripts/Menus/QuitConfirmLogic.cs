////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2018 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuitConfirmLogic : MonoBehaviour
{
    public Canvas confirmationCanvas;
    bool showConfirm;

    void Start()
    {
        HideConfirm();
    }

    public void HideConfirm()
    {
        // enable confirm screen
        confirmationCanvas.enabled = false;
        showConfirm = false;
    }

    public void ShowConfirmQuit()
    {
        // enable confirm screen
        confirmationCanvas.enabled = true;
        showConfirm = true;
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
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
