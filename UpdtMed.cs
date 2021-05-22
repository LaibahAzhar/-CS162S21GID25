using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace dashboard
{
    public partial class UpdtMed : UserControl
    {
        EditingMed edt = new EditingMed();
        public UpdtMed()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Controls.Add(edt);
            panel1.Controls["EditingMed"].BringToFront();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Controls.Add(edt);
            panel1.Controls["EditingMed"].BringToFront();
        }

        
    }
}
