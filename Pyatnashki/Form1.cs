using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pyatnashki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Memo.randMem();
            InitializeComponent();
        }

        public bool checkstate()
        {
            int[] game = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            if (Enumerable.SequenceEqual(game,Memo.GetNumbersArr()))
                return true;
            else
                return false;
        }

        public void MyLine()
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Gold);
            
            SolidBrush grayB = new SolidBrush(Color.Gray);
            SolidBrush whiteB = new SolidBrush(Color.White);
            Graphics g = this.CreateGraphics();

            for(int i = 0;i < 4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    Rectangle q = new Rectangle(73 * j + 7, 73 * i + 25, 72, 72);
                    PointF drawpoint = new PointF(73 * j + 7 + 25, 73 * i + 25 + 25);

                    int mass = Convert.ToInt32((Math.Pow(4, 0) * (j % 4)) + (Math.Pow(4, 1) * (i % 4)));
                    string cheks = Convert.ToString(Memo.GetNumber(mass));
                    if (cheks == "0")
                    {
                        cheks = "";
                        g.FillRectangle(whiteB, q);
                    }
                    else
                    {
                        g.DrawRectangle(new Pen(Color.Black), q);
                        g.FillRectangle(grayB, q);
                        g.DrawString(cheks, drawFont, drawBrush, drawpoint);
                    }        
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MyLine();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Memo.randMem();
            MyLine();
            Memo.ResetTime();
            Memo.ResetTurns();
            label2.Text = "Время: " + Memo.GetTime();
            label1.Text = "Ходы: " + Memo.GetTurns();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Up)
            {
                if (!Memo.GetInvert())
                    Movement.Check_Up();
                else
                    Movement.Check_Down();
            }
            else if(e.KeyData==Keys.Down)
            {
                if (!Memo.GetInvert())
                    Movement.Check_Down();
                else
                    Movement.Check_Up();
            }
            else if(e.KeyData==Keys.Left)
            {
                if (!Memo.GetInvert())
                    Movement.Check_Left();
                else
                    Movement.Check_right();
            }
            else if(e.KeyData==Keys.Right)
            {
                if (!Memo.GetInvert())
                    Movement.Check_right();
                else
                    Movement.Check_Left();
            }

            label1.Text = "Ходы: " + Memo.GetTurns();

            MyLine();

            if (checkstate())
            {
                timer1.Stop();
                if (MessageBox.Show("Победа!!!\nСделано ходов: " + Memo.GetTurns() + "\nВремя: " + Memo.GetTime(),
                    "Victory", MessageBoxButtons.RetryCancel) == DialogResult.Retry) 
                {
                    Memo.randMem();
                    MyLine();
                    Memo.ResetTime();
                    Memo.ResetTurns();
                    label2.Text = "Время: " + Memo.GetTime();
                    label1.Text = "Ходы: " + Memo.GetTurns();
                    timer1.Start();
                }
                else
                    Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Memo.TimerTick();
            label2.Text = "Время: " + Memo.GetTime();
        }

        private void invertedMoveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (invertedMoveToolStripMenuItem.Checked)
            {
                Memo.InvertChage(true);
            }
            if (!invertedMoveToolStripMenuItem.Checked)
            {
                Memo.InvertChage(false);
            }
        }
    }
}
