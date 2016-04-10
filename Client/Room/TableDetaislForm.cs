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
        IListSingleton listServer;
        OrderEventRepeater orderRepeater;
        delegate ListViewItem ListItemAddDelegate(ListViewItem lvItem);

        public TableDetaislForm(Table table, Dictionary<string, Product> products)
        {
            Table = table;
            Products = products;
            InitializeComponent();

            listServer = (IListSingleton)RemoteNew.New(typeof(IListSingleton));
            orderRepeater = new OrderEventRepeater();
            orderRepeater.alterEvent += new OrderDelegate(DoAlterations);
            listServer.OrderEvent += new OrderDelegate(orderRepeater.Repeater);
        }

        public void DoAlterations(Operation op, Order item, int tableId)
        {
            ListItemAddDelegate lvAdd;

            switch (op)
            {
                case Operation.New:
                    lvAdd = new ListItemAddDelegate(ListViewOrders.Items.Add);
                    ListViewItem lvItem = CreateNewListViewItem(item);
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
            }
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
            listServer.OrderEvent -= new OrderDelegate(orderRepeater.Repeater);
            orderRepeater.alterEvent -= new OrderDelegate(DoAlterations);
            Close();
        }

        private void OpenNewOrderDialog(object sender, EventArgs e)
        {
            var orderDialog = new AddOrderDialog(Products);

            using (orderDialog)
            {
                if (orderDialog.ShowDialog() == DialogResult.OK)
                {
                    var order = new Order(orderDialog.GetQuantity(), orderDialog.GetProduct());
                    listServer.AddOrder(order, int.Parse(this.Tag.ToString()));
                }
            }
        }

        private ListViewItem CreateNewListViewItem(Order order)
        {
            string[] row = { order.Quantity.ToString(), order.Product.Description, order.State.ToString() };

            return new ListViewItem(row);
        }
    }
}
