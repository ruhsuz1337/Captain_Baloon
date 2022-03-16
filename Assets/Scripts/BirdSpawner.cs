using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{

    [SerializeField]
    private int minTime;

    [SerializeField]
    private int maxTime;

    [SerializeField]
    private GameObject bird;

    [SerializeField]
    private Transform leftSpawnPoint;

    [SerializeField]
    private Transform rightSpawnPoint;

    public static BirdSpawner instance;
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


        //

    }
    void Start()
    {
        
       // minTime = (AdvancedLoopScript.instance.spawnedStages1.Count - 1) * 15;
        //maxTime = minTime + 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int randomTimer(int min, int max)
    {
        int randomT = Random.Range(min, max);
        return randomT;

    }


    private void spawnBird()
    {
        if (GameManager.instance.gamesStarted && !GameManager.instance.gameOver)
        {
            SoundManager.instance.playBirdFlying();
            int rndPosIndex = Random.Range(0, 2);
            if (rndPosIndex == 0)
            {
                Instantiate(bird, leftSpawnPoint);

            }
            else if (rndPosIndex == 1)
            {
                Instantiate(bird, rightSpawnPoint);
            }
        }
       
    }
    public IEnumerator countdown()
    {
        int t = randomTimer(minTime, maxTime);
        while (t != 0)
        {
            yield return new WaitForSeconds(1);
            
            t--;
        }

        spawnBird();
        yield return null;
    }

}
