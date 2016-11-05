/*
 * Written by Kaila Harris
 * Color Palette Class
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorPalette
{
    public string name = "";
    bool bColorBlindOK;

    //always set values
    List<Color> PlanetsAndSatellites = new List<Color>();

    public ColorPalette()
    {
    }

    public ColorPalette(string _name)
    {
        name = _name;
    }

    public void SetPlanetsAndSatellites(Color _main1, Color _main2, Color _main3, Color _main4, Color _main5) 
    {
        PlanetsAndSatellites.Add(_main1);
        PlanetsAndSatellites.Add(_main2);
        PlanetsAndSatellites.Add(_main3);
        PlanetsAndSatellites.Add(_main4);
        PlanetsAndSatellites.Add(_main5);
    }

    public List<Color> GetPlanetColors()
    {
        return PlanetsAndSatellites;
    }

    public void ClearAllPalettes()
    {

    }
}