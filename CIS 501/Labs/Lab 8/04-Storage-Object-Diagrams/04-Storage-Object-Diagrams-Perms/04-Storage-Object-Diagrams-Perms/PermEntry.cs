using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage_Object_Diagrams_Perms
{

    // PermEntry holds a  word  along with all its permutations:
    class PermEntry
    {
        private static int maxLength = 8;            // the largest word length for which we try to compute permutations
        public readonly string word;
        public readonly int quantity;        // how many permutations
        public readonly List<string> perms;  // a list of all the permutations

        public PermEntry(string w)
        {
            word = w;
            int len = word.Length;
            quantity = factorial(len);
            if (len <= maxLength) { perms = makePerms(word); }
        }

        // factorial(n)  computes the quantity of permutations of a sequence of  n  items, for  n >= 0 :
        private int factorial(int n)
        {
            if (n == 0) { return 1; }
            else { return n * factorial(n - 1); }
        }

        // makePerms(s)  returns a list of all possible permutations of string  s :
        private List<string> makePerms(string s)
        {
            if (s == "") { return new List<string> { "" }; }           // for s == "", there is just  [""].

            else if (s.Length == 1) { return new List<string> { s }; }  // for a single char c, there is just [c].

            else
            {   // s is a string of two or more chars, and we decompose it and compute recursively:
                // compute perms for suffix  s[1]s[2]...s[s.Length-1]:
                List<string> subanswer = makePerms(s.Substring(1, s.Length - 1));
                char c = s[0];
                List<string> answer = new List<string> { };
                // insert lead char  c  into all possible positions of each permutation of the suffix:
                foreach (string p in subanswer)
                {
                    for (int i = 0; i <= p.Length; i++)
                    {
                        answer.Add(p.Substring(0, i) + c + p.Substring(i));
                    }
                }
                return answer;
            }
        }


    }
}
