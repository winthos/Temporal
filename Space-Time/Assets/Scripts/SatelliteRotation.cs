using UnityEngine;
using System.Collections;

public class SatelliteRotation : MonoBehaviour
{
    [SerializeField]
    float RotationSpeed = 20;
    GameObject Planet;

	// Use this for initialization
	void Start ()
    {
        Planet = gameObject.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CameraController.GetPTime() == true)
        {
            return;
        }
        else
        {
            transform.RotateAround(Planet.transform.position, Vector3.up, RotationSpeed * TimeZone.DeltaTime());
        }
            
    }
}
