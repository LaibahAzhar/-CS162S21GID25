using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class EdtngEmp : UserControl
    {
        UpdtEmp upd = new UpdtEmp();

        public EdtngEmp()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(upd);
            panel1.Controls["UpdtEmp"].BringToFront();
        }
    }
}
