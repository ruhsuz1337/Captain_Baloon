using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update

    




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {

            SoundManager.instance.playCrashSound();
            if (P_Manager.instance.invincibilityCount > 0 && !P_Manager.instance.invincibility)
            {

                P_Manager.instance.invincibilityCount--;
                gameObject.GetComponent<P_invincibility>().turnOffCol();
                

                
                
            }else if ( P_Manager.instance.invincibility)
            {

                return;
            }else if (!P_Manager.instance.invincibility)
            {

                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
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
            MMVibrationManager.Haptic(HapticTypes.LightImpact);
            SoundManager.instance.playCollectCoinSound();
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Pmagnet"))
        {
            SoundManager.instance.playMagnetPickUp();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            P_Manager.instance.magnetActive = true;
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            //collision.gameObject.GetComponent<SpriteRenderer>();
            P_Manager.instance.P_Magnet.SetActive(true);
            StartCoroutine(P_Manager.instance.countDown());

        }






    }
}
