using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIsystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap topBar = new Bitmap("topbar.png");
        Bitmap mainMenuBg = new Bitmap("mainmenu.png");
        MyUiComponent ui = new MyUiComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1024, 768);

            ui.Add(new MyButton(new Point(50, 550)));
            ui.Add(new MyButton(new Point(300, 550)));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(topBar, new Rectangle(0, 0, 1024, 50));
            e.Graphics.DrawImage(mainMenuBg, new Rectangle(0, 768-300, 1024, 300));

            ui.Draw(e.Graphics);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ui.MouseMove(e);
            
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ui.MouseClick(e);
        }
    }
}
