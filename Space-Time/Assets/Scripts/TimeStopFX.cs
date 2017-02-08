////////////////////////////////////////////////////////////////////////////////
//	Authors: Winson Han
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class TimeStopFX : MonoBehaviour 
{

  //CameraController CameraScript;
  bool timeStopped;
  bool timeFXplayed = true;

  private bool SeriouslyDontDoThisTheFirstTime = false;

  uint timeStopID;
  uint timeResumeID;

  // Use this for initialization
  void Start ()
  {
    //CameraScript = GameObject.Find("Main Camera").GetComponent<CameraController>();
    timeStopped = CameraController.GetPTime();
  }
	
	// Update is called once per frame
	void Update ()
  {
    timeStopped = CameraController.GetPTime();
    
    //this flawless code right here makes ths time resume sound not play the first time
    if(!timeStopped && timeFXplayed == false)
  {
      SeriouslyDontDoThisTheFirstTime = true;
    }
    
    //normal time
    if (!timeStopped && timeFXplayed == false && SeriouslyDontDoThisTheFirstTime == true)
    {
      SoundHub.PlayTimeResumeSFX(gameObject);
      timeFXplayed = true;
    }


    //stopped time
    if (timeStopped && timeFXplayed)
    {
      SoundHub.PlayTimeStopSFX(gameObject);
      timeFXplayed = false;
    }
    
	}
}
