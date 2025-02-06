using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_OCP
{
    public interface IPaymentMethod
    {
        bool ProcessPayment(double amount);
    }
}
