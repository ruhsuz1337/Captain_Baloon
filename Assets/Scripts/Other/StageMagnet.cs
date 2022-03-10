using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMagnet : MonoBehaviour
{

    public List<Transform> magnetList;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Pmagnet"))
            {
                magnetList.Add(transform.GetChild(i));
            }
        }
    }
    void Start()
    {
        

    }

    void Update()
    {
        
    }
}
