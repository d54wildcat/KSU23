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
    public partial class AddProductForm : Form
    {
        List<Product> addList = new List<Product>();
        Product selectedProduct;
        AddProductDelegate addProd;
        public AddProductForm(AddProductDelegate d)
        {
            InitializeComponent();
            CreateAddList();
            uxListBox.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            uxListBox.DisplayMember = "Name";
            uxListBox.DataSource = addList;
            addProd = d;
        }

        public void CreateAddList()
        {
            addList.Add(new Product("Ice Skates", (decimal)22.26, 2, 6, 23, 20, ProductStatus.open));
            addList.Add(new Product("Sweatshirt", (decimal)34.65, 6, 2, 56, 47, ProductStatus.open));
            addList.Add(new Product("Soccer Ball", (decimal)15.45, 7, 3, 33, 33, ProductStatus.open));
            addList.Add(new Product("Teddy Bear", (decimal)9.76, 1, 10, 12, 5, ProductStatus.open));
        }

        private void uxAddBtn_Click(object sender, EventArgs e)
        {
            addProd(selectedProduct);
            this.Close();
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (uxListBox.SelectedIndex != -1)
            {
                Product selectedProduct = (Product)uxListBox.SelectedItem;
                ChangeSelectedProduct(selectedProduct);
            }
        }

        public void ChangeSelectedProduct(Product p)
        {
            selectedProduct = p;
        }

        public void SetAddProductDel(AddProductDelegate d)
        {
            addProd += d;
        }
    }
}
