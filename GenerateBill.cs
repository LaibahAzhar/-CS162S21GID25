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
        DataTable dt = new DataTable();

        public GenerateBill()
        {
            InitializeComponent();
            AutoCompleteTextBox();


        }


        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GenerateBill_Load(object sender, EventArgs e)
        {
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
            DataSet dataSet = new DataSet();
            DataColumn dc1 = new DataColumn("MedicineName");
            DataColumn dc2 = new DataColumn("Quantity");
            DataColumn dc3 = new DataColumn("Price");
            DataGridViewButtonColumn cmdbtn = new DataGridViewButtonColumn();
            dc1.ReadOnly = true;
            dc1.MaxLength = 200;
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dataSet.Tables.Add(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns.Add(cmdbtn);
            cmdbtn.HeaderText = "DeleteEntry";
            cmdbtn.Text = "Delete ";
            cmdbtn.UseColumnTextForButtonValue = true;
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
            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                string query = "SELECT MedicineName,SellingPrice FROM MedicineTable where MedicineName = '" + textBox3.Text + "'";
                string mName="";
                int price=0;
                DateTime expiryDate;
                int stock;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlDataReader myReader;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader.GetString("MedicineName") == textBox3.Text)
                    {
                        mName = myReader.GetString("MedicineName");
                        price = Int32.Parse(myReader.GetString("SellingPrice"));
                        //expiryDate = DateTime.Parse(myReader.GetString("ExpiryDate"));
                   //     stock = Int32.Parse(myReader.GetString("Stock"));
                        break;
                    }
                }
                myReader.Close();
                con.Close();
               
                DataRow dr = dt.NewRow();
               
                dt.Rows.Add(mName,"1",price);
                   
                

            }
            catch (Exception ex)
            {
                string message = ex.Message;


            }
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

        }
        
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    dt.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch
            {
                MessageBox.Show("No data exit in this row");
            }
            
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
              //  SqlConnection con = new SqlConnection(Configuration.conection);

              //  Medicine med = new Medicine();

              //  string query = "SELECT MedicineName,SellingPrice FROM MedicineTable where MedicineName = '" + textBox3.Text + "'";
              //  con.Open();
              //  SqlDataAdapter sda = new SqlDataAdapter(query, con);

              //  DataTable dt = new DataTable();
              //  sda.Fill(dt);
              ////  dataGridView2.DataSource = dt;
              //  dataGridView2.DataMember = "MedicineTable";
              //  dataGridView2.Columns.Add(cmdbox);
              //  //dataGridView2.Columns.Add(cmdbtn);
              //  cmdbox.HeaderText = "Quantity";
              //  cmdbox.Name = "AddButton";
              //  cmdbtn.HeaderText = "AddQuantity";
              //  //cmdbtn.Text = "Add ";
              //  //cmdbtn.Name = "AddButton";
              //  //cmdbtn.UseColumnTextForButtonValue = true;
              //  dataGridView2.DataSource = dt;
              //  (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("MedicineName LIKE '%{0}%'", textBox3.Text);
              //  con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
        public int CalculateTotal()
        {
           
                int total = 0;
                int price = 0;
                int quantity = 0;
            try
            {
                MessageBox.Show(dataGridView2.RowCount.ToString());
                for (int i = 1; i < dataGridView2.RowCount ; i++)
                {
                    quantity = Int32.Parse(dataGridView2..Cells[1].Value.ToString());
                    price = Int32.Parse(dataGridView2.SelectedRows[i].Cells[2].Value.ToString());
                    total = total + (price * quantity);
                }
                int discount = (Int32.Parse(textBox4.Text) * total) / 100;
            } catch (Exception ex)
            {
                string message = ex.Message;
            }
            return total;
        }

        private void dataGridView2_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //int total = CalculateTotal();
            //textBox5.Text = total.ToString();
        }
    }
    
}
