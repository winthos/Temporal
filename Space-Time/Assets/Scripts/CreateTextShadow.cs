using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateTextShadow : MonoBehaviour
{
    public Vector3 offset = new Vector3(2,-0.5f,-0.5f);

    private void Awake()
    {
        GameObject shadowObj = new GameObject();
        Text shadowText = shadowObj.AddComponent<Text>();
        Text originalText = gameObject.GetComponent<Text>();

        // text
        shadowText.text = originalText.text;
        // character
        shadowText.font = originalText.font;
        shadowText.fontStyle = originalText.fontStyle;
        shadowText.fontSize = originalText.fontSize;
        shadowText.lineSpacing = originalText.lineSpacing;
        shadowText.supportRichText = originalText.supportRichText;
        //paragraph
        shadowText.alignment = originalText.alignment;
        shadowText.alignByGeometry = originalText.alignByGeometry;
        shadowText.horizontalOverflow = originalText.horizontalOverflow;
        shadowText.verticalOverflow = originalText.verticalOverflow;
        shadowText.resizeTextForBestFit = originalText.resizeTextForBestFit;
        // color
        shadowText.color = Color.black;

        Instantiate(shadowObj, gameObject.transform.position + offset, gameObject.transform.rotation, gameObject.transform);
    }

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
