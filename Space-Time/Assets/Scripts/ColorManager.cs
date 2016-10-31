/*
 * Written by Kaila Harris
 * Goes on the Level Globals or Game Manager object
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorManager : MonoBehaviour
{
    public ColorPalette palPinkTriad = new ColorPalette(); 

    // Use this for initialization
    void Awake ()
    {
        SetPinkTriad();
    }

	// Update is called once per frame
	void Update ()
    {
	
	}

    void SetPinkTriad()
    {
        palPinkTriad.SetPlanetsAndSatellites(
            new Color(0.5882352941176471f, 0.07058823529411765f, 0.6980392156862745f),
            new Color(1.0f, 0.8901960784313725f, 0.6078431372549019f),
            new Color(0.9137254901960784f, 0.5058823529411764f, 1.0f),
            new Color(0.3254901960784314f, 0.8f, 0.6431372549019608f),
            new Color(0.3176470588235294f, 0.6980392156862745f, 0.5725490196078431f));
    }
}

// gray skybox  A1A7A705
//skybox  	#c2ab4a; 76.1, 67.1, 29