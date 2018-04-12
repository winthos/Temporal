////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;

public class BarVisulization : MonoBehaviour
{
    public GameObject visualsCanvas;
    Vector3 startPos1 = new Vector3(-7.5f, 3, 0);
    Vector3 startPos2 = new Vector3(7.5f, 3, 0);
    float offset = 0.15f;
    float heightScale = 0.20f;
    float widthMultiplier = 5f;

    public GameObject prefab1;
    public GameObject prefab2;
    public int numberOfObjects = 40;
    public GameObject[] bars1;
    public GameObject[] bars2;

    public float[] samples;
    public float[] buffer;

    AudioSource source;
    private static float globalVizScaler = 1;
    public static float GlobalVizScaler {
        get { return globalVizScaler; }
    }

    void Start()
    {
        source = SoundHub.source_bgm;

        if (visualsCanvas != null)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                Vector3 pos1 = startPos1 + new Vector3(0, i * offset, 0);
                Vector3 pos2 = startPos2 + new Vector3(0, i * offset, 0);

                Instantiate(prefab1, pos1, Quaternion.identity, visualsCanvas.transform);
                Instantiate(prefab2, pos2, Quaternion.identity, visualsCanvas.transform);
            }

            bars1 = GameObject.FindGameObjectsWithTag("bar1");
            bars2 = GameObject.FindGameObjectsWithTag("bar2");


            visualsCanvas.transform.position = new Vector3(0, -5, -2);
            visualsCanvas.transform.Rotate(new Vector3(8.331f, 0, 0));

            visualsCanvas.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
        }
    }

    void Update ()
    {
        //if(PauseController.Paused())
            Visualization(source, 1024, 40, 30);
    }



    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        samples = new float[_sampleNumber];
        buffer = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Triangle);

        for (int i = 0; i < numberOfObjects; i++)
        {
            if (visualsCanvas != null)
            {
                bars1[i].GetComponent<SpriteRenderer>().transform.localScale = new Vector3(samples[i] * widthMultiplier, heightScale, 1);
                bars2[i].GetComponent<SpriteRenderer>().transform.localScale = new Vector3(samples[i] * widthMultiplier, heightScale, 1);
            }

            if (i == numberOfObjects - 2) globalVizScaler = samples[i];
        }
	}

    public void OnDestroy()
    {
        if (visualsCanvas != null)
            Destroy(visualsCanvas);
    }
}