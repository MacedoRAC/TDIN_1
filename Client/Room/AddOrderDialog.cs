using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class AddOrderDialog : Form
    {
        Dictionary<string, Product> products;
        int Quantity;
        Product Product;

        public AddOrderDialog(Dictionary<string, Product> products)
        {
            this.products = products;
            InitializeComponent();
            
            this.productsComboBox.DataSource = new BindingSource(products, null);
            this.productsComboBox.ValueMember = "Value";
            this.productsComboBox.DisplayMember = "Key";
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public Product GetProduct()
        {
            return Product;
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void Add(object sender, EventArgs e)
        {
            Quantity = Convert.ToInt32(quantitySelector.Value);
            Product = ((KeyValuePair<string, Product>)productsComboBox.SelectedItem).Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
