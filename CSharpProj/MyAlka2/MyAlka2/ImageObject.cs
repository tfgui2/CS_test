using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyAlka2
{
    class ImageObject
    {
        Bitmap img;
        public Point pos = new Point(0, 0);
        public Size size = new Size(0, 0);

        public void Load(string filename)
        {
            img = new Bitmap(filename);
            size = img.Size;
        }

        public Rectangle Bound()
        {
            return new Rectangle(pos, size);
        }

        public bool CheckInter(ImageObject obj)
        {
            if (this.Bound().IntersectsWith(obj.Bound()))
            {
                return true;
            }

            return false;
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawImage(img, this.Bound());
        }
    }
}
