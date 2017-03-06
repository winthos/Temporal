using UnityEngine;
using System.Collections;

public class HUDTargetingController : MonoBehaviour
{


	// Use this \for initialization
	void Start () {
	
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