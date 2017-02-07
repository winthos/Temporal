using UnityEngine;

public class PlanetVisualizer : MonoBehaviour
{
    float scaleMultiplier = 120;
    //float sampleMultiplier = 40;
    float timeMultiplier = 30;
    Vector3 scaleMinimum;

    GameObject[] objects;
    Vector3[] scaleMin;

    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Planet");
        scaleMin = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            scaleMin[i] = objects[i].transform.localScale;
        }
    }

    void Update()
    {
        Visualization(SoundHub.source_bgm, 1024, 40, 30);
    }

    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        float[] samples = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Hamming);

        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 previousScale = objects[i].transform.localScale;
            Vector3 newScale = scaleMin[i] + new Vector3(samples[i], samples[i], samples[i]) * scaleMultiplier;
            objects[i].transform.localScale = Vector3.Lerp(previousScale, newScale, Time.deltaTime * 30);
            objects[i].transform.localScale = newScale;
        }
    }
}