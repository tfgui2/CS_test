using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAlka2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyPad pad;
        MyBall ball;
        MyBlock[,] blocks;
        int stageWidth = 500;
        int stageHeight = 500;

        private void Form1_Load(object sender, EventArgs e)
        {
            pad = new MyPad();
            ball = new MyBall();
            blocks = new MyBlock[5, 2];
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    blocks[i, j] = new MyBlock();
                }
            }

            this.ResetPosition();

            timer1.Start();
        }

        private void ResetPosition()
        {
            Graphics g = this.CreateGraphics();

            pad.pos.X = 100;
            pad.pos.Y = 300;

            ball.pos.X = 100;
            ball.pos.Y = 250;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    blocks[i, j].pos.X = i * blocks[i, j].size.Width;
                    blocks[i, j].pos.Y = j * blocks[i, j].size.Height;
                }
            }
        }

        private void CheckBlocks(MyBall ball)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    blocks[i, j].Check(ball);
                }
            }
        }

        private void CheckLeftWall(MyBall ball)
        {
            if (ball.pos.X <= 0)
            {
                ball.velo.X = 2;
            }
        }

        private void CheckRightWall(MyBall ball)
        {
            if (ball.pos.X >= stageWidth)
            {
                ball.velo.X = -2;
            }
        }

        private void CheckTopWall(MyBall ball)
        {
            if (ball.pos.Y <= 0)
            {
                ball.velo.Y = 2;
            }
        }

        private void CheckPad(MyPad pad, MyBall ball)
        {
            if (pad.CheckInter(ball))
            {
                ball.velo.Y = -2;
            }
        }
        bool gameEnd = false;

        private void CheckBottom(MyBall ball)
        {
            if (ball.pos.Y > pad.pos.Y + 10)
            {
                gameEnd = true;

                MessageBox.Show("game end");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameEnd == false)
            {
                ball.Move();
                pad.Move();

                CheckBlocks(ball);
                CheckTopWall(ball);
                CheckLeftWall(ball);
                CheckRightWall(ball);
                CheckPad(pad, ball);
                CheckBottom(ball);
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(0, 0, stageWidth, stageHeight));
            pad.Draw(e.Graphics);
            ball.Draw(e.Graphics);
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    blocks[i, j].Draw(e.Graphics);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pad.LeftGo();
            }

            if (e.KeyCode == Keys.Right)
            {
                pad.RightGo();
            }

            if (e.KeyCode == Keys.Space)
            {
                ball.Go();
            }

            if (e.KeyCode == Keys.R)
            {
                gameEnd = false;
                ball.pos.X = pad.pos.X;
                ball.pos.Y = pad.pos.Y;
                ball.velo.X = 0;
                ball.velo.Y = 0;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pad.LeftStop();
            }

            if (e.KeyCode == Keys.Right)
            {
                pad.RightStop();
            }
        }
    }
}
