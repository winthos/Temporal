using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUDTargetingController : MonoBehaviour
{
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
    void Start () {

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
            img.color -= new Color(0, 0, 0, 1);
        }
    }
    void ShowImageInList(List<Image> _imgList)
    {
        foreach (Image img in _imgList)
        {
            img.color += new Color(0, 0, 0, 1);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}


public class Target
{
    public TargetType type;
    public GameObject obj;
}

public enum TargetType
{
    hazard, pickup
}