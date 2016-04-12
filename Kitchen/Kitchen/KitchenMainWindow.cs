using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class KitchenMainWindow : Form
    {
        IListSingleton ListServer;
        OrderEventRepeater orderRepeater;
        delegate ListViewItem ListItemAddDelegate(ListViewItem lvItem);
        List<Table> Tables;

        public KitchenMainWindow()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            ListServer = (IListSingleton)RemoteNew.New(typeof(IListSingleton));
            orderRepeater = new OrderEventRepeater();
            orderRepeater.alterEvent += new OrderDelegate(DoAlterations);
            ListServer.KitchenEvent += new OrderDelegate(orderRepeater.Repeater);

            Tables = ListServer.GetTablesList();

            InitializeComponent();
        }

        public void DoAlterations(Operation op, Order item, int tableId)
        {
            ListItemAddDelegate lvAdd;

            switch (op)
            {
                case Operation.New:
                    lvAdd = new ListItemAddDelegate(ListViewOrders.Items.Add);
                    ListViewItem lvItem = CreateNewListViewItem(item, (tableId+1).ToString());
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
            }
        }

        public void KitchenMainWindow_Load(object sender, EventArgs e)
        {
            foreach(var table in Tables)
            {
                foreach(var order in table.orders)
                {
                    if(order.State != "Done" && !order.Product.Bar)
                    {
                        var lvItem = CreateNewListViewItem(order, (table.ID+1).ToString());
                        ListViewOrders.Items.Add(lvItem);
                    }
                }
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            ListServer.OrderEvent -= new OrderDelegate(orderRepeater.Repeater);
            orderRepeater.alterEvent -= new OrderDelegate(DoAlterations);
            Application.Exit();
        }

        private void AttendOrder(object sender, EventArgs e)
        {
            var selectedOrders = ListViewOrders.SelectedItems;

            if (selectedOrders.Count == 0)
                return;

            foreach (var item in selectedOrders)
            {
                //ListServer.AttendOrder((ListViewItem)item.Text);
            }
        }

        private void FinishOrder(object sender, EventArgs e)
        {

        }

        private ListViewItem CreateNewListViewItem(Order order, string tableId)
        {
            string[] row = { "0", order.Quantity.ToString(), order.Product.Description, tableId, order.State.ToString() };

            return new ListViewItem(row);
        }
    }
}
