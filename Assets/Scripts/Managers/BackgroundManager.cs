using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private int backgroundChangeTime = 5;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private int treshold1 = 50;

    [SerializeField]
    private int treshold2 = 100;





    private void Start()
    {
    }

    private void Update()
    {
        
        changeBackground();
    }


    private void changeBackground()
    {
        
        if (GameManager.instance.sessionGold >= treshold1)
        {
            background.transform.DOMoveY(-7.5f, 2);
            

        }else if (GameManager.instance.sessionGold >= treshold2)
        {
            background.transform.DOMoveY(-15f, 2);
        }
        
    }
    

}
