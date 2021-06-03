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
    public partial class ViewMed : UserControl
    {
        public ViewMed()
        {
            InitializeComponent();
            //Table_Load();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            
        }
        public void Table_Load()
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
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ocurred");
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           /* string outputInfo = "";
            string[] keyWords = textBox1.Text.Split(' ');
            SqlConnection con = new SqlConnection(Configuration.conection);
            con.Open();
            Medicine med = new Medicine();

            string query = "SELECT * FROM MedTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (string word in keyWords)
            {
                if (outputInfo.Length == 0)
                {
                    outputInfo = "(MedicineName LIKE '%" + word + "%' OR MedicineID LIKE '%" + word + "%' OR Company LIKE '%" + word + "%' OR Status LIKE '%" + word + "%')";
                }
                else
                {
                    outputInfo += " AND (MedicineName LIKE '%" + word + "%' OR MedicineID LIKE '%" + word + "%' OR Company LIKE '%" + word + "%' OR Status LIKE '%" + word + "%')";
                }
            }

            //Applies the filter to the DataView
            //dt.RowFilter = outputInfo;
            con.Close();*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                dataGridView1.DataSource = dt;
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MedicineName LIKE '%{0}%'", textBox1.Text);
                con.Close();
            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
    }

        private void ViewMed_Load(object sender, EventArgs e)
        {
            Table_Load();
        }
    }
}
