/*
 * Written by Kaila Harris
 * controls the rotation of satellite objects around a gameObject
 * must be a child of the target object
 */
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
        transform.localScale *= Random.Range(1f, 1.3f);
        RotationSpeed = Random.Range(10, 20);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CameraController.GetPTime() == true)
            return;
        else
            transform.RotateAround(Planet.transform.position, Vector3.up, RotationSpeed * TimeZone.DeltaTime());
            
    }
}
