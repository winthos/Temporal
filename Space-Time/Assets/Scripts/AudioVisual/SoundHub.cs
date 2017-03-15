////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using AudioVisualization;
using System.Collections.Generic;


public class SoundHub : MonoBehaviour
{
    // Static instance
    static SoundHub _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _instance.Initialize();
        }
    }


    public static SoundHub GetInstance()
    {
        return _instance;
    }

    AudioClip logoScreen;
    AudioClip ui_select;
    AudioClip ai_hover;

    AudioClip bgm;

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

    static public AudioSource source_bgm;

    void Initialize()
    {
        // programatically load audio clips
        //sound = Resources.Load<AudioClip>(path);
        logoScreen  = Resources.Load<AudioClip>("Sound/bgm/Intro_Splashscreen");
        ui_select   = Resources.Load<AudioClip>("Sound/ui/Menu_Select");
        ai_hover    = Resources.Load<AudioClip>("Sound/ui/Menu_Hover");

        //bgm = Resources.Load<AudioClip>("Sound/bgm/Space-Time_a.groves_StylePiece");
        bgm = Resources.Load<AudioClip>("Sound/SpaceTime");

        moveDirection = new List<AudioClip>();
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_01"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_02"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_03"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_04"));
        moveDirection.Add(Resources.Load<AudioClip>("Sound/sfx/Direction_Change_05"));

        timeStop        = Resources.Load<AudioClip>("Sound/sfx/TimeSlowsSound");
        timeResume      = Resources.Load<AudioClip>("Sound/sfx/TimeSpeedsUpSound");
        timeWobble      = Resources.Load<AudioClip>("Sound/sfx/boopsound");
        tickingClock    = Resources.Load<AudioClip>("Sound/sfx/persistantClockTick");

        //playerDamage = Resources.Load<AudioClip>("Sound/sfx/Sinematic - Complex Tech Hits -04");
        playerDeath = Resources.Load<AudioClip>("Sound/sfx/Sinematic - Complex Tech Hits - 04");
        pickupRift = Resources.Load<AudioClip>("Sound/sfx/PickupSound");

        timeBomb = Resources.Load<AudioClip>("Sound/sfx/BombSound");
        asteroidExplosion = Resources.Load<AudioClip>("Sound/sfx/SmashSound");

        source_bgm = AudioVisualManager.PlayBGM(bgm, false, 0, -0.3f);
    }

    // Use this for initialization
    void Start()
    {
    }

    /*
    public static void FireWeapon(GameObject _obj)
    {
        AudioVisualManager.PlaySFX(GetInstance().gunshot, _obj, 1);
    }
    */
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


    public static void PlayerDeath()
    {
        AudioVisualManager.PlaySFX(GetInstance().playerDeath);
    }

    public static void PlayerMoves(GameObject _obj)
    {
        AudioVisualManager.PlaySFXRandomized(GetInstance().moveDirection[0], null, 0, +0.3f,0.8f,1.3f);
        //AudioVisualManager.PlaySFXRandomizedFromList(GetInstance().moveDirection, _obj, 1);
    }

    public static void EnemyTimeBomb()
    {
        AudioVisualManager.PlaySFX(GetInstance().timeBomb);
    }

    public static void AsteroidExplosion()
    {
        AudioVisualManager.PlaySFX(GetInstance().asteroidExplosion);
    }

    public static void Pickup()
    {
        AudioVisualManager.PlaySFX(GetInstance().pickupRift);
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




    /// <summary>
    /// functions called from the game, much like the AKbanks
    /// </summary>

    public void EnterPauseState()
    {
        // muffle bg audio
        // pause all sfx
        // pause all visuals?
    }

    public void ExitPauseState()
    {
        // remove effect on bg audio
        // resume all sfx
        // resume all visuals?
    }

    public void StopAllAudio()
    {

    }

    public void ResetAllAudio()
    {

    }
}
