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
    public partial class AdminRegistory : Form
    {
        public AdminRegistory()
        {
            InitializeComponent();
        }
        private string name;
        private string mail;
        private string userName;
        private string password;
        public string Name
        {
            get; set;
        }
        public string Mail
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nme;
            string mail;
            string uName;
            string pssword;
            string cPssword;
            nme = textBox1.Text;
            mail = textBox2.Text;
            pssword = textBox4.Text;
            uName = textBox3.Text;
            cPssword = textBox5.Text;
            SqlConnection con = new SqlConnection(Configuration.conection);
            if (pssword == cPssword)
            {
                try
                {
                    con.Open();

                    string insertCommand = "INSERT INTO AdminLogin_Table (Name,Email,UserName,Password) VALUES (@Name,@Email,@UserName,@Password)";
                    using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", nme);
                        cmd.Parameters.AddWithValue("@Email", mail);
                        cmd.Parameters.AddWithValue("@UserName", uName);
                        cmd.Parameters.AddWithValue("@Password", pssword);

                        cmd.ExecuteNonQuery();


                    }
                    con.Close();
                    this.Hide();
                    new Login().Show();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            else
            {
                MessageBox.Show("Password Doesn't Match");
            }
        }
               

      
    }
}
