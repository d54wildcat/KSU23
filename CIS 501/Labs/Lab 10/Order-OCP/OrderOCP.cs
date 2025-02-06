using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_OCP
{
    class OrderOCP
    {
        private int id;
        private string name;
        private double amount;
        private bool paid;

        public OrderOCP(int id, String name, double amount)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
            paid = false;
        }
        public void ProcessOrder(IPaymentMethod ip)
        {
            ip.ProcessPayment(this.amount);
        }
    }
}
