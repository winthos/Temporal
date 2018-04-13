////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class MainMenuSound : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
  {

        SoundHub.GetInstance().ExitPauseState();
    }
	
	// Update is called once per frame
	void Update () 
  {
	
	}
  
  public void PlayButtonHover()
  {
    SoundHub.PlayButtonHover();
  }
  
  public void PlayButtonConfirm()
  {
    SoundHub.PlayButtonClick();
  }
}
