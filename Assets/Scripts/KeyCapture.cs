using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCapture : MonoBehaviour
{
    //キー入力の向き
    public static int keyDirection = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時に無効にする
        keyDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        KeyInputDirection();
    }

    void KeyInputDirection()
    {
        //キー入力を受け付ける。
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyDirection = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyDirection = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyDirection = 3;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyDirection = 4;
        }

        //指を離したことを検知したら入力方向を無効にする。
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            keyDirection = 0;
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            keyDirection = 0;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            keyDirection = 0;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            keyDirection = 0;
        }
    }
}
