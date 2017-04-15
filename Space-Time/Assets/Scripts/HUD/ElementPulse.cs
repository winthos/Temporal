using UnityEngine;
using System.Collections;

public class ElementPulse : MonoBehaviour
{
    //public int NumberOfPulses = 2;
    public GameObject pulsePrefab;

	// Use this for initialization
	void Start ()
    {
        /*
	    if(pulsePrefab != null)
            StartCoroutine(CreatePulse());
            */
	}

    public void CreatePulse(int _numberOfPulses = 2)
    {
            for (int i = 0; i < _numberOfPulses; i++)
                Instantiate(pulsePrefab, gameObject.transform.position, gameObject.transform.rotation, GameObject.Find("pulseObjects").transform);
    }
}
