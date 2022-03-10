using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyRushScript : MonoBehaviour
{


    public GameObject coin;

    private List<GameObject> coinList;

    private List<Vector3> spawnPos;


    void Start()
    {
        spawnPos = new List<Vector3>();
        spawnCoins();
    }

    void Update()
    {
        
    }


    private void spawnCoins()
    {
        float x = -3;
        float y = 0;
        int Index = 0;
        
        for (int i = 0; i < 19; i++)
        {
            
            for (int j = 0; j < 3; j++)
            {
                Debug.Log("x: " + x + " y: " + y);
                spawnPos.Add(new Vector3(x, y, -1));
                GameObject obj = Instantiate(coin, spawnPos[Index], Quaternion.identity, gameObject.transform);
               // obj.transform.position= obj.transform.loca
                Index++;
                x += 3;
            }
            x = -3;
            y += 3;
        }

        
    }
}
