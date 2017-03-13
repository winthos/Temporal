////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUDTargetingController : MonoBehaviour
{
    public static HUDTargetingController HUDTarget;

    public float detectionDistance = 200f;

    // targeting icons
    public List<Image> hazardIcons = new List<Image>(9);
    public List<Image> pickupIcons = new List<Image>(9);

    public Image hLeftBar1;
    public Image hLeftBar2;
    public Image hLeftBar3;
    public Image hRghtBar1;
    public Image hRghtBar2;
    public Image hRghtBar3;
    public Image hColmBarA;
    public Image hColmBarB;
    public Image hColmBarC;

    public Image pLeftBar1;
    public Image pLeftBar2;
    public Image pLeftBar3;
    public Image pRghtBar1;
    public Image pRghtBar2;
    public Image pRghtBar3;
    public Image pColmBarA;
    public Image pColmBarB;
    public Image pColmBarC;

    /*
    public List<Image> hLeftBars = new List<Image>(3);
    public List<Image> hRghtBars = new List<Image>(3);
    public List<Image> hColmBars = new List<Image>(3);

    public List<Image> pLeftBars = new List<Image>(3);
    public List<Image> pRghtBars = new List<Image>(3);
    public List<Image> pColmBars = new List<Image>(3);*/

    List<GridInfo> hazardSpaces = new List<GridInfo>(9);
    List<GridInfo> pickupSpaces = new List<GridInfo>(9);


    // Use this for initialization
    void Start()
    {
        HUDTarget = GetComponent<HUDTargetingController>();

        //hazard space information
        hazardSpaces.Add(new GridInfo(hazardIcons[0], hLeftBar1, hRghtBar1, hColmBarA));
        hazardSpaces.Add(new GridInfo(hazardIcons[1], hLeftBar1, hRghtBar1, hColmBarB));
        hazardSpaces.Add(new GridInfo(hazardIcons[2], hLeftBar1, hRghtBar1, hColmBarC));
        hazardSpaces.Add(new GridInfo(hazardIcons[3], hLeftBar2, hRghtBar2, hColmBarA));
        hazardSpaces.Add(new GridInfo(hazardIcons[4], hLeftBar2, hRghtBar2, hColmBarB));
        hazardSpaces.Add(new GridInfo(hazardIcons[5], hLeftBar2, hRghtBar2, hColmBarC));
        hazardSpaces.Add(new GridInfo(hazardIcons[6], hLeftBar3, hRghtBar3, hColmBarA));
        hazardSpaces.Add(new GridInfo(hazardIcons[7], hLeftBar3, hRghtBar3, hColmBarB));
        hazardSpaces.Add(new GridInfo(hazardIcons[8], hLeftBar3, hRghtBar3, hColmBarC));

        //pickup space information
        pickupSpaces.Add(new GridInfo(pickupIcons[0], pLeftBar1, pRghtBar1, pColmBarA));
        pickupSpaces.Add(new GridInfo(pickupIcons[1], pLeftBar1, pRghtBar1, pColmBarB));
        pickupSpaces.Add(new GridInfo(pickupIcons[2], pLeftBar1, pRghtBar1, pColmBarC));
        pickupSpaces.Add(new GridInfo(pickupIcons[3], pLeftBar2, pRghtBar2, pColmBarA));
        pickupSpaces.Add(new GridInfo(pickupIcons[4], pLeftBar2, pRghtBar2, pColmBarB));
        pickupSpaces.Add(new GridInfo(pickupIcons[5], pLeftBar2, pRghtBar2, pColmBarC));
        pickupSpaces.Add(new GridInfo(pickupIcons[6], pLeftBar3, pRghtBar3, pColmBarA));
        pickupSpaces.Add(new GridInfo(pickupIcons[7], pLeftBar3, pRghtBar3, pColmBarB));
        pickupSpaces.Add(new GridInfo(pickupIcons[8], pLeftBar3, pRghtBar3, pColmBarC));

        HideAllTargetingElements();
    }

    void HideAllTargetingElements()
    {
        foreach (GridInfo space in hazardSpaces)
            space.HideSpace();
        foreach (GridInfo space in pickupSpaces)
            space.HideSpace();
    }

    private void Update()
    {
        //hazardSpaces[1].ShowSpace(1);
    }

    // --------------------------------------------------------------------
    // --------------------------HAZARDS-----------------------------------
    // --------------------------------------------------------------------

    // show hazards -----------------------------------------------------//
    public void Hazard1A(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[0].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[0].HideSpace();
    }
    public void Hazard1B(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[1].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[1].HideSpace();
    }
    public void Hazard1C(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[2].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[2].HideSpace();
    }
    public void Hazard2A(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[3].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[3].HideSpace();
    }
    public void Hazard2B(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[4].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[4].HideSpace();
    }
    public void Hazard2C(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[5].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[5].HideSpace();
    }
    public void Hazard3A(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[6].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[6].HideSpace();
    }
    public void Hazard3B(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[7].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[7].HideSpace();
    }
    public void Hazard3C(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[8].ShowSpace(NormalizeValue(_distance));
        else
            hazardSpaces[8].HideSpace();
    }



    // --------------------------------------------------------------------
    // --------------------------PICKUPS-----------------------------------
    // --------------------------------------------------------------------

    // show pickups -----------------------------------------------------//
    public void Pickup1A(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[0].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[0].HideSpace();
    }
    public void Pickup1B(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[1].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[1].HideSpace();
    }
    public void Pickup1C(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[2].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[2].HideSpace();
    }
    public void Pickup2A(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[3].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[3].HideSpace();
    }
    public void Pickup2B(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[4].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[4].HideSpace();
    }
    public void Pickup2C(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[5].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[5].HideSpace();
    }
    public void Pickup3A(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[6].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[6].HideSpace();
    }
    public void Pickup3B(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[7].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[7].HideSpace();
    }
    public void Pickup3C(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[8].ShowSpace(NormalizeValue(_distance));
        else
            pickupSpaces[8].HideSpace();
    }

    float NormalizeValue(float _value)
    {
        float temp = (detectionDistance - Mathf.Max(0, _value)) / (detectionDistance + Mathf.Max(0, _value));
        return Mathf.Min(Mathf.Max(0, temp), 1f);
        //return 0.5f;
    }
}

[System.Serializable]
public class GridInfo
{
    public Image icon;
    public Image rowLt;
    public Image rowRt;
    public Image colm;

    public bool visible;

    public GridInfo()
    {
        icon = null;
        rowLt = null;
        rowRt = null;
        colm = null;

        visible = false;
    }
    public GridInfo(Image _icon, Image _rowLt, Image _rowRt, Image _colm)
    {
        icon = _icon;
        rowLt = _rowLt;
        rowRt = _rowRt;
        colm = _colm;

        visible = false;
    }

    public void ShowSpace(float _alpha)
    {
        ImgAlpha(icon, _alpha);

        ImgAlpha(rowLt, _alpha);
        ImgAlpha(rowRt, _alpha);
        ImgAlpha(colm, _alpha);
    }

    public void HideSpace()
    {
        ImgAlpha(icon, 0, true);

        ImgAlpha(rowLt, 0, true);
        ImgAlpha(rowRt, 0, true);
        ImgAlpha(colm, 0, true);
    }

    void ImgAlpha(Image _img, float _alpha, bool _hide = false)
    {
        var tempColor = _img.color;

        if (_hide)
            tempColor.a = 0;
        else
            tempColor.a = Mathf.Max(tempColor.a, _alpha);
        _img.color = tempColor;
    }
}