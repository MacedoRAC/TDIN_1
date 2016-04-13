using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class BarMainWindow : Form
    {
        IListSingleton ListServer;
        OrderEventRepeater orderRepeater;
        delegate ListViewItem ListItemAddDelegate(ListViewItem lvItem);
        delegate void ListItemUpdateDelegate(ListViewItem lvItem);
        List<Table> Tables;

        public BarMainWindow()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            ListServer = (IListSingleton)RemoteNew.New(typeof(IListSingleton));
            orderRepeater = new OrderEventRepeater();
            orderRepeater.alterEvent += new OrderDelegate(DoAlterations);
            ListServer.BarEvent += new OrderDelegate(orderRepeater.Repeater);

            Tables = ListServer.GetTablesList();

            InitializeComponent();
        }

        public void DoAlterations(Operation op, Order item, int tableId)
        {
            ListItemAddDelegate lvAdd;
            ListItemUpdateDelegate lvUpdate;

            switch (op)
            {
                case Operation.New:
                    lvAdd = new ListItemAddDelegate(ListViewOrders.Items.Add);
                    ListViewItem lvItem = CreateNewListViewItem(item, (tableId+1).ToString());
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
                case Operation.Change:
                    lvUpdate = new ListItemUpdateDelegate(UpdateListViewItemOrderStatus);
                    ListViewItem updatedOrder = CreateNewListViewItem(item, (tableId+1).ToString());
                    BeginInvoke(lvUpdate, new object[] { updatedOrder });
                    break;
            }
        }

        private void UpdateListViewItemOrderStatus(ListViewItem lvItem)
        {
            for(int i = 0; i < ListViewOrders.Items.Count; i++)
            {
                if (ListViewOrders.Items[i].Text == lvItem.Text)
                {
                    ListViewOrders.Items[i] = lvItem;
                }
            }
        }

        public void BarMainWindow_Load(object sender, EventArgs e)
        {
            FillListViewOrders();
        }

        private void FillListViewOrders()
        {
            foreach (var table in Tables)
            {
                foreach (var order in table.orders)
                {
                    if (order.State != "Done" && order.Product.Bar)
                    {
                        var lvItem = CreateNewListViewItem(order, (table.ID + 1).ToString());
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
              ListServer.AttendOrder(int.Parse(((ListViewItem)item).Text));
            }
        }

        private void FinishOrder(object sender, EventArgs e)
        {
            var selectedOrders = ListViewOrders.SelectedItems;

            if (selectedOrders.Count == 0)
                return;

            foreach (var item in selectedOrders)
            {
                var orderId = ((ListViewItem)item).Text;
                var result = ListServer.FinishOrder(int.Parse(orderId));

                if (result != -1)
                    RemoveOrderFromListView(orderId);
            }
        }

        private void RemoveOrderFromListView(string orderId)
        {
            for (int i = 0; i < ListViewOrders.Items.Count; i++)
            {
                if (ListViewOrders.Items[i].Text == orderId)
                {
                    ListViewOrders.Items[i].Remove();
                }

            }
        }

        private ListViewItem CreateNewListViewItem(Order order, string tableId)
        {
            string[] row = { order.Id.ToString(), order.Quantity.ToString(), order.Product.Description, tableId, order.State.ToString() };

            return new ListViewItem(row);
        }
    }
}
