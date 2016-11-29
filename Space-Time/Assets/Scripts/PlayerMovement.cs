using UnityEngine;
using System.Collections;


  // Controls player's individual movement
public class PlayerMovement : MonoBehaviour 
{

  float MovementSpeed = 11.0f;
  public int SpeedStacks = 0;
  [SerializeField]
  float MaximumDistance = 5.0f;
  
  GameObject LevelGlobals;
  GameObject CentrePoint;
  [SerializeField]
  public GameObject[] Points;
  GameObject Camera;
  CameraController Camcontrol;
  
  Vector3 DashDestination;
  GameObject DashTo;
  
  float moveTime = 0.0f;
  
  [SerializeField]
  float MinDashTimeNeeded = 1.0f;
  
  float VerticalBound;
  float HorizontalBound;
  
  public int GridPos = 5;

  // Use this for initialization
  void Start () 
  {
    
    LevelGlobals = GameObject.FindWithTag("Globals");
    CentrePoint = LevelGlobals.GetComponent<LevelGlobals>().CentrePoint;
    Camera = LevelGlobals.GetComponent<LevelGlobals>().Camera;
    Camcontrol = Camera.GetComponent<CameraController>();
    VerticalBound = CentrePoint.transform.position.y;
    HorizontalBound = CentrePoint.transform.position.x;
  }
  
  // Update is called once per frame
  void Update () 
  {
      // if we're in normal time
    //if (!Camcontrol.GetPTime() && !Camcontrol.GetETime() && !Camcontrol.IsTimeTransitioning())
    //{
      //Vector3 dir = new Vector3();
      //allow WASD input yay
      //dir = transform.position;
      if (PauseController.Paused)
        return;
      if (Input.anyKey && DashTo == null)
      {
        /*
        //Vector3 up = transform.position * transform.up;
        //Vector3 centrup = CentrePoint.transform.position * transform.up;
         //if transform (up) is less than CentrePoint's transform (up)
        print(transform.up);
        if (Input.GetKey("w") && CalcBound(0))
        {
           dir += transform.up * MovementSpeed;
        }
        else if (Input.GetKey("s") && CalcBound(1))
        {
          dir -= transform.up * MovementSpeed;
        }
        if (Input.GetKey("a") && CalcBound(2))
        {
          dir -= transform.right * MovementSpeed;
        }
        else if (Input.GetKey("d") && CalcBound(3))
        {
          dir += transform.right * MovementSpeed;
        }
        else if (Input.GetKey("space")) // if middle mouse
        {
          dir = CentrePoint.transform.position;
        }
        */
        /*
        if (Input.GetKeyDown("w") && Input.GetKeyDown("a"))
        {
          DashTo = CalcNextGridPos(5); //upperleft
          
        }
        else if (Input.GetKeyDown("w") && Input.GetKeyDown("d"))
        {
          DashTo = CalcNextGridPos(9); //upperight
          
        } 
        else if (Input.GetKeyDown("s") && Input.GetKeyDown("a"))
        {
          DashTo = CalcNextGridPos(6); //lowerleft
          
        } 
        else if (Input.GetKeyDown("s") && Input.GetKeyDown("d"))
        {
          DashTo = CalcNextGridPos(10); //lowerright
        } 
        else */
        if (Input.GetKeyDown("w"))
        {
          DashTo = CalcNextGridPos(1); //up
          
        }
        else if (Input.GetKeyDown("s"))
        {
          DashTo = CalcNextGridPos(2); //down
          
        }
        else if (Input.GetKeyDown("a"))
        {
          DashTo = CalcNextGridPos(4); //left
          
        }
        else if (Input.GetKeyDown("d"))
        {
          DashTo = CalcNextGridPos(8); //right
        }

          
          moveTime = Time.time;
        
          
        
      }
      //else
       // dir = CentrePoint.transform.position;
      
      
      if (DashTo != null && DashDestination != DashTo.transform.position)
        DashDestination = DashTo.transform.position;
      
      if (DashTo != null && DashDestination != Vector3.zero && transform.position != DashDestination)
      {
        //print(DashDestination);
        transform.position = Vector3.Lerp(transform.position, DashDestination, MovementSpeed * TimeZone.DeltaTime(false));
        if (Vector3.Distance(transform.position,DashDestination) < 0.1)
        {
          //CentrePoint.transform.position = transform.position;
          //DashDestination = Vector3.zero;
          DashTo = null;
          
        }
      }
      
      //transform.position = Vector3.MoveTowards(transform.position, dir, TimeZone.DeltaTime(false) * MovementSpeed);
      
      
    //}
    /*
    else if (Camcontrol.GetPTime() || (Camcontrol.GetPTime() && Camcontrol.GetETime()))
    {
      //key pressed -> store grid location -> quickly lerp over -> new location!
      if (Input.anyKey && DashTo == null && Camcontrol.GetPTimeStopTimer() > MinDashTimeNeeded)
      {
        
        if (Input.GetKeyDown("w") && Input.GetKeyDown("a")) // 1
        {
          DashDestination = CentrePoint.transform.Find("1").transform.position;
          DashTo = CentrePoint.transform.Find("1").gameObject;
          GridPos = 1;
        }
        else if (Input.GetKeyDown("w") && Input.GetKeyDown("d")) //3
        {
          DashDestination = CentrePoint.transform.Find("3").transform.position;
          DashTo = CentrePoint.transform.Find("3").gameObject;
          GridPos = 3;
        } 
        else if (Input.GetKeyDown("s") && Input.GetKeyDown("a")) //7
        {
          DashDestination = CentrePoint.transform.Find("7").transform.position;
          DashTo = CentrePoint.transform.Find("7").gameObject;
          GridPos = 7;
        } 
        else if (Input.GetKeyDown("s") && Input.GetKeyDown("d")) //9
        {
          DashDestination = CentrePoint.transform.Find("9").transform.position;
          DashTo = CentrePoint.transform.Find("9").gameObject;
          GridPos = 9;
        } 
        else if (Input.GetKeyDown("w")) //2
        {
          DashDestination = CentrePoint.transform.Find("2").transform.position;
          DashTo = CentrePoint.transform.Find("2").gameObject;
          GridPos = 2;
        }
        else if (Input.GetKeyDown("s")) //8
        {
          DashDestination = CentrePoint.transform.Find("8").transform.position;
          DashTo = CentrePoint.transform.Find("8").gameObject;
          GridPos = 8;
        }
        else if (Input.GetKeyDown("a")) //4
        {
          DashDestination = CentrePoint.transform.Find("4").transform.position;
          DashTo = CentrePoint.transform.Find("4").gameObject;
          GridPos = 4;
        }
        else if (Input.GetKeyDown("d")) //6
        {
          DashDestination = CentrePoint.transform.Find("6").transform.position;
          DashTo = CentrePoint.transform.Find("6").gameObject;
          GridPos = 6;
        }
        else if (Input.GetKeyDown("space")) //5
        {
          DashDestination = CentrePoint.transform.position;
          DashTo = CentrePoint;
          GridPos = 5;
        }
        moveTime = Time.time;
      }
      
      if (DashTo != null && DashDestination != DashTo.transform.position)
        DashDestination = DashTo.transform.position;
      
      if (DashTo != null && DashDestination != Vector3.zero && transform.position != DashDestination)
      {
        print(DashDestination);
        transform.position = Vector3.Lerp(transform.position, DashDestination, 0.125f);
        if (Vector3.Distance(transform.position,DashDestination) < 0.1)
        {
          //CentrePoint.transform.position = transform.position;
          //DashDestination = Vector3.zero;
          DashTo = null;
          
        }
      }
      
    }
    */
    //if in normal time
      //if keys WASD are held, move toward a specific direction
      //if no keys are held, gravitate back toward the centre
    
  }
  

  
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Rift")
    {
      AkSoundEngine.PostEvent("event_riftGet", this.gameObject);
      SpeedStacks++;
      Camcontrol.IncreasePStopTime(1.0f);
      Destroy(other.gameObject);
    }
    else if (other.gameObject.tag == "Hazard")
    {
      print("OW");
      GetComponent<Health>().DecrementHealth();
    }
    else if (other.gameObject.tag == "Spacer")
    {
      other.gameObject.GetComponent<Health>().DecrementHealth();
    }
  }
  
  void RecalculateBounds()
  {
    
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
    AkSoundEngine.PostEvent("event_DirectionChange", this.gameObject);

    int oldPos = GridPos;
    if (dir == 1) //up
    {
      if (GridPos > 3)
        GridPos -= 3;
      //if (GridPos < 1)
        //GridPos = 1;
      
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
      if (GridPos < 7)
        GridPos += 3;
      //if (GridPos > 9)
        //GridPos = 9;
      
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
