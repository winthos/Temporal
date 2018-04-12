////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//  Edits: Kaila Harris, 2018
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
    private static bool paused = false;

    // Use this for initialization
    void Start()
    {
        PauseVolume();
    }
    
    public static bool Paused()
    {
        //PauseVolume();
        return paused;
    }

    public static void TogglePause()
    {
        if (LevelGlobals.PlayerDown)
            return;

        paused = !paused;
        PauseVolume();
    }

    public static void SetPause(bool pause)
    {
        if (LevelGlobals.PlayerDown)
            return;

        paused = pause;
        PauseVolume();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        paused = !hasFocus;
        PauseVolume();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        paused = pauseStatus;
    }

    private static void PauseVolume()
    {
        if (paused)
            SoundHub.GetInstance().EnterPauseState(0.25f);
        else
            SoundHub.GetInstance().ExitPauseState();
    }
}