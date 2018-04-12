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

    float NormalizeValue(float _value)
    {
        float temp = (detectionDistance - Mathf.Max(0, _value)) / (detectionDistance + Mathf.Max(0, _value));
        return Mathf.Min(Mathf.Max(0, temp), 1f);
    }
}