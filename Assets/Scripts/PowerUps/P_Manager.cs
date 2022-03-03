using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
public class P_Manager : MonoBehaviour
{

    public static P_Manager instance;

    public bool magnetActive;
    public bool invincibility;
    public bool secondChance;

    public int invincibilityCount;
    public int secondChanceCount;

    public int magnetTime = 10;

    public GameObject P_Magnet;

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


        //

    }
    void Start()
    {
        magnetActive = false;
        invincibility = false;
        secondChance = false;
        P_Magnet.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        checkPowers();
    }

   
    private void checkPowers()
    {

        PlayerPrefs.SetInt("invincibility", invincibilityCount);
            }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pmagnet"))
        {
            magnetActive = true;
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            collision.gameObject.GetComponent<SpriteRenderer>();
            P_Magnet.SetActive(true);
            StartCoroutine(countDown());
            
        }
    }

    private IEnumerator countDown()
    {
        float currentT = 0;
        while (currentT < magnetTime)
        {
            currentT += Time.deltaTime;
            yield return null;

        }
        magnetActive = false;
        P_Magnet.SetActive(false);
    }

}
