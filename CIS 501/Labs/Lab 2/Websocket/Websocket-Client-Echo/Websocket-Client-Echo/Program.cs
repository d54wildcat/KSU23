using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Websocket_Client_Echo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a websocket connection to the websocket service in 
            // the local machine (127.0.0.1) at port 8001 
            using (var ws = new WebSocket("ws://127.0.0.1:8001/echo"))
            {
                // Set the client to print messages from the server
                ws.OnMessage += (sender, e) => Console.WriteLine(e.Data);

                // Connect to the server
                ws.Connect();

                Console.Write("Enter a message: ");
                string line = Console.ReadLine();

                // Send message to the server
                ws.Send(line);

                Console.ReadLine();
            }
        }
    }
}
