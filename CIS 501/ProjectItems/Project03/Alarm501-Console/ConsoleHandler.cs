/*
 * ConsoleHandler.cs
 * Group2A
 */
using Alarm501_MC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501_Console
{
    /// <summary>
    /// Class to handle the setting delegates for the console application
    /// </summary>
    public class ConsoleHandler
    {
        /// <summary>
        /// Delegate for returning the list of alarms
        /// </summary>
        public ReturnListOfAlarmsDel ReturnListOfAlarms;
        /// <summary>
        /// Delegate to read in the alarms
        /// </summary>
        public ReadInAlarmDel ReadInAlarm;
        /// <summary>
        /// Delegate to Write the alarms to the file
        /// </summary>
        public WriteAlarmsToFileDel WriteAlarmsToFile;
        /// <summary>
        /// Delegate to add an alarm
        /// </summary>
        public AddAlarmDel AddAlarm;
        /// <summary>
        /// Delegate to edit an alarm
        /// </summary>
        public EditAlarmDel EditAlarm;
        /// <summary>
        /// Delegate to get the hour of the alarm
        /// </summary>
        public GetAlarmHourDel GetHour;
        /// <summary>
        /// Delegate to get the minute of the alarm
        /// </summary>
        public GetAlarmMinuteDel GetMinute;
        /// <summary>
        /// Delegate to get the second of the alarm
        /// </summary>
        public GetAlarmSecondDel GetSecond;
        /// <summary>
        /// Delegate to get the am/pm of the alarm
        /// </summary>
        public GetAmPmDel GetAmPm;
        /// <summary>
        /// Delegate to get the on/off of the alarm
        /// </summary>
        public GetOnOffDel GetOnOff;
        /// <summary>
        /// Delegate to get the sound of the alarm
        /// </summary>
        public GetAlarmSoundDel GetSound;
        /// <summary>
        /// Delegate to get the snooze time of the alarm
        /// </summary>
        public GetSnoozeTimeDel GetSnoozeTime;
        /// <summary>
        /// Delegate to pass the alarm to edit
        /// </summary>
        public GetAlarmToEditIndexDel PassAlarmToEdit;
        /// <summary>
        /// Delegate to handle the respond to snoozing
        /// </summary>
        public SnoozeStopResponseDel SnoozeResponse;
        /// <summary>
        /// Delegate to handle snoozing the alarm
        /// </summary>
        public SnoozeAlarmDel SnoozeAlarm;
        /// <summary>
        /// Delegate to handle stopping the alarm
        /// </summary>
        public StopAlarmDel StopAlarm;
        /// <summary>
        /// Private instance of the alarm controller
        /// </summary>
        private AlarmController ac = new AlarmController();
        /// <summary>
        /// Method to set the stop alarm delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetStopAlarmDel(StopAlarmDel del)
        {
            StopAlarm = del;
        }
        /// <summary>
        /// Method to set the snooze stop delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetSnoozeStop(SnoozeStopResponseDel del)
        {
            SnoozeResponse = del;
        }
        /// <summary>
        /// Method to set the snooze alarm delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetSnoozeDel(SnoozeAlarmDel del)
        {
            SnoozeAlarm = del;
        }
        /// <summary>
        /// Method to set the return list of alarms delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetReturnListOfAlarmsDel(ReturnListOfAlarmsDel del)
        {
            ReturnListOfAlarms = del;
        }
        /// <summary>
        /// Method to set the read in alarm delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetReadInAlarmDel(ReadInAlarmDel del)
        {
            ReadInAlarm = del;
        }
        /// <summary>
        /// Method to set the close app delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetCloseAppDel(WriteAlarmsToFileDel del)
        {
            WriteAlarmsToFile = del;
        }
        /// <summary>
        /// Method to set the add alarm delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetAddAlarmDel(AddAlarmDel del)
        {
            AddAlarm = del;
        }
        /// <summary>
        /// Method to set the edit alarm delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetEditAlarmDel(EditAlarmDel del)
        {
            EditAlarm = del;
        }
        /// <summary>
        /// Method to set the get hour delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetGetHourDel(GetAlarmHourDel del)
        {
            GetHour = del;
        }
        /// <summary>
        /// Method to set the get minute delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetGetMinuteDel(GetAlarmMinuteDel del)
        {
            GetMinute = del;
        }
        /// <summary>
        /// Method to set the get second delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetGetSecondDel(GetAlarmSecondDel del)
        {
            GetSecond = del;
        }
        /// <summary>
        /// Method to set the get am/pm delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetGetAmPmDel(GetAmPmDel del)
        {
            GetAmPm = del;
        }
        /// <summary>
        /// Method to set the get on/off delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetGetOnOffDel(GetOnOffDel del)
        {
            GetOnOff = del;
        }
        /// <summary>
        /// Method to set the get sound delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetGetSoundDel(GetAlarmSoundDel del)
        {
            GetSound = del;
        }
        /// <summary>
        /// Method to set the get snooze time delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetGetSnoozeTime(GetSnoozeTimeDel del)
        {
            GetSnoozeTime = del;
        }
        /// <summary>
        /// Method to set the pass alarm delegate
        /// </summary>
        /// <param name="del">the delegate</param>
        public void SetPassAlarmDel(GetAlarmToEditIndexDel del)
        {
            PassAlarmToEdit = del;
        }
        /// <summary>
        /// Method to set all the delegates
        /// </summary>
        public ConsoleHandler()
        {
            SetReturnListOfAlarmsDel(ac.ReturnListOfAlarms);
            SetReadInAlarmDel(ac.ReadFromFile);
            SetCloseAppDel(ac.CloseAndWrite);
            SetAddAlarmDel(ac.AddAlarm);
            SetGetHourDel(ac.GetAlarmHour);
            SetGetMinuteDel(ac.GetAlarmMinute);
            SetGetSecondDel(ac.GetAlarmSecond);
            SetGetAmPmDel(ac.GetAmPm);
            SetGetOnOffDel(ac.GetOnOff);
            SetGetSoundDel(ac.GetAlarmSound);
            SetGetSnoozeTime(ac.GetSnoozeTime);
            SetPassAlarmDel(ac.GetEditIndex);
            SetEditAlarmDel(ac.EditAlarm);
            SetSnoozeStop(ac.SnoozeStopResponse);
            SetSnoozeDel(ac.SnoozeNow);
            SetStopAlarmDel(ac.StopAlarm);
        }


        
    }
    
}
