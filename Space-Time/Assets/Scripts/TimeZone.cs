////////////////////////////////////////////////////////////////////////////////
//	Authors: Jordan Yong
//	Copyright © 2016 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class TimeZone
{
    private static float timeScale;
 
      //Sets TimeScale (Lerp?)
    public static void SetTimeScale( float ts ) 
    {
       Time.timeScale = ts;
       timeScale = ts;
    }
 
      //Custom deltaTime, those unaffected by time slow still move at the same speed.
    public static float DeltaTime( bool affectBySlowTime ) 
    {
       return Time.deltaTime / ((affectBySlowTime)? 1f : timeScale);
    }
    
      // Default param gets normal delta time
    public static float DeltaTime() 
    {
       return Time.deltaTime;
    }
 }