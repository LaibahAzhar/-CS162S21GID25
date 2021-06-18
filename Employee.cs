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
       EdtngEmp upd = new EdtngEmp();
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
           new  AdminPortal().Show();
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
                warnName.Visible = true;
                x = true;
            }
            if (textBoxEmail.Text == "")
            {
                warnEmail.Visible = true;
                x = true;
            }
            if (textBoxBonus.Text == "")
            {
                warnBonus.Visible = true;
                x = true;
            }
            if (textBoxPassword.Text == "")
            {
                warnPassword.Visible = true;
                x = true;
            }
            if (textBoxSalary.Text == "")
            {
                warnSalary.Visible = true;
                x = true;
            }
            if (textBoxUserName.Text == "")
            {
                warnUserName.Visible = true;
                x = true;
            }
            if (textBoxworkHrs.Text == "")
            {
                warnWorkHrs.Visible = true;
                x = true;
            }
            if (maskedTextBoxCNIC.Text == "")
            {
                warnCnic.Visible = true;
                x = true;
            }
            if (maskedTextBoxContact.Text == "")
            {
                warnContact.Visible = true;
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
                Validators validate = new Validators();
                if (job == "Pharmacist")
                {
                    Pharmasist p = new Pharmasist();
                    if (validate.ValidateName(name))
                        p.StaffName = name;
                    if (validate.ValidateMail(email))
                        p.mail = email;
                    if (validate.ValidateBonus(bonus))
                        p.Bonus = bonus;
                    if (validate.ValidateSalary(salary))
                        p.Salary = salary;
                    if (validate.ValidateWorkHrs(workHrs))
                        p.Workhr = workHrs;
                    p.CNIC = cnic;
                    p.Nmber = contact;
                    p.UserName = userName;
                    p.Password = password;
                    //added to list
                    p.AddDataInList(p);
                    //added to DataBase
                    p.AddDataInDataBase(p);
                    Done task = new Done();
                    task.Show();
                }
                if (job == "Accountant")
                {
                    Accountants a = new Accountants();
                    if (validate.ValidateName(name))
                        a.StaffName = name;
                    if (validate.ValidateMail(email))
                        a.mail = email;
                    if (validate.ValidateBonus(bonus))
                        a.Bonus = bonus;
                    if (validate.ValidateSalary(salary))
                        a.Salary = salary;
                    if (validate.ValidateWorkHrs(workHrs))
                        a.Workhr = workHrs;
                    a.CNIC = cnic;
                    a.Nmber = contact;
                    a.UserName = userName;
                    a.Password = password;
                    //added to list
                    a.AddDataInList(a);
                    //added to DataBase
                    a.AddDataInDataBase(a);
                    Done task = new Done();
                    task.Show();
                }
                if (job == "Security")
                {
                    Security s = new Security();
                    if (validate.ValidateName(name))
                        s.StaffName = name;
                    if (validate.ValidateMail(email))
                        s.mail = email;
                    if (validate.ValidateBonus(bonus))
                        s.Bonus = bonus;
                    if (validate.ValidateSalary(salary))
                        s.Salary = salary;
                    if (validate.ValidateWorkHrs(workHrs))
                        s.Workhr = workHrs;
                    s.CNIC = cnic;
                    s.Nmber = contact;
                   
                    //added to list
                    s.AddDataInList(s);
                    //added to DataBase
                    s.AddDataInDataBase(s);
                    Done task = new Done();
                    task.Show();
                }




            }
            setNullValuesToTextBoxes();
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

        private void buttonUp_Click(object sender, EventArgs e)
        {
           panel3.Controls.Add(upd);
           panel3.Controls["EdtngEmp"].BringToFront();
        }
    }
}
