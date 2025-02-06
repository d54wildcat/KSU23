using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_OCP
{
    public class CashPayment : IPaymentMethod
    {
        public bool ProcessPayment(double amount)
        {
            //Ask to tender the amount
            //Verify that it is enough
            Console.WriteLine("Processing payment with Cash - OCP");
            return true;
        }
    }
}
