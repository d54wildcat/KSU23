using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNaive
{
    class Order
    {
        private int id;
        private string name;
        private double amount;
        private bool paid;

        public Order(int id, String name, double amount)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
            paid = false;
        }

        public void ProcessOrder(int method)
        {
            // 1- Get funds from payment method
            switch(method)
            {
                case 1:
                    Console.WriteLine("Processing payment with Cash");
                    break;
                case 2:
                    Console.WriteLine("Processing payment with Credit Card");
                    break;
                default:
                    Console.WriteLine("Payment Method Not Accepted");
                    break;
            }

            // 2 - If enough funds, mark order as paid
            paid = true;
        }

    }
}
