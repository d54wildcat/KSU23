using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_OCP
{
    public class VisaPayment : IPaymentMethod
    {
        public bool ProcessPayment(double amount)
        {
            //Connect to Bank
            //Wait for response
            Console.WriteLine("Processing payment with Credit Card - OCP");
            return true;
        }
    }
}
