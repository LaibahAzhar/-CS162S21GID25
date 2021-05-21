using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class AdminRegistory : Form
    {
        public AdminRegistory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            AdminRegistory rgstr = new AdminRegistory();
            rgstr.Hide();
        }
    }
}
