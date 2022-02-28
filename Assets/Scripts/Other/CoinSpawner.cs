using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner instance;


    public List<GameObject> coinList;
    public GameObject coin;

    [SerializeField]
    private Transform spawner;


    private float yVal;


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

    // Start is called before the first frame update
    void Start()
    {
        yVal = 10;
        for (int i = 0; i < 10; i++)
        {
            
            GameObject go = Instantiate(coin, spawner);
            Vector3 newPos = new Vector3(spawnCoin().x, spawnCoin().y + yVal, spawnCoin().z);
            go.transform.position = newPos;
            yVal += 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private int randomInteger()
    {
        int rnd = Random.Range(0, 3);
        return rnd;
    }
    public Vector3 spawnCoin()
    {
        int spawnIndex = randomInteger();



        if(spawnIndex == 0)
        {
            return new Vector3(0, 10, 0);

        }else if(spawnIndex == 1)
        {
            return new Vector3(-1.3f, 10, 0);

        }
        else if (spawnIndex == 2)
        {
            return new Vector3(1.3f, 10, 0);

        }
        else
        {
            return new Vector3(0, 10, 0);
        }
    }
}
