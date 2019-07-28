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

namespace FilenameMng
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LogAdd(string str)
        {
            listBox1.Items.Add(str);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldstr = textBox2.Text;

            foreach (FileInfo fi in listBox2.Items)
            {
                string orignalUpper = fi.Name.ToLower();
                int index = orignalUpper.IndexOf(oldstr.ToLower());
                string end = fi.Name.Substring(index);

                string newName = end;
                string newPath = fi.DirectoryName + "\\" + newName;
                listBox3.Items.Add(newPath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dir = textBox1.Text;
            if (Directory.Exists(dir) == false)
            {
                LogAdd("Invalid dir " + dir);
                return;
            }

            DirectoryInfo di = new DirectoryInfo(dir);

            string patternStr = textBox2.Text + "*";
            if (checkBox1.Checked == false)
            {
                patternStr = "*" + patternStr;
            }

            try
            {
                FileInfo[] filist = di.GetFiles(patternStr);
                foreach (FileInfo fi in filist)
                {
                    listBox2.Items.Add(fi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count1 = listBox2.Items.Count;
            int count2 = listBox3.Items.Count;
            if (count1 != count2)
            {
                MessageBox.Show("Error dif count");
                return;
            }

            try
            {
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    FileInfo fi = (FileInfo)listBox2.Items[i];
                    string newName = (string)listBox3.Items[i];

                    fi.MoveTo(newName);
                    LogAdd(newName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Done");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                ReplaceRegExp(textBox2.Text, textBox3.Text);
            }
            else if (checkBox2.Checked)
            {
                ReplaceString(textBox2.Text, textBox3.Text);
            }
            else
            {
                ChangeString(textBox2.Text, textBox3.Text);
            }
        }

        private void ChangeString(string oldstr, string newstr)
        {
            foreach (FileInfo fi in listBox2.Items)
            {
                string orignal = fi.Name.ToLower();
                int index = orignal.IndexOf(oldstr.ToLower());
                int length = oldstr.Length;

                string front = fi.Name.Substring(0, index);
                string end = fi.Name.Substring(index + length);

                string newName = front + newstr + end;
                string newPath = fi.DirectoryName + "\\" + newName;
                listBox3.Items.Add(newPath);
            }
        }

        private void ReplaceString(string oldstr, string newstr)
        {
            foreach (FileInfo fi in listBox2.Items)
            {
                string original = fi.Name.ToLower();
                string newName = original.Replace(oldstr, newstr);
                string newPath = fi.DirectoryName + "\\" + newName;
                listBox3.Items.Add(newPath);
            }
        }

        private void ReplaceRegExp(string oldstr, string newstr)
        {
            string temp = oldstr.Replace('?', '.').Replace("(", "\\(").Replace(")", "\\)");

            foreach (FileInfo fi in listBox2.Items)
            {
                string original = fi.Name.ToLower();
                
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(original, temp);
                int index = match.Index;
                int length = match.Length;

                string front = fi.Name.Substring(0, index);
                string end = fi.Name.Substring(index + length);

                string newName = front + newstr + end;
                string newPath = fi.DirectoryName + "\\" + newName;
                listBox3.Items.Add(newPath);
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            foreach (FileInfo fi in listBox2.Items)
            {
                string newName = fi.Name.ToLower();
                string newPath = fi.DirectoryName + "\\" + newName;
                listBox3.Items.Add(newPath);
            }
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            try
            {
                foreach (string f in files)
                {
                    if (File.GetAttributes(f).HasFlag(FileAttributes.Directory))
                        continue;

                    FileInfo fi = new FileInfo(f);
                    listBox2.Items.Add(fi);

                    if (textBox1.Text.Length == 0)
                    {
                        textBox1.Text = fi.DirectoryName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
