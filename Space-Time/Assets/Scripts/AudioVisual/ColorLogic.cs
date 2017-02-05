////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//  Goes on every visible object in the game
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
public class ColorLogic : MonoBehaviour
{
    Renderer rend;
    Color previousColor;
    Color currentColor;
    Color nextColor;

    float transitionTime;
    bool colorFade = false;

    private void Awake()
    {
        ColorManager.GetInstance().colorLog.Add(this);
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateObjectWithCurrentPalette();
        //ColorManager.GetInstance().GetPaletteName();
    }
    /*
    void Update()
    {
        if(colorFade)
        {
            currentColor = Color.Lerp(currentColor, nextColor, transitionTime);
            print(currentColor);
            rend.material.SetColor("_Color", currentColor);
            if (currentColor == nextColor)
                colorFade = false;
        }
    }
    */

    void SetObjectColor(Color _color, bool _fade = false, float _transitionTime = 1f)
    {
        if (rend != null)
        {
            if (_fade)
            {
                transitionTime = _transitionTime;
                previousColor = rend.material.color;
                nextColor = _color;
                colorFade = true;
                //StartCoroutine(LerpColor(_transitionTime));
            }
            else
            {
                colorFade = false;
                rend.material.SetColor("_Color", _color);
            }
        }
    }

    /*
    IEnumerator LerpColor(float _time)
    {
        currentColor = previousColor;
        while(currentColor != nextColor)
        {
            currentColor = Color.Lerp(currentColor, nextColor, _time);
            print(currentColor);
            rend.material.SetColor("_Color", currentColor);
        }
        yield return 0;
    }
    */

    // sets all objects to chosen palette
    public void UpdateObjectWithCurrentPalette(bool _instantly = true)
    {
        switch (gameObject.tag)
        {
            case "Player":
            case "enemy1":
            case "enemy2":
            case "rift":
            case "planet":
            case "satellite":
                //SetObjectColor(ColorManager.GetInstance().GetColor(gameObject.tag), true, 1);
                break;
            default:
                break;
        }

    }

    void OnDestroy()
    {
        //ColorManager.GetInstance().colorLog.Remove(this);
    }
}