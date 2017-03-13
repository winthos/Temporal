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
        switch (Location)
        {
            case 1: //1A
                HUDTargetingController.HUDTarget.Hazard1A(dist);
                break;
            case 2: //1B
                HUDTargetingController.HUDTarget.Hazard1B(dist);
                break;
            case 3: //1C
                HUDTargetingController.HUDTarget.Hazard1C(dist);
                break;
            case 4: //2A
                HUDTargetingController.HUDTarget.Hazard2A(dist);
                break;
            case 5: //TWO-BEE
                HUDTargetingController.HUDTarget.Hazard2B(dist);
                break;
            case 6: //2C
                HUDTargetingController.HUDTarget.Hazard2C(dist);
                break;
            case 7: //3A
                HUDTargetingController.HUDTarget.Hazard3A(dist);
                break;
            case 8: //3B
                HUDTargetingController.HUDTarget.Hazard3B(dist);
                break;
            case 9: //3C
                HUDTargetingController.HUDTarget.Hazard3C(dist);
                break;
        }

    }

    public void HighlightTargetPickup(float dist)
    {
        print("Rift");
        switch (Location)
        {
            case 1: //1A
                HUDTargetingController.HUDTarget.Pickup1A(dist);
                break;
            case 2: //1B
                HUDTargetingController.HUDTarget.Pickup1B(dist);
                break;
            case 3: //1C
                HUDTargetingController.HUDTarget.Pickup1C(dist);
                break;
            case 4: //2A
                HUDTargetingController.HUDTarget.Pickup2A(dist);
                break;
            case 5: //TWO-BEE
                HUDTargetingController.HUDTarget.Pickup2B(dist);
                break;
            case 6: //2C
                HUDTargetingController.HUDTarget.Pickup2C(dist);
                break;
            case 7: //3A
                HUDTargetingController.HUDTarget.Pickup3A(dist);
                break;
            case 8: //3B
                HUDTargetingController.HUDTarget.Pickup3B(dist);
                break;
            case 9: //3C
                HUDTargetingController.HUDTarget.Pickup3C(dist);
                break;

        }
    }
}
