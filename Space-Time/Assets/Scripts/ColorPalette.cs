using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorPalette
{
    bool bColorBlindOK;

    //always set values
    List<Color> PlanetsAndSatellites = new List<Color>();

    public ColorPalette()
    {
    }

    
    public void SetPlanetsAndSatellites(Color _main1, Color _main2, Color _main3, Color _main4, Color _main5) 
    {
        PlanetsAndSatellites.Add(_main1);
        PlanetsAndSatellites.Add(_main2);
        PlanetsAndSatellites.Add(_main3);
        PlanetsAndSatellites.Add(_main4);
        PlanetsAndSatellites.Add(_main5);
    }

    public void AddColorTo(List<Color> _list, Color _color)
    {
        _list.Add(_color);
    }

    public List<Color> GetPlanetColors()
    {
        return PlanetsAndSatellites;
    }


    /* 
    * base setter classes 
    */
    void Set1Color(Color[] _array, Color _main)
    {
        _array[0] = _main;
    }

    void Set2Colors(Color[] _array, Color _main, Color _accent)
    {
        _array[0] = _main;
        _array[1] = _accent;
    }

    void Set3Colors(Color[] _array, Color _main, Color _accent1, Color _accent2)
    {
        _array[0] = _main;
        _array[1] = _accent1;
        _array[2] = _accent2;
    }
    void Set4Colors(Color[] _array, Color _main1, Color _main2, Color _main3, Color _main4)
    {
        _array[0] = _main1;
        _array[1] = _main2;
        _array[2] = _main3;
        _array[3] = _main4;
    }
    void Set5Colors(Color[] _array, Color _main1, Color _main2, Color _main3, Color _main4, Color _main5)
    {
        _array[0] = _main1;
        _array[1] = _main2;
        _array[2] = _main3;
        _array[3] = _main4;
        _array[4] = _main5;
    }
}