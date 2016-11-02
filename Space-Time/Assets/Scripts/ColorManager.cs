﻿/*
 * Written by Kaila Harris
 * Goes on the Level Globals or Game Manager object
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorManager : MonoBehaviour
{
    ConvertHexColor convertHex              = new ConvertHexColor();

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
        ColorPalette palPinkTriad = new ColorPalette("PinkTriad");

        palPinkTriad.SetPlanetsAndSatellites(
            convertHex.toRGB("9612B2"),
            convertHex.toRGB("FFE39B"),
            convertHex.toRGB("E981FF"),
            convertHex.toRGB("53CCA4"),
            convertHex.toRGB("51B292"));

        return palPinkTriad;
    }

    ColorPalette StreetsOfMorioh2()
    {
        ColorPalette palStreetsOfMorioh2 = new ColorPalette("StreetsOfMorioh2");

        palStreetsOfMorioh2.SetPlanetsAndSatellites(
            convertHex.toRGB("19A2AD"),
            convertHex.toRGB("E176F8"),
            convertHex.toRGB("DCA026"),
            convertHex.toRGB("FEFF83"),
            convertHex.toRGB("1DB64B"));

        return palStreetsOfMorioh2;
    }

    ColorPalette JosephAndCeasar()
    {
        ColorPalette palJosephAndCeasar = new ColorPalette("JosephAndCeasar");

        palJosephAndCeasar.SetPlanetsAndSatellites(
            convertHex.toRGB("FB80B7"),
            convertHex.toRGB("F85B76"),
            convertHex.toRGB("722E81"),
            convertHex.toRGB("28F6CF"),
            convertHex.toRGB("32CBEA"));

        return palJosephAndCeasar;
    }
}