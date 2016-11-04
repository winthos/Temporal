using UnityEngine;
using System.Collections;

public class LevelGlobals : MonoBehaviour 
{
  public GameObject Player;
  public GameObject CentrePoint;
  public GameObject Camera;
  public TimeZone timezone;
  
  [SerializeField]
  public bool Debugging = true;

	// Use this for initialization
	void Start () 
  {
    TimeZone.SetTimeScale(1f);
    Camera = GameObject.FindWithTag("MainCamera");
    Player = GameObject.FindWithTag("Player");
    CentrePoint = GameObject.FindWithTag("Centrepoint");
    Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (Input.GetKeyDown("k"))
      Debugging = !Debugging;
    if (Input.GetKey("escape"))
            Application.Quit();
        
	}
}
