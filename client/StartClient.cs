using System;
using System.Windows.Forms;
using MPP_TeledonClientServer.services;
using networking;

namespace MPP_TeledonClientServer
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ITeledonService server=new ProxyService("127.0.0.1",55555);
            Controller controller=new Controller(server);
            Application.Run(new FormLogin(controller));
            
        }
    }
}