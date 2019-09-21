using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDatingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        int currentStage = 0;
        IntroStage stage = new IntroStage();
        MyRoomStage room = new MyRoomStage();

        public void ChangeStage(int stage)
        {
            currentStage = stage;
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (currentStage)
            {
                case 0:
                    stage.Process(this.CreateGraphics());
                    break;

                case 1:
                    room.Process(this.CreateGraphics());
                    break;
            }

            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (currentStage)
            {
                case 0:
                    stage.Mouse(e.Location);
                    break;

                case 1:
                    room.Mouse(e.Location);
                    break;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (currentStage)
            {
                case 0:
                    stage.Keyboard(e.KeyChar);
                    break;

                case 1:
                    room.Keyboard(e.KeyChar);
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            switch (currentStage)
            {
                case 0:
                    stage.Draw(e.Graphics);
                    break;

                case 1:
                    room.Draw(e.Graphics);
                    break;
            }
        }
    }
}
