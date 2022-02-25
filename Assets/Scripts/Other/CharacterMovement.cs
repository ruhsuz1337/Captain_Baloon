using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{


    private float verticalSpeed;
    public float lerpTime = 10f;

    private float defaultVerticalSpeed;

    




    private Rigidbody2D rb;

    private void Awake()
    {
        defaultVerticalSpeed = verticalSpeed;
    }
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        verticalSpeed = GameManager.instance.currentVerticalSpeed;
        //verticalSpeed = 0;
        
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f), Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
        if (GameManager.instance.gamesStarted)
        {
            verticalSpeed = GameManager.instance.currentVerticalSpeed;
        }

    }
    void FixedUpdate()
    {

        if (GameManager.instance.gamesStarted && !GameManager.instance.gameOver)
        {
            //Rb.AddForce(0,0,Speed * Time.deltaTime);
            rb.velocity = new Vector3(0, 0, verticalSpeed);

            if (Input.touchCount > 0) //TOUCHING NOW
            {
                Touch finger = Input.GetTouch(0);


                //TOUCH BEGAN
                if (finger.phase == TouchPhase.Began)
                {
                    //Debug log baþladý...
                }

                Touch screenTouch = Input.GetTouch(0);

                //TOUCH MOVING
                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, screenTouch.deltaPosition.x, 0f), lerpTime * Time.deltaTime);

                    transform.Translate(screenTouch.deltaPosition.x * verticalSpeed * Time.deltaTime, 0f, 0f, Space.World);
                    rb.velocity = new Vector3(screenTouch.deltaPosition.x * verticalSpeed * 0.8f, 0f, 0f);
                }

                //STILL TOUCHING BUT STILL
                //ROTATION DEFAULT
                if (finger.phase == TouchPhase.Stationary)
                {
                    // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, _firstAngle * 0.02f, 0f), lerpTime * Time.deltaTime);
                }

            }
        


        }

        //TOUCH END - ROTATION DEFAULT
        else if (Input.touchCount == 0)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, _firstAngle * .2f, 0f), lerpTime * Time.deltaTime);
        }
    }


   


}

