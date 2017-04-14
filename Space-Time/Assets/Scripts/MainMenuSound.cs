using UnityEngine;
using System.Collections;

public class MainMenuSound : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
	
	}
  
  public void PlayButtonHover()
  {
    SoundHub.PlayButtonHover();
  }
  
  public void PlayButtonConfirm()
  {
    SoundHub.PlayButtonClick();
  }
}
