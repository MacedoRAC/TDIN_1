using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class TableDetaislForm : Form
    {
        protected Table Table;
        protected Dictionary<string, Product> Products;

        public TableDetaislForm(Table table, Dictionary<string, Product> products)
        {
            Table = table;
            Products = products;
            InitializeComponent();
        }

        public void MealDetailsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenNewOrderDialog(object sender, EventArgs e)
        {
            var orderDialog = new AddOrderDialog(Products);
            orderDialog.ShowDialog();
        }
    }
}
