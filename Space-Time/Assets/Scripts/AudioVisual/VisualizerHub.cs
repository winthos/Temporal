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

    void Initialize()
    {
        numberOfSamples = 512;
        allSamples = new float[numberOfSamples];
    }
    
    void Update()
    {
        //Background Music
        Visualization(SoundHub.source_bgm, numberOfSamples, 40, 30);
    }

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
}
