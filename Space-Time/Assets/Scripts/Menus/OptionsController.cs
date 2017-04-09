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
    /*
    [SerializeField]
    Toggle muteAllAudioToggle;
    [SerializeField]
    Toggle muteSFXAudioToggle;
    [SerializeField]
    Toggle muteBgAudioToggle;
    [SerializeField]
    Toggle fullscreenOn;
    */

    // Use this for initialization
    void Start() {
        /*
        allMute = false;
        bgmMute = false;
        if(Screen.fullScreen)
            fullscreenOn = false;
        else
            fullscreenOn = true;
            */
    }

    // Update is called once per frame
    void Update() {

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
        //AudioVisualManager.DisableSoundImmediate();
        //SoundHub.GetInstance().UnmuteAllSFX(); TurnOnBgm();
        allAudioIsOn = true;
        //bgmIsOn = true;
        SetAudio();
    }
    public void TurnOffAllAudio()
    {
        //AudioVisualManager.EnableSoundImmediate();
        //SoundHub.GetInstance().MuteAllSFX(); TurnOffBgm();
        allAudioIsOn = false;
        //bgmIsOn = false;
        SetAudio();
    }
    public void TurnOnBgm()
    {
        //SoundHub.GetInstance().UnmteBackgroundAudio();
        //allAudioIsOn = true;
        bgmIsOn = true;
        SetAudio();
    }
    public void TurnOffBgm()
    {
        //SoundHub.GetInstance().MuteBackgroundAudio();
        bgmIsOn = false;
        SetAudio();
    }


    private void SetAudio()
    {
        if(!allAudioIsOn && !bgmIsOn) // all off, bgm off
        {
            SoundHub.GetInstance().MuteAllSFX();
            SoundHub.GetInstance().MuteBackgroundAudio();   
            /*
            allOn.isOn = false;
            allOff.isOn = true;
            bgmOn.isOn = false;
            bgmOff.isOn = true;*/
        }
        else if(allAudioIsOn && !bgmIsOn) // all on, bgm off
        {
            SoundHub.GetInstance().UnmuteAllSFX();
            SoundHub.GetInstance().MuteBackgroundAudio();
        
            /*
            allOn.isOn = true;
            allOff.isOn = false;
            bgmOn.isOn = false;
            bgmOff.isOn = true;
            */
        }
        else if (!allAudioIsOn && bgmIsOn) // all off, bgm on
        {
            SoundHub.GetInstance().MuteAllSFX();
            SoundHub.GetInstance().MuteBackgroundAudio();
            //bgmIsOn = false;

            /*
            allOn.isOn = false;
            allOff.isOn = true;
            bgmOn.isOn = false;
            bgmOff.isOn = true;*/
        }
        else if (allAudioIsOn && bgmIsOn) // all on, bgm on
        {
            SoundHub.GetInstance().UnmuteAllSFX();
            SoundHub.GetInstance().UnmteBackgroundAudio();

            /*
            allOn.isOn = true;
            allOff.isOn = false;
            bgmOn.isOn = true;
            bgmOff.isOn = false;*/
        }

    }

    /*
    public void ToggleMasterVolume()
    {
        allMute = !allMute;

        if (allMute)
        {
            AudioVisualManager.DisableSoundImmediate();
            masterVolText.text = "OFF";
        }
        else
        {
            AudioVisualManager.EnableSoundImmediate();
            masterVolText.text = "ON";
        }
    }

    public void ToggleBgMusicVolume()
    {
        bgmMute = !bgmMute;

        if (allMute)
        {
            SoundHub.GetInstance().MuteBackgroundAudio();
            bgmVolText.text = "OFF";
        }
        else
        {
            SoundHub.GetInstance().UnmteBackgroundAudio();
            bgmVolText.text = "ON";
        }
    }

    public void ToggleFullscreen()
    {
        fullscreenOn = !fullscreenOn;

        if (fullscreenOn)
        {
            Screen.fullScreen = true;
            fullscreenText.text = "ON";
        }
        else
        {
            Screen.fullScreen = false;
            fullscreenText.text = "OFF";
        }
    }
    */

    /*
    public void UpdateSoundEffects()
    {
        if (muteSFXAudioToggle.isOn)
        {
            SoundHub.GetInstance().MuteAllSFX();
            muteAllAudioToggle.isOn = false;
        }
        else
            SoundHub.GetInstance().UnmuteAllSFX();
    }

    public void UpdateBackgroundAudio()
    {

        if (muteBgAudioToggle.isOn)
        {
            SoundHub.GetInstance().MuteBackgroundAudio();
            muteAllAudioToggle.isOn = false;
        }
        else
            SoundHub.GetInstance().UnmteBackgroundAudio();
    }

    public void MuteAllAudio()
    {
        if (muteAllAudioToggle.isOn)
        {
            muteBgAudioToggle.isOn = true;
            muteSFXAudioToggle.isOn = true;
        }
        else
        {
            muteBgAudioToggle.isOn = false;
            muteSFXAudioToggle.isOn = false;
        }

        UpdateSoundEffects();
        UpdateBackgroundAudio();
    }

    */
}
