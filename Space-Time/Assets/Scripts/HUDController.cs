////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HUDController : MonoBehaviour 
{

  [SerializeField]
  GameObject TimeBarPlayer;
  [SerializeField]
  GameObject HealthBarPlayer;
  [SerializeField]
  GameObject SpeedStacksPlayer;
  
  [SerializeField]
  GameObject Player;
  
  [SerializeField]
  GameObject Timer;
  
  [SerializeField]
  GameObject TimeStopFilter;
  
  [SerializeField]
  GameObject PauseBlock;
  
  [SerializeField]
  GameObject DefaultPauseScreen;
  
  [SerializeField]
  GameObject DestructiveActionScreen;
  /*
  [SerializeField]
  GameObject HTPButton;
  
  [SerializeField]
  GameObject ResumeButton;
  
  [SerializeField]
  GameObject TitleButton;
  */
  
  [SerializeField]
  GameObject HTPScreen;
  
  [SerializeField]
  GameObject LoseScreen;
  
  [SerializeField]
  GameObject DebugText;
  
  [SerializeField]
  GameObject DistTraveled;
  
  [SerializeField]
  GameObject TimePassed;
  
  
  /*
  [SerializeField]
  GameObject RetryButton;
  */
  
  int dTime = 0;
  float independentTime;
  float startTime = 0.0f;
  
	// Use this for initialization
  
  
	void Start () 
  {
    independentTime = Time.time;
    PauseController.Paused = false;
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (Player.GetComponent<Health>().health <= 0 && PauseController.Paused)
    {
      Cursor.lockState = CursorLockMode.None;
      LoseScreen.SetActive(true);
      return;
    }
    else if (PauseController.Paused)
    {
      print("Currently paused");
      PauseBlock.SetActive(true);
      Cursor.lockState = CursorLockMode.None;
      return;
    }
    else
    {
      DefaultPauseScreen.SetActive(true);
      PauseBlock.SetActive(false);
      Cursor.lockState = CursorLockMode.Locked;
    }
    independentTime += TimeZone.DeltaTime(false);
    HealthBarUpdate();
    TimeBarUpdate();
    SpeedUpdate();
    TimeAlter();
    OtherUpdate();
    
	}
  
  public void HealthBarUpdate()
  {
    HealthBarPlayer.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 
                                    Player.GetComponent<Health>().health * 100.0f);
  }
  
  public void TimeBarUpdate()
  {
    
    TimeBarPlayer.GetComponent<Image>().fillAmount = Timer.GetComponent<CameraController>().GetTimeRatio();
  }
  
  public void SpeedUpdate()
  {
    SpeedStacksPlayer.GetComponent<Text>().text = Player.GetComponent<PlayerMovement>().SpeedStacks.ToString();
  }
  
  public void TimeAlter()
  {
    
    if (dTime == 0)
      return;
    else if (dTime > 0)
    {
      TimeStopFilter.transform.localScale = Vector3.Lerp(TimeStopFilter.transform.localScale, new Vector3(25,25,25), independentTime - startTime);
      if (TimeStopFilter.transform.localScale.x == 25)
        dTime = 0;
    }
    else if (dTime < 0)
    {
      TimeStopFilter.transform.localScale = Vector3.Lerp(TimeStopFilter.transform.localScale, new Vector3(0,0,0), independentTime - startTime);
      if (TimeStopFilter.transform.localScale.x == 0)
        dTime = 0;
    }
    
    
  }
  
  public void TimeSet(int t)
  {
    dTime = t;
    startTime = independentTime;
  }
  
  public void OtherUpdate()
  {
    if (LevelGlobals.Debugging)
      DebugText.SetActive(true);
    else
      DebugText.SetActive(false);
    
    DistTraveled.GetComponent<Text>().text = "Distance: " + (int)LevelGlobals.distanceTraveled + " km";
    DistTraveled.transform.GetChild(0).GetComponent<Text>().text = "Distance: " + (int)LevelGlobals.distanceTraveled + " km";
    TimePassed.GetComponent<Text>().text = "Time: " + Mathf.Floor(LevelGlobals.runningTime / 60).ToString("00") + ":"
                                                    + Mathf.Floor(LevelGlobals.runningTime % 60).ToString("00");
    TimePassed.transform.GetChild(0).GetComponent<Text>().text = "Time: " + Mathf.Floor(LevelGlobals.runningTime / 60).ToString("00") + ":"
                                                    + Mathf.Floor(LevelGlobals.runningTime % 60).ToString("00");
  }
  
  public void HowToPlayOn()
  {
    HTPScreen.SetActive(true);
    DefaultPauseScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
  }
  
  public void Resume()
  {
    //DefaultPauseScreen.SetActive(true);
    HTPScreen.SetActive(false);
    PauseController.SetPause(false);
    print("BUTTON CLICKED");
    
  }
  
  public void DefaultPauseOn()
  {
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(true);
    DestructiveActionScreen.SetActive(false);
  }
  
  public void DestructiveActionOn()
  {
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(false);
    DestructiveActionScreen.SetActive(true);
  }
  
  public void Retry()
  {
    PauseController.SetPause(false);
    PauseBlock.SetActive(false);
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(false);
    LoseScreen.SetActive(false);
    LevelGlobals.calcHighScores();

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //do other retry things
  }
  
  public void ReturnToTitle()
  {
    //Application.LoadLevel("Title");
  }
  
  public void Quit()
  {
    Application.Quit();
  }
  
}
