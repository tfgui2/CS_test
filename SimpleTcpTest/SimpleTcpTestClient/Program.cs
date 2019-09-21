using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObooltNet;

namespace SimpleTcpTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            NetConnection client = new NetConnection();
            client.OnConnect += Client_OnConnect;
            client.OnDataReceived += Client_OnDataReceived;

            client.Connect("localhost", 55555);

            while (true)
            {
                Console.Write(">");
                client.Send(Encoding.UTF8.GetBytes(Console.ReadLine()));
            }

        }

        private static void Client_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            Console.WriteLine("Message from server " + Encoding.UTF8.GetString(e));
        }

        private static void Client_OnConnect(object sender, NetConnection connection)
        {
            Console.WriteLine("Connect to " + connection.RemoteEndPoint);
        }
    }
}
