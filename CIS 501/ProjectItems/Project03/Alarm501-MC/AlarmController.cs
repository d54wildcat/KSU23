/*
 * AlarmController.cs
 * Group2A
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Threading;


namespace Alarm501_MC
{
    #region Delegates
    /// <summary>
    /// Delegate to Return List of Alarms
    /// </summary>
    public delegate void ReturnListOfAlarmsDel();
    /// <summary>
    /// Delegate to Read in the Alarms
    /// </summary>
    public delegate void ReadInAlarmDel();
    /// <summary>
    /// Delegate to Write Alarms to File
    /// </summary>
    public delegate void WriteAlarmsToFileDel();
    /// <summary>
    /// Delegate to Add Alarm
    /// </summary>
    public delegate void AddAlarmDel();
    /// <summary>
    /// Delegate to Edit Alarm
    /// </summary>
    public delegate void EditAlarmDel();
    /// <summary>
    /// Delegate to snooze alarm
    /// </summary>
    public delegate void SnoozeAlarmDel();
    /// <summary>
    /// Delegate to Stop Alarms
    /// </summary>
    public delegate void StopAlarmDel();
    /// <summary>
    /// Delegate to Remove an Alarm
    /// </summary>
    public delegate void RemoveAlarmDel();
    /// <summary>
    /// Delegate to handle the response of snooze or stop
    /// </summary>
    /// <returns></returns>
    public delegate bool SnoozeStopResponseDel();
    #endregion
    /// <summary>
    /// This class is the controller, holds the logic for the operations and functions of the alarm.
    /// </summary>
    public class AlarmController
    {
        #region Private Variables
        /// <summary>
        /// bool to check if the alarm is going off
        /// </summary>
        private bool goingOff;
        /// <summary>
        /// List of alarms
        /// </summary>
        private List<Alarm> alarms = new List<Alarm>();
        /// <summary>
        /// Thread for the alarm
        /// </summary>
        private Thread alarmThread;
        /// <summary>
        /// Number of Alarm that is going off
        /// </summary>
        private int alarmReactNum;
        /// <summary>
        /// the alarm count
        /// </summary>
        private int alarmCount = 0;
        /// <summary>
        /// The index of the alarm to edit
        /// </summary>
        private int indexToEdit;
        /// <summary>
        /// The hour
        /// </summary>
        private int hour;
        /// <summary>
        /// The minute
        /// </summary>
        private int minute;
        /// <summary>
        /// The second
        /// </summary>
        private int second;
        /// <summary>
        /// The snoozeTime
        /// </summary>
        private int snoozeTime;
        /// <summary>
        /// The sound
        /// </summary>
        private string sound;
        /// <summary>
        /// Char to represent alarm on or off
        /// </summary>
        private char isOn;
        /// <summary>
        /// char to represent AM or PM
        /// </summary>
        private char amPm;
        #endregion
        /// <summary>
        /// Method to Read from the file
        /// </summary>
        public void ReadFromFile()
        {
            for(int i=0; i<5; i++)
            {
                Alarm a = new Alarm();
                a.New = true;
                alarms.Add(a);
            }
            alarmCount = 0;
            if (System.IO.File.Exists("alarms.txt"))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("alarms.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] readAlarm = line.Split(' ');

                            int num = int.Parse(readAlarm[0]);
                            Alarm alarm = new Alarm();
                            alarm.Number = num;
                            alarm.Hour = Convert.ToInt32(readAlarm[1]);
                            alarm.Minute = Convert.ToInt32(readAlarm[2]);
                            alarm.Second = Convert.ToInt32(readAlarm[3]);
                            if (readAlarm[4].ToString().Equals("True"))
                            {
                                alarm.AM = true;
                            }
                            else { alarm.AM = false; }
                            if (readAlarm[5] == "True")
                            {
                                alarm.On = true;
                            }
                            else { alarm.On = false; }
                            switch (readAlarm[6])
                            {
                                case "Radar":
                                    alarm.Sound = AlarmSound.Radar;
                                    break;
                                case "Beacon":
                                    alarm.Sound = AlarmSound.Beacon;
                                    break;
                                case "Chimes":
                                    alarm.Sound = AlarmSound.Chimes;
                                    break;
                                case "Reflection":
                                    alarm.Sound = AlarmSound.Reflection;
                                    break;
                                case "Circuit":
                                    alarm.Sound = AlarmSound.Circuit;
                                    break;
                            }

                            if (readAlarm[7] != null)
                            {
                                alarm.SnoozeTime = Convert.ToInt32(readAlarm[7]);
                            }
                            alarm.New = false;
                            alarms[num] = alarm;

                            alarmCount++;
                        
                    }
                }
            }
            else { Console.WriteLine("Can't Read File!"); }
            alarmThread = new Thread(AlarmFunctionality);
            alarmThread.IsBackground = true;
            alarmThread.Start();
        }
        /// <summary>
        /// Method that holds the alarm functionality
        /// </summary>
        private void AlarmFunctionality()
        {
            while (true)
            {
                for(int i = 0; i < 5; i++)
                {
                    Alarm alarm = alarms[i];
                    if (alarm.On)
                    {
                        int alarmFormat = ConvertTime(alarm.Hour, alarm.AM);
                        DateTime currentTime = DateTime.Now;
                        //Console.WriteLine($"{alarmFormat.ToString()} == {currentTime.Hour.ToString()} && {alarm.Minute.ToString()} == {currentTime.Minute.ToString()}");
                        if(alarmFormat == currentTime.Hour && alarm.Minute == currentTime.Minute)
                        {
                            TimeSpan tolerance = TimeSpan.FromSeconds(1);
                            if(Math.Abs((alarm.Second - DateTime.Now.Second)) <= tolerance.TotalSeconds)
                            {
                                alarmReactNum = alarm.Number;
                                AlarmReaction();
                                break;
                            }
                        }
                    }
                }
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// Checks to see if the alarm is going off
        /// </summary>
        /// <returns>True if the alarm is going off</returns>
        public bool SnoozeStopResponse()
        {
            return goingOff;

        }
        /// <summary>
        /// Methof that handles when the alarm is stopped
        /// </summary>
        public void StopAlarm()
        {
            Console.WriteLine("\n**************************************************************");
            Console.WriteLine("Hello! Alarm Number " + alarmReactNum + " is now stopped!");
            Console.WriteLine("**************************************************************");
            alarms[alarmReactNum].On = false;
            goingOff = false;

        }
        /// <summary>
        /// Method that handles when the alarm goes off
        /// </summary>
        public void AlarmReaction()
        {
            goingOff = true;
            Console.WriteLine("\n**************************************************************");
            Console.WriteLine("Hello! Alarm Number " + alarmReactNum + " is going off!");
            Console.WriteLine("**************************************************************");
            alarms[alarmReactNum].On = false;

            
        }
        /// <summary>
        /// Converts the time from 24 hour to 12 hour format
        /// </summary>
        /// <param name="hour">the hour the alarm is set for</param>
        /// <param name="isAM">if the alarm is AM or PM</param>
        /// <returns></returns>
        public int ConvertTime(int hour, bool isAM)
        {
            if (isAM && hour == 12)
            {
                return 0;
            }
            if(!isAM && hour < 12)
            {
                return hour + 12;
            }
            return hour;
        }   
        /// <summary>
        /// Method to handle when the alarm is snoozed.
        /// </summary>
        public void SnoozeNow()
        {
            goingOff = false;

            alarms[alarmReactNum].On = true;
            Console.WriteLine("**************************************************************************************************************");
            Console.WriteLine("Hello! Alarm Number " + alarmReactNum + " is now snoozed for " + alarms[alarmReactNum].SnoozeTime + " second!");
            Console.WriteLine("**************************************************************************************************************");

            if (DateTime.Now.Second + alarms[alarmReactNum].SnoozeTime > 60)
            {
                alarms[alarmReactNum].Second = DateTime.Now.Second + alarms[alarmReactNum].SnoozeTime - 60;
                if (alarms[alarmReactNum].Minute != 59)
                {
                    alarms[alarmReactNum].Minute++;
                }
                else
                {
                    if (alarms[alarmReactNum].Hour != 12)
                    {
                        alarms[alarmReactNum].Hour++;
                    }
                    else
                    {
                        alarms[alarmReactNum].Hour = 1;
                        if (alarms[alarmReactNum].AM == true)
                        {
                            alarms[alarmReactNum].AM = false;
                        }
                        else
                        {
                            alarms[alarmReactNum].AM = true;
                        }
                    }
                }
            }
            else
            {
                alarms[alarmReactNum].Second = alarms[alarmReactNum].SnoozeTime + DateTime.Now.Second;
            }

        }
        /// <summary>
        /// Writes the list of alarms in a string format
        /// </summary>
        public void ReturnListOfAlarms()
        {
            for(int i = 0; i < alarms.Count; i++)
            {
                if (alarms[i].New == false)
                {
                    Console.WriteLine(CreateStringOfAlarm(alarms[i]));

                }
            }
            
        }

        /// <summary>
        /// App Closing Event
        /// </summary>
        public void CloseAndWrite()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("alarms.txt"))
            {
                foreach (Alarm alarm in alarms)
                {
                    if (!alarm.New)
                    {
                        sw.WriteLine(alarm.Number.ToString() + " " + alarm.Hour.ToString() + " " + alarm.Minute.ToString() + " " + alarm.Second.ToString() + " " + alarm.AM + " " + alarm.On + " " + alarm.Sound.ToString() + " " + alarm.SnoozeTime.ToString());

                    }

                }
            }
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
            string amPmString = a.AM ? "AM" : "PM";
            string hour = "";
            string minute = "";
            string second = "";
            if(a.Hour < 10)
            {
                hour = "0" + a.Hour.ToString();
            }
            else { hour = a.Hour.ToString(); }
            if(a.Minute < 10)
            {
                minute = "0" + a.Minute.ToString();
            }
            else { minute = a.Minute.ToString(); }
            if(a.Second < 10)
            {
                second = "0" + a.Second.ToString();
            }
            else { second = a.Second.ToString(); }
            return $"{a.Number.ToString()} {hour}:{minute}:{second} {amPmString} {soundString} {statusString}";
        }
        /// <summary>
        /// Edits the alarm
        /// </summary>
        public void EditAlarm()
        {
            var newAlarm = new Alarm();
            if (isOn == 'o') newAlarm.On = true;
            else { newAlarm.On = false; }
            if (amPm == 'a') newAlarm.AM = true;
            else { newAlarm.AM = false; }
            switch (sound)
            {
                case "Radar":
                    newAlarm.Sound = AlarmSound.Radar;
                    break;
                case "Beacon":
                    newAlarm.Sound = AlarmSound.Beacon;
                    break;
                case "Chimes":
                    newAlarm.Sound = AlarmSound.Chimes;
                    break;
                case "Reflection":
                    newAlarm.Sound = AlarmSound.Reflection;
                    break;
                case "Circuit":
                    newAlarm.Sound = AlarmSound.Circuit;
                    break;
                default:
                    Console.WriteLine("You did not enter a valid alarm");
                    break;

            }
            newAlarm.SnoozeTime = snoozeTime;
            newAlarm.New = false;
            newAlarm.Number = indexToEdit;
            newAlarm.Hour = hour;
            newAlarm.Minute = minute;
            newAlarm.Second = second;
            alarms[indexToEdit] =(newAlarm);
        }
        /// <summary>
        /// Add the alarm
        /// </summary>
        public void AddAlarm()
        {
            if (alarmCount == 5)
            {
                Console.WriteLine("You have reached your limit of 5 alarms");
                return;
            }
            var newAlarm = new Alarm();
            if (isOn == 'o') newAlarm.On = true;
            else { newAlarm.On = false; }
            if(amPm == 'a') newAlarm.AM = true;
            else { newAlarm.AM = false; }
            switch (sound)
            {
                case "Radar":
                    newAlarm.Sound = AlarmSound.Radar;
                    break;
                case "Beacon":
                    newAlarm.Sound = AlarmSound.Beacon;
                    break;
                case "Chimes":
                    newAlarm.Sound = AlarmSound.Chimes;
                    break;
                case "Reflection":
                    newAlarm.Sound = AlarmSound.Reflection;
                    break;
                case "Circuit":
                    newAlarm.Sound = AlarmSound.Circuit;
                    break;
                default:
                    Console.WriteLine("You did not enter a valid alarm");
                    break;

            }
            newAlarm.SnoozeTime = snoozeTime;
            newAlarm.New = false; 
            newAlarm.Number= alarmCount;
            newAlarm.Hour = hour;
            newAlarm.Minute = minute;
            newAlarm.Second = second;
            alarms[alarmCount] = newAlarm;
            alarmCount++;
        }
        /// <summary>
        /// Gets the alarm hour value
        /// </summary>
        /// <param name="i">the hour</param>
        public void GetAlarmHour(int i)
        {
            hour = i;
        }
        /// <summary>
        /// Gets the alarm minute value
        /// </summary>
        /// <param name="i">The minute(s)</param>
        public void GetAlarmMinute(int i)
        {
            minute = i;
        }
        /// <summary>
        /// Gets the alarm second value
        /// </summary>
        /// <param name="i">The second(s)</param>
        public void GetAlarmSecond(int i)
        {
            second = i;
        }
        /// <summary>
        /// Gets the AM or PM value
        /// </summary>
        /// <param name="c">The users response, either 'a' or'p' </param>
        public void GetAmPm(char c)
        {
            amPm = c;
        }
        /// <summary>
        /// Gets if the alarm is on or off
        /// </summary>
        /// <param name="c">The users response 'o' or 'n'</param>
        public void GetOnOff(char c)
        {
            isOn = c;
        }
        /// <summary>
        /// Gets the alarms sound
        /// </summary>
        /// <param name="s">The alarm sound</param>
        public void GetAlarmSound(string s)
        {
            sound = s;
        }
        /// <summary>
        /// Gets the snooze time
        /// </summary>
        /// <param name="i">The snooze time</param>
        public void GetSnoozeTime(int i)
        {
            snoozeTime = i;
        }
        /// <summary>
        /// Gets the index of the alarm to edit
        /// </summary>
        /// <param name="i"></param>
        public void GetEditIndex(int i)
        {
            indexToEdit = i;
        }


        
    }
}
