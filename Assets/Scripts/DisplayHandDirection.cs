using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHandDirection : MonoBehaviour
{
    public Text direction;

    // Start is called before the first frame update
    void Start()
    {
        if (SystemVariable.inputMode == 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HandCapture.HandDirection == 1)
        {
            direction.text = "↑";
        }
        else if(HandCapture.HandDirection == 2)
        {
            direction.text = "↓";
        }
        else if (HandCapture.HandDirection == 4)
        {
            direction.text = "→";
        }
        else if (HandCapture.HandDirection == 3)
        {
            direction.text = "←";
        }
    }
}
