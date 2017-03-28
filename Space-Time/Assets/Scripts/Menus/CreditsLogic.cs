////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreditsLogic : MonoBehaviour
{
    public List<Canvas> credits;
    float fadeTime = 1f;
    float viewTime = 4f;
    float waitTime = 0.5f;

    Coroutine current;
    bool isRunning;

    // Use this for initialization
    void Start ()
    {
        if (credits.Count != 0)
        {
            foreach (Canvas c in credits)
                c.GetComponent<CanvasGroup>().alpha = 0;

            //StartCoroutine(CycleCredits());
        }

    }

    void Update()
    {
        if (!isRunning) StartCoroutine(CycleCredits());
    }

    IEnumerator CycleCredits()
    {

        isRunning = true;

        FadeInCanvas(credits[0].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(viewTime);
        FadeOutCanvas(credits[0].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(waitTime);

        FadeInCanvas(credits[1].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(viewTime);
        FadeOutCanvas(credits[1].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(waitTime);

        FadeInCanvas(credits[2].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(viewTime);
        FadeOutCanvas(credits[2].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(waitTime);

        FadeInCanvas(credits[3].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(viewTime);
        FadeOutCanvas(credits[3].GetComponent<CanvasGroup>());
        yield return new WaitForSeconds(waitTime);

        yield return new WaitForSeconds(waitTime * 3);

        isRunning = false;

        //StartCoroutine(FadeCanvas(credits[0].GetComponent<CanvasGroup>()));
        //StartCoroutine(FadeCanvas(credits[1].GetComponent<CanvasGroup>()));
        //StartCoroutine(FadeCanvas(credits[2].GetComponent<CanvasGroup>()));
        //StartCoroutine(FadeCanvas(credits[3].GetComponent<CanvasGroup>()));


        //StartCoroutine(CycleCredits());
    }

    void FadeInCanvas(CanvasGroup _group)
    {
        //start canvas invisible
        _group.alpha = 0;

        // fade-in logic
        for (float t = 0; t < 1; t += Time.deltaTime / fadeTime)
            _group.alpha = Mathf.Lerp(_group.alpha, 1, t);

        // canvas visible
        _group.alpha = 1;
    }

    void FadeOutCanvas(CanvasGroup _group)
    {
        // fade-out logic
        for (float t = 0; t < 1; t += Time.deltaTime / fadeTime)
            _group.alpha = Mathf.Lerp(_group.alpha, 0, t);

        // canvas invisible again
        _group.alpha = 0;
    }

    IEnumerator FadeCanvas(CanvasGroup _group)
    {
        //start canvas invisible
        _group.alpha = 0;

        // fade-in logic
        for (float t = 0; t < 1; t += Time.deltaTime / fadeTime)
        {
            _group.alpha = Mathf.Lerp(_group.alpha, 1, t);
            yield return null;
        }

        // canvas visible
        _group.alpha = 1;
        yield return new WaitForSeconds(viewTime);

        // fade-out logic
        for (float t = 0; t < 1; t += Time.deltaTime / fadeTime)
        {
            _group.alpha = Mathf.Lerp(_group.alpha, 0, t);
            yield return null;
        }

        // canvas invisible again
        _group.alpha = 0;


        yield return new WaitForSeconds(waitTime);
    }
}
