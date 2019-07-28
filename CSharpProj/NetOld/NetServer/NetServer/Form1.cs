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
using System.Net;
using System.Threading;


namespace NetServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<TcpClient> clientList = new List<TcpClient>();

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 4000);
            listener.Start();

            while (true)
            {
                if (listener.Pending())
                {
                    TcpClient tc = listener.AcceptTcpClient();
                    clientList.Add(tc);
                }
                else
                {
                    Console.Write("no con\n");
                }
                Thread.Sleep(100);

                PacketProcess();
            }

        }

        private void PacketProcess()
        {
            byte[] buf = new byte[1024];

            foreach (TcpClient tc in clientList)
            {
                NetworkStream stream = tc.GetStream();
                if (stream.CanRead)
                {
                    int len = stream.Read(buf, 0, buf.Length);
                    stream.Write(buf, 0, len);
                }
            }
        }
    }
}
