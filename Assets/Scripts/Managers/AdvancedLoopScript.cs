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
    public Vector3 spawnerPoint;
    public int desiredLevelCount;

    public List<GameObject> allLevelsList;

    [SerializeField]
    private List<GameObject> spawnedLevels1;
    [SerializeField]
    private List<GameObject> spawnedLevels2;



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
        desiredSpeed = movementSpeed;
        offset = startPos.position - endPos.position;
        spawnerPoint = new Vector3(100, 0, -2);

        spawnedLevels1 = new List<GameObject>();

        spawnAllStages();
        setLevel(spawnedLevels1);
        setPositions(spawnedLevels1);
    }

    private void Update()
    {
        setMovementSpeed();
        reSpawnTile(spawnedLevels1);
    }

    private void spawnAllStages()
    {
        Vector3 vec = new Vector3(100, 0, -2);

        for (int i = 0; i < allLevelsList.Count; i++)
        {
            GameObject obj = Instantiate(allLevelsList[i], vec, Quaternion.identity);
            allLevelsList[i] = obj;
        }

        
    }

    private void setLevel(List<GameObject> list)
    {
        

        for (int i = 0; i < desiredLevelCount; i++)
        {
            int rnd = Random.Range(0, allLevelsList.Count);

            GameObject obj = allLevelsList[rnd];
            allLevelsList.Remove(obj);
            list.Add(obj);


            
        }

        
    }

    private void setPositions(List<GameObject> list)
    {
        Vector3 vec = new Vector3(0, 0, -2);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.position = vec;
            vec += offset;
        }
    }

    private void reSpawnTile(List<GameObject> list)
    {
        if(spawnedLevels1[0].transform.position.y < -offset.y)
        {
            int rnd = Random.Range(0, allLevelsList.Count);
            spawnedLevels1[0].transform.position = spawnerPoint;
            GameObject obj = spawnedLevels1[0];
            allLevelsList.Add(obj);
            spawnedLevels1.Remove(obj);
            spawnedLevels1.Add(allLevelsList[rnd]);
            spawnedLevels1[spawnedLevels1.Count - 1].transform.position = offset;

            
            
        }
    }

    private void setMovementSpeed()
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

}

    
    

    

