﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using OpenCvSharp;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 元画像の表示
            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            this.pictureBoxIpl1.ImageIpl = src;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 元画像の表示
            Mat src = new Mat("Images/testimage.png", ImreadModes.GrayScale);
            this.pictureBoxIpl1.ImageIpl = src;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // グレースケール
            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);

            this.pictureBoxIpl1.ImageIpl = gray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ２値化 大津式
            Mat src = new Mat("Images/testimage.png", ImreadModes.GrayScale);

            Mat binary = src.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            this.pictureBoxIpl1.ImageIpl = binary;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // グレースケール
            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
         
            // ２値化 大津式
            Mat binary = gray.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            this.pictureBoxIpl1.ImageIpl = binary;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 閾値を指定します
            int threshold = 128;

            Mat gray = new Mat("Images/testimage.png", ImreadModes.GrayScale);
            Mat binary = gray.Threshold(threshold, 255, ThresholdTypes.Binary);

            this.pictureBoxIpl1.ImageIpl = binary;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 閾値を指定します
            int threshold = 64;

            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);

            Mat binary = gray.Threshold(threshold, 255, ThresholdTypes.Binary);

            this.pictureBoxIpl1.ImageIpl = binary;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 適応的閾値処理
            // やっぱり文字認識用かな
            Mat src = new Mat("Images/testimage.png", ImreadModes.GrayScale);
            Mat mat1 = src.AdaptiveThreshold(255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 9, 12);
            this.pictureBoxIpl1.ImageIpl = mat1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 適応的閾値処理
            // やっぱり文字認識用かな
            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat mat1 = gray.AdaptiveThreshold(255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 9, 12);
            this.pictureBoxIpl1.ImageIpl = mat1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 適応的閾値処理
            // やっぱり文字認識用かな
            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat mat1 = gray.AdaptiveThreshold(255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 9, 12);
            this.pictureBoxIpl1.ImageIpl = mat1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // 適応的閾値処理
            // やっぱり文字認識用かな
            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat mat1 = gray.AdaptiveThreshold(255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 9, 12);
            this.pictureBoxIpl1.ImageIpl = mat1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // 輪郭検出

            // 閾値固定
            int threshold = 128;

            Mat src = new Mat("Images/testimage.png", ImreadModes.Color); // カラー
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);

            // 黒ベースの白のオブジェクトにしておく
            Mat binary = gray.Threshold(threshold, 255, ThresholdTypes.BinaryInv);

            OpenCvSharp.Point[][] ss;

            ss = binary.Clone().FindContoursAsArray(RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            int num = 0;
            for (int i = 0; i < ss.Length; i++)
            {

                num++;
                //
                // 2値化後の画像に描いても、白または黒になってしまいます。
                // 元の画像に描く方が分かりやすいです。
                // ここまで作って、検査時に使った元画像なんて破壊されても別に問題ないじゃんと思ってしまった
                //
                src.DrawContours(ss, i, Scalar.Aqua, 4, LineTypes.AntiAlias);

            }

            this.pictureBoxIpl1.ImageIpl = src;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // グレースケール
            Mat src = new Mat("Images/testimage.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);

            // ２値化 大津式
            // 黒ベースの白のオブジェクトにしておく
            Mat binary = gray.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.BinaryInv);
            this.pictureBoxIpl1.ImageIpl = binary;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // ラベリング

            // 閾値指定
            int threshold = 128;

            Mat src = new Mat("Images/testimage.png", ImreadModes.Color); // カラー
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);

            // ここで反転させたけど、これは元画像の状態によるので注意してね
            // 黒背景で白物体にしたいだけだから
            Mat binary = gray.Threshold(threshold, 255, ThresholdTypes.BinaryInv);
            
            Mat labelView = src.EmptyClone();
            Mat rectView = binary.CvtColor(ColorConversionCodes.GRAY2BGR);

            ConnectedComponents cc = Cv2.ConnectedComponentsEx(binary);
            if (cc.LabelCount <= 1)
            {
                // 見つからないね
                // ここで抜ける処理入れてね

                Debug.WriteLine("All Label = " + cc.LabelCount.ToString());
            }

            // draw labels
            cc.RenderBlobs(labelView);

            int num = 0;

            foreach (var blob in cc.Blobs.Skip(1))
            {
                int area = blob.Area;

                //if ((250 < area) && (area < 10000)) // 一定量を制限する場合
                //{
                    Debug.WriteLine(area.ToString());
                    num++;
                    rectView.Rectangle(blob.Rect, Scalar.Red);
                //}
            }
            Debug.WriteLine("num = " + num.ToString());

            // filter maximum blob
            var maxBlob = cc.GetLargestBlob();
            var filtered = new Mat();
            cc.FilterByBlob(src, filtered, maxBlob);

            this.pictureBoxIpl1.ImageIpl = binary;
            this.pictureBoxIpl2.ImageIpl = labelView;
            this.pictureBoxIpl3.ImageIpl = rectView;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBoxIpl1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxIpl2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxIpl3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
