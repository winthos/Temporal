using UnityEngine;
using System.Collections;

public class BakudanDonePlaying : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(gameObject.GetComponent<ParticleSystem>().isPlaying == false)
        {
            gameObject.SetActive(false);
        }
	}
}
