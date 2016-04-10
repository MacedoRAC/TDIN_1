﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class KitchenMainWindow : Form
    {
        IListSingleton listServer;
        OrderEventRepeater orderRepeater;
        delegate ListViewItem ListItemAddDelegate(ListViewItem lvItem);
        List<Table> Tables;

        public KitchenMainWindow()
        {
            listServer = (IListSingleton)RemoteNew.New(typeof(IListSingleton));
            orderRepeater = new OrderEventRepeater();
            orderRepeater.alterEvent += new OrderDelegate(DoAlterations);
            listServer.OrderEvent += new OrderDelegate(orderRepeater.Repeater);

            Tables = listServer.GetTablesList();

            InitializeComponent();
        }

        public void DoAlterations(Operation op, Order item, int tableId)
        {
            ListItemAddDelegate lvAdd;

            switch (op)
            {
                case Operation.New:
                    /*lvAdd = new ListItemAddDelegate(ListViewOrders.Items.Add);
                    ListViewItem lvItem = CreateNewListViewItem(item);
                    BeginInvoke(lvAdd, new object[] { lvItem });*/
                    break;
            }
        }

        public void KitchenMainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void Exit(object sender, EventArgs e)
        {
            listServer.OrderEvent -= new OrderDelegate(orderRepeater.Repeater);
            orderRepeater.alterEvent -= new OrderDelegate(DoAlterations);
            Application.Exit();
        }

        private void AttendOrder(object sender, EventArgs e)
        {

        }

        private void FinishOrder(object sender, EventArgs e)
        {

        }
    }
}