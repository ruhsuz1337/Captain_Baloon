using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float desiredVerticalSpeed = 10f;
    public float currentVerticalSpeed;
    public float backgroundSpeed = 4f;

    public bool gamesStarted;
    public bool gameOver;

    public int score;
    

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
        gamesStarted = true;
        gameOver = false;
    }

    private void Update()
    {
        gameStatus();
    }

    private void gameStatus()
    {
        if (gameOver)
        {
            currentVerticalSpeed = 0;
            backgroundSpeed = 0;
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
