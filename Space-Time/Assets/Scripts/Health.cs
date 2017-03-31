////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

  [SerializeField]
  GameObject DamageFlash;
 
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
    if (Boom && !PauseController.Paused && !Tutorial.TutorialOccuring)
    {
      if (gameObject.tag == "Player")
      {
        gameObject.GetComponent<Renderer>().material.Lerp(GetComponent<PlayerMovement>().defaultMaterial, 
                                                          GetComponent<PlayerMovement>().KOMaterial, TimeZone.DeltaTime(false)* 50.0f);
        TimeZone.SetTimeScale(Mathf.Lerp(TimeZone.DeltaTime(), 0.0000000001f, TimeZone.DeltaTime(false)* 15.0f));
        PauseController.Paused = true;
      }
      else
        Destroy(gameObject);
      
    }
    
  }
  
  public void DecrementHealth()
  {
    if ((gameObject.tag == "Player" && LevelGlobals.Debugging) || hp <= 0)
      return;
    hp--;
    if (gameObject.tag == "Player")
      StartCoroutine(Flash());
    if (hp <= 0 && ! CoroutineProcessing && DestroyAtZero)
    {
      print("hp 0");
      
      if (CreateOnDeath != null && CreateOnDeath.Length > 0)
      {
        Instantiate(CreateOnDeath[0], transform.position, Quaternion.identity);
        
        /*
        GameObject create;
        for (int i = 0; i < CreateOnDeath.Length; i++)
        {
          create = (GameObject)Instantiate(CreateOnDeath[i], transform.position, Quaternion.identity);

        }
        */
      }
      
      
      if (gameObject.tag == "Spacer")
      {
        EnemySpawner.SetOccupancy(GetComponent<SpacerControl>().GetID(), false);
        PlayerMovement.pMove.Points[GetComponent<SpacerControl>().GetID() - 1].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "";
      }

      if(gameObject.tag == "Player")
      {
        //AkSoundEngine.PostEvent("event_playerDeath", this.gameObject);
        SoundHub.PlayPlayerDeath();
        DamageFlash.SetActive(false);
      }
      
      
      StartCoroutine(Wait());
    }
      //destroy!
  }
  
  
  IEnumerator Wait()
  {
    CoroutineProcessing = true;
    yield return new WaitForSeconds(0.00625f);
    Boom = true;
    CoroutineProcessing = false;
  }

  IEnumerator Flash()
  {
    DamageFlash.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    DamageFlash.SetActive(false);
  }
}
