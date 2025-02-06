/*
 * Dacey WIeland
 * Alarm501.cs
 * This class is the main form of the program.
 */

using System;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using static Alarm501.AddEditAlarm;
using static Alarm501.Alarm;

namespace Alarm501
{
    /// <summary>
    /// Handles logic for the Alarm501 form
    /// </summary>
    public partial class Alarm501 : Form
    {
        // <summary>
        /// the array of the alarms
        /// </summary>
        public Alarm[] alarms = new Alarm[5];

        /// <summary>
        /// which alarm is selected to be edited
        /// </summary>
        public int selectedIndex;

        /// <summary>
        /// if the goal is to edit or to add an alarm
        /// </summary>
        public bool edit;

        /// <summary>
        /// number of alarms in app
        /// </summary>
        public int alarmCount = 0;

        /// <summary>
        /// thread to make sure the alarm will go off
        /// </summary>
        private Thread alarmTracker;

        /// <summary>
        /// the alarm that went off
        /// </summary>
        public int alarmReactNum;


        /// <summary>
        /// constructor for the Alarm app
        /// </summary>
        public Alarm501()
        {
            InitializeComponent();
            for (int i = 0; i < alarms.Length; i++)
            {
                alarms[i] = new Alarm();
            }

            ReadFromFile();
            UpdateAlarms();
            alarmTracker = new Thread(AlarmFunctionality);
            alarmTracker.IsBackground = true;
            alarmTracker.Start();
            uxAlarmLabel.Text = "Welcome to Alarm!";
            uxStop.Enabled = false;
            uxSnooze.Enabled = false;

            this.FormClosing += AppClosedEvent;

        }

        /// <summary>
        /// method to read from file name if present
        /// </summary>
        /// <param name="filename">the name of the file</param>
        private void ReadFromFile()
        {
            if (System.IO.File.Exists("alarms.txt"))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("alarms.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] readAlarm = line.Split(' ');
                        if (readAlarm.Length >= 3)
                        {
                            int num = int.Parse(readAlarm[0]);
                            DateTime time = DateTime.Parse(readAlarm[1]);

                            try {
                                AlarmSound sound = (AlarmSound)Enum.Parse(typeof(AlarmSound), readAlarm[2]);
                                Alarm alarm = new Alarm();
                                alarm.Number = num;
                                alarm.AlarmTime = time;
                                alarm.On = false;
                                alarm.New = false;
                                alarm.Sound = sound;
                                alarms[num] = alarm;
                                alarmCount++;
                            }
                            catch( ArgumentException ex)
                            {
                                // Handle the case where the parsed sound is not a valid enum value
                                // You can log the error or take appropriate action here.
                                Console.WriteLine($"Invalid sound value: {readAlarm[2]}. Error: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format: {line}");
                        }
                            
                    }
                }
            }
        }

        /// <summary>
        /// pull up add edit screen when plus is clicked
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args e</param>
        private void uxAdd_Click(object sender, EventArgs e)
        {
            AddEditAlarm addEditAlarm = new AddEditAlarm(this);
            edit = false;
            addEditAlarm.ShowDialog();
        }

        /// <summary>
        /// updates the list of alarms
        /// </summary>
        public void UpdateAlarms()
        {
            uxAlarmListBox.Items.Clear();
            foreach (Alarm alarm in alarms)
            {
                if (!alarm.New)
                {
                    uxAlarmListBox.Items.Add(CreateStringOfAlarm(alarm));
                }
            }
            if (alarmCount == 5)
            {
                uxAdd.Enabled = false;
            }
            if (alarmCount == 0) uxEdit.Enabled = false;
            else uxEdit.Enabled = true;

        }

        /// <summary>
        /// creates a string to display of the alarm
        /// </summary>
        /// <param name="a">the alarm to change</param>
        /// <returns>returns a string</returns>
        private string CreateStringOfAlarm(Alarm a)
        {
            string soundString = Enum.GetName(typeof(AlarmSound), a.Sound);
            string statusString = a.On ? "ON" : "Off";
            return $"{a.AlarmTime.ToString("hh:mm tt")} {soundString} {statusString}";
        }

        /// <summary>
        /// what to do when the edit button is clicked
        /// </summary>
        /// <param name="sender">sender obnject</param>
        /// <param name="e">event args</param>
        private void uxEdit_Click(object sender, EventArgs e)
        {
            selectedIndex = uxAlarmListBox.SelectedIndex;
            AddEditAlarm addEditAlarm = new AddEditAlarm(this, alarms[selectedIndex]);

            edit = true;
            addEditAlarm.ShowDialog();

        }

        /// <summary>
        /// method to handle reaction of alarm going off
        /// </summary>
        private void AlarmReaction()
        {
            Invoke((MethodInvoker)delegate
            {
                uxAlarmLabel.Text = "ALARM " + (alarmReactNum + 1) + " ALERT";
                uxStop.Enabled = true;
                uxSnooze.Enabled = true;
            });
        }

        /// <summary>
        /// checks to see if teh alarm should be going off
        /// </summary>
        private void AlarmFunctionality()
        {
            while (true)
            {
                foreach (Alarm alarm in alarms)
                {
                    if (alarm.On)
                    {
                        if (alarm.AlarmTime.Hour == DateTime.Now.Hour && alarm.AlarmTime.Minute == DateTime.Now.Minute)
                        {
                            TimeSpan tolerance = TimeSpan.FromSeconds(1);
                            if (Math.Abs((alarm.AlarmTime - DateTime.Now).TotalSeconds) <= tolerance.TotalSeconds)
                            {
                                AlarmReaction();
                                alarmReactNum = alarm.Number;
                            }
                        }
   
                    }

                }
                Thread.Sleep(500);
            }

        }

        /// <summary>
        /// STOP button click
        /// </summary>
        /// <param name="sender">the stop button</param>
        /// <param name="e">event args e</param>
        private void uxStop_Click(object sender, EventArgs e)
        {
            alarms[alarmReactNum].On = false;
            UpdateAlarms();
            uxAlarmLabel.Text = "Alarm " + (alarmReactNum + 1) + " Stopped";
            uxStop.Enabled = false; uxSnooze.Enabled = false;
        }


        /// <summary>
        /// snooze button click
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args e</param>
        private void uxSnooze_Click(object sender, EventArgs e)
        {
            alarms[alarmReactNum].AlarmTime = DateTime.Now.AddSeconds(alarms[alarmReactNum].SnoozeTime);
            UpdateAlarms();
            uxAlarmLabel.Text = "Alarm " + (alarmReactNum + 1) + " Snoozed";
            uxStop.Enabled = false; uxSnooze.Enabled = false;

        }


        /// <summary>
        /// to handle when the app is closed so it can save the file
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">form closing args</param>
        private void AppClosedEvent(object sender, FormClosingEventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("alarms.txt"))
            {
                foreach (Alarm alarm in alarms)
                {
                    if (!alarm.New)
                    {
                        sw.WriteLine($"{alarm.Number} {alarm.AlarmTime:HH:mm:ss} {alarm.Sound}"); // Save the sound
                    }

                }
                
            };
        }
    }
}
