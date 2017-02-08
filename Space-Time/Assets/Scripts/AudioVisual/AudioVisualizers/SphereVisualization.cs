using UnityEngine;

public class SphereVisualization : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public float scaleMultiplier;
    Vector3 scaleMinimum = new Vector3(1,1,1);
    public GameObject[] cubes;

    AudioSource source;

    void Start()
    {

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }

        cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach (GameObject cube in cubes)
        {
            cube.transform.localScale = scaleMinimum;
        }
        
        source = SoundHub.source_bgm;
    }

    void Update()
    {
        Visualization(source, 1024, 40, 30);
    }

    void Visualization(AudioSource _source, int _sampleNumber, float _sampleMultiplier, float _timeMultiplier)
    {
        float[] samples = new float[_sampleNumber];

        _source.GetSpectrumData(samples, 0, FFTWindow.Hamming);
        
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 previousScale = cubes[i].transform.localScale;
            Vector3 newScale = scaleMinimum + new Vector3(samples[i], samples[i], samples[i]) * 10;
            cubes[i].transform.localScale = Vector3.Lerp(previousScale, newScale, Time.deltaTime * 30);
            //previousScale.y = Mathf.Lerp(previousScale.y, samples[i] * 40, Time.deltaTime * 30);
            cubes[i].transform.localScale = newScale;
        }
    }
}