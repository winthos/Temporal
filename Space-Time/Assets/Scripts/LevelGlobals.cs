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
  
  [SerializeField]
  public bool Debugging = true;
  
  

	// Use this for initialization
	void Start () 
  {
    distanceTraveled = 0;
    TimeZone.SetTimeScale(1f);
    Camera = GameObject.FindWithTag("MainCamera");
    Player = GameObject.FindWithTag("Player");
    CentrePoint = GameObject.FindWithTag("Centrepoint");
    Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () 
  {
    distanceTraveled += CentrePoint.GetComponent<CentrePointMovement>().GetTrueSpeed();
    if (Input.GetKeyDown("k"))
      Debugging = !Debugging;
    if (Input.GetKey("escape"))
            Application.Quit();
        
	}
  
  public static void calcHighScores()
  {
    if (distanceTraveled > highestDistance)
      highestDistance = distanceTraveled;
  }
}
