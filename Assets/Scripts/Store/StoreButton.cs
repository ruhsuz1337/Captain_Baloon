using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{

    [SerializeField]
    private TMP_Text buttonText;

    [SerializeField]
    private string desiredText;

    private Image image;

    private void Start()
    {
        setText();

    }

    public void setText()
    {
        buttonText.text = desiredText;
    }

    public void setImage()
    {

    }

    public void onClick()
    {

    }
}
