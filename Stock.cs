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
    public partial class Stock : Form
    {
        ViewMed viewM = new ViewMed();
        UpdtMed updt = new UpdtMed();
        EditingMed edt = new EditingMed();
        public Stock()
        {
            InitializeComponent();
            //fillCombo();
            AutoCompleteText();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(viewM);
            panel3.Controls["ViewMed"].BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Remove(viewM);
            panel3.Controls.Remove(updt);
        }

        private void updt_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(updt);
            panel3.Controls["UpdtMed"].BringToFront();

          
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medicine m = new Medicine();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateBill b = new GenerateBill();
            b.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff stf = new Staff();
            stf.Show();
        }
        public void AutoCompleteText()
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
            }catch(Exception ex)
            {
                string message = ex.Message;
            }
            textBox8.AutoCompleteCustomSource = comString;
        }
        public void SetValues()
        {
            try { 
            string mName=textBox8.Text;
            SqlConnection con = new SqlConnection(Configuration.conection);
            
            string query = "SELECT * FROM MedicineTable where MedicineName = '"+mName+"'";

            SqlCommand sda = new SqlCommand(query, con);
            SqlDataReader dr;
                con.Open();
                dr = sda.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                textBox1.Text = (dr["MedicineName"].ToString());
                textBox4.Text = (dr["MedicineID"].ToString());
                    textBox3.Text = (dr["ChemicalName"].ToString());
                    textBox6.Text = (dr["Stock"].ToString());
                    textBox5.Text = (dr["MarketPrice"].ToString());
                    textBox2.Text = (dr["ManufacturingDate"].ToString());
                    textBox9.Text = (dr["ExpiryDate"].ToString());
                    textBox10.Text = (dr["Company"].ToString());
                    textBox11.Text = (dr["Status"].ToString());
                    textBox7.Text = (dr["SellingPrice"].ToString());

                }
                dr.Close();
            con.Close();
        }
            catch(Exception ex)
            {
                string message = ex.Message;
            }

         }
        private void setNullValuesToTextBoxes()
        {
            textBox1.Text = null;
            textBox4.Text = null;
            textBox3.Text = null;
            textBox6.Text = null;
            textBox5.Text = null;
            textBox2.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox7.Text = null;
            
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string mName = textBox8.Text;
            SqlConnection con = new SqlConnection(Configuration.conection);
            con.Open();
            string query = "SELECT * FROM MedicineTable where MedicineName = '" + mName + "'";

            SqlCommand sda = new SqlCommand(query, con);
           
            if (!(textBox8.Text == mName))
            {
                setNullValuesToTextBoxes();
            }
            else
            {
                SetValues();
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int stk;
            int mPrice;
            int sPrice;
            stk = Int32.Parse(textBox6.Text);
              mPrice= Int32.Parse(textBox5.Text);
            sPrice = Int32.Parse(textBox7.Text);

            SqlConnection con = new SqlConnection(Configuration.conection);
            try
            {
                con.Open();

                string insertCommand = "UPDATE MedicineTable SET (Stock,MarketPrice,SellingPrice) VALUES (@Stock,@MarketPrice,@SellingPrice ) where '"+textBox1.Text+"'";
                using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Stock", stk);
                    cmd.Parameters.AddWithValue("@MarketPrice", mPrice);
                    cmd.Parameters.AddWithValue("@SellingPrice", sPrice);

                    cmd.ExecuteNonQuery();


                }
                con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            setNullValuesToTextBoxes();
        }
    }
}
