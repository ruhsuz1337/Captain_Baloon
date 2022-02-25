using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private int firstNumber;

    private float timerValue;

    private float cuberootvalue;

    private CircleCollider2D circleCol;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = new Vector3(1, 3, 3);
        timerValue = 1;
        circleCol = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gamesStarted && !GameManager.instance.gameOver)
        {
            if (Input.GetMouseButton(0))
            {
                timerValue += Time.deltaTime;
            }
            else
            {
                if (timerValue > .5)
                {
                    timerValue -= Time.deltaTime * 1.5f;

                }
            }


           



        }
        transform.localScale = new Vector3(CubeRootFunction(timerValue), CubeRootFunction(timerValue), CubeRootFunction(timerValue));
        circleCol.transform.localScale = transform.localScale;
    }

    public float CubeRootFunction(float timefloat)
    {
        float rootvalue = 1 / 3f;
        cuberootvalue = Mathf.Pow(timefloat, rootvalue);
        return cuberootvalue;
    }
}