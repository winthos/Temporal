////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class ElementPulse : MonoBehaviour
{
    public int NumberOfPulses = 2;
    public GameObject pulsePrefab;

	// Use this for initialization
	void Start ()
    {
        /*
	    if(pulsePrefab != null)
            StartCoroutine(CreatePulse());
            */
	}

    public IEnumerator CreatePulse(int _pulseNumber = 0, float _delay = 0)
    {
        if (_pulseNumber != 0)
            NumberOfPulses = _pulseNumber;

        yield return new WaitForSeconds(_delay);
        for (int i = 0; i < NumberOfPulses; i++)
            Instantiate(pulsePrefab, gameObject.transform.position, gameObject.transform.rotation, GameObject.Find("pulseObjects").transform);
            
    }
}
