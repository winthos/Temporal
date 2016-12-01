﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour 
{
  [SerializeField]
  string ToLoad;
  bool FaderIn = false;
  bool FaderOut = false;

	// Use this for initialization
	void Start () 
  {
    StartCoroutine(FadeIn());
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (FaderIn)
    {
      GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, new Color(), Time.deltaTime * 2.0f);
    }
    else if (FaderOut)
    {
      GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, Color.black, Time.deltaTime * 2.0f);
    
    }
	}
  
  IEnumerator FadeIn()
  {
   FaderIn = true;
   yield return new WaitForSeconds(3.0f); 
   FaderIn = false;
   StartCoroutine(Wait());
  }
  
  IEnumerator Wait()
  {
    yield return new WaitForSeconds(2.0f);
    StartCoroutine(FadeOut());
  }
  
  IEnumerator FadeOut()
  {
    FaderOut = true;
    yield return new WaitForSeconds(3.0f); 
    FaderOut = false;
    Application.LoadLevel(ToLoad);
  }
}