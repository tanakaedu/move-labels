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
        int iTime = 0;

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

            if (    (cpos.X > label1.Left)
                &&  (cpos.X < label1.Right)
                &&  (cpos.Y > label1.Top)
                &&  (cpos.Y < label1.Bottom)
                ) {
                //label1.Visible = false;
                    
                //label1.Text = "◎";
                //vx = 0;
                //vy = 0;

                    timer1.Enabled = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

    }
}
