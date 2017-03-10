using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUDTargetingController : MonoBehaviour
{
    int indexx = 0;
    public float detectionDistance = 10;


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


    // Use this \for initialization
    void Start ()
    {
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

    void HideImageInList(List<Image> _imgList)
    {
        foreach (Image img in _imgList)
        {
            var tempColor = img.color;
            tempColor.a = 0f;
            img.color = tempColor;
        }
    }
    void ShowImageInList(List<Image> _imgList)
    {
        foreach (Image img in _imgList)
        {
            var tempColor = img.color;
            tempColor.a = 1f;
            img.color = tempColor;
        }
    }
    

    // Update is called once per frame
    void Update ()
    {
        for(int i = 0; i < 0; i++)
        {
            if (hazardDists[i] != 0)
                UpdateHazardTargeting(i, hazardDists[i]);
            if(pickupDists[i] != 0)
                UpdatePickupTargeting(i, pickupDists[i]);
        }

        if (Input.GetKeyUp(KeyCode.G))
            ShowHazard3C(1);
        if (Input.GetKeyUp(KeyCode.H))
            ShowPickup3C(1);
    }

    private void UpdateHazardTargeting(int _index, float _hazardDist)
    {
        print("update hazard targeting");
    }

    private void UpdatePickupTargeting(int _index, float _pickupDist)
    {

    }


    // --------------------------------------------------------------------
    // --------------------------HAZARDs-----------------------------------
    // --------------------------------------------------------------------

    // show hazards -----------------------------------------------------//
    void ShowHazard1A(float _distance = 0)
    {
        //show 1A Hazard
        ShowHazard(_distance, 0, hazardR1, hazardCA);
    }
    void ShowHazard1B(float _distance = 0)
    {
        //show 1B Hazard
        ShowHazard(_distance, 1, hazardR1, hazardCB);
    }
    void ShowHazard1C(float _distance = 0)
    {
        //show 1C Hazard
        ShowHazard(_distance, 2, hazardR1, hazardCC);
    }
    void ShowHazard2A(float _distance = 0)
    {
        //show 2A Hazard
        ShowHazard(_distance, 3, hazardR2, hazardCA);
    }
    void ShowHazard2B(float _distance = 0)
    {
        //show 2B Hazard
        ShowHazard(_distance, 4, hazardR2, hazardCB);
    }
    void ShowHazard2C(float _distance = 0)
    {
        //show 2C Hazard
        ShowHazard(_distance, 5, hazardR2, hazardCC);
    }
    void ShowHazard3A(float _distance = 0)
    {
        //show 3A Hazard
        ShowHazard(_distance, 6, hazardR3, hazardCA);
    }
    void ShowHazard3B(float _distance = 0)
    {
        //show 3B Hazard
        ShowHazard(_distance, 7, hazardR3, hazardCB);
    }
    void ShowHazard3C(float _distance = 0)
    {
        //show 3C Hazard
        ShowHazard(_distance, 8, hazardR3, hazardCC);
    }

    // hide hazards -----------------------------------------------------//
    void HideHazard1A(float _distance = 0)
    {
        //Hide 1A Hazard
        HideHazard(_distance, 0, hazardR1, hazardCA);
    }
    void HideHazard1B(float _distance = 0)
    {
        //Hide 1B Hazard
        HideHazard(_distance, 1, hazardR1, hazardCB);
    }
    void HideHazard1C(float _distance = 0)
    {
        //Hide 1C Hazard
        HideHazard(_distance, 2, hazardR1, hazardCC);
    }
    void HideHazard2A(float _distance = 0)
    {
        //Hide 2A Hazard
        HideHazard(_distance, 3, hazardR2, hazardCA);
    }
    void HideHazard2B(float _distance = 0)
    {
        //Hide 2B Hazard
        HideHazard(_distance, 4, hazardR2, hazardCB);
    }
    void HideHazard2C(float _distance = 0)
    {
        //Hide 2C Hazard
        HideHazard(_distance, 5, hazardR2, hazardCC);
    }
    void HideHazard3A(float _distance = 0)
    {
        //Hide 3A Hazard
        HideHazard(_distance, 6, hazardR3, hazardCA);
    }
    void HideHazard3B(float _distance = 0)
    {
        //Hide 3B Hazard
        HideHazard(_distance, 7, hazardR3, hazardCB);
    }
    void HideHazard3C(float _distance = 0)
    {
        //Hide 3C Hazard
        HideHazard(_distance, 8, hazardR3, hazardCC);
    }

    void ShowHazard(float _distance, int _index, List<Image> _hRow, List<Image> _hCol)
    {
        var tempColor = hazardIcons[_index].color;
        tempColor.a = NormalizeValue(_distance);
        hazardIcons[_index].color = tempColor;

        ShowImageInList(_hRow);
        ShowImageInList(_hCol);
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

    // show hazards -----------------------------------------------------//
    void ShowPickup1A(float _distance = 0)
    {
        //show 1A Hazard
        ShowPickup(_distance, 0, pickupR1, pickupCA);
    }
    void ShowPickup1B(float _distance = 0)
    {
        //show 1B Hazard
        ShowPickup(_distance, 1, pickupR1, pickupCB);
    }
    void ShowPickup1C(float _distance = 0)
    {
        //show 1C Hazard
        ShowPickup(_distance, 2, pickupR1, pickupCC);
    }
    void ShowPickup2A(float _distance = 0)
    {
        //show 2A Hazard
        ShowPickup(_distance, 3, pickupR2, pickupCA);
    }
    void ShowPickup2B(float _distance = 0)
    {
        //show 2B Hazard
        ShowPickup(_distance, 4, pickupR2, pickupCB);
    }
    void ShowPickup2C(float _distance = 0)
    {
        //show 2C Hazard
        ShowPickup(_distance, 5, pickupR2, pickupCC);
    }
    void ShowPickup3A(float _distance = 0)
    {
        //show 3A Hazard
        ShowPickup(_distance, 6, pickupR3, pickupCA);
    }
    void ShowPickup3B(float _distance = 0)
    {
        //show 3B Hazard
        ShowPickup(_distance, 7, pickupR3, pickupCB);
    }
    void ShowPickup3C(float _distance = 0)
    {
        //show 3C Hazard
        ShowPickup(_distance, 8, pickupR3, pickupCC);
    }

    // hide hazards -----------------------------------------------------//
    void HidePickup1A(float _distance = 0)
    {
        //Hide 1A Hazard
        HidePickup(_distance, 0, hazardR1, hazardCA);
    }
    void HidePickup1B(float _distance = 0)
    {
        //Hide 1B Hazard
        HidePickup(_distance, 1, hazardR1, hazardCB);
    }
    void HidePickup1C(float _distance = 0)
    {
        //Hide 1C Hazard
        HidePickup(_distance, 2, hazardR1, hazardCC);
    }
    void HidePickup2A(float _distance = 0)
    {
        //Hide 2A Hazard
        HidePickup(_distance, 3, hazardR2, hazardCA);
    }
    void HidePickup2B(float _distance = 0)
    {
        //Hide 2B Hazard
        HidePickup(_distance, 4, hazardR2, hazardCB);
    }
    void HidePickup2C(float _distance = 0)
    {
        //Hide 2C Hazard
        HidePickup(_distance, 5, hazardR2, hazardCC);
    }
    void HidePickup3A(float _distance = 0)
    {
        //Hide 3A Hazard
        HidePickup(_distance, 6, hazardR3, hazardCA);
    }
    void HidePickup3B(float _distance = 0)
    {
        //Hide 3B Hazard
        HidePickup(_distance, 7, hazardR3, hazardCB);
    }
    void HidePickup3C(float _distance = 0)
    {
        //Hide 3C Hazard
        HidePickup(_distance, 8, hazardR3, hazardCC);
    }

    void ShowPickup(float _distance, int _index, List<Image> _hRow, List<Image> _hCol)
    {
        var tempColor = pickupIcons[_index].color;
        tempColor.a = NormalizeValue(_distance);
        pickupIcons[_index].color = tempColor;

        ShowImageInList(_hRow);
        ShowImageInList(_hCol);
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
        float temp = (detectionDistance - _value) / (detectionDistance + _value);
        //return Mathf.Max(0, temp);

        return 1f;
    }
}