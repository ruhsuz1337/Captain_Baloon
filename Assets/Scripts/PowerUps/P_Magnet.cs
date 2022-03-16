using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class P_Magnet : MonoBehaviour
{

    public GameObject player;
    public GameObject magnetParticle;
    // Update is called once per frame
    void Update()
    {
        transform.position = GameManager.instance.transform.position;
        magnetParticle.transform.position = player.transform.position;
        magnetParticle.transform.localScale = player.transform.localScale;

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            SoundManager.instance.playMagnetCoin();
            collision.gameObject.transform.DOMove(player.transform.position, .2f);              
            
        }




    }

}
