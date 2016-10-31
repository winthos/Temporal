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
    if (CameraController.GetPTime() || CameraController.GetETime())
      return;
    //IsTimeStopped = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;
    RaycastHit hit;
    transform.LookAt(Player.transform);
    if(Physics.Raycast(transform.position, transform.forward, out hit))
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
        line.SetPosition(1, new Vector3(0, 0, 5000));
    }
	}
}
