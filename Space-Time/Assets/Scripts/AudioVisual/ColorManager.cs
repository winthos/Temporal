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
        print(palettes.Count);
    }

    public void Update()
    {
        //if (Input.GetKeyUp(KeyCode.L))
        //    ChangeCurrentPaletteToRandom();
    }

    public void ChangeCurrentPaletteToRandom(bool _instantly = true)
    {
        int random = Random.Range(0, palettes.Count);
        while (random == currentPalette)
            random = Random.Range(0, palettes.Count);

        ChangeCurrentPaletteTo(random, _instantly);
    }

    public void ChangeCurrentPaletteTo(int _paletteIndex, bool _instantly = true)
    {
        currentPalette = _paletteIndex;

        foreach (ColorLogic colLog in colorLog)
        {
            colLog.UpdateObjectWithCurrentPalette(_instantly);
        }
    }

    public Color GetColor(string _value)
    {
        string value = "placeholder";
        if (palettes[currentPalette].TryGetValue(_value, out value))
        {
            value = _value;
        }
        return convertHex.StringToRGB(palettes[currentPalette][value]);
    }


    public IEnumerator ChangePalleteAtEndOfTrack(float _trackLength, bool _instantly = true)
    {
        ColorManager colorManager = ColorManager.GetInstance();
        if (_instantly)
        {
            yield return new WaitForSeconds(_trackLength);
            colorManager.ChangeCurrentPaletteToRandom(_instantly);
        }
        else
        {
            colorManager.ChangeCurrentPaletteToRandom();
        }
    }

    void OnDestroy()
    {
        colorLog.Clear();
        palettes.Clear();
        currentColors.Clear();
    }
}