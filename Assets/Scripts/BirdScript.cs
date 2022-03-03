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

    private void Awake()
    {
        if(transform.position.x < 0)
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
    }
    void Start()
    {
        Destroy(gameObject, 10);
        if (!isLeft)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }

        SoundManager.instance.birdWing.Play();
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
