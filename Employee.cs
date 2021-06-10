using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;


namespace dashboard
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        ViewStaff vew = new ViewStaff();
       // EdtngEmp upd = new EdtngEmp();
        WarnMsg warning = new WarnMsg();
        private void button1_Click(object sender, EventArgs e)
        {
            GenerateBill bill = new GenerateBill();
            this.Hide();
            bill.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medicine med = new Medicine();
            this.Hide();
            med.Show();

        }

        private void stockBtn_Click(object sender, EventArgs e)
        {
            Stock stk = new Stock();
            this.Hide();
            stk.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPortal port = new AdminPortal();
            port.Show();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void setNullValuesToTextBoxes()
        {
            textBoxName.Text = null;
            textBoxEmail.Text = null;
            textBoxSalary.Text = null;
            textBoxBonus.Text = null;
            textBoxworkHrs.Text = null;
            maskedTextBoxContact.Text = null;
            maskedTextBoxCNIC.Text = null;
            textBoxPassword.Text = null;
            textBoxUserName.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }
        private bool CheckNull()
        {
            bool x = false;
            if (textBoxName.Text == "")
            {
                warnName.Enabled = true;
                x = true;
            }
            if (textBoxEmail.Text == "")
            {
                warnEmail.Enabled = true;
                x = true;
            }
            if (textBoxBonus.Text == "")
            {
                warnBonus.Enabled = true;
                x = true;
            }
            if (textBoxPassword.Text == "")
            {
                warnPassword.Enabled = true;
                x = true;
            }
            if (textBoxSalary.Text == "")
            {
                warnSalary.Enabled = true;
                x = true;
            }
            if (textBoxUserName.Text == "")
            {
                warnUserName.Enabled = true;
                x = true;
            }
            if (textBoxworkHrs.Text == "")
            {
                warnWorkHrs.Enabled = true;
                x = true;
            }
            if (maskedTextBoxCNIC.Text == "")
            {
                warnCnic.Enabled = true;
                x = true;
            }
            if (maskedTextBoxContact.Text == "")
            {
                warnContact.Enabled = true;
                x = true;
            }
            return x;
            }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(CheckNull() == true)
            {
                warning.Show();
            }
            else
            {

                SqlConnection con = new SqlConnection(Configuration.conection);
                string name;
                string email;
                string contact;
                string cnic;
                int salary;
                DateTime birthDate;
                int bonus;
                int workHrs;
                string job="";
                string userName;
                string password;

                //*******************************************************************************************

                AddDataInList();


                //get data into local variables from the textBoxes, DateTimePicker etc
                name = textBoxName.Text;
                email = textBoxEmail.Text;
                cnic = maskedTextBoxCNIC.Text;
                contact = maskedTextBoxContact.Text;
                salary = Convert.ToInt32(textBoxSalary.Text);
                bonus = Convert.ToInt32(textBoxBonus.Text);
                workHrs = Convert.ToInt32(textBoxworkHrs.Text);
                userName = textBoxUserName.Text;
                birthDate = dateTimePicker1.Value;
                password = textBoxPassword.Text;
                if (radioButton1.Checked)
                    job = radioButton1.Text;
                if (radioButton2.Checked)
                    job = radioButton2.Text;
                if (radioButton3.Checked)
                    job = radioButton3.Text;

                //       ********************DataBASE******************************
                //add to DataBase
                try
                {
                    con.Open();

                    string insertCommand = "INSERT INTO StaffTable (Name,CNICnmbr,Email,Salary,Bonus,WorkingHrs,ContactNmbr,DOB,Job,UserName,Password) VALUES (@Name,@CNICnmbr,@Email,@Salary,@Bonus,@WorkingHrs,@ContactNmbr,@DOB,@Job,@UserName,@Password)";
                    using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@CNICnmbr", cnic);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Salary", salary);
                        cmd.Parameters.AddWithValue("@Bonus", bonus);
                        cmd.Parameters.AddWithValue("@WorkingHrs", workHrs);
                        cmd.Parameters.AddWithValue("@ContactNmbr", contact);
                        cmd.Parameters.AddWithValue("@DOB",birthDate);
                        cmd.Parameters.AddWithValue("@Job", job);
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();


                    }

                    
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

            }
            setNullValuesToTextBoxes();
        }
        private bool ValidateName(string name)
        {
            bool flag = false;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] >= 'a' && name[i] <= 'z' || name[i] >= 'A' && name[i] <= 'Z' || name[i] == ' ')
                    flag = true;
                else
                    return false;
            }

            return flag;
        }

        private bool ValidateMail(string mail)
        {
            var email = new MailAddress(mail);
            bool isValidEmail = email.Host.Contains(".");
            if (!isValidEmail)
                return false;
            else
                return true;
        }

        private bool ValidateSalary(int sal)
        {
            if (sal >= 20000 && sal <= 200000)
                return true;
            else
                return false;
        }

        private bool ValidateBonus(int bon)
        {
            if (bon >= 1000 && bon <= 30000)
                return true;
            else
                return false;
        }
        private bool ValidateWorkHrs(int work)
        {
            if (work >= 1 && work <= 15)
                return true;
            else
                return false;
        }

        private void AddDataInList()
        {
            string name;
            string email;
            string contact;
            string cnic;
            int salary;
            DateTime birthDate;
            int bonus;
            int workHrs;
            string job = "";
            string userName;
            string password;


            name = textBoxName.Text;
            email = textBoxEmail.Text;
            cnic = maskedTextBoxCNIC.Text;
            contact = maskedTextBoxContact.Text;
            salary = Convert.ToInt32(textBoxSalary.Text);
            bonus = Convert.ToInt32(textBoxBonus.Text);
            workHrs = Convert.ToInt32(textBoxworkHrs.Text);
            userName = textBoxUserName.Text;
            birthDate = dateTimePicker1.Value;
            password = textBoxPassword.Text;
            if (radioButton1.Checked)
                job = radioButton1.Text;
            if (radioButton2.Checked)
                job = radioButton2.Text;
            if (radioButton3.Checked)
                job = radioButton3.Text;

            Done task = new Done();
            task.Show();



        }

        private void button9_Click(object sender, EventArgs e)
        {   
            //panel3.Controls.Add(vew);
            //panel3.Controls["ViewStaff"].BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           // panel3.Controls.Remove(vew);
           // panel3.Controls.Remove(upd);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
         //   panel3.Controls.Add(upd);
         //   panel3.Controls["EdtngEmp"].BringToFront();
        }
    }
}
