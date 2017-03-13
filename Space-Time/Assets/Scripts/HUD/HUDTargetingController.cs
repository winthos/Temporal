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


    //holds the distance values per space on the grid
    public List<float> hazardDists;
    public List<float> pickupDists;

    // targeting icons
    public List<Image> hazardIcons = new List<Image>(9);
    public List<Image> pickupIcons = new List<Image>(9);

    // hazard targeting bars
    public List<Image> hazardR1 = new List<Image>(2);
    public List<Image> hazardR2 = new List<Image>(2);
    public List<Image> hazardR3 = new List<Image>(2);
    public List<Image> hazardCA = new List<Image>(1);
    public List<Image> hazardCB = new List<Image>(1);
    public List<Image> hazardCC = new List<Image>(1);

    // pickups targeting bars
    public List<Image> pickupR1 = new List<Image>(2);
    public List<Image> pickupR2 = new List<Image>(2);
    public List<Image> pickupR3 = new List<Image>(2);
    public List<Image> pickupCA = new List<Image>(1);
    public List<Image> pickupCB = new List<Image>(1);
    public List<Image> pickupCC = new List<Image>(1);


    // Use this for initialization
    void Start ()
    {
        HUDTarget = GetComponent<HUDTargetingController>();
        hazardDists = new List<float>(9);
        pickupDists = new List<float>(9);
        HideAllTargetingElements();
    }

    void HideAllTargetingElements()
    {
        HideImageInList(hazardIcons);
        HideImageInList(pickupIcons);

        HideImageInList(hazardR1);
        HideImageInList(hazardR2);
        HideImageInList(hazardR3);
        HideImageInList(hazardCA);
        HideImageInList(hazardCB);
        HideImageInList(hazardCC);

        HideImageInList(pickupR1);
        HideImageInList(pickupR2);
        HideImageInList(pickupR3);
        HideImageInList(pickupCA);
        HideImageInList(pickupCB);
        HideImageInList(pickupCC);
    }

    void HideImageInList(List<Image> _imgList, float _distance = 0)
    {
        foreach (Image img in _imgList)
        {
            var tempColor = img.color;
            tempColor.a = 0f;
            img.color = tempColor;
        }
    }
    void ShowImageInList(List<Image> _imgList, float _distance = 1f)
    {
        foreach (Image img in _imgList)
        {
            var tempColor = img.color;
            tempColor.a = Mathf.Max(0.5f, NormalizeValue(_distance));
            //tempColor.a = 1f;
            img.color = tempColor;
        }
    }


    // --------------------------------------------------------------------
    // --------------------------HAZARDS-----------------------------------
    // --------------------------------------------------------------------

    // show hazards -----------------------------------------------------//
    public void Hazard1A(float _distance = 0)
    {
        if (_distance > 0)
            //show 1A Hazard
            ShowHazard(_distance, 0, hazardR1, hazardCA);
        else
            HideHazard(_distance, 0, hazardR1, hazardCA);
    }
    public void Hazard1B(float _distance = 0)
    {
        if (_distance > 0)
            //show 1B Hazard
            ShowHazard(_distance, 1, hazardR1, hazardCB);
        else
            HideHazard(_distance, 1, hazardR1, hazardCB);
    }
    public void Hazard1C(float _distance = 0)
    {
        if (_distance > 0)
            //show 1C Hazard
            ShowHazard(_distance, 2, hazardR1, hazardCC);
        else
            HideHazard(_distance, 2, hazardR1, hazardCC);
    }
    public void Hazard2A(float _distance = 0)
    {
        if (_distance > 0)
            //show 2A Hazard
            ShowHazard(_distance, 3, hazardR2, hazardCA);
        else
            HideHazard(_distance, 3, hazardR2, hazardCA);
    }
    public void Hazard2B(float _distance = 0)
    {
        if (_distance > 0)
            //show 2B Hazard
            ShowHazard(_distance, 4, hazardR2, hazardCB);
        else
            HideHazard(_distance, 4, hazardR2, hazardCB);
    }
    public void Hazard2C(float _distance = 0)
    {
        if (_distance > 0)
            //show 2C Hazard
            ShowHazard(_distance, 5, hazardR2, hazardCC);
        else
            HideHazard(_distance, 5, hazardR2, hazardCC);
    }
    public void Hazard3A(float _distance = 0)
    {
        if (_distance > 0)
            //show 3A Hazard
            ShowHazard(_distance, 6, hazardR3, hazardCA);
        else
            HideHazard(_distance, 6, hazardR3, hazardCA);
    }
    public void Hazard3B(float _distance = 0)
    {
        if (_distance > 0)
            //show 3B Hazard
            ShowHazard(_distance, 7, hazardR3, hazardCB);
        else
            HideHazard(_distance, 7, hazardR3, hazardCB);
    }
    public void Hazard3C(float _distance = 0)
    {
        if (_distance > 0)
            //show 3C Hazard
            ShowHazard(_distance, 8, hazardR3, hazardCC);
        else
            HideHazard(_distance, 8, hazardR3, hazardCB);
    }

    void ShowHazard(float _distance, int _index, List<Image> _hRow, List<Image> _hCol)
    {
        var tempColor = hazardIcons[_index].color;
        tempColor.a = Mathf.Max(tempColor.a, NormalizeValue(_distance));
        //tempColor.a = 1f;
        hazardIcons[_index].color = tempColor;

        ShowImageInList(_hRow, _distance);
        ShowImageInList(_hCol, _distance);
    }
    void HideHazard(float _distance, int _index, List<Image> _hRow, List<Image> _hCol)
    {
        var tempColor = hazardIcons[_index].color;
        tempColor.a = 0;
        hazardIcons[_index].color = tempColor;

        HideImageInList(_hRow);
        HideImageInList(_hCol);
    }



    // --------------------------------------------------------------------
    // --------------------------PICKUPS-----------------------------------
    // --------------------------------------------------------------------

    // show pickups -----------------------------------------------------//
    public void Pickup1A(float _distance = 0)
    {
        if (_distance > 0)
            //show 1A Pickup
            ShowPickup(_distance, 0, pickupR1, pickupCA);
        else
            HidePickup(_distance, 0, pickupR1, pickupCA);
    }
    public void Pickup1B(float _distance = 0)
    {
        if (_distance > 0)
            //show 1B Pickup
            ShowPickup(_distance, 1, pickupR1, pickupCB);
        else
            HidePickup(_distance, 1, pickupR1, pickupCB);
    }
    public void Pickup1C(float _distance = 0)
    {
        if (_distance > 0)
            //show 1C Pickup
            ShowPickup(_distance, 2, pickupR1, pickupCC);
        else
            HidePickup(_distance, 2, pickupR1, pickupCC);
    }
    public void Pickup2A(float _distance = 0)
    {
        if (_distance > 0)
            //show 2A Pickup
            ShowPickup(_distance, 3, pickupR2, pickupCA);
        else
            HidePickup(_distance, 3, pickupR2, pickupCA);
    }
    public void Pickup2B(float _distance = 0)
    {
        if (_distance > 0)
            //show 2B Pickup
            ShowPickup(_distance, 4, pickupR2, pickupCB);
        else
            HidePickup(_distance, 4, pickupR2, pickupCB);
    }
    public void Pickup2C(float _distance = 0)
    {
        if (_distance > 0)
            //show 2C Pickup
            ShowPickup(_distance, 5, pickupR2, pickupCC);
        else
            HidePickup(_distance, 5, pickupR2, pickupCC);
    }
    public void Pickup3A(float _distance = 0)
    {
        if (_distance > 0)
            //show 3A Pickup
            ShowPickup(_distance, 6, pickupR3, pickupCA);
        else
            HidePickup(_distance, 6, pickupR3, pickupCA);
    }
    public void Pickup3B(float _distance = 0)
    {
        if (_distance > 0)
            //show 3B Pickup
            ShowPickup(_distance, 7, pickupR3, pickupCB);
        else
            HidePickup(_distance, 7, pickupR3, pickupCB);
    }
    public void Pickup3C(float _distance = 0)
    {
        if (_distance > 0)
            //show 3C Pickup
            ShowPickup(_distance, 8, pickupR3, pickupCC);
        else
            HidePickup(_distance, 8, pickupR3, pickupCB);
    }

    void ShowPickup(float _distance, int _index, List<Image> _hRow, List<Image> _hCol)
    {
        var tempColor = pickupIcons[_index].color;
        tempColor.a = Mathf.Max(tempColor.a, NormalizeValue(_distance));
        //tempColor.a = 1f;
        pickupIcons[_index].color = tempColor;

        ShowImageInList(_hRow, _distance);
        ShowImageInList(_hCol, _distance);
    }
    void HidePickup(float _distance, int _index, List<Image> _hRow, List<Image> _hCol)
    {
        var tempColor = pickupIcons[_index].color;
        tempColor.a = 0;
        pickupIcons[_index].color = tempColor;

        HideImageInList(_hRow);
        HideImageInList(_hCol);
    }


    float NormalizeValue(float _value)
    {
        float temp = (detectionDistance - Mathf.Max(0, _value)) / (detectionDistance + Mathf.Max(0, _value));
        return Mathf.Max(0, temp);
        //return 0.5f;
    }
}

enum IncomingType
{
    hazard, pickup, none
}