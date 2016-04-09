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
        Dictionary<string, string> products;

        public AddOrderDialog(Dictionary<string, string> products)
        {
            this.products = products;
            InitializeComponent();
            
            this.productsComboBox.DataSource = new BindingSource(products, null);
            this.productsComboBox.ValueMember = "Key";
            this.productsComboBox.DisplayMember = "Value";
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
