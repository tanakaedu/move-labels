using System;
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
        // 0～2までで3つの値をもてる
        int[] vx = new int[3];
        int[] vy = new int[3];
        int iTime = 0;
        Label[] labels = new Label[3];

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
            label4.Left = cpos.X - label4.Width / 2;
            label4.Top = cpos.Y - label4.Height / 2;


            // label1.Left = label1.Left + vx;
            label1.Left += vx[0];
            label1.Top += vy[0];
            label6.Left += vx[1];
            label6.Top += vy[1];
            label7.Left += vx[2];
            label7.Top += vy[2];

            if (label1.Left < 0)
            {
                vx[0] = Math.Abs(vx[0]);
            }
            if (label1.Top < 0)
            {
                vy[0] = Math.Abs(vy[0]);
            }
            if (label1.Left > ClientSize.Width - label1.Width)
            {
                vx[0] = -Math.Abs(vx[0]);
            }
            if (label1.Top > ClientSize.Height - label1.Height)
            {
                vy[0] = -Math.Abs(vy[0]);
            }


            if (label6.Left < 0)
            {
                vx[1] = Math.Abs(vx[1]);
            }
            if (label6.Top < 0)
            {
                vy[1] = Math.Abs(vy[1]);
            }
            if (label6.Left > ClientSize.Width - label6.Width)
            {
                vx[1] = -Math.Abs(vx[1]);
            }
            if (label6.Top > ClientSize.Height - label6.Height)
            {
                vy[1] = -Math.Abs(vy[1]);
            }


            if (label7.Left < 0)
            {
                vx[2] = Math.Abs(vx[2]);
            }
            if (label7.Top < 0)
            {
                vy[2] = Math.Abs(vy[2]);
            }
            if (label7.Left > ClientSize.Width - label7.Width)
            {
                vx[2] = -Math.Abs(vx[2]);
            }
            if (label7.Top > ClientSize.Height - label7.Height)
            {
                vy[2] = -Math.Abs(vy[2]);
            }


            if ((cpos.X > label1.Left)
                && (cpos.X < label1.Right)
                && (cpos.Y > label1.Top)
                && (cpos.Y < label1.Bottom)
                )
            {
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
            // 冗長（じょうちょう）だったコードをまとめることができた
            // 冗長＝同じものが繰り返される様
            for (int idx = 0; idx < 3; idx++)
            {
                vx[idx] = rand.Next(-10, 11);
                vy[idx] = rand.Next(-10, 11);

                // ラベルを生成
                labels[idx] = new Label();
                labels[idx].AutoSize = true;  // 幅と高さを自動制御
                labels[idx].Text = "◆";
                // フォームに配置
                Controls.Add(labels[idx]);

                labels[idx].Left = rand.Next(ClientSize.Width - labels[idx].Width);
                labels[idx].Top = rand.Next(ClientSize.Height - labels[idx].Height);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            for (int idx = 0; idx < 3; idx++)
            {
                MessageBox.Show("" + idx);
            }
        }

    }
}
