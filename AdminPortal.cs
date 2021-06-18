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
            this.SendToBack();
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
            this.SendToBack();
            bill.Show();
            
        }

        private void stockbtn_Click(object sender, EventArgs e)
        {
            Stock stk = new Stock();
            this.SendToBack();
            stk.Show();
            
        }

        private void staff_Click(object sender, EventArgs e)
        {
            try
            {
                Employee stf = new Employee();
                stf.Show();
                this.Hide();

            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
            
        }

        private void recordbtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Dispose();
            log.Show();
        }

        private void AdminPortal_Load(object sender, EventArgs e)
        {
            label4.Text = Login.UserName;
        }
    }
}
