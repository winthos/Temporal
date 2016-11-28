using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
  
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
    if (!Spawning && NumOccupancies() < 8)
    {
      
      StartCoroutine(SpawnEnemyWait());
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
    return OccupiedSpaces[pos - 1];
  }
  
  public static void SetOccupancy(int pos, bool set)
  {
    if (pos < 1 || pos > 8)
      return;
    OccupiedSpaces[pos - 1] = set;
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
  
  
  void SpawnEnemy()
  {
    int spawnpoint = (int)Random.Range(0,8);
    if (spawnpoint > 7)
      spawnpoint = 7;
    if (!CheckOccupancy(spawnpoint))
    {
      GameObject en = (GameObject)Instantiate(Spacer[spawnpoint], transform.position + new Vector3(0, 0, -10), Quaternion.identity);
      SetOccupancy(spawnpoint, true);
    }
    print("Spawn");
    
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
