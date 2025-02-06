using LogIn200_MVC;
using System;
using System.Windows.Forms;
namespace Login200_MVC
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

            CredentialsM model = new CredentialsM("Alice","Wonderland");
            LoginForm view = new LoginForm();
            Controller controller = new Controller(model);

            view.SetDelegates(controller.UpdateViewCallback, controller.HandleEvents);
            controller.UpdateViewCallback += view.DisplayState;
            Application.Run(view);
        }
    }
}