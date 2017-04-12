using UnityEngine;

public class PlanetVisualizer : MonoBehaviour
{
    //float sampleMultiplier = 40;
    float timeMultiplier = 30;
    Vector3 scaleMinimum;

    GameObject[] objects;
    Vector3[] scaleMinObjs;
    float scaleMultiplier = 180;

    GameObject[] projections;
    Vector3[] scaleMinProj;
    float scaleMultiProj = 0.5f;

    GameObject player;
    Vector3 playerMin;
    float scaleMultiPlay = 5f;

    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Planet");
        projections = GameObject.FindGameObjectsWithTag("projection");
        player = GameObject.FindGameObjectWithTag("Player");

        scaleMinObjs = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            scaleMinObjs[i] = objects[i].transform.localScale;
        }

        scaleMinProj = new Vector3[projections.Length];
        for (int i = 0; i < projections.Length; i++)
        {
            scaleMinProj[i] = projections[i].transform.localScale;
        }

        playerMin = player.transform.localScale;
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
            /*
            if (objects[i].tag == "Player")
                scaleMultiplier = 100.0f;
            else if(objects[i].tag == "Planet")
                scaleMultiplier = 180f;
            */
            Vector3 previousScale = objects[i].transform.localScale;
            Vector3 newScale = scaleMinObjs[i] + new Vector3(samples[i], samples[i], samples[i]) * scaleMultiplier;
            //newScale = Vector3.Min(newScale, (scaleMinObjs[i] * 1.1f));
            objects[i].transform.localScale = Vector3.Lerp(previousScale, newScale, Time.deltaTime * 30);
            objects[i].transform.localScale = newScale;
        }

        for (int i = 0; i < projections.Length; i++)
        {
            Vector3 previousScale2 = projections[i].transform.localScale;
            Vector3 newScale2 = scaleMinProj[i] + new Vector3(samples[objects.Length + i], samples[objects.Length + i], samples[objects.Length + i]) * scaleMultiProj;
            projections[i].transform.localScale = Vector3.Lerp(previousScale2, newScale2, Time.deltaTime * 30);
            projections[i].transform.localScale = newScale2;
        }

        Vector3 previousScale3 = player.transform.localScale;
        Vector3 newScale3 = playerMin + new Vector3(samples[objects.Length + projections.Length + 1], samples[objects.Length + projections.Length + 1], samples[objects.Length + projections.Length + 1]) * scaleMultiPlay;
        player.transform.localScale = Vector3.Lerp(previousScale3, newScale3, Time.deltaTime * 30);
        player.transform.localScale = newScale3;
    }
}