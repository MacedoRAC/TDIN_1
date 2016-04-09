using System;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class TableDetaislForm : Form
    {
        protected Table Table;

        public TableDetaislForm(Table table)
        {
            Table = table;
            InitializeComponent();
        }

        public void MealDetailsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }
    }
}
