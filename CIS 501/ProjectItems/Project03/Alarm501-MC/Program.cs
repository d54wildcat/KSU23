using Alarm501_MC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Alarm501_MC
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            AlarmController controller = new AlarmController();
            Alarm alarm = new Alarm();
        }
    }
}