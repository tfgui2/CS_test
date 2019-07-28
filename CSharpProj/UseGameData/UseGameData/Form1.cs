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

namespace UseGameData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (LoadInitData()==false)
            {
                Application.Exit();
            }
        }

        private bool LoadInitData()
        {
            try
            {
                StreamReader read = File.OpenText("init.txt");
                string s = read.ReadLine();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
