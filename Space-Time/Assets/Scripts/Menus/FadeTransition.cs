﻿////////////////////////////////////////////////////////////////////////////////
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
    public bool fadeIn = true;
    public float fadeInTime = 1f;

    public bool fadeOut = true;
    public float fadeOutTime = 1f;

    public bool LoadNextScene = false;
    public string SceneToLoad;
    public float waitTime = 2f;
    public bool UseKeyInput = false;
    [SerializeField]
    KeyCode userIn = KeyCode.Return;
    [SerializeField]
    KeyCode userInAlt = KeyCode.None;

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
        if (UseKeyInput)
        {
            if (Input.GetKeyUp(userIn) || Input.GetKeyUp(userInAlt) || Input.anyKey || Input.GetMouseButtonDown(0))
            {
                LoadNextScene = true;
                QuickLoadNextScreen();
            }
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
        if (LoadNextScene)
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

    /*
    public void ForceFadeOut(string _sceneToLoad)
    {
        group.alpha = 0;

        for (float t = 0; t < 1; t += Time.deltaTime / fadeOutTime)
        {
            group.alpha = Mathf.Lerp(group.alpha, 1, t);
        }

        group.alpha = 1;

        SceneManager.LoadScene(_sceneToLoad);
    }
    */
}