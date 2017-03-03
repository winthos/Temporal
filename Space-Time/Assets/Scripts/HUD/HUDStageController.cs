﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDStageController : MonoBehaviour
{
    public bool TestModeOn = false;

    [SerializeField]
    List<Canvas> stages = new List<Canvas>(5);
    public int prevStage = 0;
    public int currStage = 0;
    public int nextStage = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (TestModeOn)
            Testing();

        if (currStage != nextStage)
            StartCoroutine(UpdateStages());
    }

    void Testing()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
            nextStage = 0;
        else if (Input.GetKeyUp(KeyCode.Alpha1))
            nextStage = 1;
        else if (Input.GetKeyUp(KeyCode.Alpha2))
            nextStage = 2;
        else if (Input.GetKeyUp(KeyCode.Alpha3))
            nextStage = 3;
        else if (Input.GetKeyUp(KeyCode.Alpha4))
            nextStage = 4;
    }

    IEnumerator UpdateStages()
    {
        prevStage = currStage;
        currStage = nextStage;
        StageUp(currStage);

        yield return 0;
    }



    public void StageUp(int _stage)
    {
        // will need something here to hide canvases that aren't in use

        //stage up; accelleration
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
    }

    //show all guidance
    void Stage0(bool _visibile = true)
    {
        if(_visibile)
        {
            stages[0].GetComponent<CanvasGroup>().alpha = 1;
            print("stage zero on");
        }
        else
        {
            stages[0].GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    // drop crosshairs
    void Stage1(bool _visibile = true)
    {
        if (_visibile)
        {
            stages[1].GetComponent<CanvasGroup>().alpha = 1;
            print("stage one on");
        }
        else
        {
            stages[1].GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    // drop tageting icons
    void Stage2(bool _visibile = true)
    {
        if (_visibile)
        {
            stages[2].GetComponent<CanvasGroup>().alpha = 1;
            print("stage two on");
        }
        else
        {
            stages[2].GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    // drop sidebars
    void Stage3(bool _visibile = true)
    {
        if (_visibile)
        {
            stages[3].GetComponent<CanvasGroup>().alpha = 1;
            print("stage three on");
        }
        else
        {
            stages[3].GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    // drop base bar
    void Stage4(bool _visibile = true)
    {
        if (_visibile)
        {
            stages[4].GetComponent<CanvasGroup>().alpha = 1;
            print("stage four on");
        }
        else
        {
            stages[4].GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}