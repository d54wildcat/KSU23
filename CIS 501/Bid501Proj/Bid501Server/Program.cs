using System.Web;
using System.Xml.Serialization;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501Server
{
    public delegate List<Product> GetAllProductsDelegate();
    public delegate bool ValidateCredsDelegate(string u, string p);
    public delegate void AddConnectedUserDelegate(string u, string p);
    public delegate void AddProductDelegate(Product p);
    public delegate void UpdateProductListDel(List<Product> l);
    public delegate void SendToClientDelegate(string s);
    //public delegate void SendBidToControllerDelegate(string s);
    //public delegate void PassTimesUpToControllerDelegate(string s);
    public delegate void UpdateServerListDelegate(List<Product> l);

    public delegate void SendToControllerDelegate(string s);

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            ActualProductList prodlist = new ActualProductList();
            Controller controller = new Controller(prodlist);
            CredentialValidator validator = new CredentialValidator("../../../credentials.txt");
            WebSocketServer wss = new WebSocketServer(8001);

            wss.AddWebSocketService<CommunicationController>("/login", () =>
            {
                var comController = new CommunicationController(validator, controller.GetProducts);

                //keep this one
                comController.SetSendToController(controller.HandleOnMessage);
                controller.SetSendToClientDel(comController.SendToClient);
                return comController;
            });
            ServerView serverView = new ServerView(controller.GetProducts);
            AdminLogin loginForm = new AdminLogin(serverView);
            controller.SetUpdateServerDel(serverView.ProductBought);
            serverView.SetUpdateProductListDel(controller.UpdatedProductList);
            validator.SetAddConnectedUserDel(serverView.DisplayUsers);


            
            wss.Start();

            Application.Run(loginForm);

            wss.Stop();
        }
    }
}