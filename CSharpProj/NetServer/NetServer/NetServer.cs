using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace NetServer
{
    public class NetServerEventArgs : EventArgs
    {
        public NetServerEventArgs(int key)
        {
            this.Key = key;
        }

        public int Key { get; set; }
    }

    public class NetServer
    {
        TcpListener listener;
        Thread worker;

        Dictionary<int, TcpClient> clientDic = new Dictionary<int, TcpClient>();
        Dictionary<int, NetworkStream> streamDic = new Dictionary<int, NetworkStream>();

        private volatile bool bActive = false;
        private volatile int uniqueId = 1;
        private int port = 0;

        public event EventHandler<NetServerEventArgs> Connect;
        public event EventHandler<NetServerEventArgs> Recieve;
        public event EventHandler<NetServerEventArgs> Close;

        public void Start(int port)
        {
            if (bActive)
            {
                return;
            }

            bActive = true;
            this.port = port;

            worker = new Thread(DoWork);
            worker.Start();
        }

        public void Stop()
        {
            bActive = false;

            if (worker != null)
            {
                worker.Join();
            }
        }

        public void DoWork()
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            while (bActive)
            {
                // accept check
                if (listener.Pending())
                {
                    TcpClient tc = listener.AcceptTcpClient();
                    NetworkStream ns = tc.GetStream();

                    clientDic.Add(uniqueId, tc);
                    streamDic.Add(uniqueId, ns);

                    if (this.Connect != null)
                    {
                        Connect(this, new NetServerEventArgs(uniqueId));
                    }

                    uniqueId++;
                }

                // recieve check
                foreach (KeyValuePair<int, NetworkStream> ns in streamDic)
                {
                    try
                    {
                        if (ns.Value.CanRead)
                        {
                            byte[] buf = new byte[1024];
                            int len = ns.Value.Read(buf, 0, buf.Length);
                            if (len > 0 && this.Recieve != null)
                            {
                                Recieve(this, new NetServerEventArgs(ns.Key));
                            }
                        }
                        else
                        {
                            if (this.Close != null)
                            {
                                Close(this, new NetServerEventArgs(ns.Key));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (this.Close != null)
                        {
                            Close(this, new NetServerEventArgs(ns.Key));
                        }
                    }
                }

                // Sleep
                Thread.Sleep(1);
            }

            listener.Stop();
        }

        public void Send(int key, byte[] buf, int len)
        {
            streamDic[key].Write(buf, 0, len);
        }
    }
}
