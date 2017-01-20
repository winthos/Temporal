using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class AddAudioToObject : MonoBehaviour
{
    /*
    //[SerializeField]
    //bool MouseOverEvent = true;

    Event eventTrigger;
    AkGameObj akGameObjectScript;
    AkBank akBankScript;

    //[SerializeField]
    //int numberOfSoundBanks = 1;
    //[SerializeField]
    //List<string> soundBanks = new List<string>();
    [SerializeField]
    string soundBank = "";
    [SerializeField]
    string eventName = "";

    void Awake()
    {
        if (gameObject.GetComponent<AkGameObj>() == null)
        {
            akGameObjectScript = gameObject.AddComponent<AkGameObj>() as AkGameObj;
        }
        akBankScript = gameObject.AddComponent<AkBank>() as AkBank;

        if (gameObject.GetComponent<AkGameObj>() != null && akBankScript != null)
            Debug.Log("All good");
    }

	// Use this for initialization
	void Start ()
    {
        akBankScript.bankName = soundBank;
        
        //if (MouseOverEvent)
            //something;
            
    }
    

    public void PlaySoundEvent()
    {
        AkSoundEngine.PostEvent(eventName, this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnDestroy()
    {
        //soundBanks.Clear();
    }
    */
}
