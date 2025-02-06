using System;

namespace Order_OCP
{
    class Program
    {
        static void Main(string[] args)
        {

            OrderOCP anOrderOCP = new OrderOCP(1, "Headphones", 35.99);
            char again = 'y';
            do
            {
                Console.WriteLine("*** O C P ***");
                Console.WriteLine();
                Console.WriteLine("  Select Methos of Payment");
                Console.WriteLine("  1- Cash");
                Console.WriteLine("  2- Credit Card");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        anOrderOCP.ProcessOrder(new CashPayment());
                        break;
                    case 2:
                        anOrderOCP.ProcessOrder(new VisaPayment());
                        break;
                    default:
                        Console.WriteLine("Payment Method not accepted");
                        break;
                }
                Console.WriteLine("Try Again?");

                again = Console.ReadLine()[0];
            } while (again == 'y');
        }
    }
}
