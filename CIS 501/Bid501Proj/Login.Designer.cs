namespace Bid501
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uxUsername = new TextBox();
            uxPassword = new TextBox();
            uxLoginButton = new Button();
            uxUsernameLabel = new Label();
            uxPasswordLabel = new Label();
            uxStateLabel = new Label();
            SuspendLayout();
            // 
            // uxUsername
            // 
            uxUsername.Location = new Point(222, 72);
            uxUsername.Name = "uxUsername";
            uxUsername.Size = new Size(100, 23);
            uxUsername.TabIndex = 0;
            // 
            // uxPassword
            // 
            uxPassword.Location = new Point(222, 143);
            uxPassword.Name = "uxPassword";
            uxPassword.PasswordChar = '*';
            uxPassword.Size = new Size(100, 23);
            uxPassword.TabIndex = 1;
            // 
            // uxLoginButton
            // 
            uxLoginButton.Location = new Point(222, 220);
            uxLoginButton.Name = "uxLoginButton";
            uxLoginButton.Size = new Size(75, 23);
            uxLoginButton.TabIndex = 2;
            uxLoginButton.Text = "Login";
            uxLoginButton.UseVisualStyleBackColor = true;
            uxLoginButton.Click += button1_Click;
            // 
            // uxUsernameLabel
            // 
            uxUsernameLabel.AutoSize = true;
            uxUsernameLabel.Location = new Point(134, 75);
            uxUsernameLabel.Name = "uxUsernameLabel";
            uxUsernameLabel.Size = new Size(60, 15);
            uxUsernameLabel.TabIndex = 3;
            uxUsernameLabel.Text = "Username";
            // 
            // uxPasswordLabel
            // 
            uxPasswordLabel.AutoSize = true;
            uxPasswordLabel.Location = new Point(134, 146);
            uxPasswordLabel.Name = "uxPasswordLabel";
            uxPasswordLabel.Size = new Size(57, 15);
            uxPasswordLabel.TabIndex = 4;
            uxPasswordLabel.Text = "Password";
            // 
            // uxStateLabel
            // 
            uxStateLabel.AutoSize = true;
            uxStateLabel.Location = new Point(239, 186);
            uxStateLabel.Name = "uxStateLabel";
            uxStateLabel.Size = new Size(32, 15);
            uxStateLabel.TabIndex = 5;
            uxStateLabel.Text = "label";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 292);
            Controls.Add(uxStateLabel);
            Controls.Add(uxPasswordLabel);
            Controls.Add(uxUsernameLabel);
            Controls.Add(uxLoginButton);
            Controls.Add(uxPassword);
            Controls.Add(uxUsername);
            Name = "Login";
            Text = "User Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox uxUsername;
        private TextBox uxPassword;
        private Button uxLoginButton;
        private Label uxUsernameLabel;
        private Label uxPasswordLabel;
        private Label uxStateLabel;
    }
}