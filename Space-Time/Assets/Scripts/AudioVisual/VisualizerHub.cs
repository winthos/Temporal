////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using AudioVisualization;
using System.Collections.Generic;


public class VisualizerHub : MonoBehaviour
{
    // Static instance
    static VisualizerHub _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _instance.Initialize();
        }
    }
    
    public static VisualizerHub GetInstance()
    {
        return _instance;
    }

    //public List<Vector3> topSample;
    //public Vector3[] trebleSamples;
    //public Vector3[] mediumSamples;
    //public  baseSamples;

    int numberOfSamples;
    float[] allSamples;
    
    float scaleMultiplier;
    GameObject[] cubes;
    List<Vector3> scaleMins;

    void Initialize()
    {
        numberOfSamples = 512;
        allSamples = new float[numberOfSamples];

        scaleMultiplier = 10;

        cubes = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject cube in cubes)
        {
            //scaleMins.Add(cube.GetComponent<VisualizationInfo>().scale);
        }
    }
    
    void Update()
    {
        //Background Music
        GetInstance().Visualization(SoundHub.source_bgm, numberOfSamples, 40, 30);
    }

    /*
    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        float[] samples = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Hamming);
        allSamples = samples;
    }

    public static float[] GetSamples()
    {
        return GetInstance().allSamples;
    }
    */

    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        VisualizerHub visHub = GetInstance();

        float[] samples = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Hamming);
       
        for (int i = 0; i < visHub.cubes.Length; i++)
        {
            Vector3 previousScale = visHub.cubes[i].transform.localScale;
            Vector3 newScale = visHub.scaleMins[i] + new Vector3(samples[i], samples[i], samples[i]) * scaleMultiplier;
            visHub.cubes[i].transform.localScale = Vector3.Lerp(previousScale, newScale, Time.deltaTime * _timeMultiplier);
            visHub.cubes[i].transform.localScale = newScale;
        }
    }

    public static void AddObjectToCubes(GameObject _obj, Vector3 _originalSize)
    {
        VisualizerHub visHub = GetInstance();

        //visHub.cubes.(_obj);
        //visHub.scaleMins.Add(_originalSize);
    }
}
