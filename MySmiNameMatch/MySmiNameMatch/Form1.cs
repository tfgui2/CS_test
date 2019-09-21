using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySmiNameMatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;
                listBox1.Items.AddRange(files);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;
                listBox2.Items.AddRange(files);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i =0; i < listBox1.Items.Count; i++)
            {
                
                string targetRef = listBox1.Items[i].ToString();
                string tempname = Path.GetFileNameWithoutExtension(targetRef) + ".smi";

                string oldname = listBox2.Items[i].ToString();
                string newname = Path.GetDirectoryName(oldname) + "\\" + tempname;

                File.Copy(oldname, newname);
            }

            MessageBox.Show("Done.");
        }
    }
}
