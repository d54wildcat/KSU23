namespace Bid501Server
{
    partial class ServerView
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
            listBox1 = new ListBox();
            uxUserList = new ListBox();
            uxAddProduct = new Button();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(380, 73);
            listBox1.Margin = new Padding(4, 5, 4, 5);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(451, 554);
            listBox1.TabIndex = 0;
            // 
            // uxUserList
            // 
            uxUserList.FormattingEnabled = true;
            uxUserList.ItemHeight = 25;
            uxUserList.Location = new Point(33, 73);
            uxUserList.Margin = new Padding(4, 5, 4, 5);
            uxUserList.Name = "uxUserList";
            uxUserList.Size = new Size(307, 554);
            uxUserList.TabIndex = 1;
            // 
            // uxAddProduct
            // 
            uxAddProduct.Location = new Point(899, 73);
            uxAddProduct.Margin = new Padding(4, 5, 4, 5);
            uxAddProduct.Name = "uxAddProduct";
            uxAddProduct.Size = new Size(150, 85);
            uxAddProduct.TabIndex = 2;
            uxAddProduct.Text = "Add Product";
            uxAddProduct.UseVisualStyleBackColor = true;
            uxAddProduct.Click += uxAddProduct_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 43);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 25);
            label1.TabIndex = 4;
            label1.Text = "Current Users";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(380, 43);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 5;
            label2.Text = "List of Products";
            // 
            // button1
            // 
            button1.Location = new Point(901, 185);
            button1.Name = "button1";
            button1.Size = new Size(148, 80);
            button1.TabIndex = 6;
            button1.Text = "Edit Product";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ServerView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(uxAddProduct);
            Controls.Add(uxUserList);
            Controls.Add(listBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ServerView";
            Text = "ServerView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox uxUserList;
        private Button uxAddProduct;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}