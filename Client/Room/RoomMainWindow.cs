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
        delegate void ChCommDelegate(Order item);
        IListSingleton listServer;
        AlterEventRepeater evRepeater;
        List<Order> orders;

        public RoomMainWindow()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            InitializeComponent();
            listServer = (IListSingleton)RemoteNew.New(typeof(IListSingleton));
            orders = listServer.GetList();
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.alterEvent += new AlterDelegate(evRepeater.Repeater);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        
        private void RoomMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.alterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }

        public void DoAlterations(Operation op, Order item)
        {
            ControlsAddDelegate ctrlsAdd;
            //ChCommDelegate chComm;

            switch (op)
            {
                case Operation.New:
                    ctrlsAdd = new ControlsAddDelegate(TablesContainer.Controls.Add);
                    Button ctrlItem = CreatedNewTableButton();
                    BeginInvoke(ctrlsAdd, new object[] { ctrlItem });
                    break;
                /*case Operation.Change:
                    chComm = new ChCommDelegate(ChangeAItem);
                    BeginInvoke(chComm, new object[] { item });
                    break;*/
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RoomMainWindow_Load(object sender, EventArgs e)
        {
            foreach (Order it in orders)
            {
                AddTableToTablesContainer();
            }
        }

        private void OpenNewTable(object sender, EventArgs e)
        {
            listServer.AddItem(new Order(OpenTablesCounter + 1));
            //AddTableToTablesContainer();
        }

        private void AddTableToTablesContainer()
        {
            var newTable = CreatedNewTableButton();

            TablesContainer.Controls.Add(newTable);
        }

        private Button CreatedNewTableButton ()
        {
            OpenTablesCounter++;
            return new Button
            {
                Name = "table_" + OpenTablesCounter,
                Text = "Table " + OpenTablesCounter,
                Height = 30,
                FlatStyle = FlatStyle.Flat

            };
        }

        private void exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
