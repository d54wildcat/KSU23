using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Bid501
{
    public class CommunicationController
    {
        private WebSocket ws;
        GetLoginResultDelegate getLoginResult;
        UpdateProductListDel updateProductList;
        HandleBidResults handleBidResults;
        TimesUpResponseDelegate timesUp;

        public CommunicationController()
        {
            ws = ws= new WebSocket("ws://127.0.0.1:8001/login");
            ws.OnMessage += OnMessageReceived;

            ws.Connect();
        }

        private void OnMessageReceived(object sender, MessageEventArgs e)
        {
            string str = e.Data.ToString();
            string message = JsonSerializer.Deserialize<string>(str);

            if (message == "VALID" || message == "INVALID")
            {
                getLoginResult(message);
            }
            else if (message.Contains("init!"))
            {
                string processedMessage = message.Substring("init!".Length);
                updateProductList(processedMessage);


            }
            else if (message.Contains("add!"))
            {
                MessageBox.Show("Hello clients a product has been added!");
                string processedMessage = message.Substring("add!".Length + 1);
                updateProductList(processedMessage);
            }
            else if (message.Contains("BIDGOOD") || message.Contains("BIDBAD"))
            {
                handleBidResults(message);
            }
            else if (message.Contains("time"))
            {
                timesUp(message);
            }
            // ... other conditions for different message types
        }


        public void Send(string message)
        {
            string send = JsonSerializer.Serialize(message);
            ws.Send(send);
        }

        public void Close()
        {
            ws.Close();
        }

        public void SetTimesUpResponseDelegate(TimesUpResponseDelegate d)
        {
            timesUp += d;
        }

        public void SetGetLoginDel(GetLoginResultDelegate d)
        {
            getLoginResult = d;
        }

        public void SetUpdateProductList(UpdateProductListDel d)
        {
            updateProductList = d;
        }

        public void SetHandleBidResults(HandleBidResults d)
        {
            handleBidResults = d;
        }

    }
}
