////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour 
{

  public static bool Paused = false;
  
	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
      if (Input.GetKeyDown("p") || Input.GetKeyDown("escape"))
      {
        print(Paused);
        Paused = !Paused;
        
      }
	}
  
  public static void TogglePause()
  {
    Paused = !Paused;
  }
  
  public static void SetPause(bool pause)
  {
    Paused = pause;
  }
}
