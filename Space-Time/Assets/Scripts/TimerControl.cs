////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class TimerControl : MonoBehaviour 
{

  
  [SerializeField]
  Vector2 RelativeToPlayer = new Vector2();
  
  Vector3 AdditionalPos;
  
  [SerializeField]
  float DistanceFromPlayer = 5.0f;
  
  float StartTime;
  float PercentDone;
  
  GameObject LevelGlobals;
  GameObject Player;
  GameObject CentrePoint;
  
  [SerializeField]
  GameObject Projectile;
  
  [SerializeField]
  GameObject Body;
  
  [SerializeField]
  float ETime = 4.0f;
  
  [SerializeField]
  GameObject TimeBar;
  
  [SerializeField]
  int ExplosionSize = 1; //1, 4, 9, are acceptable
  
  [SerializeField]
  GameObject Explosion;
  

  [SerializeField]
  Vector3 RotateDir = new Vector3(-1,1,0);
	// Use this for initialization
	void Start () 
  {
    LevelGlobals = GameObject.FindWithTag("Globals");
    Player = LevelGlobals.GetComponent<LevelGlobals>().Player;
    CentrePoint = LevelGlobals.GetComponent<LevelGlobals>().CentrePoint;
    CalcRelativePosition();
    
    StartTime = Time.time;
    PercentDone = Vector3.Distance(transform.position, CentrePoint.transform.position + AdditionalPos);
    
    CameraController.SetETime(true);
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (PauseController.Paused)
      return;
    if (ETime > 0.0f)
    {
      ETime -= TimeZone.DeltaTime(false);
      if (ETime <= 0.0f)
        StartCoroutine(Explode());
    }
    float dist = (Time.time - StartTime);
    float perc = dist / PercentDone;
    
    
    //lerp smoothly to designated position
    if (perc < 1.0)
    {
      transform.position = Vector3.Lerp(transform.position, CentrePoint.transform.position + AdditionalPos, 
                                                                        perc );
      
      
    }
    //maintain position
    else
    {
      transform.position = Vector3.Lerp(transform.position, CentrePoint.transform.position + AdditionalPos, 
                                                                        TimeZone.DeltaTime(false) * 150.0f);
    }
    //CalcRelativePosition();
 
    Body.transform.Rotate(RotateDir, 40.0f * Time.deltaTime);
	}
  
  
  void CalcRelativePosition()
  {
    AdditionalPos = CentrePoint.transform.forward * DistanceFromPlayer;

    if (RelativeToPlayer.x != 0)
    {
      AdditionalPos += CentrePoint.transform.right * RelativeToPlayer.x;
    }
    if (RelativeToPlayer.y != 0)
    {
      AdditionalPos += CentrePoint.transform.up * RelativeToPlayer.y;
    }
    
    
  }
  

  IEnumerator Explode()
  {
    //change material to signify its about to blow up
    yield return new WaitForSeconds(0.125f);
    /*
      //Creates explosion hitboxes on designated squares based on current position (offset based on explo size)
      GameObject boom;
      if (ExplosionSize >= 1)
      {
        boom = Instantiate(transform.position, "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
      }
      if (ExplosionSize >= 4) //cardinal only
      {
        boom = Instantiate(transform.position + Vector3(5,0,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
        
        boom = Instantiate(transform.position + Vector3(-5,0,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
        
        boom = Instantiate(transform.position + Vector3(0,5,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
        
        boom = Instantiate(transform.position + Vector3(0,-5,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
      }
      if (ExplosionSize >= 9) //cardinal + diagonals
      {
        boom = Instantiate(transform.position + Vector3(5,5,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
        
        boom = Instantiate(transform.position + Vector3(5,-5,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
        
        boom = Instantiate(transform.position + Vector3(-5,5,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
        
        boom = Instantiate(transform.position + Vector3(-5,-5,0), "Explosion", Quaternion.identity);
        boom.transform.parent = CentrePoint.transform;
      }
    */
  }
}
