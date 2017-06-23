﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace move_labels
{
    public partial class Form1 : Form
    {
        int vx = -15;
        int vy = -15;
        int vx6 = -15;
        int vy6 = -15;
        int vx7 = -15;
        int vy7 = -15;
        int iTime = 0;
        private static Random rand = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            iTime++;
            label5.Text = "" + iTime;

            // 2次元クラスPoint型の変数cposを宣言
            Point cpos;

            // cposに、マウスのフォーム座標を取り出す。
            //// MousePositionにマウス座標のスクリーン左上からのX、Yが入っている。
            //// PointToClient()を使うと、スクリーン座標を、フォーム座標に変換できる。
            cpos = PointToClient(MousePosition);

            // ラベルに座標を表示
            //// 変換したフォーム座標は、cpos.X、cpos.Yで取り出せる。            
            label2.Text = "" + cpos.X + "," + cpos.Y;
            label3.Text = "" + MousePosition.X + "," + MousePosition.Y;
            
            // 新しく作ったラベルをマウスカーソルの場所に移動
            // それができたら、マウスカーソルがそのラベルの中心を指すようにする
            // (オフセット、ピボット(Pivot)などの概念)
            label4.Left = cpos.X-label4.Width/2;
            label4.Top = cpos.Y-label4.Height/2;
            
            
            // label1.Left = label1.Left + vx;
            label1.Left += vx;
            label1.Top += vy;
            label6.Left += vx6;
            label6.Top += vy6;
            label7.Left += vx7;
            label7.Top += vy7;

            if (label1.Left < 0) {
                vx = Math.Abs(vx);
            }
            if (label1.Top < 0)
            {
                vy = Math.Abs(vy);
            }
            if (label1.Left > ClientSize.Width-label1.Width)
            {
                vx = -Math.Abs(vx);
            }
            if (label1.Top > ClientSize.Height-label1.Height)
            {
                vy = -Math.Abs(vy);
            }


            if (label6.Left < 0)
            {
                vx6 = Math.Abs(vx6);
            }
            if (label6.Top < 0)
            {
                vy6 = Math.Abs(vy6);
            }
            if (label6.Left > ClientSize.Width - label6.Width)
            {
                vx6 = -Math.Abs(vx6);
            }
            if (label6.Top > ClientSize.Height - label6.Height)
            {
                vy6 = -Math.Abs(vy6);
            }


            if (label7.Left < 0)
            {
                vx7 = Math.Abs(vx7);
            }
            if (label7.Top < 0)
            {
                vy7 = Math.Abs(vy7);
            }
            if (label7.Left > ClientSize.Width - label7.Width)
            {
                vx7 = -Math.Abs(vx7);
            }
            if (label7.Top > ClientSize.Height - label7.Height)
            {
                vy7 = -Math.Abs(vy7);
            }


            if (    (cpos.X > label1.Left)
                &&  (cpos.X < label1.Right)
                &&  (cpos.Y > label1.Top)
                &&  (cpos.Y < label1.Bottom)
                ) {
                label1.Visible = false;
            }


            if ((cpos.X > label6.Left)
                && (cpos.X < label6.Right)
                && (cpos.Y > label6.Top)
                && (cpos.Y < label6.Bottom)
                )
            {
                label6.Visible = false;
            }

            if ((cpos.X > label7.Left)
    && (cpos.X < label7.Right)
    && (cpos.Y > label7.Top)
    && (cpos.Y < label7.Bottom)
    )
            {
                label7.Visible = false;
            }

        }

        public Form1()
        {
            InitializeComponent();

            // vx,vyに乱数を求める
            vx = rand.Next(-10, 11);
            vy = rand.Next(-10, 11);
            vx6 = rand.Next(-10, 11);
            vy6 = rand.Next(-10, 11);
            vx7 = rand.Next(-10, 11);
            vy7 = rand.Next(-10, 11);
            // ラベルのLeftとTopに乱数を入れる
            label1.Left = rand.Next(ClientSize.Width - label1.Width);
            label1.Top = rand.Next(ClientSize.Height - label1.Height);
            label6.Left = rand.Next(ClientSize.Width - label6.Width);
            label6.Top = rand.Next(ClientSize.Height - label6.Height);
            label7.Left = rand.Next(ClientSize.Width - label7.Width);
            label7.Top = rand.Next(ClientSize.Height - label7.Height);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 0以上、intの範囲内の乱数
            Text = "" + rand.Next();
            // さいころの目の例(実用ではないが、知識として知っておくこと)
            Text += "," + ((rand.Next() % 6) + 1);

            // 0以上、指定の値「未満」の乱数
            // 以下は、0～5までの乱数
            Text += "/" + rand.Next(6);

            // 指定の値以上、指定の値「未満」の乱数
            // 以下は、1～6までの乱数
            Text += "/" + rand.Next(1, 7);

            // 0～1未満の乱数
            Text += "/" + rand.NextDouble();
            // NextDoubleを使って、1～6の乱数を算出するには？
            // NextDouble()の最小値=0
            // NextDouble()の最大値=0.99999999・・・
            Text += "/" + (int)(rand.NextDouble() * 6 + 1);

        }

    }
}
