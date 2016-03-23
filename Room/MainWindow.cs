using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room
{
    public partial class MainWindow : Form
    {
        private int OpenTablesCounter { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void OpenNewTable(object sender, EventArgs e)
        {
            OpenTablesCounter++;
            Button newTable = new Button
            {
                Name = "table_" + OpenTablesCounter,
                Text = "Table " + OpenTablesCounter,
                Height = 30,
                FlatStyle = FlatStyle.Flat
                
            };
            
            TablesContainer.Controls.Add(newTable);
        }

        private void exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
