////////////////////////////////////////////////////////////////////////////////
//	Authors: Winson Han
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class LensEffectLogic : MonoBehaviour 
{

  private float count = 0f;
  private float speed = 0.5f;
  private Vector3 InitialScale;

  // Use this for initialization
  void Start()
  {

    InitialScale = transform.localScale;
    transform.localScale = new Vector3(0, 0, 0);
  }

  // Update is called once per frame
  void Update()
  {
    //while time is stopped
    if (CameraController.GetPTime() == true)
    {
      if (count >= speed)
      {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        return;
      }

      transform.localScale = Vector3.Lerp(Vector3.zero, InitialScale, count / speed);
      count += TimeZone.DeltaTime(false);
      //print(count);
    }

    if (CameraController.GetPTime() == false)
    {

      gameObject.GetComponent<MeshRenderer>().enabled = true;
      transform.localScale = Vector3.zero;
      count = 0f;
    }

  }
}
