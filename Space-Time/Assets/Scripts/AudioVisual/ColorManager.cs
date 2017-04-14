////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
// Goes on the Level Globals or Game Manager object
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorManager : MonoBehaviour
{
    static ColorManager _instance;

    public static ColorManager GetInstance()
    {
        if (!_instance)
        {
            GameObject colorManager = new GameObject("ColorManager");
            _instance = colorManager.AddComponent<ColorManager>();
            _instance.Initialize();
        }

        return _instance;
    }


    ConvertHexColor convertHex = new ConvertHexColor();

    List<Dictionary<string, string>> palettes = new List<Dictionary<string, string>>();
    Dictionary<string, string>.KeyCollection keyColl;
    int currentPalette = 0;
    List<Color> currentColors = new List<Color>();

    public List<ColorLogic> colorLog = new List<ColorLogic>();

    // Use this for initialization
    void Initialize()
    {
        palettes = CSVReader.Read("Palettes");
        ChangeCurrentPaletteToRandom();
        //print(palettes.Count);
    }

    // picks a random number that represents a new palette. calls "ChangeCurrentPaletteTo"
    public void ChangeCurrentPaletteToRandom(bool _instant = true)
    {
        ColorManager colorMan = GetInstance();

        int random = Random.Range(0, colorMan.palettes.Count);
        while (random == colorMan.currentPalette)
            random = Random.Range(0, colorMan.palettes.Count);

        ChangeCurrentPaletteTo(random, _instant);
    }

    //will change the current palette based on an index number
    public void ChangeCurrentPaletteTo(int _paletteIndex, bool _instant = true)
    {
        ColorManager colorMan = GetInstance();
        colorMan.currentPalette = _paletteIndex;

        foreach (ColorLogic colLog in colorMan.colorLog)
        {
            colLog.UpdateObjectWithCurrentPalette(_instant);
        }
    }

    public Color GetColor(string _value)
    {
        ColorManager colorMan = GetInstance();

        string value = "placeholder";
        if (colorMan.palettes[currentPalette].TryGetValue(_value, out value))
        {
            value = _value;
        }
        return convertHex.StringToRGB(palettes[currentPalette][value]);
    }

    /*
    public IEnumerator ChangePalleteAtEndOfTrack(float _trackLength, bool _instant = true)
    {
        ColorManager colorManager = ColorManager.GetInstance();
        if (_instant)
        {
            yield return new WaitForSeconds(_trackLength);
            colorManager.ChangeCurrentPaletteToRandom(_instant);
        }
        else
        {
            colorManager.ChangeCurrentPaletteToRandom();
        }
    }
    */

        /*
    public void SetObjectColor(Renderer _renderer, Color _color)
    {
        _renderer.material.SetColor("_Color", _color);
    }
    */

    void OnDestroy()
    {
        colorLog.Clear();
        palettes.Clear();
        currentColors.Clear();
    }
}