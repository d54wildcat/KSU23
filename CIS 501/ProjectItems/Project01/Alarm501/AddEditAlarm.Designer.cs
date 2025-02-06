namespace Alarm501
{
    partial class AddEditAlarm
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
            this.uxDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uxSetAlarm = new System.Windows.Forms.Button();
            this.uxCancelEditAlarm = new System.Windows.Forms.Button();
            this.uxOnCheckBox = new System.Windows.Forms.CheckBox();
            this.uxSoundBox = new System.Windows.Forms.ComboBox();
            this.AlarmSoundLabel = new System.Windows.Forms.Label();
            this.snoozeLabel = new System.Windows.Forms.Label();
            this.uxSnoozeTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // uxDateTimePicker
            // 
            this.uxDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxDateTimePicker.Location = new System.Drawing.Point(28, 34);
            this.uxDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.uxDateTimePicker.Name = "uxDateTimePicker";
            this.uxDateTimePicker.Size = new System.Drawing.Size(152, 20);
            this.uxDateTimePicker.TabIndex = 0;
            this.uxDateTimePicker.Value = new System.DateTime(2021, 1, 29, 22, 30, 0, 0);
            // 
            // uxSetAlarm
            // 
            this.uxSetAlarm.Location = new System.Drawing.Point(230, 125);
            this.uxSetAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.uxSetAlarm.Name = "uxSetAlarm";
            this.uxSetAlarm.Size = new System.Drawing.Size(57, 30);
            this.uxSetAlarm.TabIndex = 1;
            this.uxSetAlarm.Text = "Set";
            this.uxSetAlarm.UseVisualStyleBackColor = true;
            this.uxSetAlarm.Click += new System.EventHandler(this.uxSetAlarm_Click);
            // 
            // uxCancelEditAlarm
            // 
            this.uxCancelEditAlarm.Location = new System.Drawing.Point(11, 125);
            this.uxCancelEditAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.uxCancelEditAlarm.Name = "uxCancelEditAlarm";
            this.uxCancelEditAlarm.Size = new System.Drawing.Size(57, 30);
            this.uxCancelEditAlarm.TabIndex = 2;
            this.uxCancelEditAlarm.Text = "Cancel";
            this.uxCancelEditAlarm.UseVisualStyleBackColor = true;
            this.uxCancelEditAlarm.Click += new System.EventHandler(this.uxCancelEditAlarm_Click);
            // 
            // uxOnCheckBox
            // 
            this.uxOnCheckBox.AutoSize = true;
            this.uxOnCheckBox.Location = new System.Drawing.Point(190, 35);
            this.uxOnCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.uxOnCheckBox.Name = "uxOnCheckBox";
            this.uxOnCheckBox.Size = new System.Drawing.Size(40, 17);
            this.uxOnCheckBox.TabIndex = 3;
            this.uxOnCheckBox.Text = "On";
            this.uxOnCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxSoundBox
            // 
            this.uxSoundBox.FormattingEnabled = true;
            this.uxSoundBox.Location = new System.Drawing.Point(28, 60);
            this.uxSoundBox.Name = "uxSoundBox";
            this.uxSoundBox.Size = new System.Drawing.Size(121, 21);
            this.uxSoundBox.TabIndex = 4;
            // 
            // AlarmSoundLabel
            // 
            this.AlarmSoundLabel.AutoSize = true;
            this.AlarmSoundLabel.Location = new System.Drawing.Point(163, 63);
            this.AlarmSoundLabel.Name = "AlarmSoundLabel";
            this.AlarmSoundLabel.Size = new System.Drawing.Size(67, 13);
            this.AlarmSoundLabel.TabIndex = 5;
            this.AlarmSoundLabel.Text = "Alarm Sound";
            // 
            // snoozeLabel
            // 
            this.snoozeLabel.AutoSize = true;
            this.snoozeLabel.Location = new System.Drawing.Point(163, 93);
            this.snoozeLabel.Name = "snoozeLabel";
            this.snoozeLabel.Size = new System.Drawing.Size(86, 13);
            this.snoozeLabel.TabIndex = 7;
            this.snoozeLabel.Text = "Snooze Time (m)";
            // 
            // uxSnoozeTime
            // 
            this.uxSnoozeTime.Location = new System.Drawing.Point(28, 91);
            this.uxSnoozeTime.Name = "uxSnoozeTime";
            this.uxSnoozeTime.Size = new System.Drawing.Size(120, 20);
            this.uxSnoozeTime.TabIndex = 8;
            this.uxSnoozeTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // AddEditAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 166);
            this.Controls.Add(this.uxSnoozeTime);
            this.Controls.Add(this.snoozeLabel);
            this.Controls.Add(this.AlarmSoundLabel);
            this.Controls.Add(this.uxSoundBox);
            this.Controls.Add(this.uxOnCheckBox);
            this.Controls.Add(this.uxCancelEditAlarm);
            this.Controls.Add(this.uxSetAlarm);
            this.Controls.Add(this.uxDateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddEditAlarm";
            this.Text = "Add/Edit Alarm";
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker uxDateTimePicker;
        private System.Windows.Forms.Button uxSetAlarm;
        private System.Windows.Forms.Button uxCancelEditAlarm;
        private System.Windows.Forms.CheckBox uxOnCheckBox;
        private System.Windows.Forms.ComboBox uxSoundBox;
        private System.Windows.Forms.Label AlarmSoundLabel;
        private System.Windows.Forms.Label snoozeLabel;
        private System.Windows.Forms.NumericUpDown uxSnoozeTime;
    }
}