using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Text NowInputMode;
    public Text NotesTimeDelayText;
    public Slider NotesTimeDelaySlider;

    // Start is called before the first frame update
    void Start()
    {
        UpdateNowInputText();
        DisplayFirstNotesTimeDelay();
    }

    // Update is called once per frame
    void Update()
    {
        SliderFunction();
    }

    //シーン読み込み時に現在の閾値をスライダーに表示する
    private void DisplayFirstNotesTimeDelay()
    {
        if (SystemVariable.NotesTimeDelay > 0)
        {
            NotesTimeDelayText.text = "+" + ((float)SystemVariable.NotesTimeDelay / 1000000).ToString() + "s";
        }
        else
        {
            NotesTimeDelayText.text = ((float)SystemVariable.NotesTimeDelay / 1000000).ToString() + "s";
        }
        NotesTimeDelaySlider.value = SystemVariable.NotesTimeDelay/1000;
    }

    //スライダーの動きに合わせて変数を更新する
    public void SliderFunction()
    {
        if (Input.GetMouseButton(0))
        {
            float tmp = (float)(NotesTimeDelaySlider.value / 1000);
            tmp = tmp * 1000;
            int tmp2 = (int)tmp;

            if (tmp2 > 0)
            {
                NotesTimeDelayText.text = "+" + ((float)tmp2 / 1000).ToString() + "s";
            }
            else
            {
                NotesTimeDelayText.text = ((float)tmp2 / 1000).ToString() + "s";
            }
            SystemVariable.NotesTimeDelay = (int)NotesTimeDelaySlider.value*1000;
            //Debug.Log(SystemVariable.NotesTimeDelay);
        }
    }

    public void LoadAdjustCamera()
    {
        SystemVariable.PreInputMode = SystemVariable.inputMode;
        SystemVariable.inputMode = 0;
        SceneManager.LoadScene("AdjustCamera");
    }

    public void LoadRankingOfGamingDistrict()
    {
        SystemVariable.selectMusic = 1;
        SceneManager.LoadScene("Ranking");
    }

    public void LoadRankingOfImperialJade()
    {
        SystemVariable.selectMusic = 2;
        SceneManager.LoadScene("Ranking");
    }

    public void ChangeInputToCamera()
    {
        SystemVariable.inputMode = 0;
        UpdateNowInputText();
    }

    public void ChangeInputToKey()
    {
        SystemVariable.inputMode = 1;
        UpdateNowInputText();
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void UpdateNowInputText()
    {
        if (SystemVariable.inputMode == 0)
        {
            NowInputMode.text = "NowInputMode:Camera";
        }
        else if(SystemVariable.inputMode == 1)
        {
            NowInputMode.text = "NowInputMode:Key";
        }
    }
}
