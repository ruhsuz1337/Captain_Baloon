using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject startBtn;
    public GameObject storePanel;
    public GameObject storeBtn;
    public GameObject endGamePanel;
    public GameObject startMenu;
    //public GameObject score;
    public GameObject headPanel;
    //public GameObject tailsPanel;
    //public GameObject goldShop;
    public TMP_Text scoreText;
    public TMP_Text totalGoldText;
    public TMP_Text endGameScoreText;
    public TMP_Text highScoreText;
    public GameObject highScoreImage;
    
    private bool storeOpen;


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

    void Start()
    {
        startMenu.SetActive(true);
        //startBtn.SetActive(true);
        //storeBtn.SetActive(true);
        storePanel.SetActive(false);
        endGamePanel.SetActive(false);
        //score.SetActive(false);
        //goldShop.SetActive(false);
        storeOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
        
    }


    public void setScoreText()
    {
        scoreText.text = "" + GameManager.instance.sessionGold;
        totalGoldText.text = "" + GameManager.instance.totalGold;          
        highScoreText.text = (int)(GameManager.instance.sessionHeight) + "ft.";
        
        
    }


    public void startGame()
    {
        

        GameManager.instance.gamesStarted = true;
        startMenu.SetActive(true);
        endGamePanel.SetActive(false);
        //score.SetActive(true);
        //startBtn.SetActive(false);
        //storeBtn.SetActive(false);
        //tailsPanel.SetActive(false);
        headPanel.SetActive(false);

    }

    public void restartGame()
    {

        
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        endGamePanel.SetActive(false);
        GameManager.instance.sessionGold = 0;
        SoundManager.instance.buttonClicker();
        PlayerPrefs.SetInt("restartCount", PlayerPrefs.GetInt("restartCount") + 1);
        GameManager.instance.popUpAd();

    }

    public void storeButton()
    {
        if (!GameManager.instance.gameOver)
        {
            if (!storeOpen)
            {
                startMenu.SetActive(false);
                storePanel.SetActive(true);
                storeOpen = true;
            }
            else
            {
                startMenu.SetActive(true);
                storePanel.SetActive(false);
                storeOpen = false;
            }
            
        }
        else
        {
            if (!storeOpen)
            {
                
                storePanel.SetActive(true);
                storeOpen = true;
            }
            else
            {
                storePanel.SetActive(false);
                storeOpen = false;
            }
            
        }
    }

    public void headsPanelClick()
    {
        SoundManager.instance.buttonClicker();
        //tailsPanel.SetActive(false);
        headPanel.SetActive(true);
        //goldShop.SetActive(false);

    }

    public void tailsPaneClickl()
    {

        //tailsPanel.SetActive(true);
        headPanel.SetActive(false);
        //goldShop.SetActive(false);

    }

    public void goldShopPanel()
    {
        SoundManager.instance.buttonClicker();

        //goldShop.SetActive(true);
        //tailsPanel.SetActive(false);
        headPanel.SetActive(false);
    }
    public void endGame()
    {
        //SoundManager.instance.buttonClick.Play();
        if (GameManager.instance.sessionHeight >= PlayerPrefs.GetFloat("highscore"))
        {
            highScoreImage.SetActive(true);
            PlayerPrefs.SetFloat("highscore", GameManager.instance.sessionHeight);
        }
        else
        {
            highScoreImage.SetActive(false);   
        }
        setScoreText();

        if (GameManager.instance.gameOver)
        {/*
            if (storeOpen)
            {
                endGamePanel.SetActive(false);
            }
            else
            {
                endGamePanel.SetActive(true);
            }*/
            //endGameScoreText.text = scoreText.text;
            endGamePanel.SetActive(true);
            //score.SetActive(false);
            

           

        }
    }

    public void closeButton()
    {
        if (endGamePanel.activeInHierarchy)
        {
            startMenu.SetActive(false);
            storePanel.SetActive(false);
            endGamePanel.SetActive(true);
            SoundManager.instance.buttonClicker();

        }
        else
        {

            
            startMenu.SetActive(true);
            storePanel.SetActive(false);
            endGamePanel.SetActive(false);
            SoundManager.instance.buttonClicker();


        }
    }
}
