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
            Instantiate(allLevelsList[i], vec, Quaternion.identity);
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
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(0, allLevelsList.Count);
            if (list[i].transform.position.y <= -offset.y - 15f)
            {
                allLevelsList.Add(list[i]);
                list.Remove(list[i]);
                list[i] = allLevelsList[rnd];
                list[i].transform.position = offset * list.Count;
                
            }
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

    
    

    

