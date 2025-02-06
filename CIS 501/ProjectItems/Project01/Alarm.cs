/*Dacey Wieland
* CIS 501
 * Alarm.cs
 *
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alarm501.AddEditAlarm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Alarm501
{
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
        public int SnoozeTime { get; set; }

        public enum AlarmSound
        {
            Radar,
            Beacon,
            Chimes,
            Circuit,
            Reflection
        }
        public AlarmSound Sound { get; set; }
    }
}

