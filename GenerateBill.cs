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
    public partial class GenerateBill : Form
    {
        Login log = new Login();
        DataTable table;
            
        public GenerateBill()
        {
            InitializeComponent();
            AutoCompleteTextBox();


        }


        int count = 1;
        DataGridViewTextBoxColumn cmdbox = new DataGridViewTextBoxColumn();
        DataGridViewButtonColumn cmdbtn = new DataGridViewButtonColumn();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GenerateBill_Load(object sender, EventArgs e)
        {   label2.Text = Login.UserName;
            AutoCompleteTextBox();
            string user = Login.User;
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
        public void AutoCompleteTextBox()
        {
            AutoCompleteStringCollection comString = new AutoCompleteStringCollection();
            try
            {

                SqlConnection con = new SqlConnection(Configuration.conection);
                string query = "SELECT * FROM MedicineTable";
                string mName;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlDataReader myReader;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    mName = myReader.GetString("MedicineName");
                    comString.Add(mName);
                }
                myReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            textBox3.AutoCompleteCustomSource = comString;
        }
        public void SetValues()
        {
            string medName;
            string stock;
            string exDate;
            string status;
            string saleprice;

            try
            {
                string mName = textBox3.Text;
                SqlConnection con = new SqlConnection(Configuration.conection);

                string query = "SELECT MedicineName,SellingPrice FROM MedicineTable where MedicineName = '" + mName + "'";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Open();
                sda.Fill(ds, "MedicineTable");
                con.Close();
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Employees";
                dataGridView2.Columns.Add(cmdbox);
                dataGridView2.Columns.Add(cmdbtn);
                cmdbox.HeaderText = "Quantity";
                cmdbox.Name = "AddButton";
                cmdbtn.HeaderText = "Add Quantity";
                cmdbtn.Text = "Add ";
                cmdbtn.Name = "AddButton";
                cmdbtn.UseColumnTextForButtonValue = true;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
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
            this.Dispose(); }

        private void button5_Click(object sender, EventArgs e)
        {

            BillRecord rec = new BillRecord();
            rec.Show();
        }
        
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                if (e.ColumnIndex == 3 )
                {
                    count++;
                    dataGridView2.Rows[e.RowIndex].Cells["Quantity"].Value = count;
                }
            
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            count = 1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);

                Medicine med = new Medicine();

                string query = "SELECT MedicineName,SellingPrice FROM MedicineTable where MedicineName = '" + textBox3.Text + "'";
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
              //  dataGridView2.DataSource = dt;
                dataGridView2.DataMember = "MedicineTable";
                dataGridView2.Columns.Add(cmdbox);
                //dataGridView2.Columns.Add(cmdbtn);
                cmdbox.HeaderText = "Quantity";
                cmdbox.Name = "AddButton";
                cmdbtn.HeaderText = "AddQuantity";
                //cmdbtn.Text = "Add ";
                //cmdbtn.Name = "AddButton";
                //cmdbtn.UseColumnTextForButtonValue = true;
                dataGridView2.DataSource = dt;
                (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("MedicineName LIKE '%{0}%'", textBox3.Text);
                con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
    }
    
}
