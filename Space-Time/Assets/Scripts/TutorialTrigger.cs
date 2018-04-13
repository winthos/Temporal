using UnityEngine;
using System.Collections;

public enum TriggerType
{
  Time,
  Collision,
  Destroy,
  
}

public class TutorialTrigger : MonoBehaviour 
{
  [SerializeField]
  TriggerType TriggerCondition;
  
  [SerializeField]
  float[] ActivationTime;
  
  
  
  float ActivationTimer;

	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (TriggerCondition == TriggerType.Time && !Tutorial.TutorialOccuring && !PauseController.GamePaused &&!LevelGlobals.PlayerDown)
    {
      ActivationTimer += TimeZone.DeltaTime(false);
      if (Tutorial.tutorial.GetTutorialIndex() - 1 < ActivationTime.Length && ActivationTimer >= ActivationTime[Tutorial.tutorial.GetTutorialIndex() - 1])
      {
        ActivationTimer = 0;
        Tutorial.tutorial.OpenTutorial();
      }
    }
	}
  
  void OnTriggerEnter(Collider other)
  {
    if (TriggerCondition == TriggerType.Collision)
    {
      Tutorial.tutorial.OpenTutorial();
    }
  }
  
  
}