using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace LogIn200
{
    /// <summary>
    /// The valid App states.
    /// </summary>
    public enum State
    {
        NOTINIT = -1,
        START = 0,
        GOTUSERNAME,
        GOTPASSWORD,
        SUCCESS,
        DECLINED,
        EXIT
    }


    public class Controller
    {
        /// <summary>
        /// The App's user interaction
        /// </summary>
        LoginForm view;
        WebSocket ws;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="v"></param>
        public Controller(LoginForm v)
        {
            view = v;
            ws = ws = new WebSocket("ws://127.0.0.1:8001/login");
            ws.OnMessage += OnMessage;
            ws.Connect();
        }

        public void Close()
        {
            ws.Close();
        }

        /// <summary>
        /// Based on the state the controller will act and apply
        /// the logic needed to process the information. After taking action,
        /// it will notify the view of the result.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        public void handleEvents(State state, String args)
        {
            switch (state)
            {
                case State.START:
                        
                    view.DisplayState(State.START);
                    break;
                case State.GOTUSERNAME:
                    view.DisplayState(State.GOTUSERNAME);
                    break;
                case State.GOTPASSWORD:
                    view.DisplayState(State.GOTPASSWORD);
                    validateCredentials(args);
                    break;
                default:
                    break;
            }
        }

        public void OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Data.Equals("VALID"))
            {
                view.DisplayState(State.SUCCESS);
            }
            else
            {
                view.DisplayState(State.DECLINED);
            }
                
        }

        /// <summary>
        /// Process the credential following the preestablished format and
        /// using the information stored in the DB, validates if the user is 
        /// allowed to log in.
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        private void validateCredentials(String cred)
        {
            ws.Send(cred);
        }
    }
}
