using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UIsystem
{
    class MyButton : MyUiComponent
    {
        public MyButton(Point p)
        {
            uiRect.Size = button0.Size;
            uiRect.Location = p;
        }

        Bitmap button0 = new Bitmap("button0.png");
        Bitmap button1 = new Bitmap("button1.png");
        bool buttonOn = false;

        public override void Draw(Graphics g)
        {
            if (buttonOn == false)
            {
                g.DrawImage(button0, uiRect);
            }
            else
            {
                g.DrawImage(button1, uiRect);
            }
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            buttonOn = true;
        }

        public override void OffMouseMove(MouseEventArgs e)
        {
            buttonOn = false;
        }

        public override void OnMouseClick(MouseEventArgs e)
        {
            string msg = "buttonClick" + uiId.ToString();
            MessageBox.Show(msg);
        }
    }
}
