/*
 * Written by Kaila Harris
 * Goes on every visible object in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorLogic : MonoBehaviour
{
    [SerializeField]
    bool RandomizedColors = false;

    Renderer rend; //Renderer of our Cube
    float transitionTime = 5f;

    GameObject ColorManager;
    ColorPalette pinkTriad;

    void Start()
    {
        ColorManager = GameObject.Find("LevelGlobals");
        pinkTriad = ColorManager.GetComponent<ColorManager>().palPinkTriad;

        rend = GetComponent<Renderer>();

        if (gameObject.tag == "Planet")
            SetPlanetColors(pinkTriad.GetPlanetColors());

    }

    void Update()
    {
    }

    void SetPlanetColors(List<Color> _list)
    {
        int planCol = Random.Range(0, (_list.Count));
        SetObjectColor(_list[planCol]);
        _list.RemoveAt(planCol);

        foreach (Transform child in transform)
        {
            int num = Random.Range(0, (_list.Count));
            child.gameObject.GetComponent<ColorLogic>().SetObjectColor(_list[num]);
        }
    }

    void SetObjectColor(Color _color)
    {
        rend.material.SetColor("_Color", _color);
    }
}