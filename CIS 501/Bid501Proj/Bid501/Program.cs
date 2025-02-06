using System.Web;
using System.Xml.Serialization;

namespace Bid501
{
    public delegate void ValidateCredsDelegate(string u, string p);
    public delegate void SendToServerDelegate(string s);
    public delegate void GetLoginResultDelegate(string s);
    public delegate void RequestProducts();
    public delegate void UpdateProductListDel(String s);
    public delegate void BidFormUpdateProducts(List<Product> p);
    public delegate void CanLoginDelegate(string s);
    public delegate void HandleLoginResultsDelegate(bool b);
    public delegate void PlaceBidDel(Product p, double price);
    public delegate void HandleBidResults(string s);
    public delegate void BidUpdatesFormDelegate(List<Product> p);
    public delegate void TimesUpToServerDelegate(string s);
    public delegate void TimesUpResponseDelegate(string s);
    public delegate string ReturnUsernameDel();
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            CommunicationController commController = new CommunicationController();
            ClientProxy proxy = new ClientProxy();
            MainController mainController = new MainController(commController.Send, proxy);

            mainController.SetSendToDelegate(commController.Send);
            commController.SetGetLoginDel(mainController.HandleLoginResult);


            BidForm bidForm = new BidForm(mainController.GetProductList);
            bidForm.SetBidDelegate(mainController.LocalValidationOfBid);
            mainController.SetBidFormUpdateDel(bidForm.RecieveList);
            bidForm.SetRequestProductsDel(mainController.GetProductList);
            commController.SetUpdateProductList(mainController.ParseProductList);
            Login login = new Login(mainController.Login, bidForm,mainController.returnUser);
            mainController.SetHandleLoginResultsDel(login.HandleLoginResponse);
            commController.SetHandleBidResults(mainController.HandleBidResult);
            bidForm.SetTimesUpDelegate(mainController.SendTimeProduct);
            commController.SetTimesUpResponseDelegate(mainController.HandleTimesUpResponse);


            Application.Run(login); commController.Close();
        }
    }
}