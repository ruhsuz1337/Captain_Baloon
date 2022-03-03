using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundManager : MonoBehaviour
{

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private int treshold1 = 50;

    [SerializeField]
    private int treshold2 = 100;

    

    [SerializeField]
    private List<GameObject> sides;

    





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
            background.transform.DOMoveY(-18f, 2);
            

        }else if (GameManager.instance.sessionGold >= treshold2)
        {
            background.transform.DOMoveY(-36f, 2);
        }
        
    }
    
    private void loopSides()
    {
        
        
            
        
    }
}
