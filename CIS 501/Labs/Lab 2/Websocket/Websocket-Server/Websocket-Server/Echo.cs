using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Websocket_Server
{
    class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            // Retrieve message from client
            string msg = e.Data;
            
            // Send the message back
            Send("Echo: " + msg);
        }
    }
}
