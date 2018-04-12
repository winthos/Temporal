////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2018 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    //public Button btn;
    public Image btnImg;
    public Text btnTxt;

    [Space()]

    public Sprite defaultSprite;
    public Sprite selectedSprite;

    [Space()]
    public string nextScene;

    [HideInInspector]
    public Color defaultColor;

    [HideInInspector]
    public bool selected;
    AudioSource source;
    public float visualizerMax = 0.18f;

    // Use this for initialization
    void Start()
    {
        source = SoundHub.source_bgm;
        defaultColor = btnTxt.color;
        UseDefaults();
    }

    public void Update()
    {

        if (selected)
        {
            float vizScale = Mathf.Min(BarVisulization.GlobalVizScaler * 10, visualizerMax);
            btnImg.GetComponent<RectTransform>().localScale = Vector3.one + new Vector3(vizScale, vizScale, 1);
            //Todo: add audio buffer
        }
        else
        {
            btnImg.transform.localScale = Vector3.one;
        }
    }


    public void UseDefaults()
    {
        btnImg.sprite = defaultSprite;
        btnImg.color = defaultColor;
        btnTxt.color = defaultColor;

        //this.transform.localScale = new Vector3(1, 1, 1);

        selected = false;
    }

    public void UseHover()
    {
        btnImg.sprite = selectedSprite;
        btnImg.color = Color.white;
        btnTxt.color = Color.black;
        
        //this.transform.localScale = new Vector3(1.18f, 1.18f, 1.18f);

        selected = true;
        //Debug.Log("hover");
    }

    public void UseClick()
    {
        StartCoroutine(FlashColors());
    }

    public IEnumerator FlashColors()
    {
        yield return new WaitForSeconds(2f);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
        if (nextScene == null || nextScene == string.Empty)
        {
            Debug.Log("Quit Game");
        }
    }
}
