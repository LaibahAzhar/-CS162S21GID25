using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class AdminPortal : Form
    {   
        public AdminPortal()
        {
          
            InitializeComponent();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            this.Dispose();
            med.Show();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void billingBtn_Click(object sender, EventArgs e)
        {
            GenerateBill bill = new GenerateBill();
            this.Dispose();
            bill.Show();
        }

        private void stockbtn_Click(object sender, EventArgs e)
        {
            Stock stk = new Stock();
            this.Dispose();
            stk.Show();
        }

        private void staff_Click(object sender, EventArgs e)
        {
            Staff stf = new Staff();
            this.Hide();
            stf.Show();
        }

        private void recordbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
