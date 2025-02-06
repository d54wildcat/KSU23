namespace Alarm501_GUI
{
    partial class Alarm501
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxEdit = new System.Windows.Forms.Button();
            this.uxAdd = new System.Windows.Forms.Button();
            this.uxAlarmListBox = new System.Windows.Forms.ListBox();
            this.uxSnooze = new System.Windows.Forms.Button();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxAlarmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxEdit
            // 
            this.uxEdit.Location = new System.Drawing.Point(24, 17);
            this.uxEdit.Margin = new System.Windows.Forms.Padding(2);
            this.uxEdit.Name = "uxEdit";
            this.uxEdit.Size = new System.Drawing.Size(72, 37);
            this.uxEdit.TabIndex = 0;
            this.uxEdit.Text = "Edit";
            this.uxEdit.UseVisualStyleBackColor = true;
            this.uxEdit.Click += new System.EventHandler(this.uxEdit_Click);
            // 
            // uxAdd
            // 
            this.uxAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAdd.Location = new System.Drawing.Point(289, 17);
            this.uxAdd.Margin = new System.Windows.Forms.Padding(2);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(70, 37);
            this.uxAdd.TabIndex = 1;
            this.uxAdd.Text = "+";
            this.uxAdd.UseVisualStyleBackColor = true;
            this.uxAdd.Click += new System.EventHandler(this.uxAdd_Click);
            // 
            // uxAlarmListBox
            // 
            this.uxAlarmListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAlarmListBox.FormattingEnabled = true;
            this.uxAlarmListBox.ItemHeight = 25;
            this.uxAlarmListBox.Items.AddRange(new object[] {
            "5:00   am  Off",
            "10:30 pm  On"});
            this.uxAlarmListBox.Location = new System.Drawing.Point(24, 87);
            this.uxAlarmListBox.Margin = new System.Windows.Forms.Padding(2);
            this.uxAlarmListBox.Name = "uxAlarmListBox";
            this.uxAlarmListBox.ScrollAlwaysVisible = true;
            this.uxAlarmListBox.Size = new System.Drawing.Size(335, 154);
            this.uxAlarmListBox.TabIndex = 2;
            // 
            // uxSnooze
            // 
            this.uxSnooze.Location = new System.Drawing.Point(24, 298);
            this.uxSnooze.Margin = new System.Windows.Forms.Padding(2);
            this.uxSnooze.Name = "uxSnooze";
            this.uxSnooze.Size = new System.Drawing.Size(72, 37);
            this.uxSnooze.TabIndex = 3;
            this.uxSnooze.Text = "Snooze";
            this.uxSnooze.UseVisualStyleBackColor = true;
            this.uxSnooze.Click += new System.EventHandler(this.uxSnooze_Click);
            // 
            // uxStop
            // 
            this.uxStop.Location = new System.Drawing.Point(287, 298);
            this.uxStop.Margin = new System.Windows.Forms.Padding(2);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(72, 37);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = true;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxAlarmLabel
            // 
            this.uxAlarmLabel.AutoSize = true;
            this.uxAlarmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAlarmLabel.Location = new System.Drawing.Point(125, 260);
            this.uxAlarmLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxAlarmLabel.Name = "uxAlarmLabel";
            this.uxAlarmLabel.Size = new System.Drawing.Size(138, 20);
            this.uxAlarmLabel.TabIndex = 6;
            this.uxAlarmLabel.Text = "Alarm went OFF";
            // 
            // Alarm501
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 359);
            this.Controls.Add(this.uxAlarmLabel);
            this.Controls.Add(this.uxStop);
            this.Controls.Add(this.uxSnooze);
            this.Controls.Add(this.uxAlarmListBox);
            this.Controls.Add(this.uxAdd);
            this.Controls.Add(this.uxEdit);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Alarm501";
            this.Text = "Alarm501";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxEdit;
        private System.Windows.Forms.Button uxAdd;
        private System.Windows.Forms.ListBox uxAlarmListBox;
        private System.Windows.Forms.Button uxSnooze;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Label uxAlarmLabel;
    }
}