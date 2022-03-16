using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;


    public AudioSource soundPlayer;
    public AudioClip buttonClick;
    public AudioClip startClick;
    public AudioClip startMusic;
    public AudioClip coinCollect;
    public AudioClip powerUp;
    public AudioClip menuMusic;
    public AudioClip inflate;
    public AudioClip exflate;
    public AudioClip baloonBoom;
    public AudioClip birdWing;
    public AudioClip birdHit;
    public AudioClip skinPurchase1;
    public AudioClip skinPurchase2;
    public AudioClip magnetPickUp;
    public AudioClip magnetCoin;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
            

    }
    
    public void playMagnetPickUp()
    {
        soundPlayer.PlayOneShot(magnetPickUp);
    }
    public void playCrashSound()
    {
        soundPlayer.PlayOneShot(baloonBoom);
    }

    public void playMagnetCoin()
    {
        soundPlayer.PlayOneShot(magnetCoin);
    }
    
    public void buttonClicker()
    {
        soundPlayer.PlayOneShot(buttonClick);
    }

    public void playCollectCoinSound()
    {
        soundPlayer.PlayOneShot(coinCollect);
    }
    public void playDeathSound()
    {
        soundPlayer.PlayOneShot(baloonBoom);
    }

    public void playBirdHit()
    {
        soundPlayer.PlayOneShot(birdHit);
    }

    public void playBirdFlying()
    {
        soundPlayer.PlayOneShot(birdWing);
    }

    public void playSkinPurchase()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            soundPlayer.PlayOneShot(skinPurchase1);
        }
        else
        {
            soundPlayer.PlayOneShot(skinPurchase2);
        }
        
    }

    public void playEquipSkin()
    {
        soundPlayer.PlayOneShot(skinPurchase2);

    }
    void Update()
    {
        
    }
}
