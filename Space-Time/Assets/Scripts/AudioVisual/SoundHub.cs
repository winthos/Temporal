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
    
    AudioClip bgm;

    List<AudioClip> moveDirection;

    AudioClip timeStop;
    AudioClip timeResume;
    AudioClip timeWobble;
    AudioClip tickingClock;
    
    AudioClip playerDamage;
    AudioClip playerDeath;
    AudioClip pickupRift;


    void Initialize()
    {
        // programatically load audio clips
        //sound = Resources.Load<AudioClip>(path);
        bgm = Resources.Load<AudioClip>("Sound/bgm/Space-Time_a.groves_StylePiece");

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
        playerDeath = Resources.Load<AudioClip>("Sound/sfx/Sinematic - Complex Tech Hits -04");
        pickupRift = Resources.Load<AudioClip>("Sound/sfx/Pickup_Rift");
    }

    // Use this for initialization
    void Start()
    {
        AudioVisualManager.PlayBGM(bgm, false, 0);
    }

    /*
    public static void FireWeapon(GameObject _obj)
    {
        AudioVisualManager.PlaySFX(GetInstance().gunshot, _obj, 1);
    }
    */
    public static void PlayTimeStopSFX()
    {
        AudioVisualManager.PlaySFX(GetInstance().timeStop);
        AudioVisualManager.PlaySFX(GetInstance().timeWobble);
    }

    public static void PlayTimeResumeSFX()
    {
        AudioVisualManager.PlaySFX(GetInstance().timeResume);
        AudioVisualManager.PlaySFX(GetInstance().timeWobble);
    }


    public static void PlayerDeath()
    {
        AudioVisualManager.PlaySFX(GetInstance().playerDeath);
    }

    public static void PlayerMoves(GameObject _obj)
    {
        AudioVisualManager.PlaySFXRandomizedFromList(GetInstance().moveDirection, _obj, 1);
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
