using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundManager : MonoBehaviour
{

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private int desiredChange;



    private Vector3 startPos;
    private Vector3 endPos;

    [SerializeField]
    private List<GameObject> backgroundList;

    void Start()
    {
        endPos = backgroundList[0].transform.position;
        startPos = backgroundList[1].transform.position;





    }

    private void Update()
    {
        
        changeBackground();
    }

    private void slide(int x, int y)
    {
        if (GameManager.instance.sessionGold % desiredChange == 0)
        {
            backgroundList[x].transform.DOMove(endPos, 2);
            
            }
    }
    

    private void changeBackground()
    {
        
        if (GameManager.instance.sessionGold == 15)
        {
            background.transform.DOMoveY(-67f, 2);            

        }else if (GameManager.instance.sessionGold == 30)
        {
            background.transform.DOMoveY(-124f, 2);
        }
        else if (GameManager.instance.sessionGold == 45)
        {
            background.transform.DOMoveY(-181f, 2);
        }
        else if (GameManager.instance.sessionGold == 60)
        {
            background.transform.DOMoveY(-238f, 2);
        }
        else if (GameManager.instance.sessionGold == 75)
        {
            background.transform.DOMoveY(-295f, 2);
        }
        else if (GameManager.instance.sessionGold == 90)
        {
            background.transform.DOMoveY(-352f, 2);
        }

    }
    
    private void loopSides()
    {
        
        
            
        
    }
}
