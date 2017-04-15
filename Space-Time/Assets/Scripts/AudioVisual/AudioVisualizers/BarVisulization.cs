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

    AudioSource source;
    
    void Start()
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

        source = SoundHub.source_bgm;

        visualsCanvas.transform.position = new Vector3(0, -5, -2);
        visualsCanvas.transform.Rotate(new Vector3(8.331f, 0, 0));

        visualsCanvas.gameObject.transform.SetParent(GameObject.Find("Main Camera").transform);
    }

    void Update ()
    {
        //if(PauseController.Paused())
            Visualization(source, 1024, 40, 30);
        //print(visualsCanvas.transform.rotation);
    }

    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        float[] samples = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Triangle);

        for (int i = 0; i < numberOfObjects; i++)
        {
            bars1[i].GetComponent<SpriteRenderer>().transform.localScale = new Vector3(samples[i] * widthMultiplier, heightScale, 1);
            bars2[i].GetComponent<SpriteRenderer>().transform.localScale = new Vector3(samples[i] * widthMultiplier, heightScale, 1);
        }
	}

    public void OnDestroy()
    {
        Destroy(visualsCanvas);
    }
}