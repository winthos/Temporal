////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using AudioVisualization;
using System.Collections.Generic;
using System.Collections;

public class SoundHub : MonoBehaviour
{
    // Static instance
    public static SoundHub instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.Initialize();
        }
    }


    public static SoundHub GetInstance()
    {
        return instance;
    }

    float sfxVolume;
    float bgmVolume;
    float globalVolume;
    float globalPauseVolume;


    AudioClip logoScreen;
    AudioClip ui_select;
    AudioClip ui_hover;

    public AudioClip bgm;

    List<AudioClip> moveDirection;

    AudioClip timeStop;
    AudioClip timeResume;
    AudioClip timeWobble;
    AudioClip tickingClock;

    AudioClip playerDamage;
    AudioClip playerDeath;
    AudioClip pickupRift;

    AudioClip timeBomb;
    AudioClip asteroidExplosion;

    static public AudioSource source_bgm { get; set; }

    void Initialize()
    {
        // programatically load audio clips
        //sound = Resources.Load<AudioClip>(path);
        logoScreen = Resources.Load<AudioClip>("Sound/bgm/Intro_Splashscreen");
        ui_select = Resources.Load<AudioClip>("Sound/ui/Menu_Select");
        ui_hover = Resources.Load<AudioClip>("Sound/ui/Menu_Hover");

        //bgm = Resources.Load<AudioClip>("Sound/bgm/Space-Time_a.groves_StylePiece");
        if (bgm == null)
            bgm = Resources.Load<AudioClip>("Sound/SpaceTime");

        moveDirection = new List<AudioClip>();
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_01"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_02"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_03"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_04"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_05"));

        timeStop = Resources.Load<AudioClip>("Sound/sfx/TimeSlowsSound");
        timeResume = Resources.Load<AudioClip>("Sound/sfx/TimeSpeedsUpSound");
        timeWobble = Resources.Load<AudioClip>("Sound/sfx/boopsound");
        tickingClock = Resources.Load<AudioClip>("Sound/sfx/persistantClockTick");

        playerDamage = Resources.Load<AudioClip>("Sound/sfx/Sinematic - Complex Tech Hits -04");
        playerDeath = Resources.Load<AudioClip>("Sound/sfx/EndSoundEffect");
        pickupRift = Resources.Load<AudioClip>("Sound/sfx/PickupSound");

        timeBomb = Resources.Load<AudioClip>("Sound/sfx/BombSound");
        asteroidExplosion = Resources.Load<AudioClip>("Sound/sfx/SmashSound");

        source_bgm = AudioVisualManager.PlayBGM(bgm, false, 0, -0.3f);

        bgmVolume = source_bgm.volume;
    }


    public static void PlaySplashScreenAudio()
    {
        AudioVisualManager.PlaySFX(GetInstance().logoScreen);
    }

    public static void PlayButtonHover()
    {
        AudioVisualManager.PlaySFX(GetInstance().ui_hover);
    }
    public static void PlayButtonClick()
    {
        AudioVisualManager.PlaySFX(GetInstance().ui_hover);
    }

    public static void PlayTimeStopSFX(GameObject _obj)
    {
        AudioVisualManager.StopAllObjectSFX(_obj);
        AudioVisualManager.PlaySFX(GetInstance().timeStop, _obj);
        AudioVisualManager.PlaySFX(GetInstance().timeWobble, _obj, 0, -0.3f);
    }

    public static void PlayTimeResumeSFX(GameObject _obj)
    {
        AudioVisualManager.StopAllObjectSFX(_obj);
        AudioVisualManager.PlaySFX(GetInstance().timeResume, _obj);
        AudioVisualManager.PlaySFX(GetInstance().timeWobble, _obj, 0, -0.3f);
    }


    public static void PlayPlayerDamaged()
    {
        AudioVisualManager.PlaySFX(GetInstance().playerDamage);
    }
    public static IEnumerator PlayPlayerDeath()
    {
        AudioVisualManager.SetBGMVolume(0.25f);
        AudioVisualManager.PlaySFX(GetInstance().playerDeath);
        yield return new WaitForSeconds(2.5f);
        yield return null;
    }

    public static void PlayerMoves(GameObject _obj)
    {
        AudioVisualManager.PlaySFXRandomized(GetInstance().moveDirection[0], null, 0, +0.3f, 0.8f, 1.3f);
        //AudioVisualManager.PlaySFXRandomizedFromList(GetInstance().moveDirection, _obj, 1);
    }

    public static void PlayEnemyTimeBomb()
    {
        AudioVisualManager.PlaySFX(GetInstance().timeBomb);
    }

    public static void PlayAsteroidExplosion()
    {
        AudioVisualManager.PlaySFX(GetInstance().asteroidExplosion);
    }

    public static void PlayPickup()
    {
        AudioVisualManager.PlaySFX(GetInstance().pickupRift);
    }


    public static void PlayStageChange()
    {
        AudioVisualManager.PlaySFX(GetInstance().pickupRift, null, 0, -0.7f);
    }


    // paused volume
    public void EnterPauseState(float _newVolume = 0.4f)
    {
        GetInstance().globalVolume = _newVolume;
        if (_newVolume == 0)
            AudioVisualManager.DisableSoundImmediate();
        else
            AudioVisualManager.SetGlobalVolume(GetInstance().globalVolume);
    }

    // resume volume
    public void ExitPauseState(float _newVolume = 1f)
    {
        GetInstance().globalVolume = _newVolume;
        AudioVisualManager.SetGlobalVolume(GetInstance().globalVolume);
    }

    // mute all sound effects
    public void MuteAllSFX(float _newVolume = 0f)
    {
        GetInstance().sfxVolume = _newVolume;
        AudioVisualManager.SetSFXVolume(GetInstance().sfxVolume);
    }

    // unmute all sound effects
    public void UnmuteAllSFX(float _newVolume = 1f)
    {
        GetInstance().sfxVolume = _newVolume;
        AudioVisualManager.SetSFXVolume(GetInstance().sfxVolume);
    }

    // mute background audio
    public void MuteBackgroundAudio(float _newVolume = 0f)
    {
        GetInstance().bgmVolume = _newVolume;
        AudioVisualManager.SetBGMVolume(GetInstance().bgmVolume);
    }
    // unmute background audio
    public void UnmteBackgroundAudio(float _newVolume = 1f)
    {
        GetInstance().bgmVolume = _newVolume;
        AudioVisualManager.SetBGMVolume(GetInstance().bgmVolume);
    }



    //load audio clips into AVM

    //player damage
    //player death
    //rift get
    //time stop
    //time resume
    //move in direction
    //enemy charging
    //enemy fires
    // collide with asteroids


    public void ResetAllAudio()
    {

    }
}
