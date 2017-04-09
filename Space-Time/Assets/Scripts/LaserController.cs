////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour 
{
  
  Vector3 MoveDir = new Vector3();
  
  [SerializeField]
  float FireSpeed = 10.0f;

	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
    //fly at the player when time is not stopped
    if (PauseController.Paused())
      return;
    transform.position = Vector3.Lerp(transform.position, transform.position + MoveDir*FireSpeed, 
                                      TimeZone.DeltaTime()*FireSpeed);
	}
  
  public void SetFireSpeed(float spd)
  {
    FireSpeed = spd;
  }
  
  public float GetFireSpeed()
  {
    return FireSpeed;
  }
  
  public void SetMoveDir(Vector3 dir)
  {
    MoveDir = dir;
  }
  
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      Destroy(gameObject);
    }
  }
  
  
}
