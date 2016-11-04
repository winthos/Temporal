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
    RaycastHit hit;
    if(Physics.Raycast(transform.position, transform.forward, out hit, MaxRayDistance))
    {
       if(hit.collider)
        {
          if (hit.collider.gameObject.tag == "Hazard")
          {
            renderer.material.SetColor("_Color", HazardColour);
          }
          else if (hit.collider.gameObject.tag == "Rift")
          {
            renderer.material.SetColor("_Color", RiftColour);
          }
          
          //spacer
          //time bomb
        }
    }

    else
    {
        //if(IsTimeStopped == false)
        renderer.material.SetColor("_Color", DefaultColour);
          
    }
	}
}
