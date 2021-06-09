using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace dashboard
{
    public partial class GenerateBill : Form
    {
        Login log = new Login();
        public GenerateBill()
        {
            InitializeComponent();
            
            
            
        }
     
      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GenerateBill_Load(object sender, EventArgs e)
        { // string user = log.getUser();
            string user = Login.User;
           // string user = Login.User;
            MessageBox.Show(Login.User);
            if (user == "Admin")
            {
                labelAdmin.Visible = true;
                labelStaff.Visible = false;

                //disable billing record button
                billingBtn.Enabled = true;
                billingBtn.Visible = true; 
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
                billingBtn.Visible = false;
                //disable staff button
                staffBtn.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Medicine m = new Medicine();
            m.Show();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Stock s = new Stock();
            s.Show();
            this.Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Barcode bar = new Barcode();
            bar.Show();
            
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Receipt re = new Receipt();
            re.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Staff stf = new Staff();
            stf.Show();
            this.Dispose();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
         /**   if(log.User == "Admin")
            {   
                AdminPortal adm = new AdminPortal();
                adm.Show();
            }
            if(log.User == "Staff")
            {
                StaffPortal stff = new StaffPortal();
                stff.Show();
            }
       **/ }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
    
}
