namespace Bid501Server
{
    partial class AdminLogin
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
            uxLoginButton = new Button();
            uxUsername = new TextBox();
            uxPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // uxLoginButton
            // 
            uxLoginButton.Location = new Point(240, 342);
            uxLoginButton.Margin = new Padding(4, 5, 4, 5);
            uxLoginButton.Name = "uxLoginButton";
            uxLoginButton.Size = new Size(107, 38);
            uxLoginButton.TabIndex = 0;
            uxLoginButton.Text = "Login";
            uxLoginButton.UseVisualStyleBackColor = true;
            uxLoginButton.Click += button1_Click;
            // 
            // uxUsername
            // 
            uxUsername.Location = new Point(303, 137);
            uxUsername.Margin = new Padding(4, 5, 4, 5);
            uxUsername.Name = "uxUsername";
            uxUsername.Size = new Size(141, 31);
            uxUsername.TabIndex = 1;
            // 
            // uxPassword
            // 
            uxPassword.Location = new Point(303, 235);
            uxPassword.Margin = new Padding(4, 5, 4, 5);
            uxPassword.Name = "uxPassword";
            uxPassword.PasswordChar = '*';
            uxPassword.Size = new Size(141, 31);
            uxPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 142);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 240);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(250, 292);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 5;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 495);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(uxPassword);
            Controls.Add(uxUsername);
            Controls.Add(uxLoginButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdminLogin";
            Text = "Admin Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button uxLoginButton;
        private TextBox uxUsername;
        private TextBox uxPassword;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}