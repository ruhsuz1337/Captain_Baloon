using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class StoreButton : MonoBehaviour
{

    [Header("Assets")]
    public Sprite baloonHat;
    public Sprite baloonSkin;      
    public Sprite baloonTail;


    [Header("Base Details")]
    [SerializeField]
    public string desiredText;
    [SerializeField]
    private int price;
    [SerializeField]
    private Sprite imageIcon;
    [SerializeField]
    public bool hasEffects;

    [Header("EditorStuff")]
    [SerializeField]
    public Button btn;
    public Sprite buyImage;
    public Sprite equippedImg;
    public Sprite equipImage;


    [SerializeField]
    private TMP_Text buttonText;
    [SerializeField]
    private TMP_Text priceText;
    [SerializeField]
    private Image img;
    [SerializeField]
    private TMP_Text story;
    [SerializeField]
    private Image goldIcon;
    [SerializeField]
    private string storyText;

    public bool selected;
    private bool bought;


    private void Start()
    {
        setText();
        setImage();
        story.text = storyText;
        if (PlayerPrefs.GetInt(desiredText) == 0)
        {
            PlayerPrefs.SetInt(desiredText, 0);
            priceText.gameObject.SetActive(true);
            goldIcon.gameObject.SetActive(true);
            story.gameObject.SetActive(false);
            btn.image.sprite = buyImage;
        }
        else 
        {
            if (selected)
            {
                btn.image.sprite = equippedImg;
            }
            else
            {
                btn.image.sprite = equipImage;
            }
            PlayerPrefs.SetInt(desiredText, 1);
            btn.image.sprite = equippedImg;
            priceText.gameObject.SetActive(false);
            goldIcon.gameObject.SetActive(false);
            story.gameObject.SetActive(true);
            
        }

        
       
        

    }

    private void Update()
    {
        
    }

    public void setText()
    {
        buttonText.text = desiredText;
        priceText.text = "" + price;
    }

    public void setImage()
    {
        img.sprite = imageIcon;
    }

   
    public void onClick()
    {
        SoundManager.instance.buttonClicker();
        
            if (PlayerPrefs.GetInt(desiredText) == 0)
            {
                if (GameManager.instance.totalGold >= price)
                {

                
                GameManager.instance.playerSkinBaloon.sprite = baloonSkin;
                    GameManager.instance.playerSkinHat.sprite = baloonHat;
                    GameManager.instance.playerSkinTail.sprite = baloonTail;
                    StoreController.instance.setSelectedButton(gameObject.GetComponent<StoreButton>());
                    GameManager.instance.totalGold -= price;
                    PlayerPrefs.SetInt("totalGold", GameManager.instance.totalGold);
                    PlayerPrefs.SetInt(desiredText, 1);
                    btn.image.sprite = equipImage;
                    bought = true;
                    selected = true;
                priceText.gameObject.SetActive(false);
                goldIcon.gameObject.SetActive(false);
                story.gameObject.SetActive(true);
            }
            }
            else if (PlayerPrefs.GetInt(desiredText) == 1)
            {
            
                GameManager.instance.playerSkinBaloon.sprite = baloonSkin;
                GameManager.instance.playerSkinHat.sprite = baloonHat;
                GameManager.instance.playerSkinTail.sprite = baloonTail;
                StoreController.instance.setSelectedButton(gameObject.GetComponent<StoreButton>());
                PlayerPrefs.SetInt(desiredText, 1);
                

                selected = true;
            }

       
        
        

    }
}
