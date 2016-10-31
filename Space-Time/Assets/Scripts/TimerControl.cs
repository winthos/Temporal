using UnityEngine;
using System.Collections;

public class TimerControl : MonoBehaviour 
{
  
  [SerializeField]
  float AttackInterval = 5.0f;
  
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
  
  float AttackTimer = 0.0f;

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
    
    if (AttackTimer < AttackInterval)
    {
      AttackTimer += TimeZone.DeltaTime(false);
      if (AttackTimer >= AttackInterval)
      {
        Fire();
        AttackTimer = 0.0f;
      }
    }
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
  
  void Fire()
  {
    GameObject laser = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
    LaserController lcontrol = laser.GetComponent<LaserController>();
    if (lcontrol != null)
    {
      lcontrol.SetMoveDir(Vector3.Normalize(Player.transform.position - transform.position));
    }
  }
}
