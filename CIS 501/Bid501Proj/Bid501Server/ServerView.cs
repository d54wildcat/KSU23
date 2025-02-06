using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501Server
{
    public partial class ServerView : Form
    {
        private List<string> connectedUsers = new List<string>();
        private AddProductForm addForm;

        List<Product> products = new List<Product>();

        GetAllProductsDelegate getAllProducts;
        UpdateProductListDel updateProductList;

        public ServerView(GetAllProductsDelegate d)
        {
            InitializeComponent();
            getAllProducts = d;
            products = getAllProducts();
            listBox1.DataSource = products;
            listBox1.DisplayMember = "DisplayString";
            UpdateUserList();
        }

        public void DisplayUsers(string user, string password)
        {
            // Check if the method call is on the UI thread
            if (this.InvokeRequired)
            {
                // If not, use Invoke to make the update on the UI thread
                this.Invoke(new Action(() => DisplayUsers(user, password)));
                return;
            }


            connectedUsers.Add(user + " " + connectedUsers.Count);
            UpdateUserList(); // Update the list box

        }

        private void UpdateUserList()
        {
            uxUserList.DataSource = null;
            uxUserList.DataSource = new BindingSource(connectedUsers, null);

        }

        public void UpdateProductList(List<Product> l)
        {
            products = l;
            listBox1.DataSource = null;
            listBox1.DataSource = new BindingSource(products, null);
            listBox1.DisplayMember = "DisplayString";
            updateProductList(products);
        }

        public void ProductBought(List<Product> l)
        {
            // Check if the method call is on the UI thread
            if (this.InvokeRequired)
            {
                // If not, use Invoke to make the update on the UI thread
                this.Invoke(new Action(() => ProductBought(l)));
                return;
            }

            products = l;
            listBox1.DataSource = null;
            listBox1.DataSource = new BindingSource(products, null);
            listBox1.DisplayMember = "Status"; // Adjust as necessary

            listBox1.Refresh(); // Now safe to call since it's on the UI thread

        }

        public void DisplayProducts(Product p)
        {
            listBox1.DisplayMember = "Name";
            if (this.InvokeRequired)
            {

                this.Invoke(new Action(() => DisplayProducts(p)));
                return;
            }
            products.Add(p);
            UpdateProductList(products);
        }

        private void uxAddProduct_Click(object sender, EventArgs e)
        {
            addForm = new AddProductForm(DisplayProducts);
            addForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("nah");
        }

        public void SetGetAllDelegates(GetAllProductsDelegate d)
        {
            getAllProducts = d;
        }

        public void SetUpdateProductListDel(UpdateProductListDel d)
        {
            updateProductList += d;
        }
    }
}
