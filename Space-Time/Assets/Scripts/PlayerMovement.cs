////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//  Edits: Kaila Harris
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;


  // Controls player's individual movement
public class PlayerMovement : MonoBehaviour 
{
  public static PlayerMovement pMove;

  float MovementSpeed = 11.0f;
  public int SpeedStacks = 0;
  [SerializeField]
  float MaximumDistance = 5.0f;
  
  GameObject LevelGlobals;
  GameObject CentrePoint;
  [SerializeField]
  public GameObject[] Points;
  GameObject Camera;
  //CameraController Camcontrol;
  
  Vector3 DashDestination;
  GameObject DashTo;
  
  //float moveTime = 0.0f;
  
  //[SerializeField]
  //float MinDashTimeNeeded = 1.0f;
  
  float VerticalBound;
  float HorizontalBound;
  
  public int GridPos = 5;
  
  public Material defaultMaterial;
  
  [SerializeField]
  public Material KOMaterial;

  public GameObject PlayerTookDamageExplosion;

  // Use this for initialization
  void Start () 
  {
    pMove =  GetComponent<PlayerMovement>();
    defaultMaterial = GetComponent<Renderer>().material;
    LevelGlobals = GameObject.FindWithTag("Globals");
    CentrePoint = LevelGlobals.GetComponent<LevelGlobals>().CentrePoint;
    Camera = LevelGlobals.GetComponent<LevelGlobals>().Camera;
    //Camcontrol = Camera.GetComponent<CameraController>();
    VerticalBound = CentrePoint.transform.position.y;
    HorizontalBound = CentrePoint.transform.position.x;
  }
  
  // Update is called once per frame
  void Update () 
  {
      if (PauseController.GamePaused || Tutorial.TutorialOccuring)
        return;
      if (Input.anyKey && DashTo == null)
      {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
          DashTo = CalcNextGridPos(1); //up
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
          DashTo = CalcNextGridPos(2); //down
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
          DashTo = CalcNextGridPos(4); //left
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
          DashTo = CalcNextGridPos(8); //right
        }
        
        //moveTime = Time.time;
      }
      
      
      if (DashTo != null && DashDestination != DashTo.transform.position)
        DashDestination = DashTo.transform.position;
      
      if (DashTo != null && DashDestination != Vector3.zero && transform.position != DashDestination)
      {
        transform.position = Vector3.Lerp(transform.position, DashDestination, MovementSpeed * TimeZone.DeltaTime(false));
        if (Vector3.Distance(transform.position,DashDestination) < 0.1)
        {
          DashTo = null;
        }
      }
  }
  

  
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Rift")
    {
      SpeedStacks++;
      //Camcontrol.IncreasePStopTime(1.0f);
      Destroy(other.gameObject);
      SoundHub.PlayPickup();
      Scoring.pickupsCollected += 1;
      StartCoroutine(HUDController.HUDControl.RiftGet());
      HUDStageController.HUDstage.PulsePickups();
      HUDStageController.HUDstage.UpdateStages(SpeedStacks);
    }
    else if (other.gameObject.tag == "Hazard")
    {
      print("OW");
      GetComponent<Health>().DecrementHealth();
      
      SoundHub.PlayAsteroidExplosion();
      HUDStageController.HUDstage.PulseHealth();

      if(PlayerTookDamageExplosion.GetComponent<ParticleSystem>().isPlaying == true)
      {
        PlayerTookDamageExplosion.SetActive(false);
        PlayerTookDamageExplosion.SetActive(true);
      }

      else
      {
        PlayerTookDamageExplosion.SetActive(true);
      }
      Destroy(other.gameObject);
    }
  }
  
  void OnTriggerStay(Collider other)
  {
    if (other.gameObject.tag == "Spacer" && CameraController.GetPTime())
    {
      print("Collided with spacer");
      if (other.gameObject.GetComponent<Health>().health > 0)
      {
        other.gameObject.GetComponent<Health>().DecrementHealth();
        
        SoundHub.PlayEnemyTimeBomb();
        
        Scoring.enemiesDestroyed += 1;
      }
    }
  }
    
  bool CalcBound(int edge) //0 = up, 1 = down, 2 = left, 3 = right
  {
    if (edge == 0)
    {
      if (transform.up.y == 1)
      {
        return transform.position.y <= VerticalBound + MaximumDistance;
      }
    }
    else if (edge == 1)
    {
      if (transform.up.y == 1)
      {
        return transform.position.y >= VerticalBound - MaximumDistance;
      }
      
    }
    else if (edge == 2)
    {
      if (transform.right.x == 1)
      {
        return transform.position.x >= HorizontalBound - MaximumDistance;
      }
    }
    else if (edge == 3)
    {
      if (transform.right.x == 1)
      {
        return transform.position.x <= HorizontalBound + MaximumDistance;
      }
    }
    return false;
  }
  
  bool MovementKeyDown()
  {
    return Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("space");
  }
  
  public void ResetDashDestination()
  {
    DashTo = null;
    //DashDestination = Vector3.zero;
  }
  
  public GameObject CalcNextGridPos(int dir)  //1 = up, 2 = down, 4 = left, 8 = right,
                                              //5 = UL, 9 = UR, 6 = DL, 10 = DR
  {
    //AkSoundEngine.PostEvent("event_DirectionChange", this.gameObject);
    SoundHub.PlayerMoves(this.gameObject);

    int oldPos = GridPos;
    if (dir == 1) //up
    {
      //above is occupied and not in time stop
      if (oldPos - 3 >= 0 && EnemySpawner.CheckOccupancy(oldPos - 3) && !CameraController.GetPTime())
        return Points[oldPos - 1];
      
      if (GridPos > 3)
        GridPos -= 3;
      
      
      //if (GridPos < 1)
        //GridPos = 1;
      
      //return oldPos - 4;
      if (oldPos == 4)
        return Points[0];
      else if (oldPos == 5)
        return Points[1];
      else if (oldPos == 6)
        return Points[2];
      else if (oldPos == 7)
        return Points[3];
      else if (oldPos == 8)
        return Points[4];
      else if (oldPos == 9)
        return Points[5];
    }
    else if (dir == 2) // down
    {
      if (oldPos + 3 < 9 && EnemySpawner.CheckOccupancy(oldPos + 3) && !CameraController.GetPTime())
        return Points[oldPos - 1] ;
      
      if (GridPos < 7)
        GridPos += 3;
      
      
      if (oldPos == 1)
        return Points[3];
      else if (oldPos == 2)
        return Points[4];
      else if (oldPos == 3)
        return Points[5];
      else if (oldPos == 4)
        return Points[6];
      else if (oldPos == 5)
        return Points[7];
      else if (oldPos == 6)
        return Points[8];
    }
    else if (dir == 4) // left
    {
      //print ("old pos" + GridPos);
      if (oldPos - 1 >= 0 && EnemySpawner.CheckOccupancy(oldPos - 1) && !CameraController.GetPTime())
        return Points[oldPos - 1];
      
      if (GridPos %3 != 1)
        GridPos -= 1;
      
      //print("new pos" + GridPos);
      
      
      if (oldPos == 2)
        return Points[0];
      else if (oldPos == 3)
        return Points[1];
      else if (oldPos == 5)
        return Points[3];
      else if (oldPos == 6)
        return Points[4];
      else if (oldPos == 8)
        return Points[6];
      else if (oldPos == 9)
        return Points[7];
    }
    else if (dir == 8) // right
    {
      if (oldPos + 1 < 9 && EnemySpawner.CheckOccupancy(oldPos + 1) && !CameraController.GetPTime())
        return Points[oldPos - 1];
      
      if (GridPos %3 != 0)
        GridPos += 1;
      
      
      
      if (oldPos == 1)
        return Points[1];
      else if (oldPos == 2)
        return Points[2];
      else if (oldPos == 4)
        return Points[4];
      else if (oldPos == 5)
        return Points[5];
      else if (oldPos == 7)
        return Points[7];
      else if (oldPos == 8)
        return Points[8];
    }
    
    else if (dir == 5) // upperleft
    {
      if (GridPos == 3)
        GridPos = 2;
      else if (GridPos == 7)
        GridPos = 4;
      else
        GridPos -= 4;
      if (GridPos < 1)
        GridPos = 1;
      
      if (oldPos == 2)
        return Points[0];
      else if (oldPos == 3)
        return Points[1];
      else if (oldPos == 4)
        return Points[0];
      else if (oldPos == 5)
        return Points[0];
      else if (oldPos == 6)
        return Points[1];
      else if (oldPos == 7)
        return Points[3];
      else if (oldPos == 8)
        return Points[3];
      else if (oldPos == 9)
        return Points[4];
    }
    else if (dir == 9) // upperright
    {
      if (GridPos == 1 || GridPos == 2)
        GridPos += 1;
      else if (GridPos %3 == 1 || GridPos %3 == 2)
        GridPos -= 2;
      else if (GridPos %3 == 0)
        GridPos -= 3;
      
      if (oldPos == 1)
        return Points[1];
      else if (oldPos == 2)
        return Points[2];
      else if (oldPos == 4)
        return Points[1];
      else if (oldPos == 5)
        return Points[2];
      else if (oldPos == 6)
        return Points[2];
      else if (oldPos == 7)
        return Points[4];
      else if (oldPos == 8)
        return Points[5];
      else if (oldPos == 9)
        return Points[5];
    }
    else if (dir == 6) // lowerleft
    {
      if (GridPos == 8 || GridPos == 9)
      {
        GridPos -= 1;
      }
      if (GridPos % 3 == 0 || GridPos %  3 == 2)
      {
        GridPos += 2;
      }
      else if (GridPos %3 == 1)
      {
        GridPos += 3;
      }
      
      if (GridPos > 9)
        GridPos = 9;
      
      
      if (oldPos == 1)
        return Points[3];
      else if (oldPos == 2)
        return Points[3];
      else if (oldPos == 3)
        return Points[4];
      else if (oldPos == 4)
        return Points[6];
      else if (oldPos == 5)
        return Points[6];
      else if (oldPos == 6)
        return Points[7];
      else if (oldPos == 8)
        return Points[6];
      else if (oldPos == 9)
        return Points[7];
      
    }
    else if (dir == 10) // lowerright
    {
      if (oldPos == 1)
        return Points[4];
      else if (oldPos == 2)
        return Points[5];
      else if (oldPos == 3)
        return Points[5];
      else if (oldPos == 4)
        return Points[7];
      else if (oldPos == 5)
        return Points[8];
      else if (oldPos == 6)
        return Points[8];
      else if (oldPos == 7)
        return Points[7];
      else if (oldPos == 8)
        return Points[8];
    }
    return null;
    
  }
  
  public void CentreGridPos()
  {
    GridPos = 5;
  }
  
}