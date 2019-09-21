using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImageViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap img = null;
        List<string> files = new List<string>();
        int index = 0;

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] drop = (string[])e.Data.GetData(DataFormats.FileDrop);
            string firstFile = drop[0];

            string dir = Path.GetDirectoryName(firstFile);
            string[] dirfiles = Directory.GetFiles(dir);

            bool find = false;
            files.Clear();
            index = 0;

            foreach(string s in dirfiles)
            {
                if (find)
                {
                    files.Add(s);
                    continue;
                }

                if (s == firstFile)
                {
                    find = true;
                    files.Add(s);
                }
            }

            img = new Bitmap(firstFile);

            Invalidate();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Gray);

            if (img != null)
            {
                int Height = this.ClientSize.Height;
                float rate = (float)Height/(float)img.Size.Height;
                Size newSize = new Size((int)(img.Size.Width * rate), Height);
                int left = (this.ClientSize.Width - newSize.Width) / 2;
                Rectangle r = new Rectangle(new Point(left, 0), newSize);
                
                g.DrawImage(img, r);
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (index < files.Count -1)
                {
                    index++;
                    img.Dispose();
                    img = new Bitmap(files[index]);
                    Invalidate();
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (index > 0)
                {
                    index--;
                    img.Dispose();
                    img = new Bitmap(files[index]);
                    Invalidate();
                }
            }
        }
    }
}
