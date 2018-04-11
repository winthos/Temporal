using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    //public Color selectedColor;
    //public Color clickedColor;
    

    void Awake()
    {
        //btn = GetComponent<Button>();
    }

    // Use this for initialization
    void Start()
    {
        defaultColor = btnTxt.color;
        UseDefaults();
    }

    public void UseDefaults()
    {
        btnImg.sprite = defaultSprite;
        btnImg.color = defaultColor;
        btnTxt.color = defaultColor;

        this.transform.localScale = new Vector3(1, 1, 1);
    }

    public void UseHover()
    {
        btnImg.sprite = selectedSprite;
        btnImg.color = Color.white;
        btnTxt.color = Color.black;
        
        this.transform.localScale = new Vector3(1.18f, 1.18f, 1.18f);

        //Debug.Log("hover");
    }

    public void UseClick()
    {
        StartCoroutine(FlashColors());
    }

    public IEnumerator FlashColors()
    {
        return null;
    }
}
