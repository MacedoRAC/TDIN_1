using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class TableDetaislForm : Form
    {
        protected Table Table;

        public TableDetaislForm(Table table)
        {
            Table = table;
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
            var listOfProducts = new Dictionary<string, string>()
            {
                { "1", "Potatoes" },
                { "2", "Soda" }
            };
            var orderDialog = new AddOrderDialog(listOfProducts);
            orderDialog.ShowDialog();
        }
    }
}
