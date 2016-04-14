using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Server.Payment
{
    public partial class PaymentMainWindow : Form
    {
        delegate void ControlsAddDelegate(Control lvItem);
        delegate void ChCommDelegate(Table item);
        ListSingleton listServer;
        AlterEventRepeater evRepeater;
        List<Table> tables;

        public PaymentMainWindow()
        {
            InitializeComponent();
            listServer = (ListSingleton) Activator.GetObject( typeof(ListSingleton), "tcp://localhost:9000/Server/ListServer");
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.PaymentEvent += new AlterDelegate(evRepeater.Repeater);


            tables = listServer.GetPaymentList();
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        private void PaymentMainWindow_Load(object sender, EventArgs e)
        {
            foreach (Table it in tables)
            {
                AddTablesToTablesContainer(it.ID);
            }
        }

        public void DoAlterations(Operation op, Table item)
        {
            ControlsAddDelegate ctrlsAdd;
            ChCommDelegate tableRemove;
            switch (op)
            {
                case Operation.Close:
                    ctrlsAdd = new ControlsAddDelegate(TablesContainer.Controls.Add);
                    Button ctrlItem = CreatedNewTableButton(item.ID);
                    BeginInvoke(ctrlsAdd, new object[] { ctrlItem });
                    break;
                case Operation.Finish:
                    tableRemove = new ChCommDelegate(RemoveTable);
                    BeginInvoke(tableRemove, new object[] { item });
                    break;
            }
        }

        private void RemoveTable(Table item)
        {
            tables.Remove(item);
            RemoveTableFromTablesContainer(item.ID);
        }        

        private void AddTablesToTablesContainer(int tableId)
        {
            var newTable = CreatedNewTableButton(tableId);

            TablesContainer.Controls.Add(newTable);
        }

        private Button CreatedNewTableButton(int tableId)
        {
            Button newTableBtn = new Button
            {
                Name = "table_" + (tableId + 1),
                Text = "Table " + (tableId + 1),
                Tag = tableId,
                Height = 30,
                FlatStyle = FlatStyle.Flat

            };
            newTableBtn.Click += new EventHandler(OpenTableDetails);

            return newTableBtn;
        }

        public void OpenTableDetails(object sender, EventArgs e)
        {
            tables = listServer.GetPaymentList();

            int tableId = int.Parse(((Button)sender).Tag.ToString());
            Table table = tables[tableId];

            var tableDetails = new ServerTableDetaislForm(table);
            tableDetails.Text = "Payment of Table " + (tableId + 1);
            tableDetails.Tag = tableId;

            using (tableDetails)
            {
                if (tableDetails.ShowDialog() == DialogResult.OK)
                {
                    var result = listServer.ToPayment(table.ID);

                    if (result != -1)
                    {
                        RemoveTableFromTablesContainer(table.ID);
                    }
                }
            }
        }

        private void RemoveTableFromTablesContainer(int tableID)
        {
            for (int i = 0; i < TablesContainer.Controls.Count; i++)
            {
                if (TablesContainer.Controls[i].Tag.ToString().Equals(tableID.ToString()))
                    TablesContainer.Controls.RemoveAt(i);
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
