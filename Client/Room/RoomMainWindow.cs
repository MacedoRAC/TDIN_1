using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class RoomMainWindow : Form
    {
        private Dictionary<int, bool> OpenTablesCounter; //false not oppened, true oppened
        delegate void ControlsAddDelegate(Control lvItem);
        delegate void ChCommDelegate(Table item);
        IListSingleton listServer;
        AlterEventRepeater evRepeater;
        List<Table> tables;
        public int MaxNumberOfTables = 15;

        public RoomMainWindow()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            InitializeComponent();
            listServer = (IListSingleton)RemoteNew.New(typeof(IListSingleton));
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.AlterEvent += new AlterDelegate(evRepeater.Repeater);
            OpenTablesCounter = new Dictionary<int, bool>();


            for (int i = 0; i < MaxNumberOfTables; i++)
            {
                OpenTablesCounter.Add(i, false);
            }

            tables = listServer.GetTablesList();

        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        private void RoomMainWindow_Load(object sender, EventArgs e)
        {
            foreach (Table it in tables)
            {
                AddTablesToTablesContainer(it.ID);
                OpenTablesCounter.Remove(it.ID);
                OpenTablesCounter.Add(it.ID, true);
            }

            if (tables.Count >= MaxNumberOfTables)
                openTableButton.Enabled = false;
        }

        public void DoAlterations(Operation op, Table item)
        {
            ControlsAddDelegate ctrlsAdd;
            ChCommDelegate tableRemove;
            switch (op)
            {
                case Operation.New:
                    ctrlsAdd = new ControlsAddDelegate(TablesContainer.Controls.Add);
                    Button ctrlItem = CreatedNewTableButton(item.ID);
                    BeginInvoke(ctrlsAdd, new object[] { ctrlItem });
                    break;
                case Operation.Close:
                    tableRemove = new ChCommDelegate(RemoveTable);
                    BeginInvoke(tableRemove, new object[] { item });
                    break;
            }
        }

        private void RemoveTable(Table item)
        {
            OpenTablesCounter.Remove(item.ID);
            OpenTablesCounter.Add(item.ID, false);
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private int getLowestAvailableTable()
        {
            int i = 0;
            foreach (bool value in OpenTablesCounter.Values)
            {
                if (!value)
                {
                    return i;
                }
                i++;
            }

            //no tables available
            return -1;
        }

        private void OpenNewTable(object sender, EventArgs e)
        {
            int table = getLowestAvailableTable();
            if (table == -1)
                openTableButton.Enabled = false;
            else
            {
                OpenTablesCounter.Remove(table);
                OpenTablesCounter.Add(table, true);
                listServer.AddTable(new Table(table));
            }
        }

        private void AddTablesToTablesContainer(int tableId)
        {
            var newTable = CreatedNewTableButton(tableId);

            TablesContainer.Controls.Add(newTable);
        }

        private Button CreatedNewTableButton(int tableId)
        {
            OpenTablesCounter.Remove(tableId);
            OpenTablesCounter.Add(tableId, true);
            Button newTableBtn = new Button
            {
                Name = "table_" + OpenTablesCounter,
                Text = "Table " + OpenTablesCounter,
                Tag = tableId,
                Height = 30,
                FlatStyle = FlatStyle.Flat

            };
            newTableBtn.Click += new EventHandler(OpenTableDetails);

            return newTableBtn;
        }

        public void OpenTableDetails(object sender, EventArgs e)
        {
            tables = listServer.GetTablesList();

            int tableId = int.Parse(((Button)sender).Tag.ToString());
            Table table = tables[tableId];

            var tableDetails = new TableDetaislForm(table, listServer.GetMenu());
            tableDetails.Text = "Table Number " + (tableId + 1);
            tableDetails.Tag = tableId;
            tableDetails.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            listServer.AlterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);

            Application.Exit();
        }

        private void RoomMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.AlterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }
    }
}
