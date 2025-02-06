using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Websocket_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start a websocket server at port 8001
            var wss = new WebSocketServer(8001);

            // Add the Echo websocket service
            wss.AddWebSocketService<Echo>("/echo");

            // Add the Chat websocket service
            wss.AddWebSocketService<Chat>("/chat");

            // Start the server
            wss.Start();

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            // Stop the server
            wss.Stop();
        }
    }
}
