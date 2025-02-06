using LogIn200;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Login200Server
{
    class Login : WebSocketBehavior
    {
        private CredentialsM cred;
        private ServerConsole form;
        public Login(CredentialsM c, ServerConsole f)
        {
            cred = c;
            form = f;
        }

        public bool HandleCredentialsRecieved(string user, string password)
        {
            return cred.Validate(user, password);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            form.AddToListBox(e.Data);
            string[] tokens = e.Data.Split(':');
            string User = tokens[0];
            string Password = tokens[1];

            bool result = HandleCredentialsRecieved(User, Password);
            
            if (result)
            {
                //form.AddToListBox("        To send: VALID");
                Send("VALID");
            }
            else
                //form.AddToListBox("        To send: INVALID");
                Send("INVALID");
        }
    }
}
