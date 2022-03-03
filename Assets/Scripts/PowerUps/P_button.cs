using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P_button : MonoBehaviour
{

    [SerializeField]
    private string pButtonName;

    [SerializeField]
    private int price;

    [SerializeField]
    private TMP_Text nameText;


    [SerializeField]
    private TMP_Text priceText;



    void Start()
    {
        nameText.text = pButtonName;
        priceText.text = "" + price;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void onClickInvincibility()
    {

        if (GameManager.instance.totalGold >= price)
        {
            P_Manager.instance.invincibilityCount++;
            GameManager.instance.totalGold -= price;
            PlayerPrefs.SetInt("totalGold", GameManager.instance.totalGold);
            PlayerPrefs.SetInt("invincibility", P_Manager.instance.invincibilityCount + 1);
        }
    }

    public void onClickSeconChance()
    {

        if (GameManager.instance.totalGold >= price)
        {
            PlayerPrefs.SetInt("secondchance", P_Manager.instance.secondChanceCount + 1);
        }
    }
}
