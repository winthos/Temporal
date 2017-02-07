using UnityEngine;

public class PlanetVisualizer : MonoBehaviour
{
    float scaleMultiplier = 10;
    //float sampleMultiplier = 40;
    float timeMultiplier = 30;
    Vector3 scaleMinimum;

    private void Awake()
    {
        scaleMinimum = gameObject.transform.localScale;
    }

    void Start()
    {        
    }

    void Update()
    {
        VisualizeScale();
    }

    void VisualizeScale()
    {
        float size = 0;
        if (VisualizerHub.GetSamples() != null)
            size = VisualizerHub.GetSamples()[4];

        Vector3 previousScale = gameObject.transform.localScale;
        Vector3 newScale = scaleMinimum + new Vector3(size, size, size) * 10;
        gameObject.transform.localScale = Vector3.Lerp(previousScale, newScale, Time.deltaTime * 30);
        gameObject.transform.localScale = newScale;

        /*
        Vector3 previousScale = gameObject.transform.localScale;
        Vector3 newScale = scaleMinimum + new Vector3(size, size, size) * scaleMultiplier;
        gameObject.transform.localScale = Vector3.Lerp(previousScale, newScale, Time.deltaTime * timeMultiplier);
        gameObject.transform.localScale = newScale;
        */
    }
}