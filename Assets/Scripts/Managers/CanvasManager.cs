using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    GameObject startBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        GameManager.instance.gamesStarted = true;
        startBtn.SetActive(false);

    }

    public void restartGame()
    {

    }
}
