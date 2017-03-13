////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ProjectionController : MonoBehaviour 
{

  [SerializeField]
  GameObject CentrePoint;
  
  Color DefaultColour;
  
  [SerializeField]
  Color HazardColour;
  
  [SerializeField]
  Color RiftColour;
  
  [SerializeField]
  int Location = 0;
  
  [SerializeField]
  float MaxRayDistance = 200.0f;

  Renderer renderer;
	// Use this for initialization
	void Start () 
  {
    
    renderer = GetComponent<Renderer>();
    DefaultColour = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (PauseController.Paused)
      return;
    RaycastHit hit;
    if(Physics.Raycast(transform.position, transform.forward, out hit, MaxRayDistance))
    {
     if(hit.collider)
      {
        if (hit.collider.gameObject.tag == "Hazard")
        {
          //renderer.material.SetColor("_Color", HazardColour);
          HighlightTargetHazard(hit.distance);
        }
        else if (hit.collider.gameObject.tag == "Rift")
        {
          //renderer.material.SetColor("_Color", RiftColour);
          HighlightTargetPickup(hit.distance);
        }
        
        //spacer
        //time bomb
      }

    }

    else
    {
      //if(IsTimeStopped == false)
      renderer.material.SetColor("_Color", DefaultColour);
      HighlightTargetHazard(0);
      HighlightTargetPickup(0);
    }
	}
  
  public void HighlightTargetHazard(float dist)
  {
    print("Hazard");
    switch(Location)
    {
      case 1: //1A
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard1A(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard1A(dist);
        break;
      case 2: //1B
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard1B(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard1B(dist);
        break;
      case 3: //1C
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard1C(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard1C(dist);
        break;
      case 4: //2A
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard2A(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard2A(dist);
        break; 
      case 5: //TWO-BEE
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard2B(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard2B(dist);
        break;
      case 6: //2C
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard2C(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard2C(dist);
        break;
      case 7: //3A
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard3A(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard3A(dist);
        break;
      case 8: //3B
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard3B(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard3B(dist);
        break;
      case 9: //3C
        if (dist == 0)
          HUDTargetingController.HUDTarget.HideHazard3C(dist);
        else
          HUDTargetingController.HUDTarget.ShowHazard3C(dist);
        break;
      
    }
  }
  
  public void HighlightTargetPickup(float dist)
  {
    print("Rift");
    switch(Location)
    {
      case 1: //1A
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup1A(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup1A(dist);
        break;
      case 2: //1B
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup1B(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup1B(dist);
        break;
      case 3: //1C
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup1C(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup1C(dist);
        break;
      case 4: //2A
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup2A(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup2A(dist);
        break; 
      case 5: //TWO-BEE
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup2B(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup2B(dist);
        break;
      case 6: //2C
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup2C(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup2C(dist);
        break;
      case 7: //3A
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup3A(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup3A(dist);
        break;
      case 8: //3B
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup3B(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup3B(dist);
        break;
      case 9: //3C
        if (dist == 0)
          HUDTargetingController.HUDTarget.HidePickup3C(dist);
        else
          HUDTargetingController.HUDTarget.ShowPickup3C(dist);
        break;
      
    }
  }
}
