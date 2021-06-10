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
        public static string User;
        public static string UserName;
        public Login()
        {
            InitializeComponent();

        }
         
      // static public string User { get; }
            public void setUser(string person)
        {
            if(person=="Admin")
            {
                Login.User = "Admin";
            }
            if(person=="Staff")
            {
                Login.User = "Staff";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(Configuration.conection);
            con.Open();
            string query = "SELECT * FROM AdminLogin_Table";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

           
            
               /* if (!(textBox3.Text != dt.Rows[0]["UserName"].ToString() && textBox1.Text != dt.Rows[0]["Password"].ToString()))
                {
                User = "Admin";
                    this.Dispose();
                    AdminPortal admn = new AdminPortal();
                    admn.Show();

                }
                else
                {
                    MessageBox.Show("Invalid Details");
                }
            
            con.Close();*/

            if (textBox3.Text == dt.Rows[0]["UserName"].ToString() && textBox1.Text == dt.Rows[0]["Password"].ToString())
            {
                setUser("Admin");
                this.Dispose();
                UserName = dt.Rows[0]["UserName"].ToString();
                AdminPortal admn = new AdminPortal();
                admn.Show();
                success = true;
                MessageBox.Show(User);
            }
            if (textBox3.Text != dt.Rows[0]["UserName"].ToString() && textBox1.Text != dt.Rows[0]["Password"].ToString())
            {
                
                string query1 = "SELECT * FROM StaffTable";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    MessageBox.Show(dt1.Rows[i]["UserName"].ToString());
                    if (textBox3.Text == dt1.Rows[i]["UserName"].ToString() && textBox1.Text == dt1.Rows[i]["Password"].ToString())                    {

                        StaffPortal staff = new StaffPortal();
                        setUser("Staff");
                        success = true;
                        UserName = dt.Rows[i]["UserName"].ToString();
                        this.Dispose();
                        staff.Show();

                        break;
                    }
                }
                if (success == false)
                {
                    WarnMsg warn = new WarnMsg();
                    warn.Show();
                }
            }
            //{
            //    AdminPortal admn = new AdminPortal();
            //    this.Dispose();
            //    admn.Show();


            //}

            string query1 = "SELECT * FROM StaffLoginTable";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            DataSet dts = new DataSet();
            con.Open();
            sda1.Fill(dt1);

            
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    if (textBox3.Text == dt.Rows[j]["UserName"].ToString() && textBox1.Text == dt.Rows[j]["Password"].ToString())
                    { 
                        StaffPortal stff = new StaffPortal();
                        User = "Staff";
                        this.Dispose();
                        stff.Show();

                    }
                }
            
            con.Close();

            /* string query1 = "SELECT * FROM StaffLoginTable";
             SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
             DataTable dt1 = new DataTable();
             sda.Fill(dt1);
             for (int i = 0; i < dt1.Rows.Count; i++)
             {
                 if (textBox3.Text == dt.Rows[i]["UserName"].ToString() && textBox1.Text == dt.Rows[i]["Password"].ToString())
                 {
                     StaffPortal stff = new StaffPortal();
                     setUser("Staff");
                     this.Dispose();
                     stff.Show();
                     break;
                 }
             }
            */
            //if(user !=" Admin" && user != "Staff")
            //{
            //    WarnMsg warn = new WarnMsg();
            //    warn.Show();
            //}
        /*    StaffPortal stff = new StaffPortal();
            setUser("Staff");
            this.Dispose();
            stff.Show();
*/        }

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
