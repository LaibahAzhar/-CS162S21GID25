using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dashboard
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox3.Text == "Admin" && textBox1.Text == "1234")
            {
                AdminPortal admn = new AdminPortal();
                this.Hide();
                admn.Show();
                DataRetrieveFromMedicineDataBase();
            }
            if (textBox3.Text == "Staff" && textBox1.Text == "0000")
            {
                StaffPortal stff = new StaffPortal();
                this.Hide();
                stff.Show();
                DataRetrieveFromMedicineDataBase();
            }
            if((textBox3.Text != "Admin" && textBox1.Text != "1234") &&  (textBox3.Text != "Staff" && textBox1.Text != "0000"))
            {
                WarnMsg warn = new WarnMsg();
                warn.Show();
            }
        }
        public void DataRetrieveFromMedicineDataBase()
        {
            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                Medicine med = new Medicine();

                string query = "SELECT * FROM MedTable";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    med = new Medicine();
                    med.MedicineName = dt.Rows[i]["MedicineName"].ToString();
                    med.MedicineID = dt.Rows[i]["MedicineID"].ToString();
                    med.ChemicalName = dt.Rows[i]["ChemicalName"].ToString();
                    med.Stock = Int32.Parse(dt.Rows[i]["Stock"].ToString());
                    med.ManufacturingDate = DateTime.Parse(dt.Rows[i]["ManufacturingDate"].ToString());
                    med.ExpiryDate = DateTime.Parse(dt.Rows[i]["ExpiryDate"].ToString());
                    med.MarketPrice = Int32.Parse(dt.Rows[i]["MarketPrice"].ToString());
                    med.Company = dt.Rows[i]["Company"].ToString();
                    med.Status = dt.Rows[i]["Status"].ToString();
                    med.GetList().Add(med);
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Ocurred");
            }
        }
        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.Show();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            StaffPortal port = new StaffPortal();
            port.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            AdminRegistory a = new AdminRegistory();
            a.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
