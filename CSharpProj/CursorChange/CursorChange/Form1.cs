using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyCursor c1 = new MyCursor();

        private void Form1_Load(object sender, EventArgs e)
        {
            c1.Add("cursor2.png");
            c1.Add("cursor1.png");
            c1.start(this);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = new Rectangle(200, 200, 200, 200);

            if (rect.Contains(e.Location))
            {
                c1.Set(0);
            }
            else
            {
                c1.Set(1);
            }
        }
    }
}
