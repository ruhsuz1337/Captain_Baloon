using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{


    public float coinSpeed = .1f; 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement();
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            SoundManager.instance.collectCoinSound();
            GameManager.instance.sessionGold++;
        }
    }
    /*
    private void spawnAtTop()
    {
        if(transform.position.y < -10)
        {
            transform.position = CoinSpawner.instance.spawnCoin();
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void movement()
    {
        if(GameManager.instance.gamesStarted && !GameManager.instance.gameOver)
        {
            transform.position += new Vector3(0, -coinSpeed, 0);
            spawnAtTop();
        }
    }*/
}
