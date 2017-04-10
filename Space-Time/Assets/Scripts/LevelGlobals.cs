﻿////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class LevelGlobals : MonoBehaviour 
{
  public GameObject Player;
  public GameObject CentrePoint;
  public GameObject Camera;
  public TimeZone timezone;
  
  public static float distanceTraveled;
  public static float highestDistance;
  
  public static float runningTime;
  public static float TimePassed;
  
  [SerializeField]
  public static bool Debugging = false;
  
  [SerializeField]
  GameObject SpeedLines;
  
  

	// Use this for initialization
	void Start () 
  {
    distanceTraveled = 0;
    runningTime = 0;
    TimeZone.SetTimeScale(1f);
    Camera = GameObject.FindWithTag("MainCamera");
    Player = GameObject.FindWithTag("Player");
    CentrePoint = GameObject.FindWithTag("Centrepoint");
    Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () 
  {
    
    if (!PauseController.Paused() && !Tutorial.TutorialOccuring)
    {
      runningTime += TimeZone.DeltaTime(true);
      TimePassed = Time.time;
      
      if (!CameraController.GetPTime())
      {
        distanceTraveled += CentrePoint.GetComponent<CentrePointMovement>().GetTrueSpeed() / 2.0f;
      }
    }
    if (Input.GetKeyDown("k"))
      Debugging = !Debugging;
    //if (Input.GetKey("escape"))
            //Application.Quit();
    if (PauseController.Paused() || CameraController.GetPTime() || Tutorial.TutorialOccuring)
      SpeedLines.SetActive(false);
    else
      SpeedLines.SetActive(true);
        
	}
  
  public static void calcHighScores()
  {
    if (distanceTraveled > highestDistance)
      highestDistance = distanceTraveled;
  }
}