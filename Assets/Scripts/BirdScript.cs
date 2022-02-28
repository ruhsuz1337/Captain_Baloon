using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private float horizontalSpeed;

    private bool isLeft;
    void Start()
    {
        Destroy(gameObject, 5);
        if(transform.position.x < 0)
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
    }

    void Update()
    {
        if (isLeft)
        {
            transform.position += new Vector3(verticalSpeed, -horizontalSpeed, 0);
        }
        else
        {
            transform.position -= new Vector3(verticalSpeed, horizontalSpeed, 0);
        }
    }

    
}
