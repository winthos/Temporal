using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
  
  public void HowToPlayOn()
  {
    HTPScreen.SetActive(true);
    DefaultPauseScreen.SetActive(false);
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
  }
  
  public void Retry()
  {
    PauseController.SetPause(false);
    PauseBlock.SetActive(false);
    HTPScreen.SetActive(false);
    DefaultPauseScreen.SetActive(false);
    LoseScreen.SetActive(false);
    LevelGlobals.calcHighScores();
    
    Application.LoadLevel(Application.loadedLevel);
    //do other retry things
  }
  
  public void ReturnToTitle()
  {
    //Application.LoadLevel("Title");
  }
}
