using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(RawImage))]
public class WaveformVisualizer : MonoBehaviour
{
    /*
    float yscale;
    float xscale;

    int nbOfSamplesPerDataPoint = 1000; // 441 points per second at 44.1kHz

    VectorLine myLine;

    void Start()
    {

        MakeLine(myGATData.ParentArray);

    }

    void Update()
    {
        myLine.Draw3D; // if not attached to a moving object, you don't need to call in update
    }


    void MakeLine(float[] rawData)
    {

        yscale = 7;

        nbOfSamplesPerDataPoint = myGATData.Count / 200; //because I'm making all waveforms appear the same x-size regardless of sample length, longer samples require less lines to be drawn. Otherwise long samples cause slowdown

        int nbOfDataPoints = rawData.Length / nbOfSamplesPerDataPoint;

        if (nbOfDataPoints % 2 != 0)
        {
            nbOfDataPoints += 1; //Discrete lineType requires an even number
        }

        Color myColor = new Color(1, 1, 1, 0.75f);

        myLine = new VectorLine("MyLine", new Vector3[nbOfDataPoints], myColor, null, 1, LineType.Discrete);

        float[] minValues = new float[nbOfDataPoints];
        float[] maxValues = new float[nbOfDataPoints];
        float max = 0f;
        float min = 0f;
        float current = 0f;
        int i = 0;
        int j = 0;
        while (i < rawData.Length)
        {
            current = rawData[i];
            if (current > max)
            {
                max = current;
            }
            else if (current < min)
            {
                min = current;
            }

            i++;

            if (i % nbOfSamplesPerDataPoint == 0)
            {
                maxValues[j] = max;
                minValues[j] = min;
                min = 0f;
                max = 0f;
                j++;

            }

        }

        xscale = (maxValues.Length / 270) + 1;

        for (int l = 0; l < maxValues.Length; l++)
        {

            if (l % 2 != 0)
            {
                myLine.points3[l] = new Vector3(((l / xscale) / 20), (minValues[l] * yscale) + 4, 0); // I have scaled all my samples to the same x-bounds
            }

            if (l % 2 != 1)
            {
                myLine.points3[l] = new Vector3(((l / xscale) / 20), (maxValues[l] * yscale) + 4, 0);
            }
        }

        myLine.drawTransform = transform; //waveform moves with gameobject

    }
    */
}