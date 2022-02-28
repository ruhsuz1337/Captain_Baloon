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

    public SpriteRenderer playerSkinBaloon;
    public SpriteRenderer playerSkinTail;

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
        gamesStarted = false;
        gameOver = false;
        sessionGold = 0;

        currentVerticalSpeed = desiredVerticalSpeed;
        StoreController.instance.getSelectedSkin();

        totalGold = PlayerPrefs.GetInt("totalGold");

    }
    /*
    private void Update()
    {
        gameStatus();
    }*/

    private void FixedUpdate()
    {
        Debug.Log("qwohe");
        gameStatus();
    }

    private void gameStatus()
    {
        if (gamesStarted && gameOver)
        {
            currentVerticalSpeed = 0;
            backgroundSpeed = 0;
            totalGold += sessionGold;
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

    
}
