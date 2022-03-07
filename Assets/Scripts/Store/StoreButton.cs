using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    [Header("EditorStuff")]
    [SerializeField]
    public Button btn;
    [SerializeField]
    public TMP_Text buyButtonText;


    [SerializeField]
    private TMP_Text buttonText;
    

    

    
    [SerializeField]
    private TMP_Text priceText;

    

    

    [SerializeField]
    private Image img;

    public bool selected;



    private void Start()
    {
        setText();
        setImage();
        if (PlayerPrefs.GetInt(desiredText) == 0)
        {
            PlayerPrefs.SetInt(desiredText, 0);
        }
        else 
        {
            PlayerPrefs.SetInt(desiredText, 1);
            buyButtonText.text = "Equip";
            btn.image.color = Color.white;
        }
       
        

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
        //SoundManager.instance.buttonClicker();
        
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
                    buyButtonText.text = "Owned";
                   
                    selected = true;
                }
            }
            else if (PlayerPrefs.GetInt(desiredText) == 1)
            {
                GameManager.instance.playerSkinBaloon.sprite = baloonSkin;
                GameManager.instance.playerSkinHat.sprite = baloonHat;
                GameManager.instance.playerSkinTail.sprite = baloonTail;
            //GameManager.instance.playerSkinTail.sprite = baloonTail;
                StoreController.instance.setSelectedButton(gameObject.GetComponent<StoreButton>());
                PlayerPrefs.SetInt(desiredText, 1);
                

                selected = true;
            }

        
        
        

    }
}
