using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCapture02 : MonoBehaviour
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
    }
}
