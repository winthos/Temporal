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

    ColorManager colorManager;

    void Start()
    {
        colorManager = GameObject.Find("LevelGlobals").GetComponent<ColorManager>();
        if (colorManager != null)
        {
            colorManager.colorLog.Add(this);
            rend = GetComponent<Renderer>();
            UpdateObjectWithCurrentPalette(colorManager.palCurrent);
        }

    }

    void Update()
    {
 
    }

    // sets all objects to chosen palette
    public void UpdateObjectWithCurrentPalette(ColorPalette _palette)
    {
        if (gameObject.tag == "Planet")
            SetPlanetColors(_palette.GetPlanetColors());
        
    }

    // sets planet and satellite colors randomly
    void SetPlanetColors(List<Color> _list)
    {
        // picks a random color from available list
        int pIndex = Random.Range(0, (_list.Count - 1));

        // sets planet to said color
        if (pIndex < _list.Count)
        {
            SetObjectColor(_list[pIndex]);

            // sets the colors for each satellite
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<ColorLogic>() != null)
                {
                    int sIndex = Random.Range(0, (_list.Count));
                    while (sIndex == pIndex)
                        sIndex = Random.Range(0, (_list.Count));

                    child.gameObject.GetComponent<ColorLogic>().SetObjectColor(_list[sIndex]);
                }
            }
        }
    }

    void SetObjectColor(Color _color)
    {
        if(rend != null)
            rend.material.SetColor("_Color", _color);
    }
    
    void OnDestroy()
    {
        colorManager.colorLog.Remove(this);
    }
}