namespace Bid501
{
    partial class BidForm
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
            label1 = new Label();
            uxProductTitle = new Label();
            uxProductTime = new Label();
            uxProductStatus = new Label();
            uxNumberOfBids = new Label();
            uxMinimumBid = new Label();
            uxPlaceBid = new Button();
            uxBidAmount = new TextBox();
            uxStatusPanel = new Panel();
            uxTimeOff = new Button();
            uxUser = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(496, 58);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(245, 349);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(589, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Products";
            // 
            // uxProductTitle
            // 
            uxProductTitle.AutoSize = true;
            uxProductTitle.Location = new Point(75, 77);
            uxProductTitle.Name = "uxProductTitle";
            uxProductTitle.Size = new Size(93, 15);
            uxProductTitle.TabIndex = 2;
            uxProductTitle.Text = "Product Name...";
            // 
            // uxProductTime
            // 
            uxProductTime.AutoSize = true;
            uxProductTime.Location = new Point(75, 144);
            uxProductTime.Name = "uxProductTime";
            uxProductTime.Size = new Size(107, 15);
            uxProductTime.TabIndex = 3;
            uxProductTime.Text = "0d, 0 hrs. 0 min left";
            // 
            // uxProductStatus
            // 
            uxProductStatus.AutoSize = true;
            uxProductStatus.Location = new Point(75, 206);
            uxProductStatus.Name = "uxProductStatus";
            uxProductStatus.Size = new Size(42, 15);
            uxProductStatus.TabIndex = 4;
            uxProductStatus.Text = "Status:";
            // 
            // uxNumberOfBids
            // 
            uxNumberOfBids.AutoSize = true;
            uxNumberOfBids.Location = new Point(206, 267);
            uxNumberOfBids.Name = "uxNumberOfBids";
            uxNumberOfBids.Size = new Size(61, 15);
            uxNumberOfBids.TabIndex = 5;
            uxNumberOfBids.Text = "(# of Bids)";
            // 
            // uxMinimumBid
            // 
            uxMinimumBid.AutoSize = true;
            uxMinimumBid.Location = new Point(106, 310);
            uxMinimumBid.Name = "uxMinimumBid";
            uxMinimumBid.Size = new Size(98, 15);
            uxMinimumBid.TabIndex = 6;
            uxMinimumBid.Text = "Minimum bid $...";
            uxMinimumBid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uxPlaceBid
            // 
            uxPlaceBid.Location = new Point(119, 355);
            uxPlaceBid.Name = "uxPlaceBid";
            uxPlaceBid.Size = new Size(75, 23);
            uxPlaceBid.TabIndex = 7;
            uxPlaceBid.Text = "Place Bid";
            uxPlaceBid.UseVisualStyleBackColor = true;
            uxPlaceBid.Click += uxPlaceBid_Click;
            // 
            // uxBidAmount
            // 
            uxBidAmount.Location = new Point(75, 264);
            uxBidAmount.Name = "uxBidAmount";
            uxBidAmount.Size = new Size(100, 23);
            uxBidAmount.TabIndex = 8;
            // 
            // uxStatusPanel
            // 
            uxStatusPanel.BackColor = Color.Lime;
            uxStatusPanel.Location = new Point(146, 195);
            uxStatusPanel.Name = "uxStatusPanel";
            uxStatusPanel.Size = new Size(48, 38);
            uxStatusPanel.TabIndex = 9;
            // 
            // uxTimeOff
            // 
            uxTimeOff.BackColor = Color.Red;
            uxTimeOff.Location = new Point(27, 410);
            uxTimeOff.Margin = new Padding(2);
            uxTimeOff.Name = "uxTimeOff";
            uxTimeOff.Size = new Size(755, 28);
            uxTimeOff.TabIndex = 10;
            uxTimeOff.Text = "ALERT ALERT TIME GOES OFF";
            uxTimeOff.UseVisualStyleBackColor = false;
            uxTimeOff.Click += uxTimeOff_Click;
            // 
            // uxUser
            // 
            uxUser.AutoSize = true;
            uxUser.Location = new Point(361, 9);
            uxUser.Name = "uxUser";
            uxUser.Size = new Size(62, 15);
            uxUser.TabIndex = 11;
            uxUser.Text = "UserName";
            // 
            // BidForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uxUser);
            Controls.Add(uxTimeOff);
            Controls.Add(uxBidAmount);
            Controls.Add(uxPlaceBid);
            Controls.Add(uxMinimumBid);
            Controls.Add(uxNumberOfBids);
            Controls.Add(uxProductStatus);
            Controls.Add(uxProductTime);
            Controls.Add(uxProductTitle);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(uxStatusPanel);
            Name = "BidForm";
            Text = "BidForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label uxProductTitle;
        private Label uxProductTime;
        private Label uxProductStatus;
        private Label uxNumberOfBids;
        private Label uxMinimumBid;
        private Button uxPlaceBid;
        private TextBox uxBidAmount;
        private Panel uxStatusPanel;
        private Button uxTimeOff;
        private Label uxUser;
    }
}