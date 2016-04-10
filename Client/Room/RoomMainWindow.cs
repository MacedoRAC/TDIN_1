using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class RoomMainWindow : Form
    {
        private int OpenTablesCounter { get; set; } = 0;
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
                AddTablesToTablesContainer();
            }

            OpenTablesCounter = tables.Count;

            if (OpenTablesCounter >= MaxNumberOfTables)
                openTableButton.Enabled = false;
        }

        public void DoAlterations(Operation op, Table item)
        {
            ControlsAddDelegate ctrlsAdd;

            switch (op)
            {
                case Operation.New:
                    ctrlsAdd = new ControlsAddDelegate(TablesContainer.Controls.Add);
                    Button ctrlItem = CreatedNewTableButton();
                    BeginInvoke(ctrlsAdd, new object[] { ctrlItem });
                    break;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenNewTable(object sender, EventArgs e)
        {
            listServer.AddTable(new Table(OpenTablesCounter));

            if (OpenTablesCounter >= MaxNumberOfTables)
                openTableButton.Enabled = false;
        }

        private void AddTablesToTablesContainer()
        {
            var newTable = CreatedNewTableButton();

            TablesContainer.Controls.Add(newTable);
        }

        private Button CreatedNewTableButton ()
        {
            OpenTablesCounter++;
            Button newTableBtn =  new Button
            {
                Name = "table_" + OpenTablesCounter,
                Text = "Table " + OpenTablesCounter,
                Tag = OpenTablesCounter-1,
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
            tableDetails.Text = "Table Number " + (tableId+1);
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
