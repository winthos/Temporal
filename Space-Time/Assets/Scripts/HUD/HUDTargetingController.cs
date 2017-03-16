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

    public List<Image> hLeftBars = new List<Image>(3);
    public List<Image> hRghtBars = new List<Image>(3);
    public List<Image> hColmBars = new List<Image>(3);

    public List<Image> pLeftBars = new List<Image>(3);
    public List<Image> pRghtBars = new List<Image>(3);
    public List<Image> pColmBars = new List<Image>(3);

    public List<GridInfo> hazardSpaces = new List<GridInfo>(9);
    public List<GridInfo> pickupSpaces = new List<GridInfo>(9);
    public List<GridInfo2> dualSpaces  = new List<GridInfo2>(9);

    private void Awake()
    {
        HUDTarget = GetComponent<HUDTargetingController>();

        //hazard space information
        hazardSpaces.Add(new GridInfo(hazardIcons[0], hLeftBars[0], hRghtBars[0], hColmBars[0]));
        hazardSpaces.Add(new GridInfo(hazardIcons[1], hLeftBars[0], hRghtBars[0], hColmBars[1]));
        hazardSpaces.Add(new GridInfo(hazardIcons[2], hLeftBars[0], hRghtBars[0], hColmBars[2]));
        hazardSpaces.Add(new GridInfo(hazardIcons[3], hLeftBars[1], hRghtBars[1], hColmBars[0]));
        hazardSpaces.Add(new GridInfo(hazardIcons[4], hLeftBars[1], hRghtBars[1], hColmBars[1]));
        hazardSpaces.Add(new GridInfo(hazardIcons[5], hLeftBars[1], hRghtBars[1], hColmBars[2]));
        hazardSpaces.Add(new GridInfo(hazardIcons[6], hLeftBars[2], hRghtBars[2], hColmBars[0]));
        hazardSpaces.Add(new GridInfo(hazardIcons[7], hLeftBars[2], hRghtBars[2], hColmBars[1]));
        hazardSpaces.Add(new GridInfo(hazardIcons[8], hLeftBars[2], hRghtBars[2], hColmBars[2]));

        //pickup space information
        pickupSpaces.Add(new GridInfo(pickupIcons[0], pLeftBars[0], pRghtBars[0], pColmBars[0]));
        pickupSpaces.Add(new GridInfo(pickupIcons[1], pLeftBars[0], pRghtBars[0], pColmBars[1]));
        pickupSpaces.Add(new GridInfo(pickupIcons[2], pLeftBars[0], pRghtBars[0], pColmBars[2]));
        pickupSpaces.Add(new GridInfo(pickupIcons[3], pLeftBars[1], pRghtBars[1], pColmBars[0]));
        pickupSpaces.Add(new GridInfo(pickupIcons[4], pLeftBars[1], pRghtBars[1], pColmBars[1]));
        pickupSpaces.Add(new GridInfo(pickupIcons[5], pLeftBars[1], pRghtBars[1], pColmBars[2]));
        pickupSpaces.Add(new GridInfo(pickupIcons[6], pLeftBars[2], pRghtBars[2], pColmBars[0]));
        pickupSpaces.Add(new GridInfo(pickupIcons[7], pLeftBars[2], pRghtBars[2], pColmBars[1]));
        pickupSpaces.Add(new GridInfo(pickupIcons[8], pLeftBars[2], pRghtBars[2], pColmBars[2]));

        dualSpaces.Add(new GridInfo2(hazardSpaces[0], pickupSpaces[0]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[1], pickupSpaces[1]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[2], pickupSpaces[2]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[3], pickupSpaces[3]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[4], pickupSpaces[4]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[5], pickupSpaces[5]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[6], pickupSpaces[6]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[7], pickupSpaces[7]));
        dualSpaces.Add(new GridInfo2(hazardSpaces[8], pickupSpaces[8]));
    }

    // Use this for initialization
    void Start()
    {

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

        if (_alpha > 0)
            visible = true;
    }

    public void HideSpace()
    {
        ImgAlpha(icon, 0, true);

        ImgAlpha(rowLt, 0, true);
        ImgAlpha(rowRt, 0, true);
        ImgAlpha(colm, 0, true);
        
        visible = false;
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

[System.Serializable]
public class GridInfo2
{
    public Image icon;
    public Image rowLt;
    public Image rowRt;
    public Image colm;
    public bool visible;

    public Image icon2;
    public Image rowLt2;
    public Image rowRt2;
    public Image colm2;
    public bool visible2;

    public GridInfo2()
    {
        icon = null;
        rowLt = null;
        rowRt = null;
        colm = null;
        visible = false;

        icon2 = null;
        rowLt2 = null;
        rowRt2 = null;
        colm2 = null;
        visible2 = false;
    }
    public GridInfo2(GridInfo _hazards, GridInfo _pickups)
    {
        icon = _hazards.icon;
        rowLt = _hazards.rowLt;
        rowRt = _hazards.rowRt;
        colm = _hazards.colm;
        visible = false;

        icon2 = _pickups.icon;
        rowLt2 = _pickups.rowLt;
        rowRt2 = _pickups.rowRt;
        colm2 = _pickups.colm;
        visible2 = false;
    }

    public void ShowSpaces(float _hazardAlpha, float _pickupAlpha)
    {
        if (_hazardAlpha > 0)
        {
            ImgAlpha(icon, _hazardAlpha);
            ImgAlpha(rowLt, _hazardAlpha);
            ImgAlpha(rowRt, _hazardAlpha);
            ImgAlpha(colm, _hazardAlpha);
            if (_hazardAlpha > 0)
                visible = true;
        }
        else
        {
            ImgAlpha(icon, 0, true);
            ImgAlpha(rowLt, 0, true);
            ImgAlpha(rowRt, 0, true);
            ImgAlpha(colm, 0, true);
            visible = false;
        }

        if (_pickupAlpha > 0)
        {
            ImgAlpha(icon2, _pickupAlpha);
            ImgAlpha(rowLt2, _pickupAlpha);
            ImgAlpha(rowRt2, _pickupAlpha);
            ImgAlpha(colm2, _pickupAlpha);
            if (_pickupAlpha > 0)
                visible2 = true;
        }
        else
        {
            ImgAlpha(icon2, 0, true);
            ImgAlpha(rowLt2, 0, true);
            ImgAlpha(rowRt2, 0, true);
            ImgAlpha(colm2, 0, true);
            visible2 = false;
        }
    }

    public void HideSpaces()
    {
        ImgAlpha(icon, 0, true);
        ImgAlpha(rowLt, 0, true);
        ImgAlpha(rowRt, 0, true);
        ImgAlpha(colm, 0, true);
        visible = false;

        ImgAlpha(icon2, 0, true);
        ImgAlpha(rowLt2, 0, true);
        ImgAlpha(rowRt2, 0, true);
        ImgAlpha(colm2, 0, true);
        visible2 = false;
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