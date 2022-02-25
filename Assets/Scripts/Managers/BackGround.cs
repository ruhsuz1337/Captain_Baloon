using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGround : MonoBehaviour
{
    public float speed;
    public GameObject spawner;
    public GameObject coin;
    private GameObject[] coinArr;

    [SerializeField]
    private GameObject background1;
    private GameObject background2;
    private Transform[] coinPosArr;
    private int backgroundCount;
    


    void Start()
    {
        coinArr = new GameObject[8];
        coinPosArr = new Transform[8];

        float rndX = Random.Range(-1.5f, 1.5f);
        int rndY = 0;
        
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

        if(transform.position.y < -20)
        {
            transform.position = spawner.transform.position;
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

   
}
