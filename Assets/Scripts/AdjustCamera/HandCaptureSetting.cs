using UnityEngine;
using UnityEngine.UI;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.ImgprocModule;
using System.Collections.Generic;

public class HandCaptureSetting : MonoBehaviour
{
    //手がどの向きを向いているか
    //Up:1,Down:2,Left:3,Right:4 上下左右で設定。
    public static int HandDirection = 0;

    WebCamTexture webCamTexture;
    Mat srcMat;

    //追加（2値化に用いるためのMat）
    Mat srcMat2;

    Texture2D dstTexture;

    //重心からのベクトル
    public int VectorX = 0;
    public int VectorY = 0;

    //カメラデバイスを取得するための配列
    WebCamDevice[] webCamDevice;

    //カメラの変更時にMat画像の初期化を行うためのフラグ
    int changeCameraFrag = 0;

    //GrayScaleかどうかのフラグ
    public static bool GrayScale = false;

    // 初期化
    void Start()
    {
        CheckCameraUse();

        // カメラの取得
        webCamDevice = WebCamTexture.devices;

        // Webカメラの開始
        this.webCamTexture = new WebCamTexture(webCamDevice[HandCapture.selectCamera].name, 256, 256, 30);
        this.webCamTexture.Play();
    }

    // フレーム毎に呼ばれる
    void Update()
    {
        //描画と手の方向の入力
        InputCameraDirection();

        //カメラの変更
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Debug.Log("ChangeCamera");
            ChangeCamera();
        }
    }

    //シーン遷移時にカメラの結合を離す。(Windowsの場合に必須)
    private void OnDestroy()
    {
        this.webCamTexture.Stop();
        Destroy(this.webCamTexture);
    }

    //カメラモードか判定して、違った場合はオブジェクトを消す。
    void CheckCameraUse()
    {
        //カメラモードではない時
        if (SystemVariable.inputMode == 1)
        {
            Destroy(this.gameObject);
        }
    }

    //カメラの変更
    //https://note.com/npaka/n/nbaa0e466b0de
    public void ChangeCamera()
    {
        changeCameraFrag = 1;

        this.webCamTexture.Stop();
        Destroy(this.webCamTexture);

        // カメラの取得
        WebCamDevice[] webCamDevice = WebCamTexture.devices;

        // カメラが1個の時は無処理
        if (webCamDevice.Length <= 1) return;

        // カメラの切り替え
        HandCapture.selectCamera++;
        if (HandCapture.selectCamera >= webCamDevice.Length)
        {
            HandCapture.selectCamera = 0;
        }
        this.webCamTexture.Stop();
        this.webCamTexture = new WebCamTexture(webCamDevice[HandCapture.selectCamera].name, 256, 256, 30);
        this.webCamTexture.Play();
    }

    //色んな処理全部
    void InputCameraDirection()
    {
        // Webカメラ準備前は無処理
        if (this.webCamTexture.width <= 16 || this.webCamTexture.height <= 16) return;

        // 初期化
        if (this.srcMat == null || changeCameraFrag == 1)
        {
            this.srcMat = new Mat(this.webCamTexture.height, this.webCamTexture.width, CvType.CV_8UC3);
            this.dstTexture = new Texture2D(this.srcMat.cols(), this.srcMat.rows(), TextureFormat.RGBA32, false);
        }
        // 初期化
        if (this.srcMat2 == null || changeCameraFrag == 1)
        {
            this.srcMat2 = new Mat(this.webCamTexture.height, this.webCamTexture.width, CvType.CV_8UC3);
            this.dstTexture = new Texture2D(this.srcMat2.cols(), this.srcMat2.rows(), TextureFormat.RGBA32, false);
        }
        changeCameraFrag = 0;

        // WebCamTexture → Mat
        Utils.webCamTextureToMat(this.webCamTexture, this.srcMat);
        Utils.webCamTextureToMat(this.webCamTexture, this.srcMat2);

        // グレースケールへの変換
        Imgproc.cvtColor(this.srcMat2, this.srcMat2, Imgproc.COLOR_RGBA2GRAY);
        //2値化
        Imgproc.threshold(this.srcMat2, this.srcMat2, SystemVariable.Threshold, 255, 0);

        //輪郭を求める
        //https://www.bacu.jp/unity/unity-opencv-hand-origin/#%E6%9C%80%E7%B5%82%E7%9A%84%E3%81%AB%E8%AA%8D%E8%AD%98%E3%81%A7%E3%81%8D%E3%81%9F%E3%82%82%E3%81%AE
        List<MatOfPoint> contours = new List<MatOfPoint>();
        //輪郭抽出の処理
        Imgproc.findContours(this.srcMat2, contours, new Mat(), Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_SIMPLE);

        //マスク領域の生成
        //https://blog.revetronique.com/unity_opencv4/
        Imgproc.drawContours(this.srcMat2, contours, -1, new Scalar(255), -1);

        //マスク領域の生成
        Imgproc.fillPoly(this.srcMat2, contours, new Scalar(255));

        //一番大きい領域を手として認識する
        //https://qiita.com/gutugutu3030/items/3907530ee49433420b37
        int index = -1;
        double area = 0;
        for (int i = 0, n = contours.Count; i < n; i++)
        {
            double tmp = Imgproc.contourArea(contours[i]);
            if (area < tmp)
            {
                area = tmp;
                index = i;
            }
        }

        //重心の座標
        int momentX = 0;
        int momentY = 0;

        //手の概形を抽出
        MatOfInt hull = new MatOfInt();
        if (index != -1)
        {
            Imgproc.convexHull(contours[index], hull);

            //重心を求める。
            //https://cvtech.cc/centroid/
            Moments mu = Imgproc.moments(contours[index], false);
            momentX = (int)(mu.m10 / mu.m00);
            momentY = (int)(mu.m01 / mu.m00);
            //Debug.Log("momentX" + momentX);
            //Debug.Log("momentY" + momentY);
        }

        //凸包の頂点の数
        //Debug.Log(hull.size().height);

        //凸包の座標
        int convexHullX = 0;
        int convexHullY = 0;
        //最大距離
        float maxDistance = 0;
        //最大の距離の座標
        int maxX = 0;
        int maxY = 0;


        //描画用に凸包座標を入れるためのList
        List<int> convexHullListX = new List<int>();
        List<int> convexHullListY = new List<int>();


        //凸包座標を求める
        //https://imoto-yuya.hatenablog.com/entry/2017/03/13/000006
        for (int k = 0; k < hull.size().height; k++)
        {
            int hullIndex = (int)hull.get(k, 0)[0];
            double[] m = contours[index].get(hullIndex, 0);

            convexHullX = (int)m[0];
            convexHullY = (int)m[1];

            //描画用にListに追加
            convexHullListX.Add(convexHullX);
            convexHullListY.Add(convexHullY);
            //x座標
            //Debug.Log("k=" + k + " m[0]" + (int)m[0]);
            //y座標
            //Debug.Log("k=" + k + " m[1]" + (int)m[1]);


            //手首の誤検出を防ぐために座標が画面端の場合は無視する。
            if (convexHullX <= 10 || convexHullY <= 10 || convexHullX >= 300)
            {
                continue;
            }

            //重心と凸包座標の距離を求める。
            float distance = 0;
            float xDistance = 0;
            float yDistance = 0;

            xDistance = Mathf.Pow((momentX - (int)m[0]), 2);
            yDistance = Mathf.Pow((momentY - (int)m[1]), 2);

            distance = Mathf.Sqrt(xDistance + yDistance);
            if (maxDistance < distance)
            {
                maxDistance = distance;
                //最大の距離の座標を記録
                maxX = convexHullX;
                maxY = convexHullY;
            }
        }

        //重心からのベクトル
        VectorX = maxX - momentX;
        VectorY = maxY - momentY;

        //Debug.Log("重心からのベクトル  X:" + VectorX + "  Y" + VectorY);

        //カメラ入力の時
        if (SystemVariable.inputMode == 0)
        {
            if (Mathf.Abs(VectorX) < Mathf.Abs(VectorY))
            {
                if (VectorY < 0)
                {
                    //Debug.Log("Up");
                    HandDirection = 1;
                }
                else
                {
                    //Debug.Log("Down");
                    HandDirection = 2;
                }
            }
            else
            {
                if (VectorX < 0)
                {
                    //Debug.Log("Left");
                    HandDirection = 4;
                }
                else
                {
                    //Debug.Log("Right");
                    HandDirection = 3;
                }
            }
        }

        //輪郭の描画
        //http://playwithopencv.blogspot.com/2013/02/opencv-java.html
        Scalar color = new Scalar(255, 241, 0);
        Imgproc.drawContours(this.srcMat, contours, -1, color, 0);

        //凸包の描画
        for (int i = 0; i < convexHullListX.Count - 1; i++)
        {
            Imgproc.line(this.srcMat, new Point(convexHullListX[i], convexHullListY[i]), new Point(convexHullListX[i + 1], convexHullListY[i + 1]), new Scalar(90, 255, 25), 1);
        }

        //重心からのベクトルの描画
        Imgproc.line(this.srcMat, new Point(maxX, maxY), new Point(momentX, momentY), new Scalar(0, 204, 255), 3);
        //重心の描画
        Imgproc.line(this.srcMat, new Point(momentX, momentY), new Point(momentX, momentY), new Scalar(90, 255, 25), 5);

        if (!GrayScale)
        {
            // Mat → Texture2D
            Utils.matToTexture2D(this.srcMat, this.dstTexture);
        }
        else
        {
            // Mat → Texture2D
            Utils.matToTexture2D(this.srcMat2, this.dstTexture);
        }

        // 表示
        GetComponent<RawImage>().texture = this.dstTexture;
    }
}
