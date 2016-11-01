/*
 * Written by Kaila Harris
 * Goes on every visible object in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorLogic : MonoBehaviour
{
    Renderer rend; //Renderer of our Cube
    float transitionTime = 5f;

    GameObject ColorManager;
    ColorPalette currentColorPalette;

    void Start()
    {
        ColorManager = GameObject.Find("LevelGlobals");
        currentColorPalette = ColorManager.GetComponent<ColorManager>().palCurrent;

        rend = GetComponent<Renderer>();
        UpdateObjectWithCurrentPalette();

    }

    void Update()
    {
        //testing code
        if (Input.anyKeyDown)
        {
            UpdateObjectWithCurrentPalette();
        }
        // testing code end
    }

    // sets all objects to chosen palette
    void UpdateObjectWithCurrentPalette()
    {
        if (gameObject.tag == "Planet")
            SetPlanetColors(currentColorPalette.GetPlanetColors());
    }

    // sets planet and satellite colors randomly
    void SetPlanetColors(List<Color> _list)
    {
        // picks a random color from available list
        int pIndex = Random.Range(0, (_list.Count - 1));
        // sets planet to said color
        SetObjectColor(_list[pIndex]);

        // removes planet color from list of options for satellites
        List<Color> temp = _list;
        temp.RemoveAt(pIndex);

        // sets the colors for each satellite
        foreach (Transform child in transform)
        {
            int num = Random.Range(0, (temp.Count));
            child.gameObject.GetComponent<ColorLogic>().SetObjectColor(temp[num]);
        }
    }

    void SetObjectColor(Color _color)
    {
        rend.material.SetColor("_Color", _color);
    }
}