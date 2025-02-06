using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501Server
{
    class CommunicationController : WebSocketBehavior
    {
        private CredentialValidator cred = new CredentialValidator("../../../credentials.txt");

        GetAllProductsDelegate getAllProducts;
        SendToControllerDelegate sendToController;

        public CommunicationController(CredentialValidator c, GetAllProductsDelegate d)
        {
            cred = c;
            getAllProducts = d;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            string str = e.Data.ToString();
            string message = JsonSerializer.Deserialize<string>(str);
            if (message.Contains("init"))
            {
                List<Product> products = getAllProducts();
                StringBuilder productString = new StringBuilder();
                productString.Append("init!");
                foreach(var product in products)
                {
                    productString.Append(product.ToString() + "!");
                }
                string m = productString.ToString();
                string serializedM = JsonSerializer.Serialize(m);


                Send(serializedM);
            }
            else if (message.Contains("placeBid!"))
            {
                sendToController(message);
                MessageBox.Show("Bid Received from client");
            }
            else if (message.Contains("time!"))
            {
                sendToController(message);
            }
            else 
            {
                string[] tokens = message.Split(':');
                string username = tokens[0];
                string password = tokens[1];
                if (username == "admin") 
                {
                    String serialized = JsonSerializer.Serialize("INVALID");
                    Send(serialized); 
                }
                else
                {
                    bool result = cred.ValidateCredentials(username, password);
                    if (result)
                    {
                        String serialized = JsonSerializer.Serialize("VALID");
                        Send(serialized);
                    }
                    else
                    {
                        String serialized = JsonSerializer.Serialize("INVALID");
                        Send(serialized);
                    }
                }
                
            }
        }

        public void SendToClient(string m)
        {
            String serialized = JsonSerializer.Serialize(m);
            Send(serialized);
        }

        public void SetGetAllProductsDel(GetAllProductsDelegate d)
        {
            getAllProducts += d;
        }

        public void SetSendToController(SendToControllerDelegate d)
        {
            sendToController += d;
        }
    }
}
