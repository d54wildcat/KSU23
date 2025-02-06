using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn200
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// The reference to the controller object, later
        /// we need to replace this with delegate(s).
        /// </summary>
        Controller controller;

        public LoginForm()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// THis method keepts the GUI controlls enabled/disabled, displaying the
        /// right information based on the App's satate.
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(State state)
        {
            switch (state)
            {
                case State.START:
                    lbStateMessage.Text = "Please Enter Username";
                    tbPassword.Enabled = false;
                    uxLoginBtn.Enabled = false;
                    break;
                case State.GOTUSERNAME:
                    lbStateMessage.Text = "Please Enter Password";
                    tbPassword.Enabled = true;
                    break;
                case State.GOTPASSWORD:
                    lbStateMessage.Text = "Validating Credentials...";
                    break;
                case State.DECLINED:
                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        tbUserName.Text = "";
                        tbPassword.Text = "";
                        lbStateMessage.Text = "Sorry, Invalid Credentials";
                    }));
                    break;
                case State.SUCCESS:
 
                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        tbUserName.Text = "";
                        tbPassword.Text = "";
                        lbStateMessage.Text = "Congrats! You are Loggedin";
                    }));
                    break;
                default:
                    lbStateMessage.Text = "Invalid State";
                    break;

            }
        }

        /// <summary>
        /// Listener to the Login button. It takes the user's input
        /// for the username and password and pass the values to the
        /// Controller along with the state the view is in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxLoginBtn_Click(object sender, EventArgs e)
        {
            String un = tbUserName.Text;
            String up = tbPassword.Text;
            Console.WriteLine(un + " " +up);
            controller.handleEvents(State.GOTPASSWORD, un+":"+up);

        }

        /// <summary>
        /// Links the View to the controller.
        /// </summary>
        /// <param name="c">The App's main controller object. Later
        /// this shold be a delegate.</param>
        public void SetController(Controller c)
        {
            controller = c;
        }

        /// <summary>
        /// TO synch the View and the Controller objects.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            controller.handleEvents(State.START, "");
        }

        /// <summary>
        /// This method helps avoid some user input propblems, and helps 
        /// keep the GUI in the right state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            controller.handleEvents(State.GOTUSERNAME, "");
        }


        /// <summary>
        /// This method helps avoid some user input propblems, and helps
        /// keep the GUI in the right state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            uxLoginBtn.Enabled = true;
        }

    }
}
