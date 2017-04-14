////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour 
{
  [SerializeField]
  float Lifetime = 3.0f;
	// Use this for initialization
	void Start () 
  {
    StartCoroutine(Boom());
	}
	
	// Update is called once per frame
	void Update () 
  {
	
	}
  
  IEnumerator Boom()
  {
    yield return new WaitForSeconds(Lifetime);
    Destroy(gameObject);
  }
  
}
