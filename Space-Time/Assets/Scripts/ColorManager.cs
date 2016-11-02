/*
 * Written by Kaila Harris
 * Goes on the Level Globals or Game Manager object
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorManager : MonoBehaviour
{
    public List<ColorPalette> allPalettes   = new List<ColorPalette>();
    public ColorPalette palCurrent          = new ColorPalette();

    // Use this for initialization
    void Awake ()
    {
        CreateAndListPalettes();
        ChangeCurrentPaletteTo(0);
    }

	// Update is called once per frame
	void Update ()
    {
        //testing code
        if (Input.anyKeyDown)
        {
            ChangeCurrentPaletteToRandom();
        }
        // testing code end
    }

    public void ChangeCurrentPaletteTo(int _paletteIndex)
    {
        palCurrent = allPalettes[_paletteIndex];
    }

    public void ChangeCurrentPaletteToRandom()
    {
        int random = Random.Range(0, allPalettes.Count); 
        while (random == allPalettes.IndexOf(palCurrent))
            random = Random.Range(0, allPalettes.Count);

        ChangeCurrentPaletteTo(random);
    }
    
    void CreateAndListPalettes()
    {
        allPalettes.Add(PinkTriad());
        allPalettes.Add(StreetsOfMorioh2());
        allPalettes.Add(JosephAndCeasar());
    }

    ColorPalette PinkTriad()
    {
        ColorPalette palPinkTriad = new ColorPalette();
        palPinkTriad.SetName("PinkTriad");

        palPinkTriad.SetPlanetsAndSatellites(
            new Color(0.5882352941176471f, 0.07058823529411765f, 0.6980392156862745f),
            new Color(1.0f, 0.8901960784313725f, 0.6078431372549019f),
            new Color(0.9137254901960784f, 0.5058823529411764f, 1.0f),
            new Color(0.3254901960784314f, 0.8f, 0.6431372549019608f),
            new Color(0.3176470588235294f, 0.6980392156862745f, 0.5725490196078431f));

        return palPinkTriad;
    }

    ColorPalette StreetsOfMorioh2()
    {
        ColorPalette palStreetsOfMorioh2 = new ColorPalette();
        palStreetsOfMorioh2.SetName("StreetsOfMorioh2");

        palStreetsOfMorioh2.SetPlanetsAndSatellites(
            new Color(0.211765f, 0.509804f, 0.501961f),
            new Color(0.674510f, 0.843137f, 0.588235f),
            new Color(0.760784f, 0.623529f, 0.172549f),
            new Color(0.729412f, 0.341176f, 0.270588f),
            new Color(0.964706f, 0.980392f, 0.937255f));

        return palStreetsOfMorioh2;
    }

    ColorPalette JosephAndCeasar()
    {
        ColorPalette palJosephAndCeasar = new ColorPalette();
        palJosephAndCeasar.SetName("JosephAndCeasar");

        palJosephAndCeasar.SetPlanetsAndSatellites(
            new Color(0.984314f, 0.501961f, 0.717647f),
            new Color(0.972549f, 0.356863f, 0.462745f),
            new Color(0.447059f, 0.180392f, 0.505882f),
            new Color(0.156863f, 0.964706f, 0.811765f),
            new Color(0.196078f, 0.796078f, 0.917647f));

        return palJosephAndCeasar;
    }
}