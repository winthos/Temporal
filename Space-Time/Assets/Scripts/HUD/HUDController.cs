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
  
  public static HUDController HUDControl;

  [SerializeField]
  GameObject TimeBarPlayer;
  
  [SerializeField]
  GameObject[] TimeBar2;
  
  [SerializeField]
  GameObject[] HealthBarPlayer;
  
  [SerializeField]
  GameObject SpeedStacksPlayer;
  
  [SerializeField]
  GameObject RiftCount;
  
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
  GameObject OptionsScreen;
  
  [SerializeField]
  GameObject CreditsScreen;
  
  [SerializeField]
  GameObject LoseScreen;
  
  
  [SerializeField]
  GameObject DebugText;
  
  [SerializeField]
  GameObject DistTraveled;
  
  //[SerializeField]
  //GameObject Score;
  
  [SerializeField]
  GameObject TimePassed;
  
  [SerializeField]
  AudioSource[] MenuSounds;
  
  
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
    HUDControl = GetComponent<HUDController>();
    independentTime = Time.time;
    PauseController.Paused = false;
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (Input.GetKeyDown("p") || Input.GetKeyDown("escape"))
    {
      PauseController.Paused = !PauseController.Paused;
      if (!PauseController.Paused)
	  {
		DefaultPauseOn();
	  }
    }
    if (Player.GetComponent<Health>().health <= 0 && PauseController.Paused)
    {
      Cursor.lockState = CursorLockMode.None;
      LoseScreen.SetActive(true);
      return;
    }
    else if (PauseController.Paused)
    {
      //print("Currently paused");
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
    RiftUpdate();
    TimeAlter();
    OtherUpdate();
    
	}
  
  public void HealthBarUpdate()
  {
    //HealthBarPlayer.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 
                                    //Player.GetComponent<Health>().health * 100.0f);

    
    for (int i = 0; i < 5; i++)
    {
      HealthBarPlayer[i].transform.GetChild(0).gameObject.SetActive( Player.GetComponent<Health>().health > i);
      
      //i = 0, hp = 1, > 0
      
      //i = 4, hp = 5 > 4
    }

  }
  
  public void TimeBarUpdate()
  {
    
    TimeBarPlayer.GetComponent<Image>().fillAmount = Timer.GetComponent<CameraController>().GetTimeRatio();
    
    for (int i = 0; i < 5; i++)
    {
      TimeBar2[i].transform.GetChild(0).gameObject.SetActive( Timer.GetComponent<CameraController>().GetTimeRatio() > i * 0.2f );

    }
  }
  
  public void SpeedUpdate()
  {
    //SpeedStacksPlayer.GetComponent<Text>().text = Player.GetComponent<PlayerMovement>().SpeedStacks.ToString();
  }
  
  public void RiftUpdate()
  {
    RiftCount.GetComponent<Text>().text = "x" + PlayerMovement.pMove.SpeedStacks;
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
    
    //DistTraveled.GetComponent<Text>().text = "Distance: " + (int)LevelGlobals.distanceTraveled + " km";
    //DistTraveled.transform.GetChild(0).GetComponent<Text>().text = "Distance: " + (int)LevelGlobals.distanceTraveled + " km";
    
    //TimePassed.GetComponent<Text>().text = "Time: " + Mathf.Floor(LevelGlobals.runningTime / 60).ToString("00") + ":"
                                                    //+ Mathf.Floor(LevelGlobals.runningTime % 60).ToString("00");
    //TimePassed.transform.GetChild(0).GetComponent<Text>().text = "Time: " + Mathf.Floor(LevelGlobals.runningTime / 60).ToString("00") + ":"
                                                    //+ Mathf.Floor(LevelGlobals.runningTime % 60).ToString("00");
                                                    
                                                    
    //TimePassed.GetComponent<Text>().text = Mathf.Floor(LevelGlobals.runningTime / 60).ToString("00") + ":" + Mathf.Floor(LevelGlobals.runningTime % 60).ToString("00"); 
    
    //TimePassed.GetComponent<Text>().text = "" + (int)(LevelGlobals.distanceTraveled * LevelGlobals.runningTime);
    
 
    
    //Score.GetComponent<Text>().text = 
  }
  
  public void HowToPlayOn()
  {
    HTPScreen.SetActive(true);
    DefaultPauseScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    OptionsScreen.SetActive(false);
    CreditsScreen.SetActive(false);
    MenuSounds[1].Play();
  }
  
  public void Resume()
  {
    //DefaultPauseScreen.SetActive(true);
    HTPScreen.SetActive(false);
    PauseController.SetPause(false);
    DestructiveActionScreen.SetActive(false);
    print("BUTTON CLICKED");
    OptionsScreen.SetActive(false);
    CreditsScreen.SetActive(false);
    MenuSounds[1].Play();
  }
  
  public void DefaultPauseOn()
  {
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(true);
    DestructiveActionScreen.SetActive(false);
    OptionsScreen.SetActive(false);
    CreditsScreen.SetActive(false);
    MenuSounds[1].Play();
  }
  
  public void DestructiveActionOn()
  {
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(false);
    DestructiveActionScreen.SetActive(true);
    OptionsScreen.SetActive(false);
    CreditsScreen.SetActive(false);
    MenuSounds[1].Play();
  }
  
  public void Retry()
  {
    PauseController.SetPause(false);
    PauseBlock.SetActive(false);
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(false);
    LoseScreen.SetActive(false);
    OptionsScreen.SetActive(false);
    CreditsScreen.SetActive(false);
    LevelGlobals.calcHighScores();
    EnemySpawner.ResetOccupancies();
    MenuSounds[1].Play();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //do other retry things
  }
  
  public void OptionsOn()
  {
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    OptionsScreen.SetActive(true);
    CreditsScreen.SetActive(false);
    MenuSounds[1].Play();
  }
  
  public void CreditsOn()
  {
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    OptionsScreen.SetActive(false);
    CreditsScreen.SetActive(true);
    MenuSounds[1].Play();
  }
  
  public void ReturnToTitle()
  {
    //Application.LoadLevel("Title");
  }
  
  public void MouseHover()
  {
    MenuSounds[0].Play();
  }
  
  public void Quit()
  {
    Application.Quit();
  }
  
}
