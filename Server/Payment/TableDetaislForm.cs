using System;
using System.Threading;
using System.Windows.Forms;

namespace Server.Payment
{
    public partial class TableDetaislForm : Form
    {
        protected Table Table;

        public TableDetaislForm(Table table)
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
            string[] row = { order.Id.ToString(), order.Quantity.ToString(), order.Product.Description, order.State.ToString() };

            return new ListViewItem(row);
        }

        private void PrintReceipt(object sender, EventArgs e)
        {

        }
    }
}
