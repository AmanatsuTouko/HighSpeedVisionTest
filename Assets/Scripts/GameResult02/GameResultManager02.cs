using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResultManager02 : MonoBehaviour
{
    public Image RingGauge;
    public GameObject RankValue;
    private Text RankValueText;

    public Text SelectMusic;
    public Text Score;
    public Text Combo;
    public Text Perfect;
    public Text Good;
    public Text Bad;

    public GameObject FullComboText;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        //デバッグ用
        //SystemVariable.selectMusic = 2;
        //SystemVariable.ComboOfRythmGame = 269;
        //SystemVariable.ScoreOfRythmGame = 250;

        DisplaySelectMusic();
        UpdateScore();
        UpdateRankTextValue();
        FullComboJudge();
    }

    // Update is called once per frame
    void Update()
    {
        RecommendToRanking();
        RotateRankValue();
    }

    //フルコンボの判定
    void FullComboJudge()
    {
        if (SystemVariable.selectMusic == 1)
        {
            if (SystemVariable.ComboOfRythmGame == 322)
            {
                FullComboText.SetActive(true);
            }
        }
        else if (SystemVariable.selectMusic == 2)
        {
            if (SystemVariable.ComboOfRythmGame == 269)
            {
                FullComboText.SetActive(true);
            }
        }
    }

    //選んだ曲の表示
    void DisplaySelectMusic()
    {
        if (SystemVariable.selectMusic == 1)
        {
            SelectMusic.text = "MUSIC:GAMING DISTRICT";
        }
        else if (SystemVariable.selectMusic == 2)
        {
            SelectMusic.text = "MUSIC:IMPERIAL JADE";
        }
        else
        {
            SelectMusic.text = "MUSIC:NOT SETTING";
        }
    }

    //各数値の更新
    void UpdateScore()
    {
        Score.text = "SCORE:" + SystemVariable.ScoreOfRythmGame.ToString("f2");
        Combo.text = "COMBO:" + SystemVariable.ComboOfRythmGame.ToString();
        Perfect.text = "PERFECT:" + SystemVariable.PerfectNotesNumber.ToString();
        Good.text = "GOOD:" + SystemVariable.GoodNotesNumber.ToString();
        Bad.text = "BAD:" + SystemVariable.BadNotesNumber.ToString();
    }

    //RANKの更新
    void UpdateRankTextValue()
    {
        RankValueText = RankValue.GetComponent<Text>();
        switch (SystemVariable.selectMusic)
        {
            case 1:
                if (SystemVariable.ScoreOfRythmGame > 300)
                {
                    RankValueText.text = "SSS";
                }
                else if (SystemVariable.ScoreOfRythmGame > 250)
                {
                    RankValueText.text = "SS";
                }
                else if (SystemVariable.ScoreOfRythmGame > 200)
                {
                    RankValueText.text = "S";
                }
                else if (SystemVariable.ScoreOfRythmGame > 150)
                {
                    RankValueText.text = "A";
                }
                else if (SystemVariable.ScoreOfRythmGame > 100)
                {
                    RankValueText.text = "B";
                }
                else if (SystemVariable.ScoreOfRythmGame > 50)
                {
                    RankValueText.text = "C";
                }
                else
                {
                    RankValueText.text = "D";
                }
                break;
            case 2:
                if (SystemVariable.ScoreOfRythmGame > 250)
                {
                    RankValueText.text = "SSS";
                }
                else if (SystemVariable.ScoreOfRythmGame > 200)
                {
                    RankValueText.text = "SS";
                }
                else if (SystemVariable.ScoreOfRythmGame > 150)
                {
                    RankValueText.text = "S";
                }
                else if (SystemVariable.ScoreOfRythmGame > 100)
                {
                    RankValueText.text = "A";
                }
                else if (SystemVariable.ScoreOfRythmGame > 50)
                {
                    RankValueText.text = "B";
                }
                else if (SystemVariable.ScoreOfRythmGame > 25)
                {
                    RankValueText.text = "C";
                }
                else
                {
                    RankValueText.text = "D";
                }
                break;
        }
    }

    //RANKの回転
    float y = 0;
    void RotateRankValue()
    {
        if (y > 360.0f)
        {
            y = 0.0f;
        }
        y = y + Time.deltaTime * 50.0f;
        RankValue.transform.rotation = Quaternion.Euler(0.0f, y, 0.0f);
    }

    //ゲージの処理
    void RecommendToRanking()
    {
        //長押ししてるかどうかの判定
        if (SystemVariable.inputMode == 0)//手の入力の時
        {
            if (HandCapture.HandDirection == 1)
            {
                time += Time.deltaTime;
            }
            else
            {
                time = 0;
            }
        }
        else//キー入力の時
        {
            if (KeyCapture.keyDirection == 1)
            {
                time += Time.deltaTime;
            }
            else
            {
                time = 0;
            }
        }
        if (time > 2.0f)
        {
            SceneManager.LoadScene("Ranking");
        }
        RingGauge.fillAmount = time / 2.0f;
    }
}
