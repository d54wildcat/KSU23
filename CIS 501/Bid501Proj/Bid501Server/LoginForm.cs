namespace Bid501Server
{
    public partial class AdminLogin : Form
    {
        ServerView serverView;

        public AdminLogin(ServerView s)
        {
            InitializeComponent();
            serverView = s;

            uxUsername.TextChanged += uxUsername_TextChanged;
            uxPassword.TextChanged += uxPassword_TextChanged;

            // Initially disable uxPassword and uxLogin
            uxPassword.Enabled = false;
            uxLoginButton.Enabled = false;
        }

        private void uxUsername_TextChanged(object sender, EventArgs e)
        {
            uxPassword.Enabled = !string.IsNullOrWhiteSpace(uxUsername.Text);

            CheckLoginButtonState();
        }

        private void uxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckLoginButtonState();
        }

        private void CheckLoginButtonState()
        {
            // Enable uxLogin if both uxUsername and uxPassword have text
            uxLoginButton.Enabled = !string.IsNullOrWhiteSpace(uxUsername.Text) && !string.IsNullOrWhiteSpace(uxPassword.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = uxUsername.Text;
            string password = uxPassword.Text;
           
            if ((username.Equals("admin")) && (password.Equals("password")))
            {
                // Credentials are valid, open the main form
                serverView.Show();
                this.Hide();
            }
            else
            {
                label3.Text = ("Invalid username or password.");
                uxPassword.Text = "";
            }
        }
    }
}