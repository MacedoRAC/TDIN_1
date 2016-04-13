using System;
using System.Windows.Forms;

namespace Server.Payment
{
    public partial class ServerTableDetaislForm : Form
    {
        protected Table Table;

        public ServerTableDetaislForm(Table table)
        {
            Table = table;
        }

        public void TableDetailsForm_Load(object sender, EventArgs e)
        {
            foreach(var order in Table.orders)
            {
                var lvItem = CreateNewListViewItem(order);
                ListViewOrders.Items.Add(lvItem);
            }
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        private ListViewItem CreateNewListViewItem(Order order)
        {
            var totalPrice = order.Product.UnitPrice * order.Quantity;
            string[] row = { order.Quantity.ToString(), order.Product.Description, order.Product.UnitPrice.ToString(), totalPrice.ToString() };

            return new ListViewItem(row);
        }

        private void PrintReceipt(object sender, EventArgs e)
        {

        }
    }
}
