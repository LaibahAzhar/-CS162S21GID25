using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dashboard
{
    public partial class Medicine : Form
    {
        public Medicine()
        {
            InitializeComponent();
        }


        private static Medicine med;
        ViewMed view = new ViewMed();
        
        
        WarnMsg warns = new WarnMsg();
        private bool CheckEmpty()
        {
            bool flag = true;
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
            if (textBox6.Text == "")
            {
                button10.Enabled = true;
                button10.Visible = true;
                flag = false;
            }
            else
            {
                button10.Enabled = false;
                button10.Visible = false;

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
            if (textBox3.Text == "")
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
            if (textBox2.Text == "")
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
            if (textBox7.Text == "")
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
            if (textBox5.Text == "")
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
            return flag;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            panel3.Controls.Add(view);
            panel3.Controls["ViewMed"].BringToFront();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Remove(view);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateBill b = new GenerateBill();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stock s = new Stock();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name;
            string id;
            string cName;
            string comp;
            int mPrice;
            int sPrice;
            DateTime mDate;
            DateTime eDate;
            int stk;
            string sats;
            if (CheckEmpty() == false)
            {
                warns.Show();
            }
            else
            {
                bool isChecked = radioButton1.Checked;
                if (isChecked)
                    sats = radioButton1.Text;
                else
                    sats = radioButton2.Text;
                name = textBox1.Text;
                id = textBox4.Text;
                cName = textBox3.Text;
                comp = textBox2.Text;
                mPrice = Int32.Parse(textBox6.Text);
                stk = Int32.Parse(textBox7.Text);
                mDate = dateTimePicker2.Value;
                eDate = dateTimePicker1.Value;
                sPrice = Int32.Parse(textBox5.Text);
                Validators validate = new Validators();
                if (sats == "Public Medicine")
                {
                    PublicMedicine pubMed = new PublicMedicine();

                    if (validate.ValidateName(name))
                        pubMed.MedicineName = name;
                    if (validate.ValidateMedicineID(id))
                        pubMed.MedicineID = id;
                    if (validate.ValidateChemicalName(cName))
                        pubMed.ChemicalName = cName;
                    if (validate.ValidateCompanyName(comp))
                        pubMed.Company = comp;
                    pubMed.MarketPrice = mPrice;
                    pubMed.Stock = stk;
                    pubMed.ManufacturingDate = mDate;
                    pubMed.ExpiryDate = eDate;
                    pubMed.SellingPrice = sPrice;
                    pubMed.AddDataInList(pubMed);
                    pubMed.AddDataInDataBase(pubMed);
                }
                if (sats == "Private Medicine")
                {
                    PrivateMedicine priMed = new PrivateMedicine();
                    if (validate.ValidateName(name))
                        priMed.MedicineName = name;
                    if (validate.ValidateMedicineID(id))
                        priMed.MedicineID = id;
                    if (validate.ValidateChemicalName(cName))
                        priMed.ChemicalName = cName;
                    if (validate.ValidateCompanyName(comp))
                        priMed.Company = comp;
                    priMed.MarketPrice = mPrice;
                    priMed.Stock = stk;
                    priMed.ManufacturingDate = mDate;
                    priMed.ExpiryDate = eDate;
                    priMed.SellingPrice = sPrice;
                    priMed.AddDataInList(priMed);
                }
               
                //*******************************************************************************************

                //med.AddDataInList();


                //get data into local variables from the textBoxes, DateTimePicker etc

                //add to List
                Done task = new Done();
                task.Show();



                setNullValuesToTextBoxes();
            }
        }


       
       
        private void setNullValuesToTextBoxes()
        {
            textBox1.Text = null;
            textBox4.Text = null;
            textBox3.Text = null;
            textBox2.Text = null;
            textBox6.Text = null;
            textBox5.Text = null;
            textBox7.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            //radioButton1.Text = null;
            //radioButton2.Text = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Staff stf = new Staff();
            stf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void labelStaff_Click(object sender, EventArgs e)
        {

        }

        private void Medicine_Load(object sender, EventArgs e)
        {   label2.Text = Login.UserName;
            string user = Login.User;
            // string user = Login.User;
           // MessageBox.Show(Login.User);
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
        }

        private void billingBtn_Click(object sender, EventArgs e)
        {
            BillRecord rec = new BillRecord();
            rec.Show();
        }
    }
}
