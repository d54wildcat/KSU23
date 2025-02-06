using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Storage_Object_Diagrams_Perms
{

    class Program
    {

        // repeatedly asks for words for which all permutations are generated:
        static void Main(string[] args)
        {
            Dictionary<string, PermEntry> d = new Dictionary<string, PermEntry>();

            while (true)
            {
                Console.Write("\nType a word: ");
                string s = Console.ReadLine();

                // add string  s and its permutations into dictionary  d:
                d[s] = new PermEntry(s);
                Console.WriteLine("There are {0} permutations of {1}.", d[s].quantity, s);

                Console.Write("Would you like to see them? (y or n)");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    List<string> thePerms = d[s].perms;   // get the permutations list from the dictionary
                    if (thePerms == null)
                    {  // null means that there are too many permutations to compute and show!
                        Console.WriteLine("Sorry --- there are too many to show you!");
                    }
                    else
                    {
                        foreach (string p in thePerms) { Console.Write(p + " "); }
                    }
                }

                Console.WriteLine();    // ***** insert a breakpoint at this line.
            }
        }
    }

}
