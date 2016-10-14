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
        distance = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(player != null)
            transform.position = player.transform.position + distance;
    }
}
