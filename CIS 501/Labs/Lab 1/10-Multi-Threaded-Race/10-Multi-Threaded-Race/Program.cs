using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// a race between two threads to seize the most tokens
namespace Multi_Threaded_Race
{

    // constructs an object that holds 100 "tokens" to give away:
    class Token
    {
        private int tokens = 100;
        // returns one token if available
        public bool getToken()
        {
            //lock (this) {   // enforce mutual exclusion on _this_ object
            bool outcome = false;
            if (tokens > 0)
            {
                tokens = tokens - 1;
                outcome = true;
            }
            return outcome;
            //}  // end lock
        }
    }

    class Program
    {
        static Token x;  // x  holds 100 tokens to give away

        static void Main(string[] args)
        {
            while (true)
            {
                x = new Token();
                new Thread(T1).Start();  // start thread to execute method T1
                new Thread(T2).Start();  // start thread to execute method T2
                Console.WriteLine("initialized");
                Console.ReadLine();
            }
            // main thread dies here.
        }

        static void T1()
        {
            loop(1);
        }
        static void T2()
        {
            loop(2);
        }

        // procedure that repeatedly seizes tokens and then prints result.
        // param: id - the index number of the thread that called the proc.
        static void loop(int id)
        {
            int success = 0;
            Random rand = new Random();
            while (x.getToken())
            {
                success = success + 1;
                Thread.Sleep(rand.Next(0, 8));   // pause for 0..7 milliseconds
            }
            Console.WriteLine("thread {0} has {1} tokens", id, success);
        }


    }

}
