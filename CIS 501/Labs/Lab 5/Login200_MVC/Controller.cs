﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogIn200_MVC
{
    public delegate void UpdateViewDelegate(State state);
    public delegate void ViewEventHandler(State state, String args);
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
        public UpdateViewDelegate UpdateViewCallback;
        /// <summary>
        /// The App's DB
        /// </summary>
        CredentialsM model;

        /// <summary>
        /// The App's user interaction
        /// </summary>
        LoginForm view;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="v"></param>
        public Controller(CredentialsM m)
        {
            model = m;

        }

        /// <summary>
        /// Based on the state the controller will act and apply
        /// the logic needed to process the information. After taking action,
        /// it will notify the view of the result.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        public void HandleEvents(State state, String args)
        {
            switch (state)
            {
                case State.START:
                        
                    UpdateViewCallback?.Invoke(State.START);
                    break;
                case State.GOTUSERNAME:
                    UpdateViewCallback?.Invoke(State.GOTUSERNAME);
                    break;
                case State.GOTPASSWORD:
                    bool valid = validateCredentials(args);
                    if(valid)
                    {
                        view.DisplayState(State.SUCCESS);
                    } else
                    {
                        view.DisplayState(State.DECLINED);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Process the credential following the preestablished format and
        /// using the information stored in the DB, validates if the user is 
        /// allowed to log in.
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        private bool validateCredentials(String cred)
        {
            bool result = false;
            String[] tokens = cred.Split(':');
            String un = tokens[0];
            String up = tokens[1];

            result = model.Validate(un, up);
            return result;
        }
    }
}
