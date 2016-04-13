using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server.Payment
{
    public partial class ServerTableDetaislForm : Form
    {
        protected Table Table;

        public ServerTableDetaislForm(Table table)
        {
            Table = table;
            InitializeComponent();
        }

        public void ServerTableDetailsForm_Load(object sender, EventArgs e)
        {
            foreach(var order in Table.orders)
            {
                var lvItem = CreateNewListViewItem(order);
                ListViewOrders.Items.Add(lvItem);
            }

            labelTotalPriceTable.Text = "Total: " + Table.totalPrice().ToString("C", CultureInfo.CreateSpecificCulture("pt-PT"));
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        private ListViewItem CreateNewListViewItem(Order order)
        {
            var totalPrice = order.Product.UnitPrice * order.Quantity + order.Product.IVA/100;
            string[] row = { order.Quantity.ToString(), order.Product.Description, order.Product.UnitPrice.ToString("C", CultureInfo.CreateSpecificCulture("pt-PT")), order.Product.IVA.ToString() + "%", totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("pt-PT")) };

            return new ListViewItem(row);
        }

        private void PrintReceipt(object sender, EventArgs e)
        {
            var path = "Receipt_Table " + (Table.ID + 1) + "_" + RandomString(6) + ".txt";

            List<string> linesList = new List<string>();
            linesList.Add("RECEIPT");
            linesList.Add("Table " + (Table.ID+1).ToString());
            linesList.Add(DateTime.Now.ToString());
            linesList.Add("\n\n");

            foreach (Order item in Table.orders)
            {
                StringBuilder sb = new StringBuilder();
                var quantity = item.Quantity;
                var unit = item.Product.UnitPrice;
                var iva = item.Product.IVA;
                var total = quantity * unit * (iva / 100);

                var line = sb.Append(quantity).Append(" ").
                                                Append(item.Product.Description).
                                                Append(" (IVA ").Append(iva).Append("%) ").
                                                Append(quantity).Append("*").
                                                Append(unit.ToString("C", CultureInfo.CreateSpecificCulture("pt-PT"))).
                                                Append("  ").
                                                Append(total.ToString("C", CultureInfo.CreateSpecificCulture("pt-PT")));

                linesList.Add(sb.ToString());
            }

            linesList.Add("\n\n");
            linesList.Add("Total: " + Table.totalPrice().ToString("C", CultureInfo.CreateSpecificCulture("pt-PT")));
            File.WriteAllLines(@path, linesList);

            System.Diagnostics.Process.Start(@path);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private static string RandomString(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
