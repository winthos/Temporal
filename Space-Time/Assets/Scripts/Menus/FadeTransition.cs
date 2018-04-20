////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
//  Attatch to Canvas with a opaque black Panel. Requires canvas group.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent (typeof(CanvasGroup))]
public class FadeTransition : MonoBehaviour
{
    public bool fadeIn = true, fadeOut = true;
    public float fadeInTime = 1f, waitTime = 2f, fadeOutTime = 1f;

    [Space(15)]

    public string SceneToLoad;
    public bool LoadNextScene = false;
    public bool UseKeyInput = false;

    CanvasGroup group;
    Coroutine currentCoroutine;

    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    // Use this for initialization
    void Start()
    {
        if (fadeIn)
            currentCoroutine = StartCoroutine(FadeIn());
        else
            ShowScreen();
    }

    void Update()
    {
        if (UseKeyInput && (Input.anyKey || Input.GetMouseButtonDown(0)))
        {
            LoadTheScene();
            LoadNextScene = true;
            QuickLoadNextScreen();
        }
    }

    IEnumerator FadeIn()
    {
        group.alpha = 1;
        if (fadeIn)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / fadeInTime)
            {
                group.alpha = Mathf.Lerp(group.alpha, 0, t);
                yield return null;
            }
        }

        currentCoroutine = StartCoroutine(ShowScreen());
    }


    IEnumerator ShowScreen()
    {
        group.alpha = 0;
        yield return new WaitForSeconds(waitTime);

        if (fadeOut)
            StartCoroutine(FadeOut());
        else
            LoadTheScene();
    }

    IEnumerator FadeOut()
    {
        group.alpha = 0;
        
        if (fadeOut)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / fadeOutTime)
            {
                group.alpha = Mathf.Lerp(group.alpha, 1, t);
                yield return null;
            }
        }

        LoadTheScene();
    }

    public float CallFadein()
    {
        currentCoroutine = StartCoroutine(FadeIn());
        return fadeInTime;
    }
    public float CallFadeout()
    {
        currentCoroutine = StartCoroutine(FadeOut());
        return fadeOutTime;
    }

    public void LoadTheScene()
    {
        if (LoadNextScene && SceneToLoad != null)
            SceneManager.LoadScene(SceneToLoad);
    }

    public void LoadAScene(string _sceneName)
    {
        currentCoroutine = StartCoroutine(FadeOut());
        SceneManager.LoadScene(_sceneName);
    }

    public void QuickLoadNextScreen()
    {
        StopCoroutine(currentCoroutine);
        LoadTheScene();
    }
    
}