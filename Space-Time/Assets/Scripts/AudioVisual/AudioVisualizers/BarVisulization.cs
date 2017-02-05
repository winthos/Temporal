using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class BarVisulization : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 40;
    public GameObject[] bars;
	public SpriteRenderer[] barsSprites;

    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        //source = SoundHub.GetGBMSource();
    }

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 5f;
            Instantiate(prefab, pos, Quaternion.identity);
        }

        bars = GameObject.FindGameObjectsWithTag("cube");
    }

    void Update ()
    {
        Visualization(source, 1024, 40, 30);
    }

    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        float[] samples = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Triangle);

        for (int i = 0; i < numberOfObjects; i++)
        {
            bars[i].GetComponent<SpriteRenderer>().transform.localScale = new Vector3(samples[i], 0.2f, 1);
            //barsSprites[i].transform.localScale = new Vector3(samples[i], 0.2f, 1);
        }
	}
}
