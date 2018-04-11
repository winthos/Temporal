using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite selectedSprite;
    public Color defaultColor;
    public Color selectedColor;

    private Button btn;
    private Image img;

    void Awake()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
    }

    // Use this for initialization
    void Start()
    {
        btn.OnPointerEnter(MouseOver());

        img.sprite = defaultSprite;
        img.color = defaultColor;
    }

    private void MouseOver()
    {
        img.sprite = selectedSprite;
        img.color = selectedColor;
        Debug.Log("hover");
    }

    private void OnMouseExit()
    {
        img.sprite = defaultSprite;
        img.color = defaultColor;
    }
}
