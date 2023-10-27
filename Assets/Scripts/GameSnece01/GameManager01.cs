using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager01 : MonoBehaviour
{
    //正解の手の向き
    //上:1、下:2、左:3、右:4
    int answerHandDirection = 0;
    //ランドルト環のオブジェクト
    GameObject LandoltRing;
    //ランドルト環の大きさ
    float LandoltRingScale = 1.0f;

    //残り時間のText
    Text LeftTimeText;
    //残り時間
    float LeftTime = 30.00f;
    //シリョクのText
    Text ScoreTextValue;
    //シリョク
    public static float ScoreValue = 0.0f;

    //ゲームスタート変数
    //falseの場合はカウントが進まない(最初のカウントダウン後にtrueにする)
    bool GamePlaying = false;
    public Text CountDownText;

    //音源
    AudioSource audioSource;
    public AudioClip BGM;
    public AudioClip CorrectSE;
    public AudioClip CountDown1;
    public AudioClip CountDown2;

    // Start is called before the first frame update
    void Start()
    {
        //シリョクのリセット
        ScoreValue = 0.0f;

        //ウィンドウサイズを指定
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1920, 1080, true, 60);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false, 60);
        }

        //初期の手の向きを生成
        answerHandDirection = Random.Range(1, 5);
        //ランドルト環のオブジェクトを取得
        LandoltRing = GameObject.Find("LandoltRing");

        //ランドルト環の向きを変える
        switch (answerHandDirection)
        {
            //上
            case 1:
                LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            //下
            case 2:
                LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            //左
            case 3:
                LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            //右
            case 4:
                LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }

        //残り時間のTextのオブジェクトを取得
        LeftTimeText = GameObject.Find("LeftTimeTextValue").GetComponent<Text>();
        //残り時間の初期値を設定
        LeftTimeText.text = LeftTime.ToString("f2");
        //シリョクのTextのオブジェクトを取得
        ScoreTextValue = GameObject.Find("ScoreTextValue").GetComponent<Text>();
        //シリョクの初期値を設定
        ScoreTextValue.text = ScoreValue.ToString("f2");

        //コンポーネントの取得
        audioSource = GetComponent<AudioSource>();

        //カウントダウンの開始
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {
        bool correct = false;
        //カメラ入力の時
        if (SystemVariable.inputMode == 0)
        {
            if (answerHandDirection == HandCapture.HandDirection)
            {
                correct = true;
            }
        }
        //カメラ入力がfalseの時
        else
        {
            if (answerHandDirection == KeyCapture.keyDirection)
            {
                correct = true;
            }
        }

        if (GamePlaying)
        {
            //正解の時
            if (correct && LeftTime > 0)
            {
                //正解音を鳴らす
                audioSource.PlayOneShot(CorrectSE);

                //正解の向きを変える
                int tmp = answerHandDirection;
                //同じ向きにならないようにする。
                while (true)
                {
                    answerHandDirection = Random.Range(1, 5);
                    if (tmp != answerHandDirection) break;
                }
                //ランドルト環の向きを変える
                switch (answerHandDirection)
                {
                    //上
                    case 1:
                        LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    //下
                    case 2:
                        LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                        break;
                    //左
                    case 3:
                        LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;
                    //右
                    case 4:
                        LandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                }

                //シリョクを加算する。
                ScoreValue += (0.2f / LandoltRingScale);

                //大きさを小さくする。  
                while (true)
                {
                    LandoltRingScale = Random.value;
                    if (LandoltRingScale > 0.05)
                    {
                        break;
                    }
                }
                //大きさを反映する。
                LandoltRing.gameObject.transform.localScale = new Vector3(LandoltRingScale, LandoltRingScale, 0);
            }
        }

        if (GamePlaying)
        {
            if (LeftTime > 0)
            {
                //残り時間の更新
                LeftTime -= Time.deltaTime;
                //残り時間の表示
                LeftTimeText.text = LeftTime.ToString("f2");
            }
            else
            {
                //残り時間の更新
                LeftTime = 0.00f;
                //残り時間の表示
                LeftTimeText.text = LeftTime.ToString("f2");

                StartCoroutine("Finish");
            }
        }

        ScoreTextValue.text = ScoreValue.ToString("f2");
    }

    //開始時のカウントダウン
    IEnumerator CountDown()
    {
        float time = 0;
        float textScale = CountDownText.transform.localScale.x;
        int numberState = 3;

        //効果音の再生
        audioSource.PlayOneShot(CountDown1);

        while (true)
        {
            time += Time.deltaTime;
            //テキストの大きさの変更
            textScale -= 0.1f;
            CountDownText.transform.localScale = new Vector3(textScale,textScale,1.0f);

            if (textScale < 0.4)
            {
                textScale = 3.0f;

                if (numberState > 1)
                {
                    numberState -= 1;
                    CountDownText.text = numberState.ToString();

                    //効果音の再生
                    audioSource.PlayOneShot(CountDown1);
                }
                else
                {
                    CountDownText.text = "START!";
                    CountDownText.transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);

                    //効果音の再生
                    audioSource.PlayOneShot(CountDown2);

                    yield return new WaitForSeconds(1.0f);
                    CountDownText.enabled = false;
                    GamePlaying = true;
                    break;
                }
            }
            yield return new WaitForSeconds(0.03f);
        }

        //BGMの再生
        audioSource.PlayOneShot(BGM);

        yield return 0;
    }

    IEnumerator Finish()
    {
        //Finishテキストの表示
        CountDownText.text = "FINISH!";
        CountDownText.enabled = true;

        //シリョクの更新
        ScoreValue *= 100.0f;
        float ScoreTmp = Mathf.Floor(ScoreValue);
        ScoreValue /= 100.0f;
        ScoreTextValue.text = ScoreValue.ToString("f2");

        //視力検査モードから遷移したことを記録しておく
        SystemVariable.selectGameMode = 1;
        //書き込みフラグをオンにする
        SystemVariable.isAddScoreRanking = true;
        //スコアをシステム変数に渡す
        SystemVariable.ScoreOfVisionTest = ScoreValue;
        
        yield return new WaitForSeconds(1.0f);

        //ResultSceneの読み込み
        SceneManager.LoadScene("GameResult01");
        yield return 0;
    }
}
