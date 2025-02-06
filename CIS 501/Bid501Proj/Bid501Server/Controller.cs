using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bid501Server
{
    public class Controller
    {
        private List<Product> products = new List<Product>();
        private decimal currentHighestBid;
        public ActualProductList productListReal;
        SendToClientDelegate sendToClient;
        UpdateServerListDelegate timesUp;

        public Controller(ActualProductList productlist)
        {
            products = new List<Product>();
            productListReal = productlist;
            LoadProductsFromFile("../../../products.txt");
        }

        public void HandleOnMessage(string message)
        {
            if (message.Contains("placeBid"))
            {
                DealWithBid(message);
            }
            else if (message.Contains("time"))
            {
                ReceiveTime(message);
            }

        }

        private void LoadProductsFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 7)
                    {
                        string title = parts[0].Trim();
                        decimal price = decimal.Parse(parts[1].Trim());
                        int bidCount = int.Parse(parts[2].Trim());
                        int day = int.Parse(parts[3].Trim());
                        int hour = int.Parse(parts[4].Trim());
                        int second = int.Parse(parts[5].Trim());
                        ProductStatus status;
                        switch (parts[6])
                        {
                            case "ProductStatus.open":
                                status = ProductStatus.open;
                                break;
                            case "ProductStatus.closed":
                                status = ProductStatus.closed;
                                break;
                            case "ProductStatus.sold":
                                status = ProductStatus.sold;
                                break;
                            default:
                                status = ProductStatus.closed;
                                break;
                        }
                        productListReal.productList.Add(new Product(title, price, bidCount, day, hour, second, status));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

      

        public void UpdatedProductList(List<Product> prods)
        {
            List<Product> temp = new List<Product>(prods);
            productListReal.productList.Clear();
            foreach (var p in temp)
            {
                productListReal.productList.Add(p);
            }
            StringBuilder productString = new StringBuilder();
            productString.Append("add!");
            foreach (var product in productListReal.productList)
            {
                productString.Append(product.ToString() + "!");
            }
            string m = productString.ToString();
            string serializedM = JsonSerializer.Serialize(m);

            sendToClient(serializedM);
        }

        public void ReceiveTime(string s)
        {
            string[] details = s.Split('!');
            foreach (var product in productListReal.productList)
            {
                if (details[1].Equals(product.Name))
                {
                    product.Status = ProductStatus.sold;
                }
            }
            timesUp(products);
            sendToClient("time!" + details[1]);
        }

        public List<Product> GetProducts()
        {
            return productListReal.productList;
        }

        public void DealWithBid(string str)
        {
            string[] bidDetails = str.Split('!');
            string name = bidDetails[1];
            decimal price = Convert.ToDecimal(bidDetails[2]);
            foreach (Product p in productListReal.productList)
            {
                if (p.Name.Equals(name))
                {
                    currentHighestBid = p.CurrentBid;
                    if (p.CurrentBid < price)
                    {
                        currentHighestBid = price;
                        p.CurrentBid = price;
                        sendToClient("BIDGOOD"+"!"+p.Name+"!"+currentHighestBid);

                        break;
                    }
                    else
                    {
                        sendToClient("BIDBAD!"+p.Name+"!"+ currentHighestBid);

                        break;
                    }
                }
            }
        }

        public void SetSendToClientDel(SendToClientDelegate d)
        {
            sendToClient += d;
        }

        public void SetUpdateServerDel(UpdateServerListDelegate d)
        {
            timesUp += d;
        }
    }
}
