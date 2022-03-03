using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed;
    public GameObject spawner;


    void Start()
    {

    }

    private void FixedUpdate()
    {



        if (GameManager.instance.gamesStarted)
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * 0 * Time.deltaTime);
        }

        if (transform.position.x < -10)
        {
            transform.position = new Vector3(10f, 0, -1);
        }
        if (GameManager.instance.gameOver)
        {
            speed = 0;
        }
        else
        {
            speed = 1;
        }




    }
}
