////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2018 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //public Button btn;
    public Image btnImg;
    public Text btnTxt;

    [Space()]

    public Sprite defaultSprite;
    public Sprite selectedSprite;

    [Space()]
    public string nextScene;
    public bool loadScene = false;

    [HideInInspector]
    public Color defaultColor;

    [HideInInspector]
    public bool selected;
    public float visualizerMax = 0.18f;

    // Use this for initialization
    void Start()
    {
        defaultColor = btnTxt.color;
        UseDefaults();
    }

    public void Update()
    {

        if (selected)
        {
            float vizScale = Mathf.Min(AudioPeer.GlobalScaler, visualizerMax);
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
        SoundHub.PlayButtonHover();
    }

    public void UseClick()
    {
        SoundHub.PlayButtonClick();
        StartCoroutine(FlashColors());
    }

    public IEnumerator FlashColors()
    {
        yield return new WaitForSeconds(2f);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        if (nextScene == null || loadScene)
        {
            SceneManager.LoadScene(nextScene);
            Debug.Log("Quit Game");
        }
        else
        {

        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        UseHover();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UseDefaults();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UseClick();
    }
}
