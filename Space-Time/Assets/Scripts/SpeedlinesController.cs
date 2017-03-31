////////////////////////////////////////////////////////////////////////////////
//  Authors: Winson Han
//  Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////


using UnityEngine;
using System.Collections;

public class SpeedlinesController : MonoBehaviour {
    [SerializeField]
    GameObject Speedlines;
	// Use this for initialization
	void Start ()
   {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CameraController.GetPTime() == true)
        {
            Speedlines.SetActive(false);
        }

        else
            Speedlines.SetActive(true);

	}
}
