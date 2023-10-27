using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdjustCameraManager : MonoBehaviour
{
    public Slider ThresholdSlider;
    public Text ThreshholdText;
    public Text ArrowText;

    // Start is called before the first frame update
    void Start()
    {
        SystemVariable.inputMode = 0;
        DisplayFirstThreshhold();
    }

    // Update is called once per frame
    void Update()
    {
        SliderFunction();
        UpdateArrow();
    }

    //練習用に矢印で認識している向きを表示させる。
    void UpdateArrow()
    {
        switch(HandCaptureSetting.HandDirection)
        {
            case 1:
                ArrowText.text = "↑";
                break;
            case 2:
                ArrowText.text = "↓";
                break;
            case 3:
                ArrowText.text = "→";
                break;
            case 4:
                ArrowText.text = "←";
                break;
        }
    }

    //閾値をデフォルト値に戻す
    public void ResetDefaultThreshholdValue()
    {
        SystemVariable.Threshold = 127;
        DisplayFirstThreshhold();
    }

    //シーン読み込み時に現在の閾値をスライダーに表示する
    private void DisplayFirstThreshhold()
    {
        ThreshholdText.text = SystemVariable.Threshold.ToString();
        ThresholdSlider.value = SystemVariable.Threshold;
    }

    public void SliderFunction()
    {
        if (Input.GetMouseButton(0))
        {
            ThreshholdText.text = ((int)ThresholdSlider.value).ToString();
            SystemVariable.Threshold = (int)ThresholdSlider.value;
        }
    }

    public void ChangeGrayScaleCamera()
    {
        if (!HandCaptureSetting.GrayScale)
        {
            HandCaptureSetting.GrayScale = true;
        }
        else
        {
            HandCaptureSetting.GrayScale = false;
        }
    }

    public void BackToSettings()
    {
        SceneManager.LoadScene("Settings");
        EndProcess();
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        EndProcess();
    }

    //終了時の処理
    void EndProcess()
    {
        SystemVariable.inputMode = SystemVariable.PreInputMode;
    }
}
