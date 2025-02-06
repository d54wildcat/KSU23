using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501
{
    public class MainController
    {
        SendToServerDelegate sendToServer;
        private string loginReturn = "";
        BidFormUpdateProducts updateBidFormProducts;
        HandleLoginResultsDelegate loginResults;
        BidUpdatesFormDelegate bidUpdateDel;
        ClientProxy clientProxy;
        List<Product> products = new List<Product>();
        private bool isValid = false;
        private string bidName;
        private string userName;
        private decimal bidPrice;
        private bool initialize=true;
        public MainController(SendToServerDelegate s, ClientProxy proxy)
        {
            sendToServer = s;
            clientProxy = proxy;
        }

        public void Login(string username, string password)
        {
            string credentials = $"{username}:{password}";
            userName = username;
            
            sendToServer(credentials);
        }

        public void HandleLoginResult(string s)
        {
            loginReturn = s;
            CanLogin();
            loginResults(isValid);
        }

        public void CanLogin()
        {
            if (loginReturn.Equals("VALID"))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
        }

        public string returnUser()
        {
            return userName;
        }

        public void GetProductList()
        {
            if (initialize)
            {
                sendToServer("init");

                initialize = false;
            }

        }

        public void LocalValidationOfBid(Product p, double price)
        {
            if (p.Status != ProductStatus.open)
            {
                MessageBox.Show("That item is not open for bidding!");
            }

            else if (p.CurrentBid > (decimal)price) MessageBox.Show("Your bid is not enough:(");
            else
            {
                bidName = p.Name;
                bidPrice = Convert.ToDecimal(price);

                sendToServer("placeBid!"+p.Name +"!" +price.ToString());

            }
        }

        public void ParseProductList(string productList)
        {
            clientProxy.productList.Clear();
            // Split the string into individual product strings
            var productStrings = productList.Split(new[] { '!' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var productString in productStrings)
            {
                // Split each product string into its properties
                var properties = productString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (properties.Length == 7)
                {
                    string title = properties[0].Trim();
                    decimal price = decimal.Parse(properties[1].Trim());
                    int bidCount = int.Parse(properties[2].Trim());
                    int day = int.Parse(properties[3].Trim());
                    int hour = int.Parse(properties[4].Trim());
                    int second = int.Parse(properties[5].Trim());
                    ProductStatus status;
                    switch (properties[6])
                    {
                        case "open":
                            status = ProductStatus.open;
                            break;
                        case "closed":
                            status = ProductStatus.closed;
                            break;
                        case "sold":
                            status = ProductStatus.sold;
                            break;
                        default:
                            status = ProductStatus.closed;
                            break;
                    }
                    clientProxy.productList.Add(new Product(title, price, bidCount, day, hour, second, status));
                }
            }

            //clientProxy.productList = products;
            updateBidFormProducts(clientProxy.productList);
        }

        public void HandleBidResult(string result)
        {
            if (result.Contains("BIDGOOD"))
            {
                string[] details = result.Split('!');

                foreach (Product p in clientProxy.productList)
                {
                    if (p.Name.Equals(details[1]))
                    {
                        p.CurrentBid = Convert.ToDecimal(details[2]);
                        p.BidCount++;
                    }
                }
                
                updateBidFormProducts(clientProxy.productList);
            }
            else
            {

                string[] details = result.Split('!');

                foreach (Product p in clientProxy.productList)
                {
                    if (p.Name.Equals(details[1]))
                    {
                        p.CurrentBid = Convert.ToDecimal(details[2]);
                    }
                }
                MessageBox.Show("too poor:( if u broke j say so");

            }
            updateBidFormProducts(clientProxy.productList);
        }

        public void HandleTimesUpResponse(string response)
        {
            string[] details = response.Split('!');
            foreach (var product in clientProxy.productList)
            {
                if (details[1].Equals(product.Name))
                {
                    product.Status = ProductStatus.sold;
                    if (bidPrice == product.CurrentBid) { MessageBox.Show("You " + userName + " won the " + product.Name); }
                    else { MessageBox.Show("You " + userName +" lost the " + product.Name); }
                }
            }
            
            updateBidFormProducts(clientProxy.productList);
        }

        public void SendTimeProduct(string s)
        {
            sendToServer(s);
        }

        public void SetSendToDelegate(SendToServerDelegate d)
        {
            sendToServer = d;
        }

        public void SetUpdateProductList(BidFormUpdateProducts d)
        {
            updateBidFormProducts = d;
        }

        public void SetBidFormUpdateDel(BidFormUpdateProducts d)
        {
            updateBidFormProducts += d;
        }

        public void SetHandleLoginResultsDel(HandleLoginResultsDelegate d)
        {
            loginResults += d;
        }
        public void SetBidUpdatesToForm(BidUpdatesFormDelegate d)
        {
            bidUpdateDel = d;
        }


    }
}
