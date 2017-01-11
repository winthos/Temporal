////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
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
