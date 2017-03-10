using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scoring : MonoBehaviour
{
    public float score;

    public List<float> times;
    public List<float> speeds;
    public List<int> enemies;
    public List<int> pickups;

    // Use this for initialization
    void Start ()
    {
        //                          S       A       B       C       D       F
        times   = new List<float> { 120f,   90f,    60f,    30f,    15f,    0};
        speeds  = new List<float> { };
        enemies = new List<int>   { 20,     10,     7,      3,      1,      0};
        pickups = new List<int>   { 20,     10,     7,      3,      1,      0 };
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    float GetScore()
    {
        float temp;

        return temp;
    }
}
