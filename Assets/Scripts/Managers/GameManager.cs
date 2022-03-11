using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float desiredVerticalSpeed = 4f;
    public float currentVerticalSpeed;
    public float backgroundSpeed = 4f;

    public bool gamesStarted;
    public bool gameOver;

    public int sessionGold;
    public int totalGold;

    public float highScoreHeight;
    public float sessionHeight;

    public int desiredRestartCount;
    public int restartCount;

    public Interstitial interstitial;
     
    public SpriteRenderer playerSkinBaloon;
    public SpriteRenderer playerSkinHat;
    public SpriteRenderer playerSkinTail;

    private int tmpSessiongold;

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

        
        //

    }

    private void Start()
    {
        //
        //restartCount = 0;
        gamesStarted = false;
        gameOver = false;
        sessionGold = 0;
        restartCount = PlayerPrefs.GetInt("highScore");
        currentVerticalSpeed = desiredVerticalSpeed;
        StoreController.instance.getSelectedSkin();

        totalGold = PlayerPrefs.GetInt("totalGold");
        //highScoreHeight = PlayerPrefs.GetInt("highscore");

    }

    private void Update()
    {
        calculateHighScore();

        if (!gameOver)
        {
            tmpSessiongold = sessionGold;
        }

        //Debug.Log(tmpSessiongold);
        
    }

    public void popUpAd()
    {
        if(PlayerPrefs.GetInt("restartCount") % desiredRestartCount == 0 && PlayerPrefs.GetInt("restartCount") != 0)
        {
            Debug.Log("akdhasldasd");
            interstitial.showads();
            PlayerPrefs.SetInt("restartCount", 0);
        }
    }
    private void FixedUpdate()
    {
        gameStatus();
    }

    private void calculateHighScore()
    {
        if (!gameOver && gamesStarted)
        {
            sessionHeight += Time.deltaTime * 25f;
        }
        
        
        
    }

    private void gameStatus()
    {
        if (gamesStarted && gameOver)
        {
            SoundManager.instance.playDeathSound();
            currentVerticalSpeed = 0;
            backgroundSpeed = 0;
            CanvasManager.instance.endGame();
            PlayerPrefs.SetInt("totalGold", totalGold);
        }

        if (!gamesStarted)
        {
            currentVerticalSpeed = 0;
            backgroundSpeed = 0;
        }
        else
        {
            currentVerticalSpeed = desiredVerticalSpeed;
            backgroundSpeed = 4f;
        }
    }


    public void AdWatched()
    {
        totalGold += tmpSessiongold * 2;


    }

    
}
