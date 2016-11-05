using UnityEngine;
using System.Collections;

public class SpacerControl : MonoBehaviour 
{
  
  [SerializeField]
  float AttackInterval = 5.0f;
  
  [SerializeField]
  Vector3 RelativeToPlayer = new Vector3();
  
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
  GameObject LaserSight;
  
  [SerializeField]
  Material LaserDefaultMaterial;
  [SerializeField]
  Material LaserAimMaterial;
  [SerializeField]
  Material LaserHitMaterial;
  
  int GridPos;
  
  bool LaserChange = false;
  bool Ready = false;
  
  float AttackTimer = 0.0f;

  Vector3 RotateDir = new Vector3(-1,1,0);
	// Use this for initialization
	void Start () 
  {
    LevelGlobals = GameObject.FindWithTag("Globals");
    Player = LevelGlobals.GetComponent<LevelGlobals>().Player;
    CentrePoint = LevelGlobals.GetComponent<LevelGlobals>().CentrePoint;
    //RandomCalcPosition();
    CalcGridPos();
    transform.parent = CentrePoint.transform;
    CalcRelativePosition();
    ReStartMovement();
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (CameraController.GetPTime() /*|| !Ready*/)
    {
      
      return;
    }
    float dist = (Time.time - StartTime);
    float perc = (dist / PercentDone)*15000;
    
    
    //lerp smoothly to designated position
    //print(perc);
    if (perc < 1.0f)
    {
      transform.position = Vector3.Lerp(transform.position, Player.transform.position + AdditionalPos, 
                                                                        TimeZone.DeltaTime() * 15.0f);
      
      
    }
    //maintain position
    else
    {
      transform.position = Vector3.Lerp(transform.position, Player.transform.position + AdditionalPos, 
                                                                        TimeZone.DeltaTime() * 150.0f);
    }
    CalcRelativePosition();
    
    float playDist = Vector3.Distance(transform.position, Player.transform.position + AdditionalPos);
    
    if (AttackTimer < AttackInterval && !CameraController.GetPTime() && !LaserChange && playDist <= DistanceFromPlayer + 1.0f)
    {
      AttackTimer += TimeZone.DeltaTime();
      if (AttackTimer >= AttackInterval)
      {
        Fire();
        AttackTimer = 0.0f;
      }
      else if (AttackTimer / AttackInterval >= 0.75f)
      {
        print("Change colours");
        LaserSight.GetComponent<LineRenderer>().material = LaserAimMaterial;
      }
      else
      {
        LaserSight.GetComponent<LineRenderer>().material = LaserDefaultMaterial;
      }
    }
    if (perc >= 1.0f && playDist > DistanceFromPlayer)
    {
      ReStartMovement();
    }
    Body.transform.Rotate(RotateDir, 40.0f * Time.deltaTime);
	}
  
  void CalcRelativePosition()
  {
    
    AdditionalPos = Player.transform.forward * DistanceFromPlayer * RelativeToPlayer.z;

    if (RelativeToPlayer.x != 0)
    {
      AdditionalPos += Player.transform.right * RelativeToPlayer.x * DistanceFromPlayer;
    }
    if (RelativeToPlayer.y != 0)
    {
      AdditionalPos += Player.transform.up * RelativeToPlayer.y * DistanceFromPlayer;
    }
    
    
  }
  
  void ReStartMovement()
  {
    StartTime = Time.time;
    PercentDone = Vector3.Distance(transform.position, Player.transform.position + AdditionalPos);
  }
  
  void Fire()
  {
    StartCoroutine(LaserFlash());
    GameObject en = (GameObject)Instantiate(Projectile, Player.transform.position, Quaternion.identity);
    en.transform.parent = Player.transform;
    Player.GetComponent<Health>().DecrementHealth();
    
  }
  
  IEnumerator LaserFlash()
  {
    LaserChange = true;
    LaserSight.GetComponent<LineRenderer>().material = LaserHitMaterial;
    yield return new WaitForSeconds(0.125f);
    LaserSight.GetComponent<LineRenderer>().material = LaserDefaultMaterial; 
    LaserChange = false;
  }
  
  void CalcGridPos()
  {
    if (RelativeToPlayer.x == -1) //L
    {
      if (RelativeToPlayer.y == -1) //D
      {
        GridPos = 7;
      }
      else if (RelativeToPlayer.y == 0) 
      {
        GridPos = 4;
      }
      else if (RelativeToPlayer.y == 1) //U
      {
        GridPos = 1;
      }
    }
    else if (RelativeToPlayer.x == 0)
    {
      if (RelativeToPlayer.y == -1) //D
      {
        
        GridPos = 8;
      }
      else if (RelativeToPlayer.y == 1) //U
      {
        GridPos = 2;
      }
    }
    else if (RelativeToPlayer.x == 1) //R
    {
      if (RelativeToPlayer.y == -1) //D
      {
        GridPos = 9;
      }
      else if (RelativeToPlayer.y == 0)
      {
        GridPos = 6;
      }
      else if (RelativeToPlayer.y == 1) //U
      {
        GridPos = 3;
      }
    }
    
  }
  
  public int GetGridPos()
  {
    return GridPos;
  }
  
  bool RandomCalcPosition()
  {
    
    
    
    if (RelativeToPlayer.x <= 1 && RelativeToPlayer.y <= 1)
    {
      CalcGridPos();
      // if no conflicts and pre-determined space, set occupancy to true
      if (!EnemySpawner.CheckOccupancy(GridPos)) 
      {
        EnemySpawner.SetOccupancy(GridPos, true);
        Ready = true;
        transform.parent = null;
        return true;
      }
    }
    

      // until we find space, continue calculations
    while (!Ready)
    {
      int xPos = 0, yPos = 0;
      
      float seed = Random.Range(0, 100);
      
      
      if (seed > 66.0f)
        xPos = 1;
      else if (seed > 33.0f)
        xPos = 0;
      else
        xPos = -1;
      RelativeToPlayer.x = xPos;
      
      
      
      seed = Random.Range(0, 100);
      
      
      if (seed > 66.0f)
        yPos = 1;
      else if (seed > 33.0f)
        yPos = 0;
      else
        yPos = -1;
      if (xPos == 0)
        yPos = 1;
      RelativeToPlayer.y = yPos;
      CalcGridPos();
      print(GridPos);
      if (!EnemySpawner.CheckOccupancy(GridPos))
      {
        
        Ready = true;
      }
    }
    
    ReStartMovement();
    transform.parent = null;
    return true;
  }
 

  
}
