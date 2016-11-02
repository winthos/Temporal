/*
 * Written by Kaila Harris
 * Keeps planets and other large bodies away from player at constant distance
 */
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
        //add some variance to size
        transform.localScale *= Random.Range(0.9f, 1.3f);

        if(player != null)
            //set the distance at which the planet will always stay
            distance = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(player != null)
            transform.position = player.transform.position + distance;
    }
}
