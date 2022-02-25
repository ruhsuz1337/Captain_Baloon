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
    public GameObject score;
    public TMP_Text scoreText;
    public TMP_Text endGameScoreText;
    private bool storeOpen;
    private bool endGameOpen;


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
        startBtn.SetActive(true);
        storeBtn.SetActive(true);
        storePanel.SetActive(false);
        endGamePanel.SetActive(false);
        score.SetActive(false);
        storeOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
    }


    public void setScoreText()
    {
        scoreText.text = "Score: " + GameManager.instance.sessionGold;
    }
    public void startGame()
    {
        GameManager.instance.gamesStarted = true;
        score.SetActive(true);
        startBtn.SetActive(false);
        storeBtn.SetActive(false);
        endGameOpen = false;

    }

    public void restartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        endGamePanel.SetActive(false);
        GameManager.instance.sessionGold = 0;
        endGameOpen = false;
    }

    public void storeButton()
    {
        if (!GameManager.instance.gameOver)
        {
            if (!storeOpen)
            {
                startBtn.SetActive(false);
                storePanel.SetActive(true);
                storeOpen = true;
            }
            else
            {
                startBtn.SetActive(true);
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

    public void endGame()
    {
        if (GameManager.instance.gameOver)
        {
            if (storeOpen)
            {
                endGamePanel.SetActive(false);
            }
            else
            {
                endGamePanel.SetActive(true);
            }
            endGameScoreText.text = scoreText.text;
            storeBtn.SetActive(true);
            score.SetActive(false);
            endGameOpen = true;
            

           

        }
    }
}
