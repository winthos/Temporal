using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUDTargetingController : MonoBehaviour
{
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
            ShowHazard1A(1);
        if (Input.GetKeyUp(KeyCode.H))
            HideHazard1A(0);
    }

    private void UpdateHazardTargeting(int _index, float _hazardDist)
    {
        print("update hazard targeting");
    }

    private void UpdatePickupTargeting(int _index, float _pickupDist)
    {

    }

    void ShowHazard1A(float _distance = 0)
    {
        var tempColor = hazardIcons[0].color;
        tempColor.a = NormalizeValue(_distance);
        hazardIcons[0].color = tempColor;

        ShowImageInList(hazardR1);
        ShowImageInList(hazardCA);
    }

    void HideHazard1A(float _distance = 0)
    {
        var tempColor = hazardIcons[0].color;
        tempColor.a = 0;
        hazardIcons[0].color = tempColor;

        HideImageInList(hazardR1);
        HideImageInList(hazardCA);
    }

    float NormalizeValue(float _value)
    {
        float temp = (detectionDistance - _value) / (detectionDistance + _value);
        //return Mathf.Max(0, temp);

        return 1f;
    }
}