using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager02 : MonoBehaviour
{
    //ノーツの生成する位置を入れる配列(x,y)
    private float[,] NotesPosArray = {
        {  0,  9.85f},
        {  0, -9.85f},
        { -9.85f,  0},
        {  9.85f,  0}
    };

    //キー入力した手の向き
    int keyHandDirection = 0;
    //カメラ入力を優先するフラグ、一度でもキー入力を行うとfalseにする。
    public static bool priorityHandCapture = true;

    //シリョクのText
    Text ScoreTextValue;
    //シリョク
    public static float ScoreValue = 0.0f;
    //判定ゾーンのオブジェクト
    public GameObject JudgeLandoltRing;

    //PrefabのGameObject
    public GameObject LandoltRingPrefab;

    //曲の再生用
    private AudioSource audioSource;
    public AudioClip GamingDistrict;
    public AudioClip SecondMusic;

    //動画の再生用
    VideoPlayer videoPlayer;

    //コンボ数の記録用変数
    public static int comboNumber = 0;
    //コンボ数のText
    Text ComboTextValue;

    //判定ゾーンの向き
    public static int judgeZoonDicection;
    //時間の管理変数
    public static float time = 0.0f;
    bool TimeCountFrag = false;
    bool MusicPlayFrag = false;

    //背景動画用
    public GameObject VideoRawImage;
    public GameObject VideoRawImage2;

    //NowLoading
    public GameObject NowLoading;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //デバッグ用、設定値が0(設定されてない場合)
        if (SystemVariable.selectMusic == 0)
        {
            //曲の設定
            SystemVariable.selectMusic = 2;
            //難易度の設定
            SystemVariable.selectDifficulty = 1;
        }

        //リズムゲームモードに設定
        SystemVariable.selectGameMode = 2;

        //変数のリセットとTime変数への遅延の設定
        ResetVariables();

        //Updateを無効にする
        enabled = false;

        //動画の再生準備
        if (SystemVariable.selectMusic == 1)
        {
            //VideoRawImage.SetActive(true);
            //使わないほうの透明度を0にする。
            RawImage videoColor = VideoRawImage2.GetComponent<RawImage>();
            videoColor.color = new Color(1, 1, 1, 0);
            videoPlayer = VideoRawImage.GetComponent<VideoPlayer>();
        }
        else
        {
            //VideoRawImage2.SetActive(true);
            //使わないほうの透明度を0にする。
            RawImage videoColor = VideoRawImage.GetComponent<RawImage>();
            videoColor.color = new Color(1, 1, 1, 0);
            videoPlayer = VideoRawImage2.GetComponent<VideoPlayer>();
        }

        yield return new WaitForSeconds(2.00f);

        //ノーツPrefabの生成
        CreateNotesBefore(LandoltRingPrefab, NotesPosArray);

        //ウィンドウサイズを指定
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1920, 1080, true, 60);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false, 60);
        }

        //シリョクのTextのオブジェクトを取得
        ScoreTextValue = GameObject.Find("ScoreTextValue").GetComponent<Text>();
        //シリョクの初期値を設定
        ScoreTextValue.text = ScoreValue.ToString("f2");

        //コンボ数のTextのオブジェクトを取得
        ComboTextValue = GameObject.Find("ComboTextValue").GetComponent<Text>();
        //コンボ数の初期値を設定
        ComboTextValue.text = comboNumber.ToString();

        //判定ゾーンのオブジェクトを取得
        //JudgeLandoltRing = GameObject.Find("JudgeLandoltRing");

        //曲の再生の準備
        audioSource = gameObject.GetComponent<AudioSource>();
        if (SystemVariable.selectMusic == 1)
        {
            audioSource.clip = GamingDistrict;
        }
        else
        {
            audioSource.clip = SecondMusic;
        }

        //ビデオの準備を待機する
        while (true)
        {
            //ビデオが準備中出ない時
            if (!videoPlayer.isPrepared)
            {
                break;
            }
        } 

        //読み込みに時間がかかると思われるのでここで遅延を挟む
        //yield return new WaitForSeconds(2.0f);

        //全ての処理が終わり次第曲の再生とtimeのカウントを始める
        TimeCountFrag = true;
        MusicPlayFrag = true;

        //NowLoadingの非表示と判定リングの表示
        NowLoading.SetActive(false);
        JudgeLandoltRing.SetActive(true);

        //動画の再生
        StartCoroutine("PlayVideo");

        //遅延を挟むことでUpdateの始まるタイミングを揃える。
        yield return new WaitForSeconds(1);

        //Updateを有効にする。
        enabled = true;

        yield return 0;
    }

    //曲の再生
    private void FixedUpdate()
    {
        if (MusicPlayFrag)
        {
            //曲の再生
            audioSource.Play();
            MusicPlayFrag = false;
        }
    }

    //動画の再生
    IEnumerator PlayVideo()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (MusicPlayFrag)
            {
                yield return new WaitForSeconds(0.700f);
                videoPlayer.Play();
                break;
            }
        }
        yield return 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCountFrag)
        {
            time += Time.deltaTime;
        }

        //曲の終了時にタイトルに戻る
        if (!audioSource.isPlaying)
        {
            //曲の終わった後の処理を実行
            StartCoroutine("EndProcess");
        }

        //カメラ入力の時
        if (SystemVariable.inputMode == 0)
        {
            judgeZoonDicection = HandCapture.HandDirection;
        }
        //カメラ入力がfalseの時
        else
        {
            judgeZoonDicection = KeyCapture02.keyDirection;
        }

        //ランドルト環の向きを変える
        switch (judgeZoonDicection)
        {
            //上
            case 1:
                JudgeLandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            //下
            case 2:
                JudgeLandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            //左
            case 3:
                JudgeLandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            //右
            case 4:
                JudgeLandoltRing.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }

        //シリョクの更新
        ScoreTextValue.text = ScoreValue.ToString("f2");
        //コンボの更新
        ComboTextValue.text = comboNumber.ToString();
    }

    //最終プロセス
    IEnumerator EndProcess()
    {
        //コンボ数をSystemVariableに渡す
        VariablePassOver();
        //スコア更新フラグをtrueにする
        SystemVariable.isAddScoreRanking = true;

        //シリョクの更新
        ScoreValue *= 100.0f;
        int ScoreTmp = (int)ScoreValue;
        ScoreValue /= 100.0f;
        ScoreTextValue.text = ScoreValue.ToString("f2");

        yield return new WaitForSeconds(2.5f);

        //ランキングシーンの読み込み
        SceneManager.LoadScene("GameResult02");
        yield return 0;
    }

    //変数のリセット
    private void ResetVariables()
    {
        ScoreValue = 0.0f;
        comboNumber = 0;
        time = 0.0f + ((float)SystemVariable.NotesTimeDelay/1000000);

        SystemVariable.PerfectNotesNumber = 0;
        SystemVariable.GoodNotesNumber = 0;
        SystemVariable.BadNotesNumber = 0;
        SystemVariable.ComboOfRythmGame = 0;
    }

    //Rankingのためにシステム変数を渡す関数
    private void VariablePassOver()
    {
        //最大コンボ数の更新(フルコンボの際はこれが用いられる)
        if (SystemVariable.ComboOfRythmGame < GameManager02.comboNumber)
        {
            SystemVariable.ComboOfRythmGame = GameManager02.comboNumber;
        }
        SystemVariable.ScoreOfRythmGame = ScoreValue;
    }

    //ノーツの生成
    private void CreateNotesBefore(GameObject LandoltRingPrefab, float[,] NotesPosArray)
    {
        //何番目のノーツを生成したか
        int NoteCounts = 0;

        //曲と難易度によって読み込むノーツ情報を変える
        //GamingDistrict
        if (SystemVariable.selectMusic == 1)
        {
            switch (SystemVariable.selectDifficulty)
            {
                //normal
                case 1:
                    while (NoteCounts < NotesData01_1.NotesData.Length / 3)
                    {
                        //生成する位置によって変える
                        int NotesPos = NotesData01_1.NotesData[NoteCounts, 2];
                        GameObject obj = Instantiate(LandoltRingPrefab,
                            new Vector3(NotesPosArray[NotesPos - 1, 0], NotesPosArray[NotesPos - 1, 1], -1), Quaternion.identity) as GameObject;
                        //MovingLandoltRingスクリプトオブジェクトを取得
                        MovingLandoltRing script = obj.GetComponent<MovingLandoltRing>();
                        //生成時間・向き・位置を設定
                        script.setNotes(NotesData01_1.NotesData[NoteCounts, 0],
                            NotesData01_1.NotesData[NoteCounts, 1], NotesData01_1.NotesData[NoteCounts, 2]);
                        NoteCounts = NoteCounts + 1;
                    }
                    break;
                //hard
                case 2:
                    while (NoteCounts < NotesData01_2.NotesData.Length / 3)
                    {
                        //生成する位置によって変える
                        int NotesPos = NotesData01_2.NotesData[NoteCounts, 2];
                        GameObject obj = Instantiate(LandoltRingPrefab,
                            new Vector3(NotesPosArray[NotesPos - 1, 0], NotesPosArray[NotesPos - 1, 1], -1), Quaternion.identity) as GameObject;
                        //MovingLandoltRingスクリプトオブジェクトを取得
                        MovingLandoltRing script = obj.GetComponent<MovingLandoltRing>();
                        //生成時間・向き・位置を設定
                        script.setNotes(NotesData01_2.NotesData[NoteCounts, 0],
                            NotesData01_2.NotesData[NoteCounts, 1], NotesData01_2.NotesData[NoteCounts, 2]);
                        NoteCounts = NoteCounts + 1;
                    }
                    break;
            }
        }
        //2曲目
        else if (SystemVariable.selectMusic == 2)
        {
            switch (SystemVariable.selectDifficulty)
            {
                //normal
                case 1:
                    while (NoteCounts < NotesData02_1.NotesData.Length / 3)
                    {
                        //生成する位置によって変える
                        int NotesPos = NotesData02_1.NotesData[NoteCounts, 2];
                        GameObject obj = Instantiate(LandoltRingPrefab,
                            new Vector3(NotesPosArray[NotesPos - 1, 0], NotesPosArray[NotesPos - 1, 1], -1), Quaternion.identity) as GameObject;
                        //MovingLandoltRingスクリプトオブジェクトを取得
                        MovingLandoltRing script = obj.GetComponent<MovingLandoltRing>();
                        //生成時間・向き・位置を設定
                        script.setNotes(NotesData02_1.NotesData[NoteCounts, 0],
                            NotesData02_1.NotesData[NoteCounts, 1], NotesData02_1.NotesData[NoteCounts, 2]);
                        NoteCounts = NoteCounts + 1;
                    }
                    break;
                //hard
                case 2:
                    while (NoteCounts < NotesData02_2.NotesData.Length / 3)
                    {
                        //生成する位置によって変える
                        int NotesPos = NotesData02_2.NotesData[NoteCounts, 2];
                        GameObject obj = Instantiate(LandoltRingPrefab,
                            new Vector3(NotesPosArray[NotesPos - 1, 0], NotesPosArray[NotesPos - 1, 1], -1), Quaternion.identity) as GameObject;
                        //MovingLandoltRingスクリプトオブジェクトを取得
                        MovingLandoltRing script = obj.GetComponent<MovingLandoltRing>();
                        //生成時間・向き・位置を設定
                        script.setNotes(NotesData02_2.NotesData[NoteCounts, 0],
                            NotesData02_2.NotesData[NoteCounts, 1], NotesData02_2.NotesData[NoteCounts, 2]);
                        NoteCounts = NoteCounts + 1;
                    }
                    break;
            }
        }
    }
}
