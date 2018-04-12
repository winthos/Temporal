////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2018 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class VizualizerScaler : MonoBehaviour {

    public float maxScaleMod = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float vizScale = Mathf.Min(AudioPeer.GlobalScaler * 0.5f, maxScaleMod);
        GetComponent<RectTransform>().localScale = Vector3.one + new Vector3(vizScale, vizScale, 1);
    }
}
