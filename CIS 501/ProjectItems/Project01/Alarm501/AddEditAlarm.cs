/*
 * Dacey Wieland
 * AddEditAlarm.cs
 * This class is the form that allows the user to add or edit an alarm.
 */
using System;
using System.Windows.Forms;
using static Alarm501.Alarm;

namespace Alarm501
{
    /// <summary>
    /// Handles logic for AddEditAlarm dialog form
    /// </summary>
    public partial class AddEditAlarm : Form
    {
        /// <summary>
        /// the instance of the main alarm interface
        /// </summary>
        private Alarm501 parentForm;

        /// <summary>
        /// alarm to edit 
        /// </summary>
        private Alarm editAlarm;


        /// <summary>
        /// constructor for window
        /// </summary>
        public AddEditAlarm(Alarm501 parent, Alarm alarm = null)
        {
            InitializeComponent();
            parentForm = parent;
            editAlarm = alarm;
            
            uxSoundBox.DataSource = Enum.GetValues(typeof(Alarm.AlarmSound));
            
            if (editAlarm != null)
            {
                uxSoundBox.SelectedItem = editAlarm.Sound;
                uxDateTimePicker.Value = editAlarm.AlarmTime;
                uxOnCheckBox.Checked = editAlarm.On;

            }
        }


        /// <summary>
        /// the button to set the alarm
        /// </summary>
        /// <param name="sender">teh sender that sets the alarm</param>
        /// <param name="e">event args </param>
        private void uxSetAlarm_Click(object sender, EventArgs e)
        {
            if (parentForm.edit)
            {
                EditAlarm();
            }
            else
            {
                CreateAlarm();
            }
            parentForm.UpdateAlarms();
            this.Close();
        }



        /// <summary>
        /// method to edit an existing alarm
        /// </summary>
        private void EditAlarm()
        {

            Alarm changedAlarm = parentForm.alarms[parentForm.selectedIndex];
            changedAlarm.AlarmTime = uxDateTimePicker.Value;
            if (uxOnCheckBox.Checked) changedAlarm.On = true;
            else changedAlarm.On = false;
            changedAlarm.Sound = (AlarmSound)uxSoundBox.SelectedItem;
            changedAlarm.SnoozeTime = (int)uxSnoozeTime.Value;
            changedAlarm.New = false;
            parentForm.alarms[parentForm.selectedIndex] = changedAlarm;
        }



        /// <summary>
        /// method to create an existing alarm
        /// </summary>
        private void CreateAlarm()
        {
            Alarm alarm = new Alarm();
            if (uxOnCheckBox.Checked) alarm.On = true;
            else alarm.On = false;
            alarm.Number = parentForm.alarmCount;
            alarm.AlarmTime = uxDateTimePicker.Value;
            alarm.New = false;
            alarm.SnoozeTime = (int)uxSnoozeTime.Value;
            alarm.Sound = (AlarmSound)uxSoundBox.SelectedItem;
            parentForm.alarms[parentForm.alarmCount] = alarm;
            parentForm.alarmCount++;

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
