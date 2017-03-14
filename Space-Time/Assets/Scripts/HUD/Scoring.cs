////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    [SerializeField]
    Text scoreField;

    [SerializeField]
    Text multiplierField;

    [SerializeField]
    Text speedField;
    
    // main score info
    float multiplier; //have multiplier depend on speed and enemy collisions
    float tempMultiplier;
    float totalScore;

    // individual scores
    float timeScore;    //based on time alive
    float speedScore;   //have speed score based off max speed
    float enemyScore;   // based on enemies destroyed
    float pickupScore;  //based on pickups collected
    public static int enemiesDestroyed;
    public static int pickupsCollected;

    // individual scores
    float timeScoreRate = 0.05f;
    float speedScoreRate = 0.15f;
    float enemyScoreRate = 10f;
    float pickupScoreRate = 5f;

    // thresholds
    List<float> times;
    List<float> speeds;
    List<float> enemies;
    List<float> pickups;

    // Style Ratings
    string timeRating;
    string speedRating;
    string enemyRating;
    string pickupRating;
    string totalRating;


    // Use this for initialization
    void Start ()
    {
        multiplier = 1;
        totalScore = 0;

        enemiesDestroyed = 0;
        pickupsCollected = 0;

        // style ratings            S       A       B       C       D       F
        times   = new List<float> { 120f,   90f,    60f,    30f,    15f,    0f };
        speeds  = new List<float> { 120f,   90f,    60f,    30f,    15f,    0f };
        enemies = new List<float> { 20,     10,     7,      3,      1,      0f };
        pickups = new List<float> { 20,     10,     7,      3,      1,      0f  };

        scoreField.text = totalScore.ToString();
        multiplierField.text = "x" + multiplier;
        speedField.text = Mathf.RoundToInt(LevelGlobals.distanceTraveled / LevelGlobals.TimePassed) + " km/s";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!PauseController.Paused)
        {
            //TimeScore();
            //SpeedScore();
            totalScore += TimeScore();

            scoreField.text = Mathf.Max(0, Mathf.RoundToInt(totalScore)).ToString();
            multiplierField.text = "x" + multiplier;
            speedField.text = Mathf.RoundToInt(LevelGlobals.distanceTraveled / LevelGlobals.TimePassed) * 10 + " km/s";
            //print("time " + TimeScore() + ", speed " + SpeedScore() + ", Enemy " + enemyScore + ", pickups " + pickupScore );
            
            ScoreMultiplier(HUDStageController.currStage);
        }
    }

    public float TimeScore()
    {
        timeScore = timeScoreRate * LevelGlobals.TimePassed;
        //totalScore += timeScore;
        return timeScore;
    }

    public float SpeedScore()
    {
        speedScore += (LevelGlobals.distanceTraveled / LevelGlobals.TimePassed) * speedScoreRate;
        //totalScore += speedScore;
        return speedScore;
    }

    public void UpdateEnemyScore()
    {
        enemyScore = enemiesDestroyed * enemyScoreRate;
        //totalScore += enemyScore;
    }
    public void UpdatePickupScore()
    {
        pickupScore = PlayerMovement.pMove.SpeedStacks * pickupScoreRate;
        //totalScore += pickupScore;
        Debug.Log("pickup");
    }

    public static void UpdateEnemyCount(int _value)
    {
        enemiesDestroyed += _value;
    }
    public static void UpdatePickupCount(int _value)
    {
        pickupsCollected += _value;

    }
    public float ChangeMultiplierTo(float _newValue)
    {
        multiplier = _newValue;
        return multiplier;
    }

    public float TotalScore()
    {
        return totalScore;
    }

    public float DecrimentMultiplierBy(float _value)
    {
        multiplier -= _value;
        return multiplier;
    }

    public void ScoreMultiplier(int _currentStage)
    {
        float stageMult = _currentStage + 1;

        /*
        if (stageMult < multiplier)
        {
            tempMultiplier = multiplier;
            multiplier = stageMult;
        }
        else*/
            multiplier = stageMult;
        

    }

    string GetScoreRating(float _score, List<float> _list)
    {
        string rating = string.Empty;

        for(int i = 0; i < _list.Count; i++)
        {
            if(_list[i] >= _score)
            {
                if (i == 0)
                    rating = "S";
                else if (i == 1)
                    rating = "A";
                else if (i == 2)
                    rating = "B";
                else if (i == 3)
                    rating = "C";
                else if (i == 4)
                    rating = "D";
                else if (i == 5)
                    rating = "F";
            }
        }

        return rating;
    }
}
