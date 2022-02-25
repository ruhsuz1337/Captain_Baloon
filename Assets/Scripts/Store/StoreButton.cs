using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{

    [SerializeField]
    private Button btn;

    [SerializeField]
    private TMP_Text buttonText;

    [SerializeField]
    private string desiredText;

    [SerializeField]
    private int price;

    [SerializeField]
    private Sprite baloonSkin;

    [SerializeField]
    private Sprite baloonTail;

    private Image image;
    

    private void Start()
    {
        setText();

    }

    public void setText()
    {
        buttonText.text = desiredText;
    }

    public void setImage()
    {

    }

    public void onClick()
    {
        if(GameManager.instance.totalGold >= price)
        {
            GameManager.instance.playerSkinBaloon.sprite = baloonSkin;
            GameManager.instance.playerSkinTail.sprite = baloonTail
            btn.image.color = Color.gray;
        }

    }
}
