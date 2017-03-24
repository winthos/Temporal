////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class HUDPulseController : MonoBehaviour
{
    public static HUDPulseController pulseControl;

    [SerializeField]
    GameObject healthUI;
    [SerializeField]
    GameObject timeUI;
    [SerializeField]
    GameObject topLeftUI;
    [SerializeField]
    GameObject topRightUI;
    [SerializeField]
    GameObject topCenterUI;

    int numOfPulses = 0;
    float uniformPulseDelay = 0f;


    private void Awake()
    {
        pulseControl = GetComponent<HUDPulseController>();
    }

    private void Update()
    {
        /*
        //testing
        if (Input.GetKeyUp(KeyCode.M))
            PulseHealthUI();
            */
    }

    public void PulseTopLeftUI()
    {
        StartCoroutine(topLeftUI.GetComponent<ElementPulse>().CreatePulse(numOfPulses, uniformPulseDelay));
    }

    public void PulseTopCenterUI()
    {
        StartCoroutine(topCenterUI.GetComponent<ElementPulse>().CreatePulse(numOfPulses, uniformPulseDelay));
    }

    public void PulseTopRightUI()
    {
        StartCoroutine(topRightUI.GetComponent<ElementPulse>().CreatePulse(numOfPulses, uniformPulseDelay));
    }

    public void PulseTimeUI()
    {
        StartCoroutine(timeUI.GetComponent<ElementPulse>().CreatePulse(numOfPulses, uniformPulseDelay));
    }

    public void PulseHealthUI()
    {
        print("health pulse");
        StartCoroutine(healthUI.GetComponent<ElementPulse>().CreatePulse(numOfPulses, uniformPulseDelay));
    }
}
