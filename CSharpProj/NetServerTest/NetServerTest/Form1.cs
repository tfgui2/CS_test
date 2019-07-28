using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetServerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NetServer.NetServer svr = new NetServer.NetServer();

        private void Form1_Load(object sender, EventArgs e)
        {
            svr.Connect += new EventHandler<NetServer.NetServerEventArgs>(OnConnect);
            svr.Recieve += new EventHandler<NetServer.NetServerEventArgs>(OnRecieve);
            svr.Close += new EventHandler<NetServer.NetServerEventArgs>(OnClose);
        }

        private void OnConnect(object sender, NetServer.NetServerEventArgs e)
        {
            Console.WriteLine("Connect {0}", e.Key);
        }

        private void OnRecieve(object sender, NetServer.NetServerEventArgs e)
        {
            Console.WriteLine("Recieve {0}", e.Key);
            byte[] buf = Encoding.ASCII.GetBytes("Hello world");
            svr.Send(e.Key, buf, buf.Length);
        }

        private void OnClose(object sender, NetServer.NetServerEventArgs e)
        {
            Console.WriteLine("Close {0}", e.Key);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            svr.Start(4000);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            svr.Stop();
        }
    }
}
