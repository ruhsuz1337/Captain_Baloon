using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedLoopScript : B_PoolerBase
{
    public static AdvancedLoopScript instance;

    public float movementSpeed;
    private float desiredSpeed;

    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform endPos;

    public Vector3 offset;
    public Vector3 spawnerPoint;
    public int desiredLevelCount;

    
    Transform lastSpawnedTransform;
    string lastSpawnedStageName = "";

    public int DesiredLuckyLocation;
    private int spawnedStageCount = 0;


    string GetRandomStageName()
    {
        string x = PoolsList[Random.Range(0, PoolsList.Count - 1)].PoolName;
        if (x == lastSpawnedStageName) return GetRandomStageName();
        return x;
    }

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
        InitiatePooller(transform);       
        desiredSpeed = movementSpeed;
        //offset = startPos.position - endPos.position;
        spawnerPoint = new Vector3(0, 15, 0);


        spawnAllStages();


    }

    private void Update()
    {
        SetMovementSpeed();
        RespawnTile();
    }

    private void spawnAllStages()
    {
        Vector3 vec = new Vector3(0, 0, 0);


        for (int i = 0; i < PoolsList.Count; i++)
        {
            string s = GetRandomStageName();
            if (i == DesiredLuckyLocation || i == 10) {  s = "S11";  }
            //GetRandomStageName()
            GameObject obj = SpawnObjFromPool(s, vec);
            vec.y += offset.y ;
            obj.transform.parent = transform;
            if (i == PoolsList.Count - 1)
            {
                lastSpawnedTransform = obj.transform;
                lastSpawnedStageName = PoolsList[i].PoolName;
            }
        }
    }

    private void RespawnTile()
    {
        if(lastSpawnedTransform.position.y < -offset.y * .45f)
        {
            spawnedStageCount++;
            Vector3 pos = Vector3.zero;

            if (spawnedStageCount >= DesiredLuckyLocation)
            {
                spawnedStageCount = 0;
                lastSpawnedStageName = "S11";
                lastSpawnedTransform = SpawnObjFromPool(lastSpawnedStageName, spawnerPoint).transform;
                pos.y += offset.y;
                lastSpawnedTransform.localPosition = pos;
                return;
            }

            lastSpawnedStageName = GetRandomStageName();
            lastSpawnedTransform = SpawnObjFromPool(lastSpawnedStageName, spawnerPoint).transform;
            //lastSpawnedTransform.localPosition = pos;
            pos.y += offset.y;
            lastSpawnedTransform.localPosition = pos;

        }
    }

    private void SetMovementSpeed()
    {
        if(GameManager.instance.gamesStarted && !GameManager.instance.gameOver)
        {
            movementSpeed = desiredSpeed;
        }
        else
        {
            movementSpeed = 0;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }




}

    
    

    

