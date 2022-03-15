using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AdvancedBackgroundManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> backgroundList;
    private List<Transform> backgroundListPositions;

    public Transform spawnPos;
    public Transform endPos;

    private Vector3 vec = new Vector3(0, 0, 0);

 

    

    private void Start()
    {
        
    }
    private void Update()
    {
        
                transform.Translate(Vector3.down * AdvancedLoopScript.instance.movementSpeed * Time.deltaTime);
            
        
        
        
        changeBackground();
    }

    private void getLocations()
    {
        for (int i = 0; i < backgroundList.Count; i++)
        {
            backgroundListPositions[i] = backgroundList[i].transform;
        }
    }

    private void changeBackground()
    {
        for (int i = 0; i < backgroundList.Count; i++)
        {
            if(backgroundList[i].transform.position.y <= endPos.position.y)
            {
                backgroundList[i].transform.position = spawnPos.position - new Vector3(0, 2.5f, 0) - AdvancedLoopScript.instance.offset ;
            }
        }
    }
}
