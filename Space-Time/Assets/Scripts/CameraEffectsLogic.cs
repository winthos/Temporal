////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraEffectsLogic : MonoBehaviour 
{
    private float count;
    public Texture Greyscale;
    public Texture ColorFlash;

    public float ColorFlashDuration = 0.2f;
    private bool dothisonce = false;

	// Use this for initialization
	void Start () 
	{
	    
	}
	
	// Update is called once per frame
	void Update () 
	{
        //if time is stopped
	    if(CameraController.GetPTime() == true)
        {
            if(dothisonce == false)
            {
                gameObject.GetComponent<Grayscale>().enabled = true;
                gameObject.GetComponent<Grayscale>().textureRamp = ColorFlash;
                dothisonce = true;
            }
            count += TimeZone.DeltaTime(false);
            if(count >= ColorFlashDuration)
            {
                gameObject.GetComponent<Grayscale>().textureRamp = Greyscale;
            }

        }

        //if toki ga ugoki desu
        else
        {
            count = 0f;
            gameObject.GetComponent<Grayscale>().enabled = false;
            dothisonce = false;
        }
	}
}
