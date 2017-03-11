using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scoring : MonoBehaviour
{
    public bool scoreRunning;

    // main score info
    float multiplier; //have multiplier deend on speed and enemy collisions
    float totalScore;

    // individual scores
    float timeScore;    //based on time alive
    float speedScore;   //have speed score based off max speed
    float enemyScore;   // based on enemies destroyed
    float pickupScore;  //based on pickups collected
    float enemiesDestroyed;
    float pickupsCollected;

    // individual scores
    float timeScoreRate = 0.0005f;
    float speedScoreRate = 0.0015f;
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
        scoreRunning = true;
        multiplier = 1;
        totalScore = 0;

        enemiesDestroyed = 0;
        pickupsCollected = 0;

        // style ratings            S       A       B       C       D       F
        times   = new List<float> { 120f,   90f,    60f,    30f,    15f,    0f };
        speeds  = new List<float> { 120f,   90f,    60f,    30f,    15f,    0f };
        enemies = new List<float> { 20,     10,     7,      3,      1,      0f };
        pickups = new List<float> { 20,     10,     7,      3,      1,      0f  };
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(scoreRunning)
        {
            totalScore += multiplier * (TimeScore() + SpeedScore() + enemyScore + pickupScore);
            //print(totalScore);
            //print("time " + TimeScore() + ", speed " + SpeedScore() + ", Enemy " + enemyScore + ", pickups " + pickupScore );
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            print(GetScoreRating(speedScore, speeds));
            print(speedScore);
        }

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

    public float TimeScore()
    {
        timeScore += timeScoreRate * Time.deltaTime;
        return timeScore;
    }

    public float SpeedScore()
    {
        speedScore += speedScoreRate * Time.deltaTime;
        return speedScore;
    }

    public void UpdateEnemyScore()
    {
        enemiesDestroyed++;
        enemyScore = enemiesDestroyed * enemyScoreRate;
    }
    public void UpdatePickupScore()
    {
        pickupsCollected++;
        pickupScore = pickupsCollected * enemyScoreRate;
    }

    public float ChangeMultiplierTo(float _newValue)
    {
        multiplier = _newValue;
        return multiplier;
    }
}
