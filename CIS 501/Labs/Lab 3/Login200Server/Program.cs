using LogIn200;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Login200Server
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ServerConsole form = new ServerConsole();
            CredentialsM cred = new CredentialsM();
            WebSocketServer wss = new WebSocketServer(8001);
            wss.AddWebSocketService<Login>("/login", () => new Login(cred, form));
            wss.Start();
            Application.Run(form);
            wss.Stop();
        }
    }
}