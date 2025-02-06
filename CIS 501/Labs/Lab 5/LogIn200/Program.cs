using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn200
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CredentialsM model = new CredentialsM("Alice", "WonderLand");
            LoginForm view = new LoginForm();
            
            Controller controller = new Controller(model, view);
            view.SetController(controller);
            
            Application.Run(view);
            
        }
    }
}
