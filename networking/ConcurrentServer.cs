using System.Net.Sockets;
using System.Threading;

namespace networking
{
    public abstract class ConcurrentServer:AbstractServer
    {
        protected ConcurrentServer(string host, int port) : base(host, port)
        {
        }

        public override void processRequest(TcpClient client)
        {
            Thread thread = createWorker(client);
            thread.Start();
        }

        public abstract Thread createWorker(TcpClient client);
    }
}