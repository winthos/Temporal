////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour 
{

  private static bool paused = false;
  
	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
      
	}
  
  public static bool Paused()
  {
    //PauseVolume();
    return paused;
  }

  public static void TogglePause()
  {
    paused = !paused;
    PauseVolume();
  }
  
  public static void SetPause(bool pause)
  {
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
        SoundHub.GetInstance().EnterPauseState();
    else
        SoundHub.GetInstance().ExitPauseState();
  }
}