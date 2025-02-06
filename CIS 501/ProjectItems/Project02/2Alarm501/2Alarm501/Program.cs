using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Alarm5012
{
    
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AlarmController controller = new AlarmController();
            Alarm5012 alarm501 = new Alarm5012(controller.SetAlarm, controller.AddAlarm, controller.EditAlarm, controller.CloseApp);
            Alarm alarm = new Alarm();

            AddEditAlarm addEditAlarm = new AddEditAlarm(alarm501, null, null);
            addEditAlarm.SetAlarmsDelegate(controller.SetAlarm); // Set the delegate
            alarm501.SetTheAlarm(controller.SetAlarm);

            controller.SetUpdateAlarmDel(alarm501.UpdateAlarms);
            controller.SetAlarmGoesOffDel(alarm501.AlarmReaction);
            controller.SetStopAlarmDel(alarm501.StopAlarm);
            controller.SetSnoozeDel(alarm501.Snooze);
            
            Application.Run(alarm501);
        }
    }
}