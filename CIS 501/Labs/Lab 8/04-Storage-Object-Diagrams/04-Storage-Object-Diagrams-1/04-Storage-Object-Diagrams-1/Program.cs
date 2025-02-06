using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage_Object_Diagrams_1
{
    // example that shows static variable and two objects
    class Program
    {

        public static int size = 4;

        public static void Main()
        {
            int[] r = new int[size];
            r[0] = size;
            int j = size - 1;
            r[j] = f(j);
        }

        public static int f(int x)
        {
            // this dictionary is a kind of array, indexed by strings, that can grow:
            Dictionary<string, int> d = new Dictionary<string, int>();
            d["a"] = x;
            d["c"] = d["a"] + x;
            //***  insert breakpoint at the front of the next line:
            return size + x;
        }
    }
}
