using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            GameManager.instance.gameOver = true;
            GameManager.instance.totalGold += GameManager.instance.sessionGold;
        }


        
    }
}
