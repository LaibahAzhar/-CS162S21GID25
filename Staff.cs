using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace dashboard
{
    public partial class Staff : Form
    {
        ViewStaff vew = new ViewStaff();
        UpdtEmp upd = new UpdtEmp();
        public Staff()
        {
            InitializeComponent();
            staffList = new List<Staff>();
            AutoCompleteText();
           
        }

        private void Warning()
        {
          
        }
    
        private static Staff stff;
        static private List<Staff> staffList;
        private string staffName;
        private string cnicNmbr;
        private string email;
        private DateTime dob;
        private int salary;
        private int bonus;
        private int workHrs;
        private string contact;
        private string job;
        private string userName;
        private string password;
      

        public static Staff getObject()
        {
            if (stff== null)
            {
                stff = new Staff();
            }
            return stff;
        }

        public List<Staff> GetList()
        {
            return staffList;
        }
        public string StaffName
        {
            get; set;
        }
        public string Nmber
        {
            get; set;
        }
        public string CNIC
        {
            get; set;
        }
        public string mail
        {
            get; set;
        }
        public int Salary
        {
            get; set;
        }
        public int Bonus
        {
            get; set;
        }
        public int Workhr
        {
            get; set;
        }
        public string Job
        {
            get; set;
        }
        public DateTime Dob
        {
            get; set;
        }
        public string Contact
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
       
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
         //   panel3.Controls.Add(upd);
         //   panel3.Controls["UpdtEmp"].BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Add(vew);
            panel3.Controls["ViewStaff"].BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Remove(vew);
            panel3.Controls.Remove(upd);
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
            Stock s = new Stock();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        WarnMsg warns = new WarnMsg();
        private bool CheckEmpty()
        {
            bool flag = true ;
            if (textBox1.Text == "")
            {
                warn.Enabled = true;
                warn.Visible = true;
                flag = false;
            }
            else
            {
                warn.Enabled = false;
                warn.Visible = false;

            }

            if (textBox4.Text == "")
            {
                button11.Enabled = true;
                button11.Visible = true;
                flag = false;
            }
            else
            {
                button11.Enabled = false;
                button11.Visible = false;
            }
            if (textBox6.Text == "")
            {
                button14.Enabled = true;
                button14.Visible = true;
                flag = false;
            }
            else
            {
                button14.Enabled = false;
                button14.Visible = false;
            }
            if (textBox7.Text == "")
            {
                button16.Enabled = true;
                button16.Visible = true;
                flag = false;
            }
            else
            {
                button16.Enabled = false;
                button16.Visible = false;
            }
            if (textBox8.Text == "")
            {
                button15.Enabled = true;
                button15.Visible = true;
                flag = false;
            }
            else
            {
                button15.Enabled = false;
                button15.Visible = false;
            }
            if (maskedTextBox1.MaskCompleted==false)
            {
                button12.Enabled = true;
                button12.Visible = true;
                flag = false;
            }
            else
            {
                button12.Enabled = false;
                button12.Visible = false;
            }
            if (maskedTextBox2.MaskCompleted==false)
            {
                button13.Enabled = true;
                button13.Visible = true;
                flag = false;
            }
            else
            {
                button13.Enabled = false;
                button13.Visible = false;
            }

            return flag;
        }
        private void button6_Click(object sender, EventArgs e)
        {   if(CheckEmpty()==false)
            {
                warns.Show();
            }
            

            else
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                string name;
                string CnicNmber;
                string Mail;
                int slry;
                int bns;
                int wHrs;
                string conNmbr;
                DateTime date;
                string job = "";
                string uName;
                string psswrd;
                //***********************************************************************************

                AddDataInList();

                // storing data into local variable from the form
                name = textBox1.Text;
                CnicNmber = maskedTextBox1.Text;
                Mail = textBox4.Text;
                slry = Int32.Parse(textBox7.Text);
                bns = Int32.Parse(textBox6.Text);
                wHrs = Int32.Parse(textBox8.Text);
                conNmbr = maskedTextBox2.Text;
                date = dateTimePicker1.Value;
                uName = textBox7.Text;
                psswrd = textBox8.Text;
                if (radioButton2.Checked)
                {
                    job = radioButton2.Text;
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        job = radioButton1.Text;
                    }
                    else
                    {
                        if (radioButton3.Checked)
                            job = radioButton3.Text;
                    }

                }

                try
                {
                    con.Open();

                    string insertCommand = "INSERT INTO StaffTable (Name,CNICnmbr,Email,Salary,Bonus,WorkingHrs,ContactNmbr,DOB,Job) VALUES (@Name,@CNICnmbr,@Email,@Salary,@Bonus,@WorkingHrs,@ContactNmbr,@DOB,@Job)";
                    using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@CNICnmbr", CnicNmber);
                        cmd.Parameters.AddWithValue("@Email", Mail);
                        cmd.Parameters.AddWithValue("@Salary", slry);
                        cmd.Parameters.AddWithValue("@Bonus", bns);
                        cmd.Parameters.AddWithValue("@WorkingHrs", wHrs);
                        cmd.Parameters.AddWithValue("@ContactNmbr", conNmbr);
                        cmd.Parameters.AddWithValue("@DOB", date);
                        cmd.Parameters.AddWithValue("@Job", job);
                      //  cmd.Parameters.AddWithValue("@UserName", uName);
                      //  cmd.Parameters.AddWithValue("@Password", psswrd);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
                try
                {
                    con.Open();

                    string insertCommand = "INSERT INTO StaffLoginTable (UserName,Password) VALUES (@UserName,@password)";
                    using (SqlCommand cnn = new SqlCommand(insertCommand, con))
                    {
                        cnn.Parameters.Clear();
                        cnn.Parameters.AddWithValue("@UserName", uName);
                        cnn.Parameters.AddWithValue("@Password", psswrd);

                        cnn.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
                setNullValuesToTextBoxes();
                //AdminRegistory.getObject().Show();
            }
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
                string CnicNmber = "";
                string Mail;
                int slry;
                int bns;
                int wHrs;
                string conNmbr = "";
                DateTime date;
                string job;
            string uName;
            string psswrd;

            name = textBox1.Text;
                CnicNmber = maskedTextBox1.Text;
                Mail = textBox4.Text;
                slry = Int32.Parse(textBox9.Text);
                bns = Int32.Parse(textBox6.Text);
                wHrs = Int32.Parse(textBox5.Text);
                conNmbr = maskedTextBox2.Text;
                date = dateTimePicker1.Value;
            uName = textBox7.Text;
            psswrd = textBox8.Text;
                if (radioButton2.Checked)
                {
                    job = radioButton2.Text;
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        job = radioButton1.Text;
                    }
                    else
                    {
                        if (radioButton3.Checked)
                            job = radioButton3.Text;
                    }

                }

                //setting the values to original attributes after validation

                stff = new Staff();
                if (ValidateName(name))
                    stff.StaffName = name;
                if (ValidateMail(Mail))
                    stff.mail = Mail;
                if (ValidateBonus(bns))
                    stff.bonus = bns;
                if (ValidateSalary(slry))
                    stff.Salary = slry;
                if (ValidateWorkHrs(wHrs))
                    stff.workHrs = wHrs;
                stff.cnicNmbr = CnicNmber;
                stff.Nmber = conNmbr;
                //added to list
                staffList.Add(stff);
            Done task = new Done();
            task.Show();



            }
        //Method for editing Staff Information
        public void AutoCompleteText()
        {
            AutoCompleteStringCollection conString = new AutoCompleteStringCollection();

            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                Staff stf = new Staff();

                string query = "SELECT * FROM StaffTable";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string sName = reader.GetString("Name");
                    conString.Add(sName);
                }
                con.Close();

            }catch(Exception ex)
            {
                string message = ex.Message;
            }
            textBox2.AutoCompleteCustomSource = conString;
        }
      /*  public void setValues()
        {
            try
            {
                string sName = textBox8.Text;
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                string query = "SELECT * FROM StaffTable where Name = ' " + sName + "'";

                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader read;

                read = sda.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    textBox1.Text = (read["Name"].ToString());
                    maskedTextBox1.Text = (read["CNICnmbr"].ToString());
                    textBox4.Text = (read["Email"].ToString());
                    textBox7.Text = (read["Salary"].ToString());
                    textBox6.Text = (read["Bonus"].ToString());
                    textBox8.Text = (read["WorkingHrs"].ToString());
                    maskedTextBox2.Text = (read["ContactNmbr"].ToString());
                    dateTimePicker1.Text = (read["DOB"].ToString());
                    radioButton3.Visible = false;
                    textBox3.Text = (read["Job"].ToString());

                }
                con.Close();
            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
        }*/
        private void setNullValuesToTextBoxes()
        {
            textBox1.Text = null;
            maskedTextBox1.Text = null;
            textBox4.Text = null;
            textBox7.Text = null;
            textBox6.Text = null;
            textBox8.Text = null;
            maskedTextBox2.Text = null;
            dateTimePicker1.Text = null;
            radioButton3.Visible = false; 
            //textBox3.Visible = true;
            //textBox3.Text = null;

        }
        
        private void textbox2_TextChanged(object sender,EventArgs e)
        {
            string sName = textBox2.Text;
            SqlConnection con = new SqlConnection(Configuration.conection);
            con.Open();
            string query = "SELECT * FROM StaffTable where Name = '" + sName + "'";

            SqlCommand sda = new SqlCommand(query, con);

            if(!(textBox2.Text== sName))
            {
                setNullValuesToTextBoxes();
            }
            con.Close();
        }
        

    }

    
}
