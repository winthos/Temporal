using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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

    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    // Use this for initialization
    void Start()
    {
        if (fadeIn)
            StartCoroutine(FadeIn());
        else
            ShowScreen();
    }

    void Update()
    {
        if (UseKeyInput)
        {
            if (Input.GetKeyUp(userIn) || Input.GetKeyUp(userInAlt))
            {
                LoadNextScene = true;
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeIn()
    {
        group.alpha = 1;

        for (float t = 0; t < 1; t += Time.deltaTime / fadeInTime)
        {
            group.alpha = Mathf.Lerp(group.alpha, 0, t);
            yield return null;
        }

        StartCoroutine(ShowScreen());
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


        for (float t = 0; t < 1; t += Time.deltaTime / fadeOutTime)
        {
            group.alpha = Mathf.Lerp(group.alpha, 1, t);
            yield return null;
        }

        LoadTheScene();
    }

    public float CallFadein()
    {
        StartCoroutine(FadeIn());
        return fadeInTime;
    }
    public float CallFadeout()
    {
        StartCoroutine(FadeOut());
        return fadeOutTime;
    }

    public void LoadTheScene()
    {
        if (LoadNextScene)
            SceneManager.LoadScene(SceneToLoad);
    }

    public void LoadAScene(string _sceneName)
    {
        print("button clicked");
        StartCoroutine(FadeOut());
        SceneManager.LoadScene(_sceneName);
    }
}