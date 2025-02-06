using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNaive
{
    class Program
    {
        static void Main(string[] args)
        {
                Order anOrder = new Order(1, "Headphones", 35.99);

                Console.WriteLine("*** N A I V E ***");
                Console.WriteLine();
                Console.WriteLine("  Select Methos of Payment");
                Console.WriteLine("  1- Cash");
                Console.WriteLine("  2- Credit Card");
                int op = Convert.ToInt32(Console.ReadLine());

                anOrder.ProcessOrder(op);

                Console.ReadLine();
            }
        }
}
