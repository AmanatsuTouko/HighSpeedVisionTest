using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLandoltRing : MonoBehaviour
{
    int NotesDirection = 1;
    int NotesPos = 1;
    float NotesCrateTime = 0;

    float speed = 0.0f;

    //判定に用いるタグを入れる配列
    string[] JudgeZoon = {"GoodForUp","BadForUp","GoodForDown","BadForDown",
        "GoodForLeft","BadForLeft","GoodForRight","BadForRight"};

    //引数を元にノーツの向き・生成時間を設定する関数(GameManager02から生成するときに設定する)
    //https://qiita.com/2dgames_jp/items/495dc59c78930e284707
    public void setNotes(int time, int direction, int pos)
    {
        NotesCrateTime = (float)time;
        NotesDirection = direction;
        NotesPos = pos;
    }

    //SE
    public AudioClip PerfectAudioClip;
    public AudioClip GoodAudioClip;
    private AudioSource audioSource;
    private bool Judging = true;

    //透明度の変更
    SpriteRenderer spriteRenderer;

    //色の変更
    //https://qiita.com/motsat/items/927a4d2682765555b80d
    SpriteRenderer MainSpriteRenderer;
    //publicで宣言し、inspectorで設定可能にする
    public Sprite RedSprite;
    public Sprite BlueSprite;
    public Sprite GreenSprite;
    public Sprite OrangeSprite;

    //colliderの変更用
    CircleCollider2D Ringcollider;

    //waveのgameobject
    public GameObject WaveBlue;
    public GameObject WaveGreen;

    // Start is called before the first frame update
    void Start()
    {
        //このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //このobjectのcolliderを取得
        Ringcollider = gameObject.GetComponent<CircleCollider2D>();

        //ランドルト環の向きを変える
        //SpriteRenderのspriteを設定済みの他のspriteに変更
        //colliderの位置を変更
        switch (NotesDirection)
        {
            //上
            case 1:
                MainSpriteRenderer.sprite = RedSprite;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                switch (NotesPos)
                {
                    //上
                    case 1: Ringcollider.offset = new Vector2(-0.1f, 0f); break;
                    //下
                    case 2: Ringcollider.offset = new Vector2(0.1f, 0f); break;
                    //左
                    case 3: Ringcollider.offset = new Vector2(0f, -0.1f); break;
                    //右
                    case 4: Ringcollider.offset = new Vector2(0f, 0.1f); break;
                }
                break;
            //下
            case 2:
                MainSpriteRenderer.sprite = BlueSprite;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                switch (NotesPos)
                {
                    //上
                    case 1: Ringcollider.offset = new Vector2(0.1f, 0f); break;
                    //下
                    case 2: Ringcollider.offset = new Vector2(-0.1f, 0f); break;
                    //左
                    case 3: Ringcollider.offset = new Vector2(0f, 0.1f); break;
                    //右
                    case 4: Ringcollider.offset = new Vector2(0f, -0.1f); break;
                }
                break;
            //左
            case 3:
                MainSpriteRenderer.sprite = GreenSprite;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                switch (NotesPos)
                {
                    //上
                    case 1: Ringcollider.offset = new Vector2(0f, 0.1f); break;
                    //下
                    case 2: Ringcollider.offset = new Vector2(0f, -0.1f); break;
                    //左
                    case 3: Ringcollider.offset = new Vector2(-0.1f, 0f); break;
                    //右
                    case 4: Ringcollider.offset = new Vector2(0.1f, 0f); break;
                }
                break;
            //右
            case 4:
                MainSpriteRenderer.sprite = OrangeSprite;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                switch (NotesPos)
                {
                    //上
                    case 1: Ringcollider.offset = new Vector2(0f, -0.1f); break;
                    //下
                    case 2: Ringcollider.offset = new Vector2(0f, 0.1f); break;
                    //左
                    case 3: Ringcollider.offset = new Vector2(0.1f, 0f); break;
                    //右
                    case 4: Ringcollider.offset = new Vector2(-0.1f, 0f); break;
                }
                break;
        }
        
        //SE
        audioSource = gameObject.GetComponent<AudioSource>();
        //透明度の変更のために取得
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = Time.deltaTime * 4.0f;

        if (GameManager02.time > (float)(NotesCrateTime / 1000000))
        {
            switch (NotesPos)
            {
                //上
                case 1:
                    switch (NotesDirection)
                    {
                        //上
                        case 1: transform.Translate(-speed, 0f, 0f); break;
                        //下
                        case 2: transform.Translate(speed, 0f, 0f); break;
                        //左
                        case 3: transform.Translate(0f, speed, 0f); break;
                        //右
                        case 4: transform.Translate(0f, -speed, 0f); break;
                    }
                    break;
                //下
                case 2:
                    switch (NotesDirection)
                    {
                        //上
                        case 1: transform.Translate(speed, 0f, 0f); break;
                        //下
                        case 2: transform.Translate(-speed, 0f, 0f); break;
                        //左
                        case 3: transform.Translate(0f, -speed, 0f); break;
                        //右
                        case 4: transform.Translate(0f, speed, 0f); break;
                    }
                    break;
                //左
                case 3:
                    switch (NotesDirection)
                    {
                        //上
                        case 1: transform.Translate(0f, -speed, 0f); break;
                        //下
                        case 2: transform.Translate(0f, speed, 0f); break;
                        //左
                        case 3: transform.Translate(-speed, 0f, 0f); break;
                        //右
                        case 4: transform.Translate(speed, 0f, 0f); break;
                    }
                    break;
                //右
                case 4:
                    switch (NotesDirection)
                    {
                        //上
                        case 1: transform.Translate(0f, speed, 0f); break;
                        //下
                        case 2: transform.Translate(0f, -speed, 0f); break;
                        //左
                        case 3: transform.Translate(speed, 0f, 0f); break;
                        //右
                        case 4: transform.Translate(-speed, 0f, 0f); break;
                    }
                    break;
            }
        }
        //判定箇所を通過した1秒後に非表示にする
        if (GameManager02.time > (float)((NotesCrateTime + 3500000) / 1000000))
        {
            gameObject.SetActive(false);
        }
    }


    //https://www.subarunari.com/entry/2017/06/30/163120
    //トリガーが他のColliderに触れ続けている間
    void OnTriggerStay2D(Collider2D other)
    {
        if (Judging)
        {
            //Perfectの判定領域の時
            if (other.gameObject.tag == "PerfectZoon")
            {
                //ノーツの方向と手の向きが同じ方向だった時に消す
                if (GameManager02.judgeZoonDicection == NotesDirection)
                {
                    //SEを鳴らす
                    audioSource.clip = PerfectAudioClip;
                    audioSource.Play();
                    //透明度を0にする
                    this.spriteRenderer.color = new Color(1, 1, 1, 0);
                    //JudgeFrag
                    Judging = false;
                    //Debug.Log("Perfect!");
                    //コンボの加算
                    GameManager02.comboNumber += 1;
                    //スコアの加算
                    AddScore("Perfect");
                    //パーフェクト数の加算
                    SystemVariable.PerfectNotesNumber += 1;
                    //waveの生成
                    if (SystemVariable.selectMusic == 1)
                    {
                        GameObject obj = Instantiate(WaveBlue, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    }
                    else if (SystemVariable.selectMusic == 2)
                    {
                        GameObject obj = Instantiate(WaveGreen, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    }
                }
            }
            //GoodZoonの時
            else if (other.gameObject.tag == JudgeZoon[NotesPos * 2 - 2])
            {
                //ノーツの方向と手の向きが同じ方向だった時に消す
                if (GameManager02.judgeZoonDicection == NotesDirection)
                {
                    //SEを鳴らす
                    audioSource.clip = GoodAudioClip;
                    audioSource.Play();
                    //透明度を0にする
                    this.spriteRenderer.color = new Color(1, 1, 1, 0);
                    //JudgeFrag
                    Judging = false;
                    //Debug.Log("Good!");
                    //コンボの加算
                    GameManager02.comboNumber += 1;
                    //スコアの加算
                    AddScore("Good");
                    //Good数の加算
                    SystemVariable.GoodNotesNumber += 1;
                }
            }
            //BadZoonの時、消す
            else if (other.gameObject.tag == JudgeZoon[NotesPos * 2 - 1])
            {
                //透明度を0にする
                this.spriteRenderer.color = new Color(1, 1, 1, 0);
                //JudgeFrag
                Judging = false;
                //Debug.Log("Bad...");
                //Debug.Log(GameManager02.judgeZoonDicection.ToString() + " " + NotesDirection.ToString());

                //最大コンボ数の記録
                if (SystemVariable.ComboOfRythmGame < GameManager02.comboNumber)
                {
                    SystemVariable.ComboOfRythmGame = GameManager02.comboNumber;
                }
                //コンボのリセット
                GameManager02.comboNumber = 0;
                //Bad数の加算
                SystemVariable.BadNotesNumber += 1;
            }
        }
    }

    //現在のコンボ数から得点を計算してシリョクに加算する関数
    void AddScore(string judge)
    {
        float r = 1.0f;
        int combo = GameManager02.comboNumber;

        //係数の場合分け
        if (combo >= 100)
        {
            r = 2.5f;
        }
        else if (combo >= 50)
        {
            r = 1.8f;
        }
        else if (combo >= 30)
        {
            r = 1.4f;
        }
        else if (combo >= 10)
        {
            r = 1.2f;
        }
        else
        {
            r = 1.0f;
        }

        if (judge == "Perfect")
        {
            GameManager02.ScoreValue += r;
        }
        else if (judge == "Good")
        {
            GameManager02.ScoreValue += r / 2;
        }
    }
}
