using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] backgroundElements;
    public float speed;
    private Vector3 startPos;
    public GameObject spawner;
    private Camera cam;


    void Start()
    {
        startPos = transform.position;
        speed = GameManager.instance.backgroundSpeed;
        
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.gamesStarted)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * 0 * Time.deltaTime);
        }

        if(transform.position.y < -20)
        {
            transform.position = spawner.transform.position;
        }
        
    }
}
