using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public bool lucky;

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
       
        gamesStarted = false;
        gameOver = false;
        sessionGold = 0;
        restartCount = PlayerPrefs.GetInt("highScore");
        currentVerticalSpeed = desiredVerticalSpeed;
        StoreController.instance.getSelectedSkin();

        totalGold = PlayerPrefs.GetInt("totalGold");
        
        
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

    

    //public Color[] SpecialSkinColors;
    //int currentColor = 0;
    //Coroutine changeColorRoutine;
    //private float changeColorSpeed = .5f;

    //Color GetRandomColorFromPalette()
    //{
    //    int x = Random.Range(0, SpecialSkinColors.Length);
    //    Color col = SpecialSkinColors[x];
    //    if (x == currentColor) return GetRandomColorFromPalette();
    //    currentColor = x;
    //    return col;
    //}

    //public void skinEffects()
    //{
    //    if(!StoreController.instance.selectedBtn.hasEffects)
    //    {
    //        if(changeColorRoutine != null)
    //            StopCoroutine(changeColorRoutine);
    //        return;
    //    }
    //    changeColorRoutine = StartCoroutine(ChangeColorRoutine());

    //}

    //IEnumerator ChangeColorRoutine()
    //{
    //    while (true)
    //    {
    //        Color colour = GetRandomColorFromPalette();
    //        playerSkinBaloon.DOColor(colour, changeColorSpeed).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
    //        yield return new WaitForSeconds(changeColorSpeed * 2 + .001f);
    //    }
    //}

    public void popUpAd()
    {
        if(PlayerPrefs.GetInt("restartCount") % desiredRestartCount == 0 && PlayerPrefs.GetInt("restartCount") != 0)
        {
            interstitial.showads();
            PlayerPrefs.SetInt("restartCount", 0);
        }
    }

    public void rewardedAd()
    {

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
