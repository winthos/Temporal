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
        //print("Hazard");
        switch (Location)
        {
            case 1: //1A
                HUDTargetingController.HUDTarget.HazardSpace(0, dist);
                break;
            case 2: //1B
                HUDTargetingController.HUDTarget.HazardSpace(1, dist);
                break;
            case 3: //1C
                HUDTargetingController.HUDTarget.HazardSpace(2, dist);
                break;
            case 4: //2A
                HUDTargetingController.HUDTarget.HazardSpace(3, dist);
                break;
            case 5: //TWO-BEE
                HUDTargetingController.HUDTarget.HazardSpace(4, dist);
                break;
            case 6: //2C
                HUDTargetingController.HUDTarget.HazardSpace(5, dist);
                break;
            case 7: //3A
                HUDTargetingController.HUDTarget.HazardSpace(6, dist);
                break;
            case 8: //3B
                HUDTargetingController.HUDTarget.HazardSpace(7, dist);
                break;
            case 9: //3C
                HUDTargetingController.HUDTarget.HazardSpace(8, dist);
                break;
        }

    }

    public void HighlightTargetPickup(float dist)
    {
        //print("Rift");
        switch (Location)
        {
            case 1: //1A
                HUDTargetingController.HUDTarget.PickupSpace(0, dist);
                break;
            case 2: //1B
                HUDTargetingController.HUDTarget.PickupSpace(1, dist);
                break;
            case 3: //1C
                HUDTargetingController.HUDTarget.PickupSpace(2, dist);
                break;
            case 4: //2A
                HUDTargetingController.HUDTarget.PickupSpace(3, dist);
                break;
            case 5: //TWO-BEE
                HUDTargetingController.HUDTarget.PickupSpace(4, dist);
                break;
            case 6: //2C
                HUDTargetingController.HUDTarget.PickupSpace(5, dist);
                break;
            case 7: //3A
                HUDTargetingController.HUDTarget.PickupSpace(6, dist);
                break;
            case 8: //3B
                HUDTargetingController.HUDTarget.PickupSpace(7, dist);
                break;
            case 9: //3C
                HUDTargetingController.HUDTarget.PickupSpace(8, dist);
                break;

        }
    }
}
