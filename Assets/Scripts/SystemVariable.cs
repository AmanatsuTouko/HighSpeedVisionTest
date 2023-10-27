using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemVariable : MonoBehaviour
{
    public static int inputMode = 1;
    //カメラ入力(0)か、キー入力(1)か。デフォルトはキー入力

    public static int selectGameMode = 0;
    //1:視力検査モード
    //2:リズムゲームモード

    public static int selectMusic = 0;
    //選んだ曲
    //Gaming District : 1
    //Imperial Jade : 2

    public static int selectDifficulty = 1;
    //選んだ難易度
    //デフォルトは1
    //今回は難易度設定を行わないのでこのまま変わらない。
    //normal : 1
    //hard : 2

    public static float ScoreOfVisionTest = 0.0f;
    //視力検査モードでのシリョク

    public static float ScoreOfRythmGame = 0.0f;
    //リズムゲームモードでの視力

    public static bool isAddScoreRanking = false;
    //ランキングにスコアを追加する時にtrueにする。
    //追加した後にfalse、各Result画面でtrueにする。

    public static int PerfectNotesNumber = 0;
    public static int GoodNotesNumber = 0;
    public static int BadNotesNumber = 0;
    public static int ComboOfRythmGame = 0;
    //リズムゲームモードでの判定数

    public static int PreInputMode = 0;
    //AdjustCameraシーンから、Settings/Titleに戻るときに以前の入力方法を記録しておく

    public static int Threshold = 127;
    //手の認識で2値化するときの閾値

    public static int NotesTimeDelay = 0;
    //ノーツが来るタイミングの遅延
}