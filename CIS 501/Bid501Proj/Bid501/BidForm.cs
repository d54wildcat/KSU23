using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml;

namespace Bid501
{
    public partial class BidForm : Form
    {
        RequestProducts requestProducts;
        List<Product> products = new List<Product>();
        private PlaceBidDel placeBidDelegate;
        private TimesUpToServerDelegate timesUpDelegate;
        public string userName;
        public BidForm(RequestProducts d)
        {
            InitializeComponent();
            requestProducts = d;

            this.Load += BidForm_Load;
            uxPlaceBid.Enabled = false;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            uxStatusPanel.BackColor = Color.Black;
            uxBidAmount.TextChanged += uxBidAmount_TextChanged;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (listBox1.SelectedIndex != -1)
            {
                Product selectedProduct = (Product)listBox1.SelectedItem;
                DisplayProductDetails(selectedProduct);
            }
        }

        private void DisplayProductDetails(Product product)
        {
            // Display product details on the form.
            // For example, if you have labels to display product name and price:
            uxProductTitle.Text = product.Name;
            uxMinimumBid.Text = product.CurrentBid.ToString();
            uxNumberOfBids.Text = product.BidCount.ToString();
            uxProductTime.Text = $"{product.Day}d, {product.Hour}hrs. {product.Second}mins";
            switch (product.Status)
            {
                case ProductStatus.open:
                    uxStatusPanel.BackColor = Color.Green;
                    break;
                case ProductStatus.closed:
                    uxStatusPanel.BackColor = Color.Red;
                    break;
                case ProductStatus.sold:
                    uxStatusPanel.BackColor = Color.Blue;
                    break;
            }
            // Add other details as needed
        }

        public void BidForm_Load(object sender, EventArgs e)
        {
            uxUser.Text = userName;
            requestProducts();

        }

        public void RecieveList(List<Product> list)
        {
            // Check if the method call is on the UI thread
            if (this.InvokeRequired)
            {
                // If not, use Invoke to make the update on the UI thread
                this.Invoke(new Action(() => RecieveList(list)));
                return;
            }
            products.Clear();
            foreach (Product p in list)
            {
                products.Add(p);
            }
            listBox1.DataSource = null;
            listBox1.DataSource = products;
            listBox1.DisplayMember = "Name";
            // listBox1.Refresh(); // This might be redundant if the DataSource is properly set
        }





        public void SetRequestProductsDel(RequestProducts d)
        {
            requestProducts += d;
        }
        public void SetBidDelegate(PlaceBidDel d)
        {
            placeBidDelegate = d;
        }

        public void SetTimesUpDelegate(TimesUpToServerDelegate d)
        {
            timesUpDelegate = d;
        }

        private void uxPlaceBid_Click(object sender, EventArgs e)
        {
            placeBidDelegate(products[listBox1.SelectedIndex], Convert.ToDouble(uxBidAmount.Text));
            uxBidAmount.Clear();

        }

        private void uxBidAmount_TextChanged(object sender, EventArgs e)
        {
            // Enable the login button if both text boxes are not empty
            uxPlaceBid.Enabled = !string.IsNullOrWhiteSpace(uxBidAmount.Text) && !string.IsNullOrWhiteSpace(uxBidAmount.Text);
        }

        private void uxTimeOff_Click(object sender, EventArgs e)
        {
            timesUpDelegate("time!" + products[listBox1.SelectedIndex].Name);
        }
    }
}
