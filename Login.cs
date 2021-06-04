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
        private string user;
        public string User { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Configuration.conection);
            con.Open();
            string query = "SELECT * FROM AdminLogin_Table";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
                if (textBox3.Text == dt.Rows[0]["UserName"].ToString() && textBox1.Text == dt.Rows[0]["Password"].ToString())
                {
                AdminPortal admn = new AdminPortal();
                this.Dispose();
                    admn.Show();
                User = "Admin";
            }
            else
            {
                //WarnMsg warn = new WarnMsg();
                //   warn.Show();
            }
            //{
            //    AdminPortal admn = new AdminPortal();
            //    this.Dispose();
            //    admn.Show();
           

            //}
            if (textBox3.Text == "Staff" && textBox1.Text == "0000")
            {
                StaffPortal stff = new StaffPortal();
                this.Dispose();
                stff.Show();
               User = "Staff";

            }

            //if(user !=" Admin" && user != "Staff")
            //{
            //    WarnMsg warn = new WarnMsg();
            //    warn.Show();
            //}
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

        private void Login_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Configuration.conection);
            con.Open();
            string query = "SELECT * FROM AdminLogin_Table";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            int i = dt.Tables[0].Rows.Count;
            if (i>0)
            {
                //MessageBox.Show("Done");
                label3.Visible = false;
                label6.Visible = false;
                panel4.Visible = false;
            }
            con.Close();
        }
        //public bool DoesTableContainRows(string tableName, SqlConnection connection)
        //{
        //    SqlCommand command = new SqlCommand($"Select * from tableName",connection);
        //    SqlDataReader resultReader = new SqlDataReader(command.ExecuteReader());
        //    resultReader = command.ExecuteReader();
        //    // check whether or not a row was returned
        //    bool containRows = resultReader.Read();
        //    resultReader.Close();
        //    return containRows;
        //}
    }
}
