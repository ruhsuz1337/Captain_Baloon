using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{

    [SerializeField]
    public Button btn;

    [SerializeField]
    private TMP_Text buttonText;

    [SerializeField]
    private string desiredText;

    [SerializeField]
    private int price;

    [SerializeField]
    public Sprite baloonSkin;

    [SerializeField]
    public Sprite baloonTail;

    [SerializeField]
    private Sprite imageIcon;

    [SerializeField]
    private Image img;

    public bool selected;

    private bool bought;

    private void Start()
    {
        setText();
        setImage();
        PlayerPrefs.SetInt(desiredText, 0);

    }

    public void setText()
    {
        buttonText.text = desiredText;
    }

    public void setImage()
    {
        img.sprite = imageIcon;
    }

    public void onClick()
    {

        if (PlayerPrefs.GetInt(desiredText) == 0)
        {
            if (GameManager.instance.totalGold >= price)
            {
                GameManager.instance.playerSkinBaloon.sprite = baloonSkin;
                GameManager.instance.playerSkinTail.sprite = baloonTail;
                StoreController.instance.setSelectedButton(gameObject.GetComponent<StoreButton>());
                GameManager.instance.totalGold -= price;
                PlayerPrefs.SetInt("totalGold", GameManager.instance.totalGold);
                PlayerPrefs.SetInt(desiredText, 1);
                selected = true;
            }
        }else if (PlayerPrefs.GetInt(desiredText) == 1)
        {
            GameManager.instance.playerSkinBaloon.sprite = baloonSkin;
            GameManager.instance.playerSkinTail.sprite = baloonTail;
            StoreController.instance.setSelectedButton(gameObject.GetComponent<StoreButton>());
            PlayerPrefs.SetInt(desiredText, 1);
            selected = true;
        }
        

    }
}