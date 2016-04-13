using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting;
using System.Threading;
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
        delegate void ListItemUpdateDelegate(ListViewItem lvItem);

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
            ListItemUpdateDelegate lvUpdate;

            switch (op)
            {
                case Operation.New:
                    lvAdd = new ListItemAddDelegate(ListViewOrders.Items.Add);
                    ListViewItem lvItem = CreateNewListViewItem(item);
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
                case Operation.Change:
                    lvUpdate = new ListItemUpdateDelegate(UpdateListViewItemOrderStatus);
                    ListViewItem updatedOrder = CreateNewListViewItem(item);
                    BeginInvoke(lvUpdate, new object[] { updatedOrder });
                    break;
                case Operation.Ready:
                    lvUpdate = new ListItemUpdateDelegate(UpdateListViewItemOrderStatus);
                    ListViewItem readyOrder = CreateNewListViewItem(item);
                    BeginInvoke(lvUpdate, new object[] { readyOrder });
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

        private void UpdateListViewItemOrderStatus(ListViewItem lvItem)
        {
            for (int i = 0; i < ListViewOrders.Items.Count; i++)
            {
                if (ListViewOrders.Items[i].Text == lvItem.Text)
                {
                    ListViewOrders.Items[i] = lvItem;

                    // flash row
                    BackgroudFlash(i);
                }
            }
        }

        private void BackgroudFlash(int i)
        {
            ListViewOrders.Items[i].BackColor = Color.LightGreen;
            ListViewOrders.Refresh();

            Thread.Sleep(1000);

            ListViewOrders.Items[i].BackColor = Color.White;
            ListViewOrders.Refresh();
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
                    int id = int.Parse(Tag.ToString());
                    listServer.AddOrder(orderDialog.GetQuantity(), orderDialog.GetProduct(), id);
                }
            }
        }

        private ListViewItem CreateNewListViewItem(Order order)
        {
            string[] row = { order.Id.ToString(), order.Quantity.ToString(), order.Product.Description, order.State.ToString() };

            return new ListViewItem(row);
        }

        private void Checkout(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            CloseWindow(sender, e);
        }
    }
}
