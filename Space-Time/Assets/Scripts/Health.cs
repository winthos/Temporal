﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
    // The character's starting HP
  [SerializeField]
  private int hp = 1;
    // Maximum HP of the character
  private int mhp;
  
  bool Boom;
  bool CoroutineProcessing = false;
 
    // Determines whether or not the character immediately explodes upon reaching 0 HP
  [SerializeField]
  public bool DestroyAtZero;
  
  [SerializeField]
  GameObject[] CreateOnDeath;
  
  public int health
  {
    get { return hp; }
    set { hp = value; }
    
  }
    // Use this for initialization
  void Start () 
  {
    if (hp < 0)
      hp = 1;
    mhp = hp;
  }
    
    // Update is called once per frame
  void Update ()
  {
    if (Boom && !PauseController.Paused)
      Destroy(gameObject);
    
  }
  
  public void DecrementHealth()
  {
    hp--;
    if (hp <= 0 && ! CoroutineProcessing && DestroyAtZero)
    {
      print("hp 0");
      if (CreateOnDeath != null && CreateOnDeath.Length > 0)
      {
        GameObject create;
        for (int i = 0; i < CreateOnDeath.Length; i++)
        {
          create = (GameObject)Instantiate(CreateOnDeath[i], transform.position, Quaternion.identity);
        }
      }
      if (gameObject.tag == "Spacer")
      {
        EnemySpawner.SetOccupancy(GetComponent<SpacerControl>().GetGridPos(), false);
      }
      StartCoroutine(Wait());
    }
      //destroy!
  }
  
  
  IEnumerator Wait()
  {
    CoroutineProcessing = true;
    yield return new WaitForSeconds(0.0125f);
    Boom = true;
    CoroutineProcessing = false;
  }
}
