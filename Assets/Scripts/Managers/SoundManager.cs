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
    public AudioClip branchCrash;
    public AudioClip skinPurchase;
    public AudioClip invincibleCrash;


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


    void Start()
    {
        
    }

    public void buttonClicker()
    {
        soundPlayer.PlayOneShot(buttonClick);
    }

    public void collectCoinSound()
    {
        soundPlayer.PlayOneShot(coinCollect);
    }
    public void playDeathSound()
    {

    }

    public void playBirdHit()
    {
        soundPlayer.PlayOneShot(birdHit);
    }

    public void playBirdFlying()
    {
        soundPlayer.PlayOneShot(birdWing);
    }
    void Update()
    {
        
    }
}
