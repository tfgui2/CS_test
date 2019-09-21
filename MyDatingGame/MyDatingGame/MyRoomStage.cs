using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyDatingGame
{
    class MyRoomStage
    {
        Bitmap back = new Bitmap("back.png");
        Bitmap bono = new Bitmap("char.png");
        List<Rectangle> objects = new List<Rectangle>();

        bool showBono = false;

        public MyRoomStage()
        {
            Rectangle r = new Rectangle(0, 0, 100, 100);
            objects.Add(r);
        }

        public void Process(Graphics g)
        {
            
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(back, 0, 0);

            foreach (Rectangle r in objects)
            {
                g.DrawRectangle(Pens.Red, r);
            }

            if (showBono)
            {
                g.DrawImage(bono, 0, 0);
            }
        }

        public void Mouse(Point p)
        {
            showBono = true;
        }

        public void Keyboard(char k)
        {

        }

    }
}
