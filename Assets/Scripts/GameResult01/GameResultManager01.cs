using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResultManager01 : MonoBehaviour
{
    //シリョクのText
    Text ScoreTextValue;
    public GameObject ScoreTextValueGameObject;

    Text ScoreGradeTextValue;
    public GameObject ScoreGradeTextValueGameObject;

    //上を長押しでタイトルに戻る
    public GameObject PushUpTextGameObject;
    Transform PushUpTextTransForm;

    //タイトルに戻るを動かすかどうかの変数
    bool PushUpButtonMove = false;

    //キー入力の方向
    int keyDirection = 0;
    float time = 0;

    //Ring
    public Image RingGauge;

    //SE
    AudioSource audioSource;
    public AudioClip SE1;
    public AudioClip SE2;
    public AudioClip SE3;

    // Start is called before the first frame update
    void Start()
    {
        //効果音
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(SE1);

        //RingGaugeの非表示
        RingGauge.enabled = false;

        //事前に更新しておく
        //シリョクのTextのオブジェクトを取得
        ScoreTextValue = ScoreTextValueGameObject.GetComponent<Text>();
        //値の更新
        ScoreTextValue.text = GameManager01.ScoreValue.ToString("f2");

        //事前に更新しておく
        //GradeのTextのオブジェクトを取得
        ScoreGradeTextValue = ScoreGradeTextValueGameObject.GetComponent<Text>();
        //値の更新
        ScoreGradeTextValue.text = SetGrade(GameManager01.ScoreValue);

        //タイトルに戻るのTransformコンポーネントを取得
        PushUpTextTransForm = PushUpTextGameObject.GetComponent<Transform>();

        StartCoroutine("ShowResult");
    }

    // Update is called once per frame
    void Update()
    {
        //上入力を受け付ける
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyDirection = 1;
        }
        //指を離したことを検知したら入力方向を無効にする。
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            keyDirection = 0;
        }

        if (PushUpButtonMove)
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
                if (keyDirection == 1)
                {
                    time += Time.deltaTime;
                }
                else
                {
                    time = 0;
                }
            }
        }

        //2秒長押しでランキング画面のロード
        if (time > 2.0f)
        {
            //Ranking画面に行く前にSystem変数にスコアを代入して、スコア加筆フラグを立てる
            SystemVariable.ScoreOfVisionTest = GameManager01.ScoreValue;
            SystemVariable.isAddScoreRanking = true;

            //ランキング画面のロード
            SceneManager.LoadScene("Ranking");
        }
        //時間の分だけゲージに反映する
        RingGauge.fillAmount = time / 2.0f;
    }

    IEnumerator ShowResult()
    {
        //1.5秒待つ
        yield return new WaitForSeconds(1.5f);

        //シリョクの表示
        ScoreTextValueGameObject.SetActive(true);
        audioSource.PlayOneShot(SE2);

        //1.5秒待つ
        yield return new WaitForSeconds(1.5f);

        //ランクの表示
        ScoreGradeTextValueGameObject.SetActive(true);
        audioSource.PlayOneShot(SE3);

        //1.0秒待つ
        yield return new WaitForSeconds(1.0f);

        //タイトルに戻るボタンの表示
        PushUpTextGameObject.SetActive(true);
        //fragのON
        PushUpButtonMove = true;
        //RingGaugeの表示
        RingGauge.enabled = true;

        yield break;
    }

    string SetGrade(float score)
    {
        if (score >= 50)
        {
            return "「森羅万象」";
        }
        else if (score >= 45)
        {
            return "「神」";
        }
        else if (score >= 40)
        {
            return "「アルマ望遠鏡級」";
        }
        else if (score >= 35)
        {
            return "「ハッブル宇宙望遠鏡級」";
        }
        else if (score >= 30)
        {
            return "「電子顕微鏡級」";
        }
        else if (score >= 25)
        {
            return "「光学顕微鏡級」";
        }
        else if (score >= 20)
        {
            return "「ハヤブサ級」";
        }
        else if (score >= 15)
        {
            return "「ダチョウ級」";
        }
        else if (score >= 10)
        {
            return "「マサイ族級」";
        }
        else if (score >= 5)
        {
            return "「カメレオン級」";
        }
        else
        {
            return "「もう少し頑張ろう！」";
        }
    }
}
