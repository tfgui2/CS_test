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

namespace FileMngInFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void LogAdd(string str)
        {
            listBox3.Items.Add(str);
            listBox3.SelectedIndex = listBox3.Items.Count - 1;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            try
            {
                foreach (string f in files)
                {
                    if (File.GetAttributes(f).HasFlag(FileAttributes.Directory) == false) continue;
                    listBox1.Items.Add(f);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LogAdd("Directory " + listBox1.Items.Count.ToString());

            GetChild();

            LogAdd("Files " + listBox2.Items.Count.ToString());
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void GetChild()
        {
            foreach (string dir in listBox1.Items)
            {
                DirectoryInfo di = new DirectoryInfo(dir);

                foreach (FileInfo f in di.GetFiles())
                {
                    if (f.Length > 1024 * 1024 * 60)
                    {
                        listBox2.Items.Add(f);
                    }
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (FileInfo fi in listBox2.SelectedItems)
            {
                string dest = fi.Directory.Parent.FullName + "\\" + fi.Name;
                LogAdd("Move " + dest);
                try
                {
                    fi.MoveTo(dest);
                    //listBox2.Items.Remove(fi);
                }
                catch (Exception ex)
                {
                    LogAdd(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            LogAdd("Clear!");
        }
    }
}
