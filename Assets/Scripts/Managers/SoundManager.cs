using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    public AudioSource buttonClick;
    public AudioSource startClick;
    public AudioSource startMusic;
    public AudioSource coinCollect;
    public AudioSource powerUp;
    public AudioSource menuMusic;
    public AudioSource inflate;
    public AudioSource exflate;
    public AudioSource baloonBoom;
    public AudioSource birdWing;
    public AudioSource branchCrash;
    public AudioSource skinPurchase;
    public AudioSource invincibleCrash;


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

    // Update is called once per frame
    void Update()
    {
        
    }
}
