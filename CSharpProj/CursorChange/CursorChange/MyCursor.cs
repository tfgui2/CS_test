using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CursorChange
{
    class MyCursor
    {
        List<Cursor> cursors = new List<Cursor>();
        int current = -1;
        Control parent = null;

        public void Add(string path)
        {
            Bitmap img = new Bitmap(path);
            Icon ico = Icon.FromHandle(img.GetHicon());
            cursors.Add(new Cursor(ico.Handle));
        }

        public void start(Control c)
        {
            parent = c;
            parent.Cursor = cursors[0];
        }

        public void Set(int id)
        {
            if (current == id)
            {
                return;
            }

            current = id;

            if (parent != null)
            {
                parent.Cursor = cursors[id];
            }
        }
    }
}
