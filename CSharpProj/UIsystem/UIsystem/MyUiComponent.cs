using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UIsystem
{
    class MyUiComponent
    {
        public int uiId = 0;

        List<MyUiComponent> subui = new List<MyUiComponent>();
        public void Add(MyUiComponent sub)
        {
            sub.uiId = subui.Count;
            subui.Add(sub);
        }

        public Rectangle uiRect = new Rectangle(0, 0, 0, 0);

        public virtual void Draw(Graphics g)
        {
            foreach(MyUiComponent ui in subui)
            {
                ui.Draw(g);
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            for (int i = 0; i < subui.Count; i++)
            {
                subui[i].MouseMove(e);
            }

            if (uiRect.Contains(e.Location))
            {
                OnMouseMove(e);
            }
            else
            {
                OffMouseMove(e);
            }
        }

        public virtual void OnMouseMove(MouseEventArgs e)
        {

        }

        public virtual void OffMouseMove(MouseEventArgs e)
        {
        }

        public bool MouseClick(MouseEventArgs e)
        {
            for (int i = 0; i < subui.Count; i++)
            {
                if (subui[i].MouseClick(e))
                {
                    return true;
                }
            }

            if (uiRect.Contains(e.Location))
            {
                OnMouseClick(e);
                return true;
            }

            return false;
        }

        public virtual void OnMouseClick(MouseEventArgs e)
        {
        }
    }
}
