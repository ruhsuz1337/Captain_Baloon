using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_invincibility : MonoBehaviour
{

    [SerializeField]
    private float desiredDuration;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void turnOffCol()
    {
        P_Manager.instance.invincibility = true;
        StartCoroutine(startCountdown());
    }

    public void turnOnCol()
    {
        P_Manager.instance.invincibility = false;
    }
    IEnumerator startCountdown()
    {
        float currentT = 0;
        while(currentT< desiredDuration)
        {
            currentT += Time.deltaTime;
            yield return null;


        }
        turnOnCol();
        

    }
}
