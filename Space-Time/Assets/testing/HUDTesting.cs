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
    float waitTime = 0.5f;

    //public Text mult;
    

    // Use this for initialization
    void Start()
    {
        if (HUDTestOn)
        {
            HUDTargetingController.HUDTarget.detectionDistance = 10;
            ResetArrays();

            HUDStageController.HUDstage.StageUp(0);
            currentCoroutine = StartCoroutine(CycleThroughHazards());

            /*
            spaceHazards = new List<float> { 0, 1, 0, 0, 1, 0, 0, 0, 0 };
            spacePickups = new List<float> { 0, 0, 0, 0, 1, 1, 0, 0, 0 };
            UpdateHazardSpaces();
            UpdatePickupSpaces();
            */
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
                currentCoroutine = StartCoroutine(CycleThroughHazards());
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
            spaceHazards[i] = 0.9f;
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
            spacePickups[i] = 0.9f;
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
        
        spaceHazards[2] = 0.9f;
        spacePickups[2] = 0.7f;
        UpdateBoth();
        yield return new WaitForSeconds(waitTime);
        spaceHazards[2] = 0;
        spacePickups[2] = 0;
        UpdateBoth();

        spaceHazards[8] = 0.9f;
        spacePickups[8] = 0.7f;
        UpdateBoth();
        yield return new WaitForSeconds(waitTime);
        spaceHazards[8] = 0;
        spacePickups[8] = 0;
        UpdateBoth();

        /*
        for (int i = 0; i < 9; i++)
        {
            spaceHazards[i] = 0.9f;
            spacePickups[i] = 0.7f;
            UpdateBoth();
            yield return new WaitForSeconds(waitTime);
            spaceHazards[i] = 0;
            spacePickups[i] = 0;
            UpdateBoth();
        }
        */
        ResetArrays();
        UpdateSpaces();

        Debug.Log("dual cycle done");

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

        /*
        yield return new WaitForSeconds(waitTime * 2);

        HUDStageController.HUDstage.StageUp(3);
        yield return new WaitForSeconds(waitTime);
        HUDStageController.HUDstage.StageUp(2);
        yield return new WaitForSeconds(waitTime);
        HUDStageController.HUDstage.StageUp(1);*/
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
            spaceHazards[i] = 0.9f;
            spacePickups[i] = 0.7f;
        }
        UpdateBoth();
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

    void UpdateBoth()
    {
        HUDTargetingController.HUDTarget.dualSpaces[0].ShowSpaces(spaceHazards[0], spacePickups[0]);
        HUDTargetingController.HUDTarget.dualSpaces[1].ShowSpaces(spaceHazards[1], spacePickups[1]);
        HUDTargetingController.HUDTarget.dualSpaces[2].ShowSpaces(spaceHazards[2], spacePickups[2]);
        HUDTargetingController.HUDTarget.dualSpaces[3].ShowSpaces(spaceHazards[3], spacePickups[3]);
        HUDTargetingController.HUDTarget.dualSpaces[4].ShowSpaces(spaceHazards[4], spacePickups[4]);
        HUDTargetingController.HUDTarget.dualSpaces[5].ShowSpaces(spaceHazards[5], spacePickups[5]);
        HUDTargetingController.HUDTarget.dualSpaces[6].ShowSpaces(spaceHazards[6], spacePickups[6]);
        HUDTargetingController.HUDTarget.dualSpaces[7].ShowSpaces(spaceHazards[7], spacePickups[7]);
        HUDTargetingController.HUDTarget.dualSpaces[8].ShowSpaces(spaceHazards[8], spacePickups[8]);
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
