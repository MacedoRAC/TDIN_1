using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Payment
{
    public partial class PaymentMainWindow : Form
    {
        public PaymentMainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
