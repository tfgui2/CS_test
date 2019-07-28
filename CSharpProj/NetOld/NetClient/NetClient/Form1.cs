using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace NetClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient tc;
        NetworkStream stream;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buf = Encoding.ASCII.GetBytes("Hello world");
            stream.Write(buf, 0, buf.Length);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stream.Close();
            tc.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] output = new byte[1024];
            int len = stream.Read(output, 0, output.Length);
            string msg = Encoding.ASCII.GetString(output, 0, len);
            Console.WriteLine(msg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                tc = new TcpClient("127.0.0.1", 4000);
                stream = tc.GetStream();
            }
            catch (SocketException se)
            {
                Console.Write(se.Data);
            }
        }
    }
}
