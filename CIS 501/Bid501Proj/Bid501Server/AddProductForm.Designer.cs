namespace Bid501Server
{
    partial class AddProductForm
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
            uxListBox = new ListBox();
            uxAddBtn = new Button();
            SuspendLayout();
            // 
            // uxListBox
            // 
            uxListBox.FormattingEnabled = true;
            uxListBox.ItemHeight = 15;
            uxListBox.Location = new Point(12, 12);
            uxListBox.Name = "uxListBox";
            uxListBox.Size = new Size(222, 349);
            uxListBox.TabIndex = 0;
            // 
            // uxAddBtn
            // 
            uxAddBtn.Location = new Point(12, 367);
            uxAddBtn.Name = "uxAddBtn";
            uxAddBtn.Size = new Size(222, 71);
            uxAddBtn.TabIndex = 1;
            uxAddBtn.Text = "Add Item";
            uxAddBtn.UseVisualStyleBackColor = true;
            uxAddBtn.Click += uxAddBtn_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 450);
            Controls.Add(uxAddBtn);
            Controls.Add(uxListBox);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox uxListBox;
        private Button uxAddBtn;
    }
}