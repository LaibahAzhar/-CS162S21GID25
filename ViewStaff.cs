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
    public partial class ViewStaff : UserControl
    {
        public ViewStaff()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                Staff stf= new Staff();

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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                Staff stf = new Staff();

                string query = "SELECT * FROM StaffTable";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox1.Text);
                con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
    }
}
