using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMapMovement : MonoBehaviour
{
    private float movementSpeed;

    void Start()
    {

    }
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
                
                movementSpeed = AdvancedLoopScript.instance.movementSpeed;
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);



    }

}