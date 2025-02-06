/*
 * Dacey Wieland
 * AlarmController.cs
 * This class is the controller for the alarm project
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm5012
{
    /// <summary>
    /// Controller for the alarm
    /// </summary>
    public class AlarmController
    {
        /// <summary>
        /// The create alarm del
        /// </summary>
        private SnoozeAlarmDel snoozeAlarmDel;
        /// <summary>
        /// The stop alarm del
        /// </summary>
        private StopAlarmDel stopAlarmDel;
        /// <summary>
        /// The update alarms del
        /// </summary>
        private UpdateAlarmDel updateAlarmsDel;
        /// <summary>
        /// The alarm goes off del
        /// </summary>
        private AlarmGoesOffDel alarmOffDel;
        /// <summary>
        /// The alarm
        /// </summary>
        private Alarm alarm;
        /// <summary>
        /// Creates an alarm
        /// </summary>
        /// <param name="alarmDel">del</param>
        public void SetStopAlarmDel(StopAlarmDel alarmDel)
        {
            stopAlarmDel = alarmDel;
        }
        /// <summary>
        /// Sets Update Alarm del
        /// </summary>
        /// <param name="uAL">del</param>
        public void SetUpdateAlarmDel(UpdateAlarmDel uAL)
        {
            updateAlarmsDel = uAL;
        }
        /// <summary>
        /// Sets AlarmGoes off del
        /// </summary>
        /// <param name="goesOff">del</param>
        public void SetAlarmGoesOffDel(AlarmGoesOffDel goesOff)
        {
            alarmOffDel = goesOff;
        }
        /// <summary>
        /// Sets snooze del
        /// </summary>
        /// <param name="snooze">del</param>
        public void SetSnoozeDel(SnoozeAlarmDel snooze)
        {
            snoozeAlarmDel = snooze;
        }

        /// <summary>
        /// Sets the alarm
        /// </summary>
        /// <param name="edit">if it is an edit</param>
        /// <param name="alarmEdit">the alarm to edit</param>
        /// <param name="newTime">new Time</param>
        /// <param name="isOn">if alarm is on</param>
        /// <param name="newSound">the sound</param>
        /// <param name="snoozeTime">snooze time</param>
        /// <param name="alarmNumber">the alarm number</param>
        /// <returns></returns>
        public Alarm SetAlarm(bool edit, Alarm alarmEdit, DateTime newTime, bool isON, AlarmSound newSound, int snoozeTime, int alarmNumber)
        {
            Alarm alarm = new Alarm();

            if (edit) { alarm = EditAlarm(alarmEdit, newTime, isON, newSound, snoozeTime, alarmNumber); }
            else { alarm = CreateAlarm(newTime, isON, newSound, snoozeTime, alarmNumber); }

            updateAlarmsDel();
            return alarm;
        }

        /// <summary>
        /// Edits alarm
        /// </summary>
        /// <param name="alarmEdit">the alarm to edit</param>
        /// <param name="newTime">new Time</param>
        /// <param name="isOn">if alarm is on</param>
        /// <param name="newSound">the sound</param>
        /// <param name="snoozeTime">snooze time</param>
        /// <param name="alarmNumber">the alarm number</param>
        /// <returns></returns>
        public Alarm EditAlarm(Alarm alarmEdit, DateTime newTime, bool isOn, AlarmSound newSound, int snoozeTime, int alarmNumber)
        {

            alarmEdit.AlarmTime = newTime;
            alarmEdit.On = isOn;
            alarmEdit.Sound = newSound;
            alarmEdit.SnoozeTime = snoozeTime;
            alarmEdit.Number = alarmNumber;
            alarmEdit.New = false;
            return alarmEdit;
        }

        /// <summary>
        /// Creates an alarm
        /// </summary>
        /// <param name="newTime">new Time</param>
        /// <param name="isOn">if alarm is on</param>
        /// <param name="newSound">the sound</param>
        /// <param name="snoozeTime">snooze time</param>
        /// <param name="alarmNumber">the alarm number</param>
        /// <returns></returns>
        public Alarm CreateAlarm(DateTime newTime, bool isOn, AlarmSound newSound, int snoozeTime, int alarmNumber)
        {
            Alarm alarmEdit = new Alarm();
            alarmEdit.AlarmTime = newTime;
            alarmEdit.On = isOn;
            alarmEdit.Sound = newSound;
            alarmEdit.SnoozeTime = snoozeTime;
            alarmEdit.New = false;
            alarmEdit.Number = alarmNumber;
            return alarmEdit;
        }
        /// <summary>
        /// Adds an alarm
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        public Alarm AddAlarm(Alarm edit)
        {
            edit.New = false;
            return edit;
        }
        /// <summary>
        /// Edits an alarm
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        public Alarm EditAlarm(Alarm edit)
        {
            edit.New = false;

            return edit;
        }
        /// <summary>
        /// App Closing Event
        /// </summary>
        /// <param name="a"></param>
        public void CloseApp(Alarm[] a)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("alarms.txt"))
            {
                foreach (Alarm alarm in a)
                {
                    if (!alarm.New)
                    {
                        sw.WriteLine(alarm.Number.ToString() + " " + alarm.AlarmTime.ToString("HH:mm:ss") + " " + alarm.On + " " + alarm.Sound + " " + alarm.SnoozeTime);

                    }
                }
            }
        }
    }
}
