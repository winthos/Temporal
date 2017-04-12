////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class RiftSpawner : MonoBehaviour 
{
  
  [SerializeField]
  GameObject Rift;
  
  float SpawnTimer = 0.0f;
  
  [SerializeField]
  float SpawnTime = 5.0f;
  
  [SerializeField]
  float SpawnTimeVariance = 2.0f;
  
  GameObject tLevelGlobals;
  GameObject CentrePoint;
  GameObject Player;
  GameObject Camera;
  CameraController CameraController;
  
  PlayerMovement pMove;
  

  // Use this for initialization
  void Start () 
  {
    tLevelGlobals = GameObject.FindWithTag("Globals");
    Player = tLevelGlobals.GetComponent<LevelGlobals>().Player;
    CentrePoint = tLevelGlobals.GetComponent<LevelGlobals>().CentrePoint;
    Camera = tLevelGlobals.GetComponent<LevelGlobals>().Camera;
    CameraController = Camera.GetComponent<CameraController>();
    SpawnTimer = SpawnTime;
    pMove = Player.GetComponent<PlayerMovement>();
  }
  
  // Update is called once per frame
  void Update () 
  {
    if (CameraController.GetPTime() || CameraController.GetETime() || PauseController.Paused() || Tutorial.TutorialOccuring || 
        !Tutorial.tutorial.IsActivatedMechanic(0) || LevelGlobals.PlayerDown)
      return;
    
    SpawnTimer -= Time.deltaTime;
    if (SpawnTimer <= 0.0)
    {
      LaunchRift();
      SpawnTimeCalc();
    }
    
    if (Input.GetKeyDown("u"))
    {
      LaunchRift();
    }
  
  }
  
  public void SpawnTimeCalc()
  {
    int stacks = Player.GetComponent<PlayerMovement>().SpeedStacks;
    SpawnTimer = Mathf.Clamp(SpawnTime + Random.Range(-SpawnTimeVariance - stacks/2, SpawnTimeVariance), 0.1f, 10.0f);
  }
  
  public void LaunchRift()
  {
    /*
    Vector3 SpawnPos = CentrePoint.transform.forward*350;
    
    float offsetx = (CentrePoint.transform.right.x + CentrePoint.transform.up.x) * 5.0f;
    float offsety = (CentrePoint.transform.right.y + CentrePoint.transform.up.y) * 5.0f;
    float offsetz = (CentrePoint.transform.right.z + CentrePoint.transform.up.z) * 5.0f;
    Vector3 offset = new Vector3(Random.Range(-offsetx, offsetx), Random.Range(-offsety, offsety),
            Random.Range(-offsetz, offsetz));
    
    
  
    //Have random location be in one of the 9 sections at the very least
    int QuadrantChance = (int)Random.Range(0,100);
    if (QuadrantChance < 25) // upperleft
    {
      SpawnPos += (CentrePoint.transform.position + CentrePoint.transform.Find("1").transform.position)/2;
    }
    else if (QuadrantChance >= 25 && QuadrantChance < 50) // upperright
    {
      SpawnPos += (CentrePoint.transform.position + CentrePoint.transform.Find("3").transform.position)/2;
    }
    else if (QuadrantChance >= 50 && QuadrantChance < 75) // lowerleft
    {
      SpawnPos += (CentrePoint.transform.position + CentrePoint.transform.Find("7").transform.position)/2;
    }
    else // lowerright
    {
      SpawnPos += (CentrePoint.transform.position + CentrePoint.transform.Find("9").transform.position)/2;
    }
    
    SpawnPos += offset;
    */
    Vector3 SpawnPos = pMove.Points[Random.Range(0,pMove.Points.Length)].transform.position + CentrePoint.transform.forward*500;
    
    /*int CreationChance = (int)Mathf.Clamp(Random.Range(0.0f,100.0f + Player.GetComponent<PlayerMovement>().SpeedStacks),
                                          0, 300); //max craziness limiter to prevent only large Rifts from spawning
   
    if (CreationChance < 75)
    {
      GameObject Rift = (GameObject)Instantiate(SmallRift, SpawnPos, Quaternion.identity);
    }
    else if (CreationChance >= 75 && CreationChance < 150)
    {
      GameObject Rift = (GameObject)Instantiate(MediumRift, SpawnPos, Quaternion.identity);
    }
    else
    {
      GameObject Rift = (GameObject)Instantiate(LargeRift, SpawnPos, Quaternion.identity);
    }
    */
    GameObject tRift = (GameObject)Instantiate(Rift, SpawnPos, Player.transform.rotation);
  }
}