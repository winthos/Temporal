////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    uint bgAudioID;

    void Awake()
    {
        //AkBankManager.Reset();
        //bgAudioID = AkSoundEngine.PostEvent("event_bg_audio", this.gameObject);
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnDestroy()
    {
        //AkSoundEngine.StopAll();
    }
}
