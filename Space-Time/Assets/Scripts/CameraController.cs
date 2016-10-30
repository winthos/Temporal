﻿using UnityEngine;
using System.Collections;


  //This controls stoptime-related things
public class CameraController : MonoBehaviour 
{
    // For checking if the player has stopped time or not
  private static bool PTimeStop = false;
  
  float PTimeStopTimer = 9.0f;
  
  [SerializeField]
  float PTimeStopTime = 9.0f;
  
    // For checking if any enemies have stopped time or not
  private static bool ETimeStop = false;
  
  public static GameObject[] ETimers;
  
  GameObject LevelGlobals;
  GameObject Player;
  GameObject CentrePoint;
  
  float xSpeed = 120.0f;
  float ySpeed = 120.0f;
  
  Vector3 DefaultCamRotation; // 8.5673,0,0
  //Vector3 DefaultCamOffset; // 0,1.55,-6.62
  
  float defaultTimer;

  
  float x = 0.0f;
  float y = 0.0f;
  float Distance = 15.0f;

  bool TimeRegen = false;
  float lerpTime = 0.0f;
  Vector3 CamSnapBackDistance;
  
  [SerializeField]
  float CamSnapSpeed = 1.5f;
    
    
  int TimeMove = 0;
	// Use this for initialization
	void Start () 
  {
    PTimeStopTimer = PTimeStopTime;
    defaultTimer = Time.time;
    DefaultCamRotation = transform.eulerAngles;
    x = transform.eulerAngles.x;
    y = transform.eulerAngles.y;
    
	  LevelGlobals = GameObject.FindWithTag("Globals");
    Player = LevelGlobals.GetComponent<LevelGlobals>().Player;
    CentrePoint = LevelGlobals.GetComponent<LevelGlobals>().CentrePoint;
    
    Distance = Vector3.Distance(transform.position, CentrePoint.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
  {
    defaultTimer += TimeZone.DeltaTime(false);
    if (TimeMove == -1) //stop time
    {
      TimeZone.SetTimeScale(Mathf.Lerp(Time.timeScale, 0.01f, 0.5f));
      if (Time.timeScale <= 0.05f)
        TimeMove = 0;
    }
    else if (TimeMove == 1) //resume time
    {
      TimeZone.SetTimeScale(Mathf.Lerp(Time.timeScale, 1.0f, 0.5f));
      if (Time.timeScale >= 0.99f)
        TimeMove = 0;
    }
    
    if (Input.GetMouseButtonDown(1)) // if right mouse is clicked
    {
      ToggleTimeStop();
    }
    
    if (!GetPTime() && !GetETime())
    {
      if (Vector3.Distance(Player.transform.position, CentrePoint.transform.position) > 0.01)
        transform.LookAt((Player.transform.position + CentrePoint.transform.position)/2);
      else
        transform.LookAt(CentrePoint.transform.position);
      
      if (IsTimeTransitioning())
        {
          transform.position = Vector3.Lerp(transform.position, CamSnapBackDistance, (defaultTimer - lerpTime) * CamSnapSpeed);
          if (Vector3.Distance(transform.position, CamSnapBackDistance) < 0.01f)
          {
            CamSnapBackDistance = Vector3.zero;
          }
        }
    }
    else if (GetPTime())
    {
        //Get mouse movement to determine the new angle
      x += Input.GetAxis("Mouse X") * xSpeed /*turnspeed*/ * Distance /*camradius*/ * 0.02f;
      y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
      
        //Clamp the y-rotation so we don't have weird circle camera shenanigans 
      y = ClampAngle(y, -85f, 85f); 
      
   
 
      transform.LookAt(CentrePoint.transform.position);

      Quaternion Rotation = Quaternion.Euler(y, x, 0);
      
      Vector3 NegativeDistance = new Vector3(0.0f, 0.0f, -Distance);
      Vector3 Pos = Rotation * NegativeDistance + CentrePoint.transform.position /*+ (CentrePoint.transform.up * 1.15f)*/;
      
      //transform.rotation = Rotation;
      transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, (defaultTimer - lerpTime) *CamSnapSpeed); //1.5f
      
      //transform.position = Pos;
      transform.position = Vector3.Slerp(transform.position, Pos, (defaultTimer - lerpTime) *CamSnapSpeed);
      
      
      CentrePoint.transform.rotation = Rotation;
      //CentrePoint.transform.rotation = Quaternion.Slerp(CentrePoint.transform.rotation, Rotation, TimeZone.DeltaTime(false)/2);
      
     
      /*
      if (Input.GetMouseButton(0) && LevelGlobals.GetComponent<LevelGlobals>().Debugging) // if left mouse is held
      {
         CentrePoint.transform.rotation = Rotation;
         float speed = CentrePoint.GetComponent<CentrePointMovement>().GetMovementSpeed();
         transform.position += transform.forward * speed;
         CentrePoint.transform.position += transform.forward * speed;
      }
      */
      if (PTimeStopTimer > 0.0f )
      {
        if (!LevelGlobals.GetComponent<LevelGlobals>().Debugging)
          PTimeStopTimer -= TimeZone.DeltaTime(false);
        if (PTimeStopTimer <= 0.0f && PTimeStop)
        {
          ToggleTimeStop();
          //TimeRegen = true;
        }
      }
      //CentrePoint.transform.LookAt(CentrePoint.transform.position + transform.forward); 
      
      
     
      
    }
    if (PTimeStopTimer < 9.0f  && !GetPTime())
      {
        PTimeStopTimer += TimeZone.DeltaTime(false) / 3.0f;
        if (PTimeStopTimer > 9.0f)
        {
          PTimeStopTime = 9.0f;
          //TimeRegen = false;
        }
      }
    //Right click to enter/exit stopped time
    
    //if in normal time, do this,
    
    
    //if in stopped time do that
    
	}
  
  public static bool GetPTime()
  {
    return PTimeStop;
  }
  
  public static bool GetETime()
  {
    return ETimeStop;
  }
  
  public static void SetPTime(bool time)
  {
    PTimeSTop = time;
  }
  
  public static void SetETime(bool time)
  {
    ETimeSTop = time;
  }
  
  public void ToggleTimeStop()
  {
    GameObject hudctrl = GameObject.FindWithTag("HUD");
    lerpTime = defaultTimer;
    if (!PTimeStop)
    {
        // if not in time stop, filter on
      hudctrl.GetComponent<HUDController>().TimeSet(1);
      //TimeZone.SetTimeScale(0.25f);
      TimeMove = -1;
      CentrePoint.transform.position = Player.transform.position;
      Player.transform.position = CentrePoint.transform.position;
      Player.GetComponent<PlayerMovement>().CentreGridPos();
      
    }
      
    
    Player.GetComponent<PlayerMovement>().ResetDashDestination();
     
    if (PTimeStop)
    {
      hudctrl.GetComponent<HUDController>().TimeSet(-1);
      TimeMove = 1;
      //TimeZone.SetTimeScale(1.0f);
      CentrePoint.transform.LookAt(CentrePoint.transform.position + transform.forward); 
      
      //transform.position += transform.up * 0.55f;
      //CamSnapBackDistance = transform.position + transform.up * 0.55f;
       CamSnapBackDistance = transform.position + transform.up * 1.16f;
    }
    else if (PTimeStopTimer <= 0.0)
    {
      hudctrl.GetComponent<HUDController>().TimeSet(-1);
      TimeZone.SetTimeScale(1.0f);
      PTimeStop = false;
      
      return;
    }
    
   
  

    //InvertAllMaterialColors();
    PTimeStop = !PTimeStop;
  }
  
  
  public static float ClampAngle(float angle, float min, float max)
  {
    if (angle < -360F)
      angle += 360F;
    if (angle > 360F)
      angle -= 360F;
    return Mathf.Clamp(angle, min, max);
  }
  
  public float GetTimeRatio()
  {
    return PTimeStopTimer / PTimeStopTime;
  }
  
  public void InvertAllMaterialColors() 
  {
    Renderer[] renderers = FindObjectsOfType(typeof(Renderer)) as Renderer[];
    foreach (Renderer render in renderers) 
    {
      if (render.material.HasProperty("_Color"))
      {
             render.material.color = InvertColour (render.material.color);
      }
    }
  }
  
  Color InvertColour(Color colour)
  {
    return new Color (1.0f- colour.r, 1.0f - colour.g, 1.0f - colour.b);
  }
  
  public float GetPTimeStopTimer()
  {
    return PTimeStopTimer;
  }
  
  public void IncreasePStopTime(float amt)
  {
    PTimeStopTimer += amt;
    if (amt > PTimeStopTime)
      amt = PTimeStopTime;
    
  }
  
  public bool IsTimeTransitioning()
  {
    return transform.position != CamSnapBackDistance && CamSnapBackDistance != Vector3.zero;
  }
}
