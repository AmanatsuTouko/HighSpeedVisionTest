using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManegerTitle : MonoBehaviour
{
    //キー入力した手の向き
    int keyHandDirection = 0;

    //UI
    //Title
    public Text TitleText;
    public GameObject Setting;
    public GameObject GirlImage;
    public GameObject TitleLogo;
    public Text StartReccomendText;
    public Image RingGauge;
    public Image RingGauge2;
    //GameModeSelect
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject UIs;
    //SelectMusic
    public GameObject LeftButton2;
    public GameObject RightButton2;
    public GameObject UIs2;
    //SelectDifficulty
    public GameObject LeftButton3;
    public GameObject RightButton3;
    public GameObject UIs3;

    //効果音
    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;

    //複数回効果音がならないようにする
    private bool LoadFrag = true;
    private bool SelectSEFragLeft = true;
    private bool SelectSEFragRight = true;

    //現在の状態変数
    //0:タイトルロゴ
    //1:モード選択
    //2:難易度選択
    private int state = 0;

    //左右どちらを選択しているか
    //0:どちらも選択していない
    //1:Left
    //2:Right
    private int LRstate = 0;

    //長押し判定に用いる
    float time = 0;
    //キャンセル時の長押し判定用
    float timeForCancel = 0;

    // Start is called before the first frame update
    void Start()
    {
        //ウィンドウサイズを指定
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1920, 1080, true, 60);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false, 60);
        }
        //二重環の非表示
        RingGauge2.enabled = false;
        //コンポーネントの取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyHandDirection = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyHandDirection = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyHandDirection = 3;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyHandDirection = 4;
        }

        //指を離したことを検知したら入力方向を無効にする。
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            keyHandDirection = 0;
        }

        //長押ししてるかどうかの判定
        if (SystemVariable.inputMode == 0)//手の入力の時
        {
            if (HandCapture.HandDirection == 1)
            {
                time += Time.deltaTime;
                timeForCancel = 0;
            }
            else if (HandCapture.HandDirection == 2)
            {
                timeForCancel += Time.deltaTime;
                time = 0;
            }
            else
            {
                time = 0;
                timeForCancel = 0;
            }
        }
        else//キー入力の時
        {
            if (keyHandDirection == 1)
            {
                time += Time.deltaTime;
            }
            else if (keyHandDirection == 2)
            {
                timeForCancel += Time.deltaTime;
            }
            else
            {
                time = 0;
                timeForCancel = 0;
            }
        }

        switch (state)
        {
            case 0:
                //2秒長押し終わったあと
                if (time > 2.0f)
                {
                    //モード選択画面へ移行
                    state = 1;
                    //効果音を鳴らす
                    audioSource.PlayOneShot(sound1);
                    StartCoroutine("TitleImageRemove");
                }
                break;
            case 1:
                //左右を入力時、選択状態をLeft・Rightにする
                UpdateLRstate();

                //選択している方のButtonを拡大する
                //RingGaugeを移動する
                if (LRstate == 1)
                {
                    LeftButton.transform.localScale = new Vector3(1.2f,1.2f,1.0f);
                    RightButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    RingGauge.transform.localPosition = new Vector3(-400,0,0);
                    PlaySELeft();
                    //2秒長押し終わったあと
                    if (time > 2.0f)
                    {
                        //視力検査ゲームのスタート
                        StartCoroutine("StartGameScene01");
                    }
                }
                else if (LRstate == 2)
                {
                    LeftButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    RightButton.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
                    RingGauge.transform.localPosition = new Vector3(400, 0, 0);
                    PlaySERight();
                    //2秒長押し終わったあと
                    if (time > 2.0f)
                    {
                        //曲選択へ移行
                        StartCoroutine("MusicSelect");
                    }
                }
                //タイトル画面に戻る
                if (timeForCancel > 2.0f)
                {
                    state = 0;
                    //効果音を鳴らす
                    audioSource.PlayOneShot(sound5);
                    //タイトルに戻る
                    StartCoroutine("BackToTitile");
                }
                break;
            case 2:
                //左右を入力時、選択状態をLeft・Rightにする
                UpdateLRstate();
                //選択している方のButtonを拡大する
                //RingGaugeを移動する
                if (LRstate == 1)
                {
                    LeftButton2.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
                    RightButton2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    RingGauge2.transform.localPosition = new Vector3(-400, 0, 0);
                    PlaySELeft();
                    //2秒長押し終わったあと
                    if (time > 2.0f)
                    {
                        //曲をGaming Districtに決定
                        SystemVariable.selectMusic = 1;
                        //ゲームのロード(2021/10/23追加)
                        StartCoroutine("StartGameScene02");
                        //StartCoroutine("selectDifficulty");
                    }
                }
                else if (LRstate == 2)
                {
                    LeftButton2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    RightButton2.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
                    RingGauge2.transform.localPosition = new Vector3(400, 0, 0);
                    PlaySERight();
                    //2秒長押し終わったあと
                    if (time > 2.0f)
                    {
                        //曲をImprerialJade に決定
                        SystemVariable.selectMusic = 2;
                        //ゲームのロード(2021/10/23追加)
                        StartCoroutine("StartGameScene02");
                        //StartCoroutine("selectDifficulty");
                    }
                }
                //一つ前の画面に戻る
                if (timeForCancel > 2.0f)
                {
                    state = 1;
                    timeForCancel = 0.0f;
                    //効果音を鳴らす
                    audioSource.PlayOneShot(sound5);
                    //タイトルに戻る
                    StartCoroutine("BackToState1");
                }
                break;
            case 3:
                //左右を入力時、選択状態をLeft・Rightにする
                UpdateLRstate();
                //選択している方のButtonを拡大する
                //RingGaugeを移動する
                if (LRstate == 1)
                {
                    LeftButton3.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
                    RightButton3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    RingGauge2.transform.localPosition = new Vector3(-400, 0, 0);
                    PlaySELeft();
                    //2秒長押し終わったあと
                    if (time > 2.0f)
                    {
                        //難易度をnormalに設定
                        SystemVariable.selectDifficulty = 1;
                        if (LoadFrag)
                        {
                            //ゲームシーンの読みこみ
                            StartCoroutine("StartGameScene02");
                            LoadFrag = false;
                        }
                    }
                }
                else if (LRstate == 2)
                {
                    LeftButton3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    RightButton3.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
                    RingGauge2.transform.localPosition = new Vector3(400, 0, 0);
                    PlaySERight();
                    //2秒長押し終わったあと
                    if (time > 2.0f)
                    {
                        //難易度をhardに設定
                        SystemVariable.selectDifficulty = 2;
                        if (LoadFrag)
                        {
                            //ゲームシーンの読みこみ
                            StartCoroutine("StartGameScene02");
                            LoadFrag = false;
                        }
                    }
                }
                //一つ前の画面に戻る
                if (timeForCancel > 2.0f)
                {
                    state = 2;
                    //効果音を鳴らす
                    audioSource.PlayOneShot(sound5);
                    //タイトルに戻る
                    StartCoroutine("BackToState2");
                }
                break;
            default:
                break;
        }

        //押している時間の分だけゲージに反映させる
        if (state == 1)
        {
            if (LRstate != 0)
            {
                RingGauge.fillAmount = time / 2.0f;
            }
        }
        else if (state == 2)
        {
            RingGauge2.fillAmount = time / 2.0f;
        }
        else
        {
            RingGauge.fillAmount = time / 2.0f;
        }
    }

    //左右選択状態を記録する
    void UpdateLRstate()
    {
        if (SystemVariable.inputMode == 0)//手の入力の時
        {
            if (HandCapture.HandDirection == 3)
            {
                LRstate = 1;
            }
            else if (HandCapture.HandDirection == 4)
            {
                LRstate = 2;
            }
        }
        else//キー入力の時
        {
            if (keyHandDirection == 3)
            {
                LRstate = 1;
            }
            else if (keyHandDirection == 4)
            {
                LRstate = 2;
            }
        }
    }
    //SEをLR選択時に一回だけ鳴らす
    void PlaySELeft()
    {
        //SE
        if (SelectSEFragLeft)
        {
            SelectSEFragLeft = false;
            SelectSEFragRight = true;
            audioSource.PlayOneShot(sound4);
        }
    }
    void PlaySERight()
    {
        //SE
        if (SelectSEFragRight)
        {
            SelectSEFragLeft = true;
            SelectSEFragRight = false;
            audioSource.PlayOneShot(sound4);
        }
    }

    //長押し終了後のタイトル画面のUIの非表示と選択画面の表示
    IEnumerator TitleImageRemove()
    {
        //UIの消去
        TitleText.enabled = false;
        StartReccomendText.enabled = false;
        Setting.SetActive(false);
        GirlImage.SetActive(false);
        TitleLogo.SetActive(false);
        //入力の無効化
        keyHandDirection = 0;
        RingGauge.fillAmount = 0.0f;

        yield return new WaitForSeconds(0.1f);

        //選択画面の表示
        LeftButton.SetActive(true);
        RightButton.SetActive(true);
        UIs.SetActive(true);
        //Ringの大きさ変更
        RingGauge.transform.localScale = new Vector3(5.0f, 5.0f, 0f);

        yield return 0;
    }

    //ゲームモード選択からタイトルに戻る処理
    IEnumerator BackToTitile()
    {
        //選択画面のリセット
        LeftButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        RightButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //選択画面の消去
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        UIs.SetActive(false);
        //Ringの大きさ変更
        RingGauge.transform.localScale = new Vector3(1.0f, 1.0f, 0f);
        RingGauge.transform.localPosition = new Vector3(0, -460, 0);
        //入力の無効化
        keyHandDirection = 0;
        HandCapture.HandDirection = 0;
        RingGauge.fillAmount = 0.0f;
        LRstate = 0;

        yield return new WaitForSeconds(0.1f);

        //タイトルUIの表示
        TitleText.enabled = true;
        StartReccomendText.enabled = true;
        Setting.SetActive(true);
        GirlImage.SetActive(true);
        TitleLogo.SetActive(true);

        yield return 0;
    }

    //state2からstate1に戻る処理
    IEnumerator BackToState1()
    {
        //選択画面のリセット
        LeftButton2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        RightButton2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //選択画面の消去
        LeftButton2.SetActive(false);
        RightButton2.SetActive(false);
        UIs2.SetActive(false);
        //入力の無効化
        keyHandDirection = 0;
        RingGauge.fillAmount = 0.0f;
        LRstate = 0;

        //ランドルト環の有効化
        RingGauge.enabled = true;
        //二重環の無効化
        RingGauge2.enabled = false;

        yield return new WaitForSeconds(0.1f);

        //選択画面の表示
        LeftButton.SetActive(true);
        RightButton.SetActive(true);
        UIs.SetActive(true);

        yield return 0;
    }

    //state3からstate2に戻る処理
    IEnumerator BackToState2()
    {
        //選択画面のリセット
        LeftButton3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        RightButton3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //選択画面の消去
        LeftButton3.SetActive(false);
        RightButton3.SetActive(false);
        UIs3.SetActive(false);
        //入力の無効化
        keyHandDirection = 0;
        RingGauge.fillAmount = 0.0f;
        LRstate = 0;

        //ランドルト環の有効化
        RingGauge.enabled = true;

        //二重環の無効化
        RingGauge2.enabled = false;

        yield return new WaitForSeconds(0.1f);

        //選択画面の表示
        LeftButton2.SetActive(true);
        RightButton2.SetActive(true);
        UIs2.SetActive(true);

        yield return 0;
    }

    IEnumerator StartGameScene01()
    {
        //効果音の再生
        audioSource.PlayOneShot(sound3);

        //変数のリセット
        state = 0;
        time = 0;
        LRstate = 0;

        //Ringを見えないようにする
        RingGauge.transform.localPosition = new Vector3(0, -1000, 0);

        //効果音のための遅延
        yield return new WaitForSeconds(1.0f);

        //非表示に戻す
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        UIs.SetActive(false);

        //視力検査ゲームスタート
        SceneManager.LoadScene("GameScene01");
        yield return 0;
    }

    IEnumerator MusicSelect()
    {
        //選択画面のリセット
        LeftButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        RightButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //効果音の再生
        audioSource.PlayOneShot(sound2);

        //入力の無効化
        keyHandDirection = 0;
        RingGauge.fillAmount = 0.0f;
        LRstate = 0;

        //モード選択画面の非表示
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        UIs.SetActive(false);
        //曲選択画面の表示
        LeftButton2.SetActive(true);
        RightButton2.SetActive(true);
        UIs2.SetActive(true);

        //ここから追加 2021/10/23
        //ランドルト環の非表示
        RingGauge.enabled = false;

        //二重環の大きさ変更
        RingGauge2.fillAmount = 0.0f;
        RingGauge2.transform.localScale = new Vector3(5.0f, 5.0f, 0f);
        //二重環の表示
        RingGauge2.enabled = true;
        //ここまで追加 2021/10/23

        //状態変数の変更
        state = 2;

        yield return 0;
    }

    IEnumerator selectDifficulty()
    {
        //選択画面のリセット
        LeftButton2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        RightButton2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //効果音の再生
        audioSource.PlayOneShot(sound2);

        //入力の無効化
        keyHandDirection = 0;
        RingGauge.fillAmount = 0.0f;
        LRstate = 0;

        //モード選択画面の非表示
        LeftButton2.SetActive(false);
        RightButton2.SetActive(false);
        UIs2.SetActive(false);
        //曲選択画面の表示
        LeftButton3.SetActive(true);
        RightButton3.SetActive(true);
        UIs3.SetActive(true);

        //ランドルト環の非表示
        RingGauge.enabled = false;

        //二重環の大きさ変更
        RingGauge2.fillAmount = 0.0f;
        RingGauge2.transform.localScale = new Vector3(5.0f, 5.0f, 0f);
        //二重環の表示
        RingGauge2.enabled = true;

        //状態変数の変更
        state = 3;

        yield return 0;
    }

    IEnumerator StartGameScene02()
    {
        audioSource.PlayOneShot(sound3);

        //wait時の表示調整
        RingGauge.fillAmount = 1.0f;
        state = 4;
        LRstate = 0;

        //円を最後まで描画する。
        RingGauge2.fillAmount = 1.0f;
        Canvas.ForceUpdateCanvases();

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("GameScene02");
        yield return 0;
    }
}
