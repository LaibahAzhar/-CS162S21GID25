using System;
using System.Windows.Forms;

namespace dashboard
{
    public partial class UpdtEmp : UserControl
    {
        EdtngEmp edit = new EdtngEmp();
        public UpdtEmp()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Controls.Add(edit);
            panel1.Controls["EdtngEmp"].BringToFront();
        }
    }
}
