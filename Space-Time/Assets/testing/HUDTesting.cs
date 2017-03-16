using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDTesting : MonoBehaviour
{
    public bool HUDTestOn = false;

    public List<float> spaceHazards;
    public List<float> spacePickups;

    bool fading;
    Coroutine currentCoroutine;
    float temp;

    private void Awake()
    {
        //spaceHazards = new List<float> { 0, 1, 0, 0, 1, 0, 0, 0, 0 };
        //spacePickups = new List<float> { 0, 0, 0, 0, 1, 1, 0, 0, 0 };
    }

    // Use this for initialization
    void Start()
    {
        if (HUDTestOn)
        {
            HUDTargetingController.HUDTarget.detectionDistance = 10;
            temp = 0;
            ResetArrays();

            currentCoroutine = StartCoroutine(CycleThroughHazards());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (HUDTestOn)
        {
            //UpdateArraysAndSpaces();

            //currentCoroutine = StartCoroutine(CycleThroughHazards());
        }
        else
        {
            ResetArrays();

            StopAllCoroutines();
        }
    }

    IEnumerator CycleThroughHazards()
    {
        ResetHazards();
        for (int i = 0; i < spaceHazards.Count; i++)
        {
            spaceHazards[i] = 0.9f;
            UpdateHazardSpace(i);
            yield return new WaitForSeconds(1);
            spaceHazards[i] = 0;
            yield return new WaitForSeconds(0.3f);
            UpdateHazardSpace(i);
        }

        currentCoroutine = StartCoroutine(CycleThroughPickups());
    }
    
    IEnumerator CycleThroughPickups()
    {
        for (int i = 0; i < spacePickups.Count; i++)
        {
            spacePickups[i] = 0.9f;
            UpdatePickupSpace(i);
            yield return new WaitForSeconds(1);
            spacePickups[i] = 0;
            yield return new WaitForSeconds(0.3f);
            UpdatePickupSpace(i);
        }
    }
    

    IEnumerator CycleThrough(List<float> _spaces)
    {
        yield return 0;
    }

    void UpdateArraysAndSpaces()
    {
        UpdateHazardSpaces();
        UpdatePickupSpaces();
    }

    void UpdateHazardSpaces()
    { 
        HUDTargetingController.HUDTarget.Hazard1A(spaceHazards[0]);
        HUDTargetingController.HUDTarget.Hazard1B(spaceHazards[1]);
        HUDTargetingController.HUDTarget.Hazard1C(spaceHazards[2]);
        HUDTargetingController.HUDTarget.Hazard2A(spaceHazards[3]);
        HUDTargetingController.HUDTarget.Hazard2B(spaceHazards[4]);
        HUDTargetingController.HUDTarget.Hazard2C(spaceHazards[5]);
        HUDTargetingController.HUDTarget.Hazard3A(spaceHazards[6]);
        HUDTargetingController.HUDTarget.Hazard3B(spaceHazards[7]);
        HUDTargetingController.HUDTarget.Hazard3C(spaceHazards[8]);
    }

    void UpdatePickupSpaces()
    {
        HUDTargetingController.HUDTarget.Pickup1A(spacePickups[0]);
        HUDTargetingController.HUDTarget.Pickup1B(spacePickups[1]);
        HUDTargetingController.HUDTarget.Pickup1C(spacePickups[2]);
        HUDTargetingController.HUDTarget.Pickup2A(spacePickups[3]);
        HUDTargetingController.HUDTarget.Pickup2B(spacePickups[4]);
        HUDTargetingController.HUDTarget.Pickup2C(spacePickups[5]);
        HUDTargetingController.HUDTarget.Pickup3A(spacePickups[6]);
        HUDTargetingController.HUDTarget.Pickup3B(spacePickups[7]);
        HUDTargetingController.HUDTarget.Pickup3C(spacePickups[8]);
    }

    void UpdateHazardSpace(int _index)
    {
        if (_index == 0)
            HUDTargetingController.HUDTarget.Hazard1A(spaceHazards[0]);
        else if (_index == 1)
            HUDTargetingController.HUDTarget.Hazard1B(spaceHazards[1]);
        else if (_index == 2)
            HUDTargetingController.HUDTarget.Hazard1C(spaceHazards[2]);
        else if (_index == 3)
            HUDTargetingController.HUDTarget.Hazard2A(spaceHazards[3]);
        else if (_index == 4)
            HUDTargetingController.HUDTarget.Hazard2B(spaceHazards[4]);
        else if (_index == 5)
            HUDTargetingController.HUDTarget.Hazard2C(spaceHazards[5]);
        else if (_index == 6)
            HUDTargetingController.HUDTarget.Hazard3A(spaceHazards[6]);
        else if (_index == 7)
            HUDTargetingController.HUDTarget.Hazard3B(spaceHazards[7]);
        else if (_index == 8)
            HUDTargetingController.HUDTarget.Hazard3C(spaceHazards[8]);
    }


    void UpdatePickupSpace(int _index)
    {
        if (_index == 0)
            HUDTargetingController.HUDTarget.Pickup1A(spacePickups[0]);
        else if (_index == 1)
            HUDTargetingController.HUDTarget.Pickup1B(spacePickups[1]);
        else if (_index == 2)
            HUDTargetingController.HUDTarget.Pickup1C(spacePickups[2]);
        else if (_index == 3)
            HUDTargetingController.HUDTarget.Pickup2A(spacePickups[3]);
        else if (_index == 4)
            HUDTargetingController.HUDTarget.Pickup2B(spacePickups[4]);
        else if (_index == 5)
            HUDTargetingController.HUDTarget.Pickup2C(spacePickups[5]);
        else if (_index == 6)
            HUDTargetingController.HUDTarget.Pickup3A(spacePickups[6]);
        else if (_index == 7)
            HUDTargetingController.HUDTarget.Pickup3B(spacePickups[7]);
        else if (_index == 8)
            HUDTargetingController.HUDTarget.Pickup3C(spacePickups[8]);

    }

    void ResetArrays()
    {
        ResetHazards();
        ResetPickups();
    }

    void ResetHazards()
    {
        spaceHazards.Clear();
        spaceHazards = new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    void ResetPickups()
    {
        spacePickups.Clear();
        spacePickups = new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }
}
