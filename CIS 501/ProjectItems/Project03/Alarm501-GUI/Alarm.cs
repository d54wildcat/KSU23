using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Alarm501_GUI
{
    public enum AlarmSound
    {
        Radar,
        Beacon,
        Chimes,
        Circuit,
        Reflection
    }
    /// <summary>
    /// Handles the logic for the alarm object
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// the number alarm it is (1-5)
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// determines if the alarm is on or not
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        /// the time the alarm is supposed to go off
        /// </summary>
        public DateTime AlarmTime { get; set; }

        /// <summary>
        /// determines if the alarm is new or edited
        /// </summary>
        public bool New { get; set; } = true;

        /// <summary>
        /// The snooze time for the alarm
        /// </summary>
        public int SnoozeTime { get; set; } = 3;

        /// <summary>
        /// Sound for the alarm when it goes off.
        /// </summary>
        public AlarmSound Sound { get; set; }
    }
}
