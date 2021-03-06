﻿////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris, and Winson a little bit
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class HUDStageController : MonoBehaviour
{
    public static HUDStageController HUDstage;

    public bool TestModeOn = false;

    List<GameObject> stage0 = new List<GameObject>();
    List<GameObject> stage1 = new List<GameObject>();
    List<GameObject> stage2 = new List<GameObject>();
    List<GameObject> stage3 = new List<GameObject>();
    List<GameObject> stage4 = new List<GameObject>();

    List<GameObject> pulseItems = new List<GameObject>();

    public static int currentStage = 0;
    public static int previousStage = 0;
    //public int nextStage = 0;

    private float TimeBetweenPulsesKailaYouMadeMeDoThis = 0.005f;

    private void Awake()
    {
        HUDstage = GetComponent<HUDStageController>();
    }

    // Use this for initialization
    void Start()
    {
        currentStage = 0;
        previousStage = 0;

        stage0 = GameObject.FindGameObjectsWithTag("stage0").ToList<GameObject>();
        stage1 = GameObject.FindGameObjectsWithTag("stage1").ToList<GameObject>();
        stage2 = GameObject.FindGameObjectsWithTag("stage2").ToList<GameObject>();
        stage3 = GameObject.FindGameObjectsWithTag("stage3").ToList<GameObject>();
        stage4 = GameObject.FindGameObjectsWithTag("stage4").ToList<GameObject>();

        pulseItems = GameObject.FindGameObjectsWithTag("pulse").ToList<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        //WINSON WAS HERE, In case... you didn't realize it... yeah
        if(CameraController.GetPTime() == true)
        {
            if(TimeBetweenPulsesKailaYouMadeMeDoThis > 0)
            {
                TimeBetweenPulsesKailaYouMadeMeDoThis -= Time.deltaTime;
                
            }

            if(TimeBetweenPulsesKailaYouMadeMeDoThis <= 0)
            {
                HUDStageController.HUDstage.PulseTime();
                TimeBetweenPulsesKailaYouMadeMeDoThis = 0.005f;
            }

        }
        //winson has left the building

        if (!PauseController.Paused())
        {
            if (TestModeOn)
                Testing();

            //RiftStages(Scoring.pickupsCollected);

            //if (currentStage != nextStage)
                //StartCoroutine(UpdateStages());
        }
    }


    public void CreatePulses()
    {
        if (pulseItems.Count != 0)
        {
            foreach (GameObject o in pulseItems)
            {
                if (o.GetComponent<ElementPulse>() != null)
                    o.GetComponent<ElementPulse>().CreatePulse();
            }
        }
    }

    public void PulseHealth()
    {
        GameObject.Find("Health_outline").GetComponent<ElementPulse>().CreatePulse(3);
    }
    public void PulsePickups()
    {
        GameObject.Find("MultiplierImg_outline").GetComponent<ElementPulse>().CreatePulse(3);
    }
    public void PulseTopRight()
    {
        GameObject.Find("ScoreImg_outline").GetComponent<ElementPulse>().CreatePulse(3);
    }
    public void PulseTopLeft()
    {
        GameObject.Find("SpeedImg_outline").GetComponent<ElementPulse>().CreatePulse(3);
    }
    public void PulseTime()
    {
        GameObject.Find("TimeOutline").GetComponent<ElementPulse>().CreatePulse(3);
    }
    

    public void UpdateStages(int _rifts)
    {
        if(_rifts >= 30)
            currentStage = 4;
        if (_rifts < 30)
            currentStage = 3;
        if (_rifts < 25)
            currentStage = 2;
        if (_rifts < 20)
            currentStage = 1;
        if (_rifts < 10)
            currentStage = 0;
        
        print(currentStage);

        if (currentStage != previousStage || currentStage >= 3)
            StageUp(currentStage);

        previousStage = currentStage;

    }


    public void StageUp(int _stage)
    {
        CreatePulses();
        //SoundHub.PlayStageChange();
        
        switch (_stage)
        {
            case 4:
                Stage4(false);
                goto case 3;
            case 3:
                Stage3(false);
                goto case 2;
            case 2:
                Stage2(false);
                goto case 1;
            case 1:
                Stage1(false);
                goto case 0;
            case 0:
                Stage0(false);
                break;
            default:
                break;
        }
        /*
        switch (_stage)
        {
            case 0:
                Stage0();
                goto case 1;
            case 1:
                Stage1();
                goto case 2;
            case 2:
                Stage2();
                goto case 3;
            case 3:
                Stage3();
                goto case 4;
            case 4:
                Stage4();
                break;
            default:
                break;
                
        }
        */
    }
    
    public void StageElements(List<GameObject> _list, bool _elementsActive)
    {
        if (_elementsActive)
        {
            foreach (GameObject o in _list)
                o.SetActive(true);
        }
        else
        {
            foreach (GameObject o in _list)
                o.SetActive(false);
        }
    }


    //show all guidance
    void Stage0(bool _visibile = true)
    {
        if (stage0.Count > 0)
        {
            if (_visibile)
                StageElements(stage0, true);
            else
                StageElements(stage0, false);
        }
    }

    // drop crosshairs
    void Stage1(bool _visibile = true)
    {
        if (stage1.Count > 0)
        {
            if (_visibile)
                StageElements(stage1, true);
            else
                StageElements(stage1, false);
        }
    }

    // drop tageting icons
    void Stage2(bool _visibile = true)
    {
        if (stage2.Count > 0)
        {
            if (_visibile)
                StageElements(stage2, true);
            else
                StageElements(stage2, false);
        }
    }

    // drop sidebars
    void Stage3(bool _visibile = true)
    {

        if (stage3.Count > 0)
        {
            if (_visibile)
                StageElements(stage3, true);
            else
                StageElements(stage3, false);
        }
    }

    // drop base bar
    void Stage4(bool _visibile = true)
    {

        if (stage4.Count > 0)
        {
            if (_visibile)
                StageElements(stage4, true);
            else
                StageElements(stage4, false);
        }
    }

    void Testing()
    {
        if (Input.GetKeyUp(KeyCode.Alpha5))
            currentStage = 0;
        else if (Input.GetKeyUp(KeyCode.Alpha1))
            currentStage = 1;
        else if (Input.GetKeyUp(KeyCode.Alpha2))
            currentStage = 2;
        else if (Input.GetKeyUp(KeyCode.Alpha3))
            currentStage = 3;
        else if (Input.GetKeyUp(KeyCode.Alpha4))
            currentStage = 4;
    }

}
