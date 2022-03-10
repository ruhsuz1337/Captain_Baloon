using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGround : MonoBehaviour
{
    public float speed;
    public GameObject spawner;
    public GameObject coin;

    public float yVal;

    
    public bool startTile;

    public Transform spawnPos;

    public GameObject[] getChildren;
    public List<GameObject> coinsArr;
    public GameObject Magnet;

    public float desiredMagnetSpawnRate;

    /*
    void Start()
    {
        
        getChildren = new GameObject[transform.childCount];
        coinsArr = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            getChildren[i] = transform.GetChild(i).gameObject;
        }
        if (startTile)
        {
            Destroy(gameObject, 5);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("coin"))
            {
                coinsArr.Add(transform.GetChild(i).gameObject);
            }
        }

        spawnAgainCoins();

    }





    private void FixedUpdate()
    {

        

        if (GameManager.instance.gamesStarted)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * 0 * Time.deltaTime);
        }
        
        if(transform.position.y < -67.6)
        {
            transform.position = new Vector3(0,105.2f,0);
            spawnAgainCoins();
            //coinSpawner();
        }
        if (GameManager.instance.gameOver)
        {
            speed = 0;
        }
        else
        {
            speed = GameManager.instance.backgroundSpeed;
        }

       


    }

    private void spawnAgainCoins()
    {
        
        for (int i = 0; i < coinsArr.Count; i++)
        {
            coinsArr[i].GetComponent<SpriteRenderer>().enabled = true;
            coinsArr[i].GetComponent<Animator>().enabled = true;
            coinsArr[i].gameObject.tag = ("coin");
            
            

        }

        magnetSpawner(desiredMagnetSpawnRate);
    }

    private void magnetSpawner(float percentage)
    {
        float chance = Random.Range(0, 100);
        int magnetIndex = Random.Range(0, coinsArr.Count);

        if(chance < percentage)
        {
            coinsArr[magnetIndex].tag = "Pmagnet";
            coinsArr[magnetIndex].GetComponent<Animator>().enabled = false;
            coinsArr[magnetIndex].GetComponent<SpriteRenderer>().sprite = Magnet.GetComponent<SpriteRenderer>().sprite;

        }
        
        
        
    }
    

   */
}
