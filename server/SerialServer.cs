using System;
using System.Net.Sockets;
using System.Threading;
using MPP_TeledonClientServer.services;
using networking;

namespace server
{
    public class SerialServer : ConcurrentServer
    {
        private ITeledonService server;
        private Worker worker;

        public SerialServer(string host, int port, ITeledonService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialServer...");
        }

        public override Thread createWorker(TcpClient client)
        {
            worker=new Worker(server,client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}