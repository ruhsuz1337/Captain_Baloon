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

        currentVerticalSpeed = desiredVerticalSpeed;

    }

    private void Start()
    {
        gamesStarted = false;
        gameOver = false;
        sessionGold = 0;
    }

    private void Update()
    {
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
