using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bid501
{
    public partial class Login : Form
    {
        ValidateCredsDelegate validateCredentials;
        HandleLoginResultsDelegate isLoggedIn;
        BidForm bidForm;
        ReturnUsernameDel returnUserNameDel;

        public Login(ValidateCredsDelegate d, BidForm b, ReturnUsernameDel user)
        {
            InitializeComponent();
            uxLoginButton.Enabled = false;
            uxPassword.Enabled = false;
            uxStateLabel.Text = "";
            validateCredentials = d;
            bidForm = b;
            returnUserNameDel = user;
            uxUsername.TextChanged += uxUsername_TextChanged;
            uxPassword.TextChanged += uxPassword_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = uxUsername.Text;
            string password = uxPassword.Text;
            uxStateLabel.Text = "Validating...";
            validateCredentials(username, password);
        }

        public void HandleLoginResponse(bool result)
        {
            // Check if the call is happening on a different thread
            if (this.InvokeRequired)
            {
                // Use Invoke to switch to the UI thread
                this.Invoke(new Action<bool>(HandleLoginResponse), result);
                return;
            }

            // Now we're on the UI thread, so we can safely update the UI
            if (result)
            {
                uxStateLabel.Text = "Success!";
                string user = returnUserNameDel();
                bidForm.userName = user;
                bidForm.Show();
                this.Hide();
            }
            else
            {
                uxStateLabel.Text = "Incorrect Login!";
                uxPassword.Text = "";
            }
        }

        private void uxUsername_TextChanged(object sender, EventArgs e)
        {
            // Enable the password text box if the username text box is not empty
            uxPassword.Enabled = !string.IsNullOrWhiteSpace(uxUsername.Text);
        }

        private void uxPassword_TextChanged(object sender, EventArgs e)
        {
            // Enable the login button if both text boxes are not empty
            uxLoginButton.Enabled = !string.IsNullOrWhiteSpace(uxUsername.Text) && !string.IsNullOrWhiteSpace(uxPassword.Text);
        }
        /*
        public void SetReturnUserDel(ReturnUsernameDel d)
        {
            returnUserNameDel = d;
        }*/

        public void SetValidateDel(ValidateCredsDelegate d)
        {
            validateCredentials = d;
        }

        public void SetIsLoggedInDelegate(HandleLoginResultsDelegate d)
        {
            isLoggedIn = d;
        }
    }
}