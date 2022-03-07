using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update


    

    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            

            if (P_Manager.instance.invincibilityCount > 0 && !P_Manager.instance.invincibility)
            {

                P_Manager.instance.invincibilityCount--;
                gameObject.GetComponent<P_invincibility>().turnOffCol();
                

                
                
            }else if ( P_Manager.instance.invincibility)
            {

                return;
            }else if (!P_Manager.instance.invincibility)
            {

                GameManager.instance.gameOver = true;
                GameManager.instance.totalGold += GameManager.instance.sessionGold;

            }




        }

        if (collision.CompareTag("bird"))
        {

            SoundManager.instance.playBirdHit();
            if (P_Manager.instance.invincibilityCount > 0 && !P_Manager.instance.invincibility)
            {

                P_Manager.instance.invincibilityCount--;
                gameObject.GetComponent<P_invincibility>().turnOffCol();




            }
            else if (P_Manager.instance.invincibility)
            {

                return;
            }
            else if (!P_Manager.instance.invincibility)
            {

                GameManager.instance.gameOver = true;
                GameManager.instance.totalGold += GameManager.instance.sessionGold;

            }
        }

        if (collision.CompareTag("coin"))
        {
            GameManager.instance.sessionGold++;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            
            SoundManager.instance.collectCoinSound();
        }


        

        


        
    }
}
