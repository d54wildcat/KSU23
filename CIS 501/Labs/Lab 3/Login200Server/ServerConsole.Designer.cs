namespace Login200Server
{
    partial class ServerConsole
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
            uxRequestListBox = new ListBox();
            SuspendLayout();
            // 
            // uxRequestListBox
            // 
            uxRequestListBox.FormattingEnabled = true;
            uxRequestListBox.ItemHeight = 30;
            uxRequestListBox.Location = new Point(21, 24);
            uxRequestListBox.Margin = new Padding(5, 6, 5, 6);
            uxRequestListBox.Name = "uxRequestListBox";
            uxRequestListBox.Size = new Size(515, 844);
            uxRequestListBox.TabIndex = 0;
            // 
            // ServerConsole
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 900);
            Controls.Add(uxRequestListBox);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ServerConsole";
            Text = "Server Console";
            ResumeLayout(false);
        }

        #endregion

        private ListBox uxRequestListBox;
    }
}