using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullComboPalse : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("ChangeTransparency");
    }

    IEnumerator ChangeTransparency()
    {
        float a_color = 1.0f;
        bool a_frag = true;

        while (true)
        {
            if (a_frag)
            {
                a_color -= 0.05f;
            }
            else
            {
                a_color += 0.05f;
            }

            text.color = new Color(text.color.r, text.color.g, text.color.b, a_color); ;

            if (a_color < 0)
            {
                a_frag = false;
            }
            else if (a_color > 1)
            {
                a_frag = true;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
