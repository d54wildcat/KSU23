/*
 * Dacey Wieland
 * AddEditAlarm.cs
 * This class is the form that allows the user to add or edit an alarm.
 */
using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Alarm5012
{
    /// <summary>
    /// Handles logic for AddEditAlarm dialog form
    /// </summary>
    public partial class AddEditAlarm : Form
    {
        
        private SetAlarmDel setAlarms;

        /// <summary>
        /// the instance of the main alarm interface
        /// </summary>
        private Alarm5012 parentForm;

        /// <summary>
        /// alarm to edit 
        /// </summary>
        private Alarm editAlarm;

        /// <summary>
        /// constructor for the add edit alarm form
        /// </summary>
        /// <param name="parent">parent form</param>
        /// <param name="setAlarmDel">set alarm del</param>
        /// <param name="alarm">the alarm</param>
        public AddEditAlarm(Alarm5012 parent, SetAlarmDel setAlarmDel, Alarm alarm)
        {
            InitializeComponent();
            InitializeAlarmSound();
            parentForm = parent;
            setAlarms = setAlarmDel ?? SetAlarm;

            if (alarm != null)
            {
                if (alarm.AlarmTime != DateTime.MinValue)
                {
                    uxDateTimePicker.Value = alarm.AlarmTime;
                }
                else
                {
                    uxDateTimePicker.Value = DateTime.Now;
                }
                editAlarm = alarm;
                uxOnCheckBox.Checked = editAlarm.On;
                uxSoundBox.Text = editAlarm.Sound.ToString();
                uxSoundBox.SelectedItem = editAlarm.Sound;
                uxSnoozeTime.Value = editAlarm.SnoozeTime;
            }
            else
            {
                editAlarm = new Alarm();
            }
        }
        /// <summary>
        /// method to set the alarm
        /// </summary>
        /// <param name="edit">if editing</param>
        /// <param name="alarmEdit">the alarm to edit</param>
        /// <param name="newTime">new Time</param>
        /// <param name="isOn">if alarm is on</param>
        /// <param name="newSound">the sound</param>
        /// <param name="snoozeTime">snooze time</param>
        /// <param name="alarmNumber">the alarm number</param>
        /// <returns></returns>
        private Alarm SetAlarm(bool edit, Alarm editAlarm, DateTime newTime, bool isOn, AlarmSound newSound, int snoozeTime, int alarmNumber)
        {
            return new Alarm();
        }
        /// <summary>
        /// delegate for setting the alarm
        /// </summary>
        /// <param name="sAD">del</param>
        public void SetAlarmsDelegate(SetAlarmDel sAD)
        {
            setAlarms = sAD;
        }
        /// <summary>
        /// method to initialize Alarm Sound
        /// </summary>
        private void InitializeAlarmSound()
        {
            uxSoundBox.Items.Add(AlarmSound.Radar);
            uxSoundBox.Items.Add(AlarmSound.Beacon);
            uxSoundBox.Items.Add(AlarmSound.Reflection);
            uxSoundBox.Items.Add(AlarmSound.Circuit);
            uxSoundBox.Items.Add(AlarmSound.Chimes);

        }
        /// <summary>
        /// method to handle the set button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSetAlarm_Click(object sender, EventArgs e)
        {
            if (parentForm.edit)
            {
                Alarm changedAlarm = parentForm.alarms[parentForm.selectedIndex];
                DateTime newAlarmTime = uxDateTimePicker.Value;
                bool isAlarmOn = uxOnCheckBox.Checked;
                AlarmSound newAlarmSound = addSound(uxSoundBox.SelectedIndex);
                int newSnoozeTime = (int)uxSnoozeTime.Value;
                int alarmNum = parentForm.selectedIndex;
                parentForm.alarms[parentForm.selectedIndex] = setAlarms(true, changedAlarm, newAlarmTime, isAlarmOn, newAlarmSound, newSnoozeTime, alarmNum);
            }
            else
            {
                Alarm changedAlarm = new Alarm();
                DateTime newAlarmTime = uxDateTimePicker.Value;
                bool isAlarmOn = uxOnCheckBox.Checked;
                AlarmSound newAlarmSound = addSound(uxSoundBox.SelectedIndex);
                int newSnoozeTime = (int)uxSnoozeTime.Value;
                int AlarmNum = parentForm.alarmCount;
                parentForm.alarms[parentForm.alarmCount] = setAlarms(false, changedAlarm, newAlarmTime, isAlarmOn, newAlarmSound, newSnoozeTime, AlarmNum);
                parentForm.alarmCount++;

            }
            parentForm.UpdateAlarms();
            this.Close();
        }

        /// <summary>
        /// method to add teh sound based on selected index
        /// </summary>
        /// <param name="index">index selected in soundBox</param>
        /// <returns>Sound to return</returns>
        private AlarmSound addSound(int index)
        {
            switch (index)
            {
                case 0:
                    return AlarmSound.Radar;
                case 1:
                    return AlarmSound.Beacon;
                case 2:
                    return AlarmSound.Reflection;
                case 3:
                    return AlarmSound.Circuit;
                case 4:
                    return AlarmSound.Chimes;
            }
            return AlarmSound.Radar;
        }
        /// <summary>
        /// cancel the window 
        /// </summary>
        /// <param name="sender">sender so prolly the cancel button</param>
        /// <param name="e">event args</param>
        private void uxCancelEditAlarm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
