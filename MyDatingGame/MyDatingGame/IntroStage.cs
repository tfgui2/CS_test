using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyDatingGame
{
    class IntroStage
    {
        Bitmap introImage = new Bitmap("intro.png");

        public void Process(Graphics g)
        {
            
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(introImage, 0, 0);
        }

        public void Mouse(Point p)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.ChangeStage(1);
        }

        public void Keyboard(char k)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.ChangeStage(1);
        }
    }
}
