using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using System.Collections.Generic;

namespace Bid501Server
{
    public class CredentialValidator
    {
        AddConnectedUserDelegate addConnectedUser;
        private Dictionary<string, string> validCredentials = new Dictionary<string, string>();
        string fileName;

        public CredentialValidator(string file)
        {
            // Initialize with default credentials if needed
            validCredentials.Add("user", "password");
            fileName = file;
        }

        public bool ValidateCredentials(string username, string password)
        {
            LoadCredentialsFromFile(fileName);
            if (validCredentials.TryGetValue(username, out string validPassword))
            {
                if (validPassword == password)
                {
                    addConnectedUser?.Invoke(username, password);
                    return true;
                }
            }
            return false;
        }

        public void AddCredential(string username, string password)
        {
            validCredentials[username] = password;
        }

        public void SetAddConnectedUserDel(AddConnectedUserDelegate d)
        {
            addConnectedUser += d;
        }
        private void LoadCredentialsFromFile(string credsFile)
        {
            try
            {
                string[] lines = File.ReadAllLines(credsFile);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string username = parts[0].Trim();
                        string password = parts[1].Trim();
                        AddCredential(username, password);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading credentials file: " + ex.Message);
            }
        }
    }
}

