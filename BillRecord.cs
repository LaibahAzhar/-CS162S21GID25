using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dashboard
{
    public partial class BillRecord : Form
    {
        public BillRecord()
        {
            InitializeComponent();
        }

        private void BillRecord_Load(object sender, EventArgs e)
        {
            label2.Text = Login.UserName;

            string user = Login.User;
            if (user == "Admin")
            {
                labelAdmin.Visible = true;
                labelStaff.Visible = false;

                //disable billing record button
                GenbillingBtn.Enabled = true;
                GenbillingBtn.Visible = true;
                //disable staff button
                staffBtn.Enabled = true;
                staffBtn.Visible = true;
            }
            //Disabling some functionality if a staff member is Signed In
            if (user == "Staff")
            {
                labelAdmin.Visible = false;
                labelStaff.Visible = true;

                //disable billing record button
                GenbillingBtn.Visible = false;
                //disable staff button
                staffBtn.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            med.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stock stk = new Stock();
            stk.Show();
        }

        private void GenbillingBtn_Click(object sender, EventArgs e)
        {
            GenerateBill bill = new GenerateBill();
            bill.Show();
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            Employee smp = new Employee();
            smp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
