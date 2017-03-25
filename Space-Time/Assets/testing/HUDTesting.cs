////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HUDTesting : MonoBehaviour
{
    public bool HUDTestOn = false;

    public List<float> spaceHazards;
    public List<float> spacePickups;

    bool fadingOn;
    bool fadeAlpha;
    Coroutine currentCoroutine;
    float waitTime = 0.3f;

    //public Text mult;
    

    // Use this for initialization
    void Start()
    {
        if (HUDTestOn)
        {
            //HUDTargetingController.HUDTarget.detectionDistance = 10;
            ResetArrays();

            HUDStageController.HUDstage.StageUp(0);
            currentCoroutine = StartCoroutine(CycleThroughHazards());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HUDTestOn)
        {
            if(Input.GetKeyUp(KeyCode.Z))
            {
                if(currentCoroutine != null)
                    StopCoroutine(currentCoroutine);

                ResetArrays();
                UpdateBoth();
                currentCoroutine = StartCoroutine(CycleThroughBoth());
            }

        }
        else
        {
            ResetArrays();

            StopAllCoroutines();
        }
    }

    IEnumerator CycleThroughHazards()
    {
        yield return new WaitForSeconds(waitTime/2);
        for (int i = 0; i < spaceHazards.Count; i++)
        {
            spaceHazards[i] = 1f;
            UpdateHazardSpace(i);
            yield return new WaitForSeconds(waitTime);
            spaceHazards[i] = 0;
            UpdateHazardSpace(i);
        }

        Debug.Log("hazard cycle done");

        currentCoroutine = StartCoroutine(CycleThroughPickups());
    }
    

    IEnumerator CycleThroughPickups()
    {
        yield return new WaitForSeconds(waitTime / 2);
        for (int i = 0; i < spacePickups.Count; i++)
        {
            spacePickups[i] = 1f;
            UpdatePickupSpace(i);
            yield return new WaitForSeconds(waitTime);
            spacePickups[i] = 0;
            UpdatePickupSpace(i);
        }

        Debug.Log("pickup cycle done");

        currentCoroutine = StartCoroutine(CycleThroughBoth());
        //currentCoroutine = StartCoroutine(CycleThroughStages());
    }
    
    IEnumerator CycleThroughBoth()
    {
        yield return new WaitForSeconds(waitTime / 2);
        
        for (int i = 0; i < 9; i++)
        {
            spaceHazards[i] = 1f;
            spacePickups[i] = 1f;
            UpdateBoth();
            yield return new WaitForSeconds(waitTime);
            spaceHazards[i] = 0;
            spacePickups[i] = 0;
            UpdateBoth();
        }

        ResetArrays();
        UpdateSpaces();

        currentCoroutine = StartCoroutine(CycleThroughStages());
    }

    IEnumerator CycleThroughStages()
    {
        yield return new WaitForSeconds(waitTime / 2);
        ShowAllIcons();
        waitTime = 1.3f;

        HUDStageController.HUDstage.StageUp(1);
        yield return new WaitForSeconds(waitTime);
        HUDStageController.HUDstage.StageUp(2);
        yield return new WaitForSeconds(waitTime);
        HUDStageController.HUDstage.StageUp(3);
        yield return new WaitForSeconds(waitTime);
        HUDStageController.HUDstage.StageUp(4);
        yield return new WaitForSeconds(waitTime);
        HUDStageController.HUDstage.StageUp(0);


        yield return new WaitForSeconds(waitTime);
        ResetArrays();
        UpdateSpaces();
    }

    void UpdateSpaces()
    {
        UpdateHazardSpaces();
        UpdatePickupSpaces();
    }

    void ShowAllIcons()
    {
        for (int i = 0; i < 9; i++)
        {
            spaceHazards[i] = 1f;
            spacePickups[i] = 1f;
        }
        UpdateBoth();
    }

    void UpdateHazardSpaces()
    {
        for (int h = 0; h < spaceHazards.Count; h++)
            HUDTargetingController.HUDTarget.HazardSpace(h, spaceHazards[h]);
        
    }

    void UpdatePickupSpaces()
    {

        for (int p = 0; p < spacePickups.Count; p++)
            HUDTargetingController.HUDTarget.PickupSpace(p, spaceHazards[p]);
    }

    void UpdateBoth()
    {
        UpdateHazardSpaces();
        UpdatePickupSpaces();
    }

    void UpdateHazardSpace(int _index)
    {
        HUDTargetingController.HUDTarget.HazardSpace(_index, spaceHazards[_index]);
    }


    void UpdatePickupSpace(int _index)
    {
        HUDTargetingController.HUDTarget.PickupSpace(_index, spacePickups[_index]);
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
