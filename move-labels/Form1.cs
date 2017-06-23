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
        // const = 定数。プログラム実行時に値が変わらないもの
        const int LABEL_COUNT = 50;

        // 0～2までで3つの値をもてる
        int[] vx = new int[LABEL_COUNT];
        int[] vy = new int[LABEL_COUNT];
        int iTime = 0;
        Label[] labels = new Label[LABEL_COUNT];

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


            for (int idx = 0; idx < LABEL_COUNT; idx++)
            {
                labels[idx].Left += vx[idx];
                labels[idx].Top += vy[idx];

                if (labels[idx].Left < 0)
                {
                    vx[idx] = Math.Abs(vx[idx]);
                }
                if (labels[idx].Top < 0)
                {
                    vy[idx] = Math.Abs(vy[idx]);
                }
                if (labels[idx].Left > ClientSize.Width - labels[idx].Width)
                {
                    vx[idx] = -Math.Abs(vx[idx]);
                }
                if (labels[idx].Top > ClientSize.Height - labels[idx].Height)
                {
                    vy[idx] = -Math.Abs(vy[idx]);
                }

                if ((cpos.X > labels[idx].Left)
    && (cpos.X < labels[idx].Right)
    && (cpos.Y > labels[idx].Top)
    && (cpos.Y < labels[idx].Bottom)
    )
                {
                    labels[idx].Visible = false;
                }

            }

        }

        public Form1()
        {
            InitializeComponent();

            // vx,vyに乱数を求める
            // 冗長（じょうちょう）だったコードをまとめることができた
            // 冗長＝同じものが繰り返される様
            for (int idx = 0; idx < LABEL_COUNT; idx++)
            {
                vx[idx] = rand.Next(-10, 11);
                vy[idx] = rand.Next(-10, 11);

                // ラベルを生成
                labels[idx] = new Label();
                labels[idx].AutoSize = true;  // 幅と高さを自動制御
                labels[idx].Text = "◆";
                labels[idx].Font = label1.Font;
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
