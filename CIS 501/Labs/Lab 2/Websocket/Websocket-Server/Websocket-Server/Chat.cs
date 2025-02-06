using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Websocket_Server
{
    // Task I:  Modify this websocket behavior so that it remembers all messages.
    //          Whenever there is a new client connected, send all stored messages to the client
    //          so the client knows the history of the conversation.
    // Task II: Add timestamp (just the hour and minute) to the messages
    //          (see http://stackoverflow.com/questions/21219797/how-to-get-correct-timestamp-in-c-sharp
    //           for an example on how to get a timestamp).
    class Chat : WebSocketBehavior
    {
        public static int msgHis = 0;
        public static List<string> messageHistory = new List<string>();

        protected override void OnOpen()
        {
            // Send the message history to the new client
            foreach (var message in messageHistory)
            {
                Send(message);
            }
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            msgHis++;

            // Retrieve message from the client
            string msg = e.Data;

            string mem = "(" + msgHis + ")" + msg;

            // Broadcast the message to all clients
            Sessions.Broadcast(mem);

            // Store the message in the history
            messageHistory.Add(mem);
        }
    }
}
