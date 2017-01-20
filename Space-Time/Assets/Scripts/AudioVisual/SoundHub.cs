////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using AudioVisualization;
using System.Collections;



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

    void Initialize()
    {
        // programatically load audio clips
    }

    public static SoundHub GetInstance()
    {
        return _instance;
    }


    [SerializeField]
    AudioClip bgm;
    [SerializeField]
    AudioClip gunshot;

    // Use this for initialization
    void Start()
    {
        AudioVisualManager.PlayBGM(bgm, false, 0);
    }

    public static void FireWeapon(GameObject _obj)
    {
        AudioVisualManager.PlaySFX(GetInstance().gunshot, _obj, 1);
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
