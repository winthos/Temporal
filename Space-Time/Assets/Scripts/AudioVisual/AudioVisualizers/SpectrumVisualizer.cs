using UnityEngine;

public class SpectrumVisualizer : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public GameObject[] cubes;

    public AudioSource source;

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
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }

        cubes = GameObject.FindGameObjectsWithTag("cube");
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
            previousScale.y = Mathf.Lerp(previousScale.y, samples[i] * 40, Time.deltaTime * 30);
            cubes[i].transform.localScale = previousScale;
        }
    }
}