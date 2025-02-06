using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn200
{
    public class CredentialsM
    {
        /// <summary>
        /// The only user name in the Credentials DB
        /// </summary>
        private String validUname;
        /// <summary>
        /// The only non-encrypted password in the Credentials DB
        /// </summary>
        private String validPassword;

        /// <summary>
        /// No parameter constructor that creates a default
        /// user name and a default password.
        /// </summary>
        public CredentialsM()
        {
            this.validUname = "user";
            this.validPassword = "password";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="un">The default user name</param>
        /// <param name="up">The default password</param>
        public CredentialsM(String un, String up)
        {
            Uname = un;
            Password = up;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Uname { get => validUname; set => validUname = value; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get => validPassword; set => validPassword = value; }

        /// <summary>
        /// Verifies that the credentials match the ONLY user's 
        /// credential in this version
        /// </summary>
        /// <param name="un">Username to verify</param>
        /// <param name="up">Password to verify</param>
        /// <returns>Returns true if the user name and p[assword match the credentials, 
        /// false otherwise</returns>
        public bool Validate(String un, String up)
        {
            bool result = false;

            if(validUname.Equals(un) && validPassword.Equals(up))
            {
                result = true;
            }

            return result;
        }
    }
}
