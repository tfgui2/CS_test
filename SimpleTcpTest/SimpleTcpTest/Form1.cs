using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObooltNet;

namespace SimpleTcpTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NetConnection server;

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new NetConnection();
            server.OnConnect += Server_OnConnect;
            server.OnDataReceived += Server_OnDataReceived;
            server.OnDisconnect += Server_OnDisconnect;

            server.Start(55555);
        }

        private void Server_OnDisconnect(object sender, NetConnection connection)
        {
            textBox1.AppendText("Disconnect fom " + connection.RemoteEndPoint);
        }

        private void Server_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            textBox1.AppendText("Message from " + connection.RemoteEndPoint + " : " + Encoding.UTF8.GetString(e));
        }

        private void Server_OnConnect(object sender, NetConnection connection)
        {
            textBox1.AppendText("Connect from " + connection.RemoteEndPoint);
        }
    }
}
