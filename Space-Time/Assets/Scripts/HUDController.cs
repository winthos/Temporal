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
  
  int dTime = 0;
  float independentTime;
  float startTime = 0.0f;
	// Use this for initialization
	void Start () 
  {
    independentTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
  {
    
    if (PauseController.Paused)
    {
      PauseBlock.SetActive(true);
      return;
    }
    else
      PauseBlock.SetActive(false);
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
}
