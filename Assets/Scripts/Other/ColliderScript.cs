using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            GameManager.instance.gameOver = true;
        }


        if (other.CompareTag("coin"))
        {
            GameManager.instance.score++;
        }
    }
}
