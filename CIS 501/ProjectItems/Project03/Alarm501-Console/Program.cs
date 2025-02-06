using System;
using System.Collections.Generic;
using System.IO;
using Alarm501_MC;

namespace Alarm501_Console{
    public delegate void GetAlarmHourDel(int i);
    public delegate void GetAlarmMinuteDel(int i);
    public delegate void GetAlarmSecondDel(int i);
    public delegate void GetSnoozeTimeDel(int i);
    public delegate void GetAmPmDel(char c);
    public delegate void GetOnOffDel(char c);
    public delegate void GetAlarmSoundDel(string s);
    public delegate void GetAlarmToEditIndexDel(int i);

    public class Program
    {
        public Alarm501_MC.ReturnListOfAlarmsDel ReturnListOfAlarms;
        static void Main(string[] args)
        {
            try
            {

            
            var view = new ConsoleHandler();
            string command = "";
            view.ReadInAlarm();
            view.ReturnListOfAlarms();

                while (command != "6")
                {
                    Console.WriteLine("Welcome to Alarm501 Console Application!");
                    Console.WriteLine("1. Add Alarm");
                    Console.WriteLine("2. Edit Alarm");
                    Console.WriteLine("3. Snooze Alarm");
                    Console.WriteLine("4. Stop Alarm");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter the command number: ");
                    command = Console.ReadLine();
                    bool exit=false;
                    switch (command)
                    {
                        case "1":
                            exit = false;
                            Console.WriteLine("Enter Alarm Hour (0-12) (Press 'x' to cancel): ");
                            string str = Console.ReadLine();
                            if (str[0] == 'x')
                            {
                                break;
                            }
                            int hour = Convert.ToInt32(str);
                            while (hour > 12 || hour < 0)
                            {
                                Console.WriteLine("Enter Alarm Hour (0-12) (Press 'x' to cancel): ");
                                str = Console.ReadLine();
                                if (str[0] == 'x') { exit = true; break; }
                                hour = Convert.ToInt32(str);
                                if (hour > 12 || hour < 0)
                                {
                                    Console.WriteLine("Invalid hour. Please try again.");
                                }
                            }
                            if (exit) { break; }


                            view.GetHour(hour);

                            Console.WriteLine("Enter Alarm Minute (0-60) (Press 'x' to cancel): ");
                            str = Console.ReadLine();
                            if (str[0] == 'x') { exit = true; break; }
                            int min = Convert.ToInt32(str);
                            while (min > 60 || min < 0)
                            {
                                Console.WriteLine("Enter Alarm Minute (0-60) (Press 'x' to cancel): ");
                                str = Console.ReadLine();
                                if (str[0] == 'x') { exit = true; break; }
                                min = Convert.ToInt32(str);
                                if (min > 60 || min < 0)
                                {
                                    Console.WriteLine("Invalid minute. Please try again.");
                                }
                            }
                            if (exit) { break; }

                            view.GetMinute(min);


                            Console.WriteLine("Enter Alarm Second (0-60) (Press 'x' to cancel): ");
                            str = Console.ReadLine();
                            if (str[0] == 'x') { exit = true; break; }
                            int sec = Convert.ToInt32(str);
                            while (sec > 60 || sec < 0)
                            {
                                Console.WriteLine("Enter Alarm Second (0-60) (Press 'x' to cancel): ");
                                str = Console.ReadLine();
                                if (str[0] == 'x') { exit = true; break; }
                                sec = Convert.ToInt32(str);
                                if (sec > 60 || sec < 0)
                                {
                                    Console.WriteLine("Invalid second. Please try again.");
                                }
                            }
                            if (exit) { break; }

                            view.GetSecond(sec);


                            Console.WriteLine("Enter Alarm Snooze Time (0-30) (Press 'x' to cancel): ");
                            str = Console.ReadLine();
                            if (str[0] == 'x') { exit = true; break; }
                            int snoozeTime = Convert.ToInt32(str);
                            while (snoozeTime > 30 || snoozeTime < 0)
                            {
                                Console.WriteLine("Enter Alarm Snooze Time (0-30) (Press 'x' to cancel): ");
                                str = Console.ReadLine();
                                if (str[0] == 'x') { exit = true; break; }
                                snoozeTime = Convert.ToInt32(str);
                                if (snoozeTime > 60 || snoozeTime < 0)
                                {
                                    Console.WriteLine("Invalid Snooze Time. Please try again.");
                                }
                            }
                            if (exit) { break; }
                            view.GetSnoozeTime(snoozeTime);


                            Console.WriteLine("Enter a for AM and p for PM (Press 'x' to cancel)");
                            char am = (Convert.ToChar(Console.ReadLine()));
                            if (am == 'x') { exit = true; break; }
                            while (am != 'a' && am != 'p')
                            {
                                Console.WriteLine("Enter a for AM and p for PM (Press 'x' to cancel)");
                                am = (Convert.ToChar(Console.ReadLine()));
                                if (am == 'x') { exit = true; break; }
                                if(am!= 'a' || am != 'p')
                                {
                                    Console.WriteLine("Invalid AM/PM. Please try again.");

                                }
                            }
                            if (exit) { break; }

                            view.GetAmPm(am);


                            Console.WriteLine("Enter o for On and n for Off (Press 'x' to cancel)");
                            char on = (Convert.ToChar(Console.ReadLine()));
                            if (on == 'x') { exit = true; break; }
                            while (on != 'o' && on != 'n')
                            {
                                Console.WriteLine("Enter o for On and n for Off (Press 'x' to cancel)");
                                on = (Convert.ToChar(Console.ReadLine()));
                                if (on == 'x') { exit = true; break; }
                                if (on != 'o' && on != 'n')
                                {
                                    Console.WriteLine("Invalid On/Off. Please try again.");

                                }
                            }
                            if (exit) { break; }
                            view.GetOnOff(on);



                            Console.WriteLine("Enter Alarm Sound (Radar, Beacon, Chimes, Circuit, Reflection) (Press 'x' to cancel): ");
                            string sound = Console.ReadLine();
                            if (sound[0] == 'x') { break; }
                            while (sound != "Radar" && sound != "Beacon" && sound != "Chimes" && sound != "Circuit" && sound != "Reflection")
                            {
                                Console.WriteLine("Enter Alarm Sound (Radar, Beacon, Chimes, Circuit, Reflection) (Press 'x' to cancel): ");
                                sound = Console.ReadLine();
                                if (sound[0] == 'x') { exit = true; break; }
                                if (sound != "Radar" && sound != "Beacon" && sound != "Chimes" && sound != "Circuit" && sound != "Reflection")
                                {
                                    Console.WriteLine("Invalid sound. Please try again.");
                                }
                            }
                            if (exit) { break; }
                            view.GetSound(sound);


                            view.AddAlarm();
                            view.WriteAlarmsToFile();
                            view.ReturnListOfAlarms();
                            break;

                        case "2":
                            exit = false;
                            Console.WriteLine("Enter Alarm To Edit");
                            string str2 = Console.ReadLine();
                            if (str2[0] == 'x')
                            {
                                break;
                            }
                            int alarmNum = Convert.ToInt32(str2);

                            while (alarmNum > 5 || alarmNum < 1)
                            {
                                Console.WriteLine("Enter Alarm To Edit");
                                str2 = Console.ReadLine();
                                if (str2[0] == 'x') { exit = true; break; }
                                alarmNum = Convert.ToInt32(str2);
                                if (alarmNum > 5 || alarmNum < 1)
                                {
                                    Console.WriteLine("Invalid alarm number. Please try again.");
                                }
                            }
                            if (exit) { break; }
                            view.PassAlarmToEdit(alarmNum);


                            Console.WriteLine("Enter Alarm Hour (0-12) (Press 'x' to cancel): ");
                            str2 = Console.ReadLine();
                            if (str2[0] == 'x')
                            {
                                break;
                            }
                            int hour2 = Convert.ToInt32(str2);
                            while (hour2 > 12 || hour2 < 0)
                            {
                                Console.WriteLine("Enter Alarm Hour (0-12) (Press 'x' to cancel): ");
                                str2 = Console.ReadLine();
                                if (str2[0] == 'x') { exit = true; break; }
                                hour2 = Convert.ToInt32(str2);
                                if (hour2 > 12 || hour2 < 0)
                                {
                                    Console.WriteLine("Invalid hour. Please try again.");
                                }
                            }
                            if (exit) { break; }


                            view.GetHour(hour2);


                            Console.WriteLine("Enter Alarm Minute (0-60) (Press 'x' to cancel): ");
                            str2 = Console.ReadLine();
                            if (str2[0] == 'x') { exit = true; break; }
                            int min2 = Convert.ToInt32(str2);
                            while (min2 > 60 || min2 < 0)
                            {
                                Console.WriteLine("Enter Alarm Minute (0-60) (Press 'x' to cancel): ");
                                str = Console.ReadLine();
                                if (str2[0] == 'x') { exit = true; break; }
                                min2 = Convert.ToInt32(str2);
                                if (min2 > 60 || min2 < 0)
                                {
                                    Console.WriteLine("Invalid minute. Please try again.");
                                }
                            }
                            if (exit) { break; }

                            view.GetMinute(min2);

                            Console.WriteLine("Enter Alarm Second (0-60) (Press 'x' to cancel): ");
                            str = Console.ReadLine();
                            if (str[0] == 'x') { exit = true; break; }
                            int sec2 = Convert.ToInt32(str);
                            while (sec2 > 60 || sec2 < 0)
                            {
                                Console.WriteLine("Enter Alarm Second (0-60) (Press 'x' to cancel): ");
                                str = Console.ReadLine();
                                if (str[0] == 'x') { exit = true; break; }
                                sec2 = Convert.ToInt32(str);
                                if (sec2 > 60 || sec2 < 0)
                                {
                                    Console.WriteLine("Invalid second. Please try again.");
                                }
                            }
                            if (exit) { break; }

                            view.GetSecond(sec2);


                            Console.WriteLine("Enter Alarm Snooze Time (0-30) (Press 'x' to cancel): ");
                            str = Console.ReadLine();
                            if (str[0] == 'x') { exit = true; break; }
                            int snoozeTime2 = Convert.ToInt32(str);
                            while (snoozeTime2 > 30 || snoozeTime2 < 0)
                            {
                                Console.WriteLine("Enter Alarm Snooze Time (0-30) (Press 'x' to cancel): ");
                                str = Console.ReadLine();
                                if (str[0] == 'x') { exit = true; break; }
                                snoozeTime2 = Convert.ToInt32(str);
                                if (snoozeTime2 > 60 || snoozeTime2 < 0)
                                {
                                    Console.WriteLine("Invalid Snooze Time. Please try again.");
                                }
                            }
                            if (exit) { break; }
                            view.GetSnoozeTime(snoozeTime2);


                            Console.WriteLine("Enter a for AM and p for PM (Press 'x' to cancel)");
                            char am2 = (Convert.ToChar(Console.ReadLine()));
                            if (am2 == 'x') { exit = true; break; }
                            while (am2 != 'a' && am2 != 'p')
                            {
                                Console.WriteLine("Enter a for AM and p for PM (Press 'x' to cancel)");
                                am2 = (Convert.ToChar(Console.ReadLine()));
                                if (am2 == 'x') { exit = true; break; }
                                if (am2 != 'a' || am2 != 'p')
                                {
                                    Console.WriteLine("Invalid AM/PM. Please try again.");

                                }
                            }
                            if (exit) { break; }

                            view.GetAmPm(am2);



                            Console.WriteLine("Enter o for On and n for Off (Press 'x' to cancel)");
                            char on2 = (Convert.ToChar(Console.ReadLine()));
                            if (on2 == 'x') { exit = true; break; }
                            while (on2 != 'o' && on2 != 'n')
                            {
                                Console.WriteLine("Enter o for On and n for Off (Press 'x' to cancel)");
                                on2 = (Convert.ToChar(Console.ReadLine()));
                                if (on2 == 'x') { exit = true; break; }
                                if (on2 != 'o' && on2 != 'n')
                                {
                                    Console.WriteLine("Invalid On/Off. Please try again.");

                                }
                            }
                            if (exit) { break; }
                            view.GetOnOff(on2);




                            Console.WriteLine("Enter Alarm Sound (Radar, Beacon, Chimes, Circuit, Reflection) (Press 'x' to cancel): ");
                            string sound2 = Console.ReadLine();
                            if (sound2[0] == 'x') { break; }
                            while (sound2 != "Radar" && sound2 != "Beacon" && sound2 != "Chimes" && sound2 != "Circuit" && sound2 != "Reflection")
                            {
                                Console.WriteLine("Enter Alarm Sound (Radar, Beacon, Chimes, Circuit, Reflection) (Press 'x' to cancel): ");
                                sound2 = Console.ReadLine();
                                if (sound2[0] == 'x') { exit = true; break; }
                                if (sound2 != "Radar" && sound2 != "Beacon" && sound2 != "Chimes" && sound2 != "Circuit" && sound2 != "Reflection")
                                {
                                    Console.WriteLine("Invalid sound. Please try again.");
                                }
                            }
                            if (exit) { break; }
                            view.GetSound(sound2);


                            view.EditAlarm();
                            view.WriteAlarmsToFile();

                            view.ReturnListOfAlarms();
                            break;
                        case "3":
                            if (view.SnoozeResponse())
                            {
                                view.SnoozeAlarm();
                            }
                            else
                            {
                                Console.WriteLine("There is no alarm going off to snooze");
                            }
                            view.ReturnListOfAlarms();

                            break;
                        case "4":
                            if (view.SnoozeResponse())
                            {
                                view.StopAlarm();
                            }
                            else
                            {
                                Console.WriteLine("There is no alarm going off to stop");
                            }
                            view.ReturnListOfAlarms();

                            break;
                        case "6":
                            Console.WriteLine("Goodbye!");
                            view.WriteAlarmsToFile();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid command. Please try again.");
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("There has been an error!");
            }
        }
    }
}
