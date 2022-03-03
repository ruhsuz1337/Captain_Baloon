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

                SoundManager.instance.invincibleCrash.Play();
                P_Manager.instance.invincibilityCount--;
                gameObject.GetComponent<P_invincibility>().turnOffCol();
                

                
                
            }else if ( P_Manager.instance.invincibility)
            {
                SoundManager.instance.invincibleCrash.Play();

                return;
            }else if (!P_Manager.instance.invincibility)
            {

                SoundManager.instance.branchCrash.Play();
                GameManager.instance.gameOver = true;
                GameManager.instance.totalGold += GameManager.instance.sessionGold;

            }




        }

        


        
    }
}
