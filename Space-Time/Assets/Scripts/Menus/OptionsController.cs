////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    Toggle muteAllAudioToggle;
    [SerializeField]
    Toggle muteSFXAudioToggle;
    [SerializeField]
    Toggle muteBgAudioToggle;
    [SerializeField]
    Toggle fullscreenOn;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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

    public void ToggleFullscreen()
    {
        if (fullscreenOn.isOn)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;

    }
}
