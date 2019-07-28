using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point rocketPoint = new Point(0, 0);
        private void updatePoint()
        {
            if (rocketPoint.X < 100) rocketPoint.X += 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            updatePoint();

            Bitmap rocket = new Bitmap("Rocket.png");
            Bitmap boss = new Bitmap("UFOBoss.png");
            e.Graphics.DrawImage(rocket, rocketPoint);
            e.Graphics.DrawImage(boss, 0, 0);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
