using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    public static StoreController instance;

    public StoreButton selectedBtn;

    [SerializeField]
    private List<StoreButton> buttonList;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        

    }

    private void Start()
    {
       
    }

    public void getSelectedSkin()
    {
        selectedBtn = buttonList[PlayerPrefs.GetInt("selectedSkinIndex")];
        equipSkin();
        
    }

    public void equipSkin()
    {
        GameManager.instance.playerSkinBaloon.sprite = selectedBtn.baloonSkin;
        GameManager.instance.playerSkinTail.sprite = selectedBtn.baloonTail;
    }

        

    public void setSelectedButton(StoreButton storebtn)
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].GetComponent<StoreButton>().selected = false;
        }

        storebtn.selected = true;
        selectedBtn = storebtn;

        for (int i = 0; i < buttonList.Count; i++)
        {
            if(buttonList[i].selected == true)
            {
                PlayerPrefs.SetInt("selectedSkinIndex", i);
                buttonList[i].btn.image.color = Color.blue;
            }
            else
            {
                buttonList[i].btn.image.color = Color.white;
            }
        }
       
    }

   
}
