using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class BarVisulization : MonoBehaviour
{
    Vector3 startPos1 = new Vector3(-7f, 3, 0);
    Vector3 startPos2 = new Vector3(7f, 3, 0);
    float offset = 0.15f;
    float heightScale = 0.2f;
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

            Instantiate(prefab1, pos1, Quaternion.identity);
            Instantiate(prefab2, pos2, Quaternion.identity);
        }

        bars1 = GameObject.FindGameObjectsWithTag("bar1");
        bars2 = GameObject.FindGameObjectsWithTag("bar2");

        source = SoundHub.source_bgm;
    }

    void Update ()
    {
        //if(PauseController.Paused())
            Visualization(source, 1024, 40, 30);
    }

    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        float[] samples = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Triangle);

        for (int i = 0; i < numberOfObjects; i++)
        {
            bars1[i].GetComponent<SpriteRenderer>().transform.localScale = new Vector3(samples[i] * widthMultiplier, heightScale, 1);
            bars2[i].GetComponent<SpriteRenderer>().transform.localScale = new Vector3(samples[i] * widthMultiplier, heightScale, 1);
            //barsSprites[i].transform.localScale = new Vector3(samples[i], 0.2f, 1);
        }
	}
}
/*
using UnityEngine;

public class BarVisualizer : MonoBehaviour
{
    public int detail = 500;
    public float minValue = 1.0f;
    public float amplitude = 0.1f;

    private float randomAmplitude = 1.0f;
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;

        randomAmplitude = Random.Range(0.5f, 1.5f);
    }

    void Update()
    {
        float[] info = new float[detail];

        AudioListener.GetOutputData(info, 0);
        float packagedData = 0.0f;

        for (int x = 0; x < info.Length; x++)
        {
            packagedData += System.Math.Abs(info[x]);
        }

        transform.localScale = new Vector3(minValue, (packagedData * amplitude * randomAmplitude) + startScale.y, minValue);
    }
}
*/