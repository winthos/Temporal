////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollingCredits : MonoBehaviour
{
    [SerializeField]
    List<GameObject> credits;
    [SerializeField]
    GameObject endOfCredits;
    [SerializeField]
    float creditsEndY = 3500f;
    List<Vector3> startingPosition;
    public float scrollSpeed = 2f;
    public string goToScene;

    Coroutine current;
    bool isRunning;

    // Use this for initialization
    void Start()
    {
        if (credits.Count != 0)
        {
            startingPosition = new List<Vector3>();
            for (int i = 0; i < credits.Count; i++)
                startingPosition.Add(credits[i].GetComponent<Transform>().position);
        }
    }

    public void ResetToStartingPositions()
    {
        if (credits.Count != 0)
        {
            for (int i = 0; i < credits.Count; i++)
                credits[i].GetComponent<Transform>().position = startingPosition[i];
        }
    }

    void Update()
    {
        if (credits.Count != 0)
        {
            for (int i = 0; i < credits.Count; i++)
                credits[i].GetComponent<Transform>().position += Vector3.up * scrollSpeed;

            //print(endOfCredits.GetComponent<Transform>().position.y);

            if (endOfCredits.GetComponent<Transform>().position.y > creditsEndY)
            {
                if (goToScene == null)
                    ResetToStartingPositions();
                else
                    UnityEngine.SceneManagement.SceneManager.LoadScene(goToScene);
            }
        }
    }
}