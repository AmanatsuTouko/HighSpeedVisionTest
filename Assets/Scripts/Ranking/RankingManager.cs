using UnityEngine;
using System.Collections;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using System; //Exception
using System.Text; //Encoding
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{
    public List<Text> Siryoku = new List<Text>();
    public List<Text> Rythm = new List<Text>();
    public Text InputModeText;
    public Text SelectMusicText;
    public Image RingGauge;

    private float time = 0.0f;

    private bool TimeCount = false;

    private IEnumerator Start()
    {
        //デバッグ用
        /*
        SystemVariable.inputMode = 1;
        SystemVariable.selectMusic = 2;
        SystemVariable.selectGameMode = 1;
        SystemVariable.ScoreOfRythmGame = 150.0f;
        SystemVariable.ScoreOfVisionTest = 24.36f;
        SystemVariable.isAddScoreRanking = true;
        */

        TimeCount = false;
        KeyCapture.keyDirection = 0;

        RandomSelectMusic();
        WriteFileFromGameMode();

        yield return new WaitForSeconds(0.1f);

        UpdateScoreText();
        UpdateInputMode();

        yield return new WaitForSeconds(0.01f);
        KeyCapture.keyDirection = 0;
        TimeCount = true;

        yield return 0;
    }

    private void Update()
    {
        //2秒長押ししてる場合にタイトルに戻る
        if (isLongInPut())
        {
            SceneManager.LoadScene("TitleScene");
        }
        //timeの数値によってLandoltRingを反映する
        RingGauge.fillAmount = time / 2.0f;
    }

    //selectMusicを選択してない場合にランダムでどちらかを表示する。
    void RandomSelectMusic()
    {
        if (SystemVariable.selectMusic == 0)
        {
            SystemVariable.selectMusic = (int)UnityEngine.Random.Range(1,3);
        }
    }

    //2.0秒長押ししてるかどうかの判定
    private bool isLongInPut()
    {
        //ファイルの読み書きが終わるまで待機
        if (!TimeCount)
        {
            return false;
        } 

        //カメラ入力の時
        if (SystemVariable.inputMode == 0)
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
        //キー入力の時
        else
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
            return true;
        }
        else
        {
            return false;
        }
    }

    //入力モードの更新
    void UpdateInputMode()
    {
        if (SystemVariable.inputMode == 0)
        {
            InputModeText.text = "入力モード:カメラ";
        }
        else
        {
            InputModeText.text = "入力モード:キー";
        }
        //曲の表示
        if (SystemVariable.selectMusic == 0)
        {
            Debug.Log("曲を設定してください");
        }
        //Gaming District
        else if (SystemVariable.selectMusic == 1)
        {
            SelectMusicText.text = "Music:Gaming District";
        }
        //ImperialJade
        else if (SystemVariable.selectMusic == 2)
        {
            SelectMusicText.text = "Music:Imperial Jade";
        }
    }

    //ファイルからデータを読み込んで反映させる関数
    void UpdateScoreText()
    {
        try
        {
            int[] SiryokuScore;
            int[] RythmScore;
            if (SystemVariable.inputMode == 0)
            {
                SiryokuScore = GetArrayFromFile("CameraSiryokuScore.txt");
                RythmScore = GetArrayFromFile("CameraRythmGamingDistrictScore.txt");
                if (SystemVariable.selectMusic == 0)
                {
                    Debug.Log("SystemVariable.selectMusic == 0 not Update ScoreText");
                    return;
                }
                else if (SystemVariable.selectMusic == 1)
                {
                    RythmScore = GetArrayFromFile("CameraRythmGamingDistrictScore.txt");
                }
                else if (SystemVariable.selectMusic == 2)
                {
                    RythmScore = GetArrayFromFile("CameraRythmImperialJadeScore.txt");
                }
            }
            else
            {
                SiryokuScore = GetArrayFromFile("KeySiryokuScore.txt");
                RythmScore = GetArrayFromFile("KeyRythmGamingDistrictScore.txt");
                if (SystemVariable.selectMusic == 0)
                {
                    Debug.Log("SystemVariable.selectMusic == 0 not Update ScoreText");
                    return;
                }
                else if (SystemVariable.selectMusic == 1)
                {
                    RythmScore = GetArrayFromFile("KeyRythmGamingDistrictScore.txt");
                }
                else if (SystemVariable.selectMusic == 2)
                {
                    RythmScore = GetArrayFromFile("KeyRythmImperialJadeScore.txt");
                }
            }
            //Textオブジェクトに反映
            for (int i = 0; i < SiryokuScore.Length; i++)
            {
                Siryoku[i].text = (i + 1) + "位 " + ((float)SiryokuScore[i] / 100.0f).ToString("F");
                Rythm[i].text = (i + 1) + "位 " + ((float)RythmScore[i] / 100.0f).ToString("F");
            }
        }
        catch (FileNotFoundException e)
        {
            throw;
        }
    }

    //ゲームモードを判別してそれぞれのテキストファイルに書き込む関数
    void WriteFileFromGameMode()
    {
        //書き込みフラグが立っていない時は実行しない。
        if (!SystemVariable.isAddScoreRanking)
        {
            Debug.Log("SystemVariable.isAddScoreRanking is false");
            return;
        }
        //書き込みフラグをオフにする
        SystemVariable.isAddScoreRanking = false;

        try
        {
            //カメラ入力の場合
            if (SystemVariable.inputMode == 0)
            {
                if (SystemVariable.selectGameMode == 0)
                {
                    Debug.Log("ゲームモードが設定されていません。");
                }
                //視力検査モードから来た時
                else if (SystemVariable.selectGameMode == 1)
                {
                    //数値を100倍して書き込む
                    int score = (int)(SystemVariable.ScoreOfVisionTest * 100.0f);
                    WriteFile("CameraSiryokuScore.txt", score);
                }
                else if (SystemVariable.selectGameMode == 2)
                {
                    //数値を100倍して書き込む
                    int score = (int)(SystemVariable.ScoreOfRythmGame * 100.0f);
                    if (SystemVariable.selectMusic == 1)
                    {
                        WriteFile("CameraRythmGamingDistrictScore.txt", score);
                    }
                    else if (SystemVariable.selectMusic == 2)
                    {
                        WriteFile("CameraRythmImperialJadeScore.txt", score);
                    }
                }
            }
            //キー入力の場合
            else
            {
                if (SystemVariable.selectGameMode == 0)
                {
                    Debug.Log("ゲームモードが設定されていません。");
                }
                //視力検査モードから来た時
                else if (SystemVariable.selectGameMode == 1)
                {
                    //数値を100倍して書き込む
                    int score = (int)(SystemVariable.ScoreOfVisionTest * 100.0f);
                    WriteFile("KeySiryokuScore.txt", score);
                }
                else if (SystemVariable.selectGameMode == 2)
                {
                    //数値を100倍して書き込む
                    int score = (int)(SystemVariable.ScoreOfRythmGame * 100.0f);
                    if (SystemVariable.selectMusic == 1)
                    {
                        WriteFile("KeyRythmGamingDistrictScore.txt", score);
                    }
                    else if (SystemVariable.selectMusic == 2)
                    {
                        WriteFile("KeyRythmImperialJadeScore.txt", score);
                    }
                }
            }
        }
        catch (FileNotFoundException e)
        {
            throw;
        }
    }

    //書き込み関数
    //FileName,WriteValue
    void WriteFile(string FileName, int WriteValue)
    {
        try
        {
            File.AppendAllText(GetReadPath(FileName), "\n" + WriteValue.ToString());
        }
        catch(FileNotFoundException e)
        {
            throw;
        }
    }

    //読み込むパスを返してくれる関数
    string GetReadPath(string FileName)
    {
        string FilePath = "";
        //プラットフォームによって読み込むパスを変える。
        //MacOSのエディタの場合
        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            FilePath = Application.dataPath + "/RankingData/" + FileName;
        }
        //MacOSのAppの場合
        else if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            FilePath = Application.dataPath + "/../../data/" + FileName;
        }
        //WindowsOSのエディタの場合
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            FilePath = Application.dataPath + "/RankingData/" + FileName;
        }
        //WindowsOSのexeの場合
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            FilePath = Application.dataPath + "/data/" + FileName;
        }
        return FilePath;
    }

    //読み込み関数
    //FileNameを引数にして、ソートした後の上から10個だけを返してくれる関数
    //引数：ファイルのパス(.txt)
    int[] GetArrayFromFile(string FileName)
    {
        try
        {
            string FilePath = GetReadPath(FileName);

            //読み込み
            string[] ScoreStr = File.ReadAllLines(FilePath);
            int[] ScoreInt = new int[ScoreStr.Length];

            //一度全てintに入れる。
            for (int i = 0; i < ScoreStr.Length; i++)
            {
                ScoreInt[i] = Int32.Parse(ScoreStr[i]);
            }
            //大きい順にソート
            Array.Sort(ScoreInt);
            Array.Reverse(ScoreInt);

            int ReturnArrayLength = 0;
            if (ScoreInt.Length < 10)
            {
                ReturnArrayLength = ScoreInt.Length;
            }
            else
            {
                ReturnArrayLength = 10;
            }

            //返り値となる配列
            int[] returnArray = new int[10];
            //初期化
            for (int i = 0; i < 10; i++) returnArray[i] = 0;
            //大きい順に上から10個だけ持ってくる。
            for (int i = 0; i < ReturnArrayLength; i++)
            {
                returnArray[i] = ScoreInt[i];
            }

            return returnArray;
        }
        catch (FileNotFoundException e)
        {
            int[] returnArray = new int[10];
            for (int i = 0; i < 10; i++) returnArray[i] = 0;

            return returnArray;
        }
    }
}
