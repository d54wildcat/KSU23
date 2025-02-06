/*
 * Dacey WIeland
 * Alarm5012.cs
 * This class is a view form of the program.
 */

using System;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Alarm5012
{
    /// <summary>
    /// delegate to stop alarm
    /// </summary>
    public delegate void StopAlarmDel();
    /// <summary>
    /// delegate to Update alarm
    /// </summary>
    public delegate void UpdateAlarmDel();
    /// <summary>
    /// delegate to Snooze alarm
    /// </summary>
    public delegate void SnoozeAlarmDel();
    /// <summary>
    /// delegate to close app
    /// </summary>
    /// <param name="a">alarm array</param>
    public delegate void CloseDel(Alarm[] a);
    /// <summary>
    /// delegate to add alarm
    /// </summary>
    /// <param name="alarm">alarm to add</param>
    /// <returns></returns>
    public delegate Alarm AddAlarmDel(Alarm alarm);
    /// <summary>
    /// delegate to edit alarm
    /// </summary>
    /// <param name="edit">alarm to edit</param>
    /// <returns></returns>
    public delegate Alarm EditAlarmDel(Alarm edit);
    /// <summary>
    /// delegate for if an alarm goes off
    /// </summary>
    public delegate void AlarmGoesOffDel();
    /// <summary>
    /// delegate to set alarm
    /// </summary>
    /// <param name="edit">if editing</param>
    /// <param name="alarmEdit">the alarm to edit</param>
    /// <param name="newTime">new Time</param>
    /// <param name="isOn">if alarm is on</param>
    /// <param name="newSound">the sound</param>
    /// <param name="snoozeTime">snooze time</param>
    /// <param name="alarmNumber">the alarm number</param>
    /// <returns></returns>
    public delegate Alarm SetAlarmDel(bool edit, Alarm alarmEdit, DateTime newTime, bool isOn, AlarmSound newSound, int SnoozeTime, int alarmNumber);
    /// <summary>
    /// Handles logic for the Alarm501 form
    /// </summary>
    public partial class Alarm5012 : Form
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
        /// the alarm count
        /// </summary>
        public int alarmCount = 0;
        /// <summary>
        /// thread to track alarms
        /// </summary>
        private Thread alarmTracker;
        /// <summary>
        /// the alarm that went off
        /// </summary>
        public int alarmReactNum;
        /// <summary>
        /// Add Alarm Delegate
        /// </summary>
        private AddAlarmDel addAlarms;
        /// <summary>
        /// Edit Alarm Delegate
        /// </summary>
        private EditAlarmDel editAlarmsDel;
        /// <summary>
        /// Close Delegate
        /// </summary>
        private CloseDel closeAlarmDel;
        /// <summary>
        /// Set Alarm Delegate
        /// </summary>
        private SetAlarmDel setAlarmDel;
        /// <summary>
        /// constructor for the Alarm app
        /// </summary>
        public Alarm5012(SetAlarmDel setAlarmDel, AddAlarmDel addAlarmDel, EditAlarmDel editAlarmDel, CloseDel closeAlarmDelv)
        {
            InitializeComponent();
            for (int i = 0; i < alarms.Length; i++)
            {
                Alarm alarm = new Alarm();
                alarms[i] = new Alarm();
            }
                addAlarms = addAlarmDel;
                editAlarmsDel = editAlarmDel;
                closeAlarmDel = closeAlarmDelv;
                ReadFromFile();
                UpdateAlarms();
                alarmTracker = new Thread(AlarmFunctionality);
                alarmTracker.IsBackground = true;
                alarmTracker.Start();
                uxAlarmLabel.Text = "Welcome to Alarm!";
                if (alarmCount < 5)
                {
                    uxAdd.Enabled = true;
                }
                uxStop.Enabled = false;
                uxSnooze.Enabled = false;



                this.FormClosing += AppClosedEvent;
        }
        /// <summary>
        /// Sets the setalarm del
        /// </summary>
        /// <param name="del">set alarm del</param>
        public void SetTheAlarm(SetAlarmDel del)
        {
            setAlarmDel = del;
        }
        /// <summary>
        /// Method to Read from the file
        /// </summary>
        private void ReadFromFile()
        {
            string filePath = System.IO.Path.Combine(Application.StartupPath, "alarms.txt");
            if (System.IO.File.Exists(filePath))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("alarms.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] readAlarm = line.Split(' ');
                        int num = int.Parse(readAlarm[0]);
                        DateTime time = DateTime.Parse(readAlarm[1]);
                        Alarm alarm = new Alarm();
                        alarm.Number = num;
                        alarm.AlarmTime = time;
                        if (readAlarm[2] == "True")
                        {
                            alarm.On = true;
                        }
                        else { alarm.On = false; }
                        if (readAlarm[4] != null)
                        {
                            alarm.SnoozeTime = int.Parse(readAlarm[4]);
                        }
                        alarm.New = false;
                        alarms[num] = alarm;
                        alarmCount++;
                    }
                }
            }
            else { MessageBox.Show("Cant Read File Dummy"); }
        }
        /// <summary>
        /// pull up add edit screen when plus is clicked
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args e</param>
        private void uxAdd_Click(object sender, EventArgs e)
        {
            edit = false;
            AddEditAlarm addEditAlarm = new AddEditAlarm(this, setAlarmDel, addAlarms(new Alarm()));
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
            edit = true;
            AddEditAlarm addEditAlarm = new AddEditAlarm(this, setAlarmDel, editAlarmsDel(alarms[selectedIndex]));
            addEditAlarm.ShowDialog();
        }
        /// <summary>
        /// method to handle reaction of alarm going off
        /// </summary>
        public void AlarmReaction()
        {
            Invoke((MethodInvoker)delegate
            {
                uxAlarmLabel.Text = "ALARM " + (alarmReactNum + 1) + " " + alarms[alarmReactNum].Sound + " " + "ALERT";
                uxStop.Enabled = true;
                uxSnooze.Enabled = true;
            });
        }

        /// <summary>
        /// checks to see if the alarm should be going off
        /// </summary>
        private void AlarmFunctionality()
        {
            while (true)
            {
                foreach (Alarm alarm in alarms)
                {
                    if (alarm != null && alarm.On)
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
        /// Stops Alarm
        /// </summary>
        public void StopAlarm()
        {
            alarms[alarmReactNum].On = false;
            UpdateAlarms();
            uxAlarmLabel.Text = "Alarm " + (alarmReactNum + 1) + " Stopped";
            uxStop.Enabled = false; uxSnooze.Enabled = false;

        }
        /// <summary>
        /// STOP button click
        /// </summary>
        /// <param name="sender">the stop button</param>
        /// <param name="e">event args e</param>
        private void uxStop_Click(object sender, EventArgs e)
        {
            StopAlarm();
        }
        /// <summary>
        /// snooze button click
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args e</param>
        private void uxSnooze_Click(object sender, EventArgs e)
        {
            Snooze();
        }
        /// <summary>
        /// Snoozes alarm
        /// </summary>
        public void Snooze()
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
            closeAlarmDel(alarms);
        }
    }
}
