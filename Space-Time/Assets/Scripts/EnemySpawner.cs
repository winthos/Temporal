////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
  public static EnemySpawner enemySpawner;
  
  [SerializeField]
  GameObject[] Spacer;
  
  [SerializeField]
  GameObject Timer;

  public static bool[] OccupiedSpaces = new bool[9];
  
  
  bool Spawning = false;
  [SerializeField]
  float SpawnDelay = 5.0f;
  
  [SerializeField]
  float SpawnVariance = 0.0f;
  
	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (PauseController.Paused)
      return;
    if (!Spawning && NumOccupancies() < 9)
    {
      
      StartCoroutine(SpawnEnemyWait());
      
    }
    if (NumOccupancies() < 9)
    {
      OccupancyText();
    }
    
	}
  
  public static bool CheckOccupancy(int pos)
  {
    if (pos < 1)
      return true;
    /*if (OccupiedSpaces[pos - 1])
      return true;
    else
      return false;
    */
    //print("still occupied at " + (pos - 1) + " " + OccupiedSpaces[pos - 1]);
    return OccupiedSpaces[pos - 1];
  }
  
  public void OccupancyText()
  {
    for (int i = 0; i < 8; i++)
    {
      if (!CheckOccupancy(i + 1) && PlayerMovement.pMove.Points[i].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text != "")
      {
        PlayerMovement.pMove.Points[i].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "";
        print(i + " no longer occupied");
      }
    }
  }
  
  public static void SetOccupancy(int pos, bool set)
  {
    if (pos < 1 || pos > 9)
      return;
    OccupiedSpaces[pos - 1] = set;
    print("setting pos " + (pos) + " to " + set);
  }
  
  public static int NumOccupancies()
  {
    int count = 0;
    for (int i = 0; i < 8; i++)
    {
      if (OccupiedSpaces[i])
        count++;
    }
    return count;
  }
  
  public static void ResetOccupancies()
  {
    for (int i = 0; i < 8; i++)
    {
      OccupiedSpaces[i] = false;
    }
  }
  
  
  void SpawnEnemy()
  {
    int spawnpoint = (int)Random.Range(0,8);
    if (spawnpoint > 7)
      spawnpoint = 7;
    if (!CheckOccupancy(spawnpoint))
    {
      GameObject en = (GameObject)Instantiate(Spacer[spawnpoint], transform.position, Quaternion.identity);

      SetOccupancy(en.GetComponent<SpacerControl>().GetID(), true);
      //print("Occupied at " + en.GetComponent<SpacerControl>().GetID());
    }
    
    
  }
  
  IEnumerator SpawnEnemyWait()
  {
    Spawning = true;
    yield return new WaitForSeconds(SpawnDelay);
    SpawnEnemy();
    Spawning = false;
  }
  
  float CalcSpawnDelay()
  {
    return SpawnDelay + Random.Range(-SpawnVariance, SpawnVariance);
  }
}
