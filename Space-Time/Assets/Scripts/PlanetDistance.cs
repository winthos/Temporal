////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//  Keeps planets and other large bodies away from player at constant distance
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
 using UnityEngine;
using System.Collections;

// attach this script to planetary objects

public class PlanetDistance : MonoBehaviour
{
    public GameObject player;

    Vector3 distance;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //add some variance to size
        transform.localScale *= Random.Range(0.9f, 1.3f);

        if(player != null)
            //set the distance at which the planet will always stay
            distance = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
      if (PauseController.Paused())
        return;
        if(player != null)
            transform.position = player.transform.position + distance;
    }
}