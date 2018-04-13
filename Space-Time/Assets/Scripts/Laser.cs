////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
  private LineRenderer line;
  private bool IsTimeStopped;
  GameObject Player;
    
    
  void Start () 
	{
    line = GetComponent<LineRenderer>();
    Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
    //IsTimeStopped = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;
    if (CameraController.GetPTime() || CameraController.GetETime() || PauseController.GamePaused)
      return;
    RaycastHit hit;
    transform.LookAt(Player.transform);
    if(Physics.Raycast(transform.position, transform.forward, out hit, 200.0f))
    {
        if(hit.collider && hit.collider.gameObject.name == "Player" )
        {
            //print(hit.collider);
            //if(IsTimeStopped == false)
            line.SetPosition(1, new Vector3(0, 0, hit.distance));

            //print("distance is " + hit.distance);
            //print("distance is " + Vector3.Distance(transform.position, hit.point));
        }
    }

    else
    {
        //if(IsTimeStopped == false)
        line.SetPosition(1, new Vector3(0, 0, 200));
    }
	}
}