////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//  Rotates an object about its center
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    Vector3 direction = new Vector3(0, 0, 1);

	// Update is called once per frame
	void Update ()
    {
        //transform.Rotate(Time.deltaTime * direction * speed);
        transform.Rotate(Time.deltaTime * direction * speed);
    }
}
