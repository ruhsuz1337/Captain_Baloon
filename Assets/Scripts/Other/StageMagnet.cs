using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMagnet : MonoBehaviour , B_OPS_IPooledObject
{

    private List<GameObject> magnetList;
    private List<GameObject> coinList;

    public int magnetSpawnChance;

    public void OnFirstSpawn()
    {
        magnetList = new List<GameObject>();
        coinList = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Pmagnet"))
            {
                magnetList.Add(transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("coin"))
            {
                coinList.Add(transform.GetChild(i).gameObject);
            }
        }

        setMagnets();
    }

    public void OnObjectSpawn()
    {
        setMagnets();
    }

    public void OnRespawn()
    {
        
    }

    private void Awake()
    {
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    if (transform.GetChild(i).CompareTag("Pmagnet"))
        //    {
        //        magnetList.Add(transform.GetChild(i).gameObject);
        //    }
        //}

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    if (transform.GetChild(i).CompareTag("coin"))
        //    {
        //        coinList.Add(transform.GetChild(i).gameObject);
        //    }
        //}
    }

    private void setMagnets()
    {
        for (int i = 0; i < magnetList.Count; i++)
        {
            magnetList[i].SetActive(false);
        }

        int rnd = Random.Range(0, 100);
        int rndMagnet = Random.Range(0, magnetList.Count);
        if(rnd < magnetSpawnChance)
        {
            magnetList[rndMagnet].SetActive(true);
        }
    }
    void Start()
    {
        

    }

    void Update()
    {
        
    }
}
