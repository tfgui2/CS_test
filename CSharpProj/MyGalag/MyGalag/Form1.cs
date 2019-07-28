using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGalag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ship.Move();
            
            foreach (MyBullet b in bulletList)
            {
                b.Move();
            }

            foreach (MyEnemy enemy in enemyList)
            {
                enemy.Move();
            }

            MyBullet hitBullet = null;
            bool hitBullett = false;

            foreach (MyBullet b in bulletList)
            {
                bool hit = false;
                MyEnemy hitted = null;

                foreach (MyEnemy enemy in enemyList)
                {
                    if (b.CheckInter(enemy))
                    {
                        hit = true;
                        hitted = enemy;
                        break;
                    }
                }

                if (hit)
                {
                    hitBullett = true;
                    enemyList.Remove(hitted);
                    hitBullet = b;
                }
            }
            if (hitBullett)
            {
                bulletList.Remove(hitBullet);
            }

            Invalidate();
        }

        MyShip ship;
        LinkedList<MyBullet> bulletList = new LinkedList<MyBullet>();
        LinkedList<MyEnemy> enemyList = new LinkedList<MyEnemy>();

        private void Form1_Load(object sender, EventArgs e)
        {
            ship = new MyShip();
            ship.pos.X = 100;
            ship.pos.Y = 300;

            MyEnemy enemy = new MyEnemy();
            enemy.pos.X = 200;
            enemy.pos.Y = 10;
            enemyList.AddLast(enemy);

            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ship.Draw(e.Graphics);

            foreach (MyBullet b in bulletList)
            {
                b.Draw(e.Graphics);
            }

            foreach (MyEnemy enemy in enemyList)
            {
                enemy.Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                ship.leftGo = true;
            }

            if (e.KeyCode == Keys.D)
            {
                ship.rightGo = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                ship.leftGo = false;
            }

            if (e.KeyCode == Keys.D)
            {
                ship.rightGo = false;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'j')
            {
                Fire(ship);
            }
        }

        private void Fire(MyShip ship)
        {
            MyBullet b = new MyBullet();
            b.pos = ship.pos;

            bulletList.AddLast(b);
        }
    }
}
