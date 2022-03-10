using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedLoopScript : MonoBehaviour
{
    public static AdvancedLoopScript instance;

    public float movementSpeed;
    private float desiredSpeed;

    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform endPos;

    public Vector3 offset;
    [SerializeField]
    private List<GameObject> stageList;
    private List<GameObject> luckyRushList;

    [SerializeField]
    private List<GameObject> allStages;

    [SerializeField]
    private List<GameObject> spawnedStages1;
    [SerializeField]
    private List<GameObject> spawnedStages2;

    private List<GameObject> spawnedStagesBool;

    private int totalStages;
    public int stageCounter;

    private Vector3 startGameVec = new Vector3(0, 0, -2);
    private Vector3 otherSpawnsVec;

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
    private void Start()
    {
        spawnedStagesBool = new List<GameObject>();
        spawnedStages1 = new List<GameObject>();
        spawnedStages2 = new List<GameObject>();
        luckyRushList = new List<GameObject>();
        allStages = new List<GameObject>();
        desiredSpeed = movementSpeed;
        offset = startPos.position - endPos.position;
        totalStages = stageList.Count + luckyRushList.Count;
        //otherSpawnsVec = startGameVec + offset;
        getAllStages();
        
        stageCounter = 0;
        spawnFirstSet(startGameVec);
    }

    private void Update()
    {

        placeAgain(spawnedStages1);
        placeAgain(spawnedStages2);

        if (GameManager.instance.gamesStarted)
        {
            if (GameManager.instance.gameOver)
            {
                movementSpeed = 0;
            }
            else
            {
                movementSpeed = desiredSpeed;
            }
        }
        else
        {
            movementSpeed = 0;
        }
    }

    private void getAllStages()
    {

         

        


        for (int i = 0; i < totalStages; i++)
        {
            int rndStage = Random.Range(0, stageList.Count);
            int rndRush = Random.Range(0, luckyRushList.Count);
            /*
            if (i % 2 == 0 && i != 0 && luckyRushList.Count != 0)
            {
                //allStages.Add(luckyRushList[rndRush].gameObject);
            }
            else*/
            
                allStages.Add(stageList[rndStage].gameObject);
            

        }
    }

    private void placeAgain(List<GameObject> list)
    {
        if(list[list.Count-1].transform.position.y <= -offset.y-15)
        {
            shuffleSet(list);
            placeList(list);
        }
    }
    
    private void spawnFirstSet(Vector3 vec)
    {
        for (int i = 0; i < allStages.Count; i++)
        {
            spawnedStages1.Add(Instantiate(allStages[i], vec, Quaternion.identity));
            vec += offset;
        }
        spawnSecondSet(vec);
    }

    private void spawnSecondSet(Vector3 vec)
    {
        for(int i = 0; i < allStages.Count; i++)
        {
            spawnedStages2.Add(Instantiate(allStages[i], vec, Quaternion.identity));
            vec += offset;
        }
    }

    private List<GameObject> shuffleSet(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int rnd = Random.Range(i, list.Count);
            list[i] = list[rnd];
            list[rnd] = temp;


        }

        return list;
    }

    private void placeList(List<GameObject> list)
    {
        Vector3 vec = new Vector3(0, offset.y * spawnedStages1.Count - 20.8f, -2);
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.position = vec;
            vec += offset;
        }
    }

    /*
    private void spawnLevels(Vector3 vec)
    {
        
        stageList[0].transform.position = endPos.position;
        for (int i = 0; i < allStages.Count; i++)
        {
            
            spawnedStages1.Add(Instantiate(allStages[i], vec, Quaternion.identity));
            vec += offset;

            
        }

        spawnLevelsAgain(vec);
    }

    private void isLevelDone()
    {/*
        if(spawnedStages[spawnedStages.Count-2].transform.position.y <= -offset.y)
        {
            stageCounter = spawnedStages.Count;
        }
    }


    private void spawnLevelsAgain(Vector3 vec)
    {
        //vec += offset;
        stageList[0].transform.position = endPos.position;
        
        for (int i = 0; i < allStages.Count; i++)
        {
            
            
            spawnedStages2[i] =Instantiate(allStages[i], vec, Quaternion.identity);
            vec += offset;


        }
    }*/
}

    

