using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class P_Magnet : MonoBehaviour
{

    public GameObject player;
    public ParticleSystem magnet;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = GameManager.instance.transform.position;

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            collision.gameObject.transform.DOMove(player.transform.position, .2f);              
            
        }




    }

}
