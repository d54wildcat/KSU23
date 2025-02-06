/*
 * Alarm501_Console
 * Alarm.CS
 * Group 2A
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501_MC
{
    /// <summary>
    /// Enum to hold the possible sounds for the Alarm
    /// </summary>
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
        /// <summary>
        /// Int for the hour of the alarm
        /// </summary>
        public int Hour { get; set; }
        /// <summary>
        /// Int for the minute of the alarm
        /// </summary>
        public int Minute { get; set; }
        /// <summary>
        /// int for the second of the alarm
        /// </summary>
        public int Second { get; set; }
        /// <summary>
        /// bool to check if the alarm is AM or PM
        /// </summary>
        public bool AM { get; set; }


    }
}
