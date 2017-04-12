////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
using AudioVisualization;
using System.Collections;

public class OptionsController : MonoBehaviour
{
    CanvasGroup group;

    bool allAudioIsOn = true;
    bool bgmIsOn = true;
    bool fullscreenOn = true;

    [SerializeField]
    Text masterVolText;
    [SerializeField]
    Text bgmVolText;
    [SerializeField]
    Text fullscreenText;

    [SerializeField]
    Toggle allOn;
    [SerializeField]
    Toggle allOff;
    [SerializeField]
    Toggle bgmOn;
    [SerializeField]
    Toggle bgmOff;
    [SerializeField]
    Toggle fullOn;
    [SerializeField]
    Toggle fullOff;

    // Use this for initialization
    void Awake() {
        group = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void HideOptionsMenu()
    {
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
    public void ShowOptionsMenu()
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    public void TurnOnFullScreen()
    {
        Screen.fullScreen = true;
        Debug.Log("Fullscreen Mode");
    }

    public void TurnOffFullscreen()
    {
        Screen.fullScreen = false;
        Debug.Log("Windowed Mode");
    }

    public void TurnOnAllAudio()
    {
        allAudioIsOn = true;
        SetAudio();
    }
    public void TurnOffAllAudio()
    {
        allAudioIsOn = false;
        SetAudio();
    }
    public void TurnOnBgm()
    {
        bgmIsOn = true;
        SetAudio();
    }
    public void TurnOffBgm()
    {
        bgmIsOn = false;
        SetAudio();
    }


    private void SetAudio()
    {
        if(!allAudioIsOn && !bgmIsOn) // all off, bgm off
        {
            SoundHub.GetInstance().MuteAllSFX();
            SoundHub.GetInstance().MuteBackgroundAudio();   
        }
        else if(allAudioIsOn && !bgmIsOn) // all on, bgm off
        {
            SoundHub.GetInstance().UnmuteAllSFX();
            SoundHub.GetInstance().MuteBackgroundAudio();
        }
        else if (!allAudioIsOn && bgmIsOn) // all off, bgm on
        {
            SoundHub.GetInstance().MuteAllSFX();
            SoundHub.GetInstance().MuteBackgroundAudio();
            //bgmIsOn = false;
        }
        else if (allAudioIsOn && bgmIsOn) // all on, bgm on
        {
            SoundHub.GetInstance().UnmuteAllSFX();
            SoundHub.GetInstance().UnmteBackgroundAudio();
        }

    }
}