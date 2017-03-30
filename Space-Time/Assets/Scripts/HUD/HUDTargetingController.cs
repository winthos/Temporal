////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class HUDTargetingController : MonoBehaviour
{
    public static HUDTargetingController HUDTarget;

    float detectionDistance = 200f;

    // targeting icons
    [SerializeField]
    List<GameObject> hazTemp;
    [SerializeField]
    List<GameObject> picTemp;
    [HideInInspector]
    public List<CanvasGroup> hazardSpaces;
    [HideInInspector]
    public List<CanvasGroup> pickupSpaces;

    private void Awake()
    {
        HUDTarget = GetComponent<HUDTargetingController>();

        hazardSpaces = new List<CanvasGroup>();
        pickupSpaces = new List<CanvasGroup>();


    //hazard space information
}

    // Use this for initialization
    void Start()
    {
        /*
        List<GameObject> hazTemp = GameObject.FindGameObjectsWithTag("TargetHazard").ToList<GameObject>();
        List<GameObject> picTemp = GameObject.FindGameObjectsWithTag("TargetPickup").ToList<GameObject>();

        */
        for (int h = 0; h < hazTemp.Count; h++)
            hazardSpaces.Add(hazTemp[h].GetComponent<CanvasGroup>());
        
        for (int p = 0; p < picTemp.Count; p++)
            pickupSpaces.Add(picTemp[p].GetComponent<CanvasGroup>());

        /*
        hazTemp.Clear();
        picTemp.Clear();
        */
        HideAllTargetingElements();
    }

    void HideAllTargetingElements()
    {
        foreach (CanvasGroup space in hazardSpaces)
            space.alpha = 0;
        foreach (CanvasGroup space in pickupSpaces)
            space.alpha = 0;
    }

    // --------------------------------------------------------------------
    // --------------------------HAZARDS-----------------------------------
    // --------------------------------------------------------------------

    // show hazards -----------------------------------------------------//

    public void HazardSpace(int _index, float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[_index].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[_index].alpha = 0;
    }
    /*
    public void Hazard1A(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[0].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[0].alpha = NormalizeValue(0);
    }
    public void Hazard1B(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[1].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[1].alpha = NormalizeValue(0);
    }
    public void Hazard1C(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[2].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[2].alpha = NormalizeValue(0);
    }
    public void Hazard2A(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[3].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[3].alpha = NormalizeValue(0);
    }
    public void Hazard2B(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[4].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[4].alpha = NormalizeValue(0);
    }
    public void Hazard2C(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[5].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[5].alpha = NormalizeValue(0);
    }
    public void Hazard3A(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[6].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[6].alpha = NormalizeValue(0);
    }
    public void Hazard3B(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[7].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[7].alpha = NormalizeValue(0);
    }
    public void Hazard3C(float _distance = 0)
    {
        if (_distance > 0)
            hazardSpaces[8].alpha = NormalizeValue(_distance);
        else
            hazardSpaces[8].alpha = NormalizeValue(0);
    }
    */


    // --------------------------------------------------------------------
    // --------------------------PICKUPS-----------------------------------
    // --------------------------------------------------------------------

    // show pickups -----------------------------------------------------//
    public void PickupSpace(int _index, float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[_index].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[_index].alpha = 0;
    }
    /*
    public void Pickup1A(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[0].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[0].alpha = 0;
    }
    public void Pickup1B(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[1].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[1].alpha = NormalizeValue(0);
    }
    public void Pickup1C(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[2].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[2].alpha = NormalizeValue(0);
    }
    public void Pickup2A(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[3].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[3].alpha = NormalizeValue(0);
    }
    public void Pickup2B(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[4].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[4].alpha = NormalizeValue(0);
    }
    public void Pickup2C(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[5].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[5].alpha = NormalizeValue(0);
    }
    public void Pickup3A(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[6].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[6].alpha = NormalizeValue(0);
    }
    public void Pickup3B(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[7].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[7].alpha = NormalizeValue(0);
    }
    public void Pickup3C(float _distance = 0)
    {
        if (_distance > 0)
            pickupSpaces[8].alpha = NormalizeValue(_distance);
        else
            pickupSpaces[8].alpha = NormalizeValue(0);
    }
    */

    float NormalizeValue(float _value)
    {
        float temp = (detectionDistance - Mathf.Max(0, _value)) / (detectionDistance + Mathf.Max(0, _value));
        return Mathf.Min(Mathf.Max(0, temp), 1f);
        //return 0.5f;
    }
}