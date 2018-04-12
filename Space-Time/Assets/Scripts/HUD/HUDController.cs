////////////////////////////////////////////////////////////////////////////////
//  Authors: Jordan Yong
//  Edits: Kaila Harris
//  Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
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
  GameObject PauseScreen;
  
  //[SerializeField]
  //GameObject DefaultPauseScreen;
  
  [SerializeField]
  GameObject DestructiveActionScreen;
  
  [SerializeField]
  GameObject RestartActionScreen;
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
  GameObject RetryScreen;
  
  //[SerializeField]
  //GameObject OptionsScreen;
  
  //[SerializeField]
  //GameObject CreditsScreen;
  
  [SerializeField]
  GameObject DebugText;
  
  //[SerializeField]
  //GameObject DistTraveled;
  
  //[SerializeField]
  //GameObject Score;
  
  //[SerializeField]
  //GameObject TimePassed;
  
  [SerializeField]
  AudioSource[] MenuSounds;
  
  [SerializeField]
  Image RiftImage;
  
  [SerializeField]
  Color RiftImageColour;
  
  [SerializeField]
  ParticleSystem RiftGetParticle;
  
  
  
  /*
  [SerializeField]
  GameObject RetryButton;
  */
  
  int dTime = 0;
  float independentTime;
  float startTime = 0.0f;
  
  
  void Start () 
  {
    HUDControl = this;
    independentTime = Time.time;
    PauseController.SetPause(false);
    RiftImageColour = RiftImage.color;
        
    DisableCanvas(PauseScreen);
    DisableCanvas(HTPScreen);
    DisableCanvas(RetryScreen);
    DisableCanvas(DestructiveActionScreen);
    DisableCanvas(RestartActionScreen);
        
    }
  
  // Update is called once per frame
  void Update () 
  {
    if (Input.GetKeyDown("p") || Input.GetKeyDown("escape"))
    {
      PauseController.TogglePause();
      if (!PauseController.Paused())
    {
    DefaultPauseOn();
    }
    }
    if (Player.GetComponent<Health>().health <= 0 && LevelGlobals.PlayerDown)
    {
      //Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      RetryScreen.SetActive(true);
      return;
    }
    else if (PauseController.Paused())
    {
      //print("Currently paused");
      PauseScreen.SetActive(true);
      //Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      return;
    }
    else
    {
      //DefaultPauseScreen.SetActive(true);
      PauseScreen.SetActive(false);
      //sCursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    independentTime += TimeZone.DeltaTime(false);
    HealthBarUpdate();
    if(TimeBarPlayer != null) TimeBarUpdate();
    SpeedUpdate();
    TimeAlter();
    OtherUpdate();
    RiftUpdate();
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
    //RiftCount.GetComponent<Text>().text = "x" + PlayerMovement.pMove.SpeedStacks;
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
  
  public IEnumerator PlayerDestroyed()
  {
    while (TimeZone.GetTimeScale() > 0.0500f )
    {
      Player.GetComponent<MeshRenderer>().material.Lerp(Player.GetComponent<PlayerMovement>().defaultMaterial, 
                                                          Player.GetComponent<PlayerMovement>().KOMaterial, TimeZone.DeltaTime(false)* 35.0f);
      TimeZone.SetTimeScale(Mathf.Lerp(TimeZone.DeltaTime(), 0.00001f, TimeZone.DeltaTime(false)* 0.125f));
      print(TimeZone.GetTimeScale());
      
      
      
      yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.25f));
      
    }
    yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(1f));
    Camera.main.fieldOfView =  Mathf.Lerp(Camera.main.fieldOfView, 179, 0.1f);
    yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(1f));
        LevelGlobals.PlayerDown = true;
  }
  
  public IEnumerator RiftGet()
  {
    RiftGetParticle.Play();
    while (RiftImage.color.a < 0.998)
    {
      RiftImage.color = Color.Lerp(RiftImage.color, RiftImageColour, 15.0f * Time.deltaTime);
      yield return new WaitForSeconds(0.0125f);
    }
    
    while (RiftImage.color.a > 0.001)
    {
      RiftImage.color = Color.Lerp(RiftImage.color, new Color(), 15.0f * Time.deltaTime);
      yield return new WaitForSeconds(0.0125f);
    }
    
    
    
    yield return new WaitForSeconds(1.0f);
  }
  
  public void HowToPlayOn()
  {
    PauseScreen.SetActive(false);
    HTPScreen.SetActive(true);
    RetryScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    RestartActionScreen.SetActive(false);

    MenuSounds[1].Play();
  }
  
  public void Resume()
  {
    PauseScreen.SetActive(false);
    HTPScreen.SetActive(false);
    RetryScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    RestartActionScreen.SetActive(false);
    MenuSounds[1].Play();
        
    PauseController.SetPause(false);
  }
  
  public void DefaultPauseOn()
  {
    PauseScreen.SetActive(true);
    HTPScreen.SetActive(false);
    RetryScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    RestartActionScreen.SetActive(false);
    MenuSounds[1].Play();
  }
  
  public void DestructiveActionOn()
  {
    PauseScreen.SetActive(false);
    HTPScreen.SetActive(false);
    RetryScreen.SetActive(false);
    DestructiveActionScreen.SetActive(true);
    RestartActionScreen.SetActive(false);
    MenuSounds[1].Play();
  }
  
  public void RestartActionOn()
  {
    PauseScreen.SetActive(false);
    HTPScreen.SetActive(false);
    RetryScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    RestartActionScreen.SetActive(true);

    MenuSounds[1].Play();
  }
  
  public void Retry()
  {
    PauseScreen.SetActive(false);
    HTPScreen.SetActive(false);
    RetryScreen.SetActive(false);
    DestructiveActionScreen.SetActive(false);
    RestartActionScreen.SetActive(false);

    PauseController.SetPause(false);

    LevelGlobals.calcHighScores();
    EnemySpawner.ResetOccupancies();
    MenuSounds[1].Play();
    LevelGlobals.PlayerDown = false;
    print(LevelGlobals.PlayerDown);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
    //do other retry things
  }
  
  public void ReturnToTitle()
  {
    SceneManager.LoadScene("2_MainMenu");
  }
  
  public void MouseHover()
  {
    MenuSounds[0].Play();
  }
  
  public void DisableCanvas(GameObject _canvas)
  { 
    DisableCanvas(_canvas.GetComponent<CanvasGroup>());
  }
  public void DisableCanvas(CanvasGroup _canvas)
  { 
    _canvas.alpha = 0;
    _canvas.blocksRaycasts = false;
    _canvas.interactable = false;
  }
  public void EnableCanvas(GameObject _canvas)
  { 
    EnableCanvas(_canvas.GetComponent<CanvasGroup>());
  }
  public void EnableCanvas(CanvasGroup _canvas)
  { 
    _canvas.alpha = 1;
    _canvas.blocksRaycasts = true;
    _canvas.interactable = true;
  }
    
  public void Quit()
  {
    Application.Quit();
  }
  
}
