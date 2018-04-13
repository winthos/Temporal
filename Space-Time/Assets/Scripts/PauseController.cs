using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PauseController : MonoBehaviour
{
    private static bool paused;
    public static bool GamePaused { get { return paused; } }

    
    private static CanvasGroup group;


    void Start()
    {
        group = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<CanvasGroup>();
        HidePauseScreen();
        PauseController.SetPause(false);
    }

    public static void SetPause(bool _paused)
    {
        paused = _paused;
        if (GamePaused)
            PauseTimeScale();
        else
            ResumeTimeScale();
    }

    public static void TogglePause()
    {
        paused = !paused;
        if (GamePaused)
            PauseTimeScale();
        else
            ResumeTimeScale();

        //if (group != null)
        //{
        //    if (GamePaused)
        //        ShowPauseScreen();
        //    else
        //        HidePauseScreen();
        //}

        //Debug.Log("Game Paused: " + GamePaused);
    }

    public static void PauseTimeScale()
    {
        Time.timeScale = 0;
    }
    public static void ResumeTimeScale()
    {
        Time.timeScale = 1;
    }

    // pause game
    public static void ShowPauseScreen()
    {
        paused = true;
        
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
        
        //AudioListener.volume = 0;
        Time.timeScale = 0;

        paused = true;
    }

    // resume game
    public static void HidePauseScreen()
    {
        paused = false;

        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;

        //AudioListener.volume = 1;
        Time.timeScale = 1;

        paused = false;
    }
}
