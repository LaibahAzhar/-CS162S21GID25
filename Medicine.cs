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
     public partial class Medicine : Form
    {
        public Medicine()
        {
            InitializeComponent();
            medList = new List<Medicine>();

        }

        private static Medicine med;
        ViewMed view = new ViewMed();
        private string medicineName;
        private string medicineID;
        private string chemicalName;
        private DateTime manufacturingDate;
        private DateTime expiryDate;
        private string compnany;
        private int marketPrice;
        private int stock;
        private int sellingPrice;
        private string category;
        private string status;
        static List<Medicine> medList;
        public static Medicine getObject()
        {
            if (med == null)
            {
                med = new Medicine();
            }
            return med;
        }
        public string MedicineName
        {
            get; set;
        }
        public string MedicineID
        {
            get; set;
        }
        public int Stock
        {
            get; set;
        }
        public string ChemicalName
        {
            get; set;
        }
        public string Company
        {
            get; set;
        }
        public int MarketPrice
        {
            get; set;
        }
        public int SellingPrice
        {
            get; set;
        }
        public string Category
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public DateTime ManufacturingDate
        {
            get; set;
        }
        public DateTime ExpiryDate
        {
            get; set;
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
            // SqlConnection con = new SqlConnection(Configuration.conection);
            AddDataInList();
            { string name;
            string id;
            string cName;
            string comp;
            int mPrice;
            DateTime mDate;
            DateTime eDate;
            int stk;
            string sats;
            //get data into local variables from the textBoxes, DateTimePicker etc
            name = textBox1.Text;
            id = textBox4.Text;
            cName = textBox3.Text;
            comp = textBox2.Text;
            mPrice = Int32.Parse(textBox6.Text);
            stk = Int32.Parse(textBox7.Text);
            mDate = dateTimePicker2.Value;
            eDate = dateTimePicker1.Value;
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                sats = radioButton1.Text;
            else
                sats = radioButton2.Text;
        
            //Set the values to he original attributes
            //med = new Medicine();
             //if (ValidateName(name))
             //    med.MedicineName = name;
             //if (ValidateMedicineID(id))
             //    med.MedicineID = id;
             //if (ValidateChemicalName(cName))
             //    med.ChemicalName = cName;
             //if (ValidateCompanyName(comp))
             //    med.Company = comp;
             //med.MarketPrice = mPrice;
             //med.Stock = stk;
             //med.ManufacturingDate = mDate;
             //med.ExpiryDate = eDate;
             ////add to List
             //medList.Add(med);
             //MessageBox.Show("DATA ADDED List");
            }
            //       ********************DataBASE******************************
            {//add to DataBase
                /*con.Open();
                //string query = "INSERT INTO MedTable (Medicine Name,Medicine ID,Chemical Name,Stock/Quantity,Manufacturing Date,Expiry Data,Market Price,Company,Status) VALUES ('" + name + "','" + id + "','" + cName + "','" + stk + "','" + mDate + "''" + eDate + "','" + mPrice + "','" + comp + "','" + sats + "')";
                //SqlDataAdapter sda = new SqlDataAdapter(query, con);
                //sda.SelectCommand.ExecuteNonQuery();
                string insertCommand = "INSERT INTO Events (Medicine Name,Medicine ID,Chemical Name,Stock/Quantity,Manufacturing Date,Expiry Data,Market Price,Company,Status) values (@name,@id,@cName ,@stk ,@mDate,@eDate ,@ mPrice,@ comp ,@ sats )";
                using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Medince Name", name);
                    cmd.Parameters.AddWithValue("@Medicine ID", id);
                    cmd.Parameters.AddWithValue("@Chemical Name", cName);
                    cmd.Parameters.AddWithValue("@Company", comp);
                    cmd.Parameters.AddWithValue("@Status", sats);
                    cmd.Parameters.AddWithValue("@Stock", stk);
                    cmd.Parameters.AddWithValue("@Stock/Quantity", stk);
                    //cmd.Parameters.AddWithValue("@Manufacturing Date", "'" + mDate + "'");
                    //cmd.Parameters.AddWithValue("@Expiry Date", "'" + eDate + "'");
                    cmd.Parameters.AddWithValue("@Manufacturing Date", "'" + mDate + "'");
                    cmd.Parameters.AddWithValue("@Expiry Date", "'" + eDate + "'");
                    cmd.ExecuteNonQuery();*/
                //  }
                // MessageBox.Show("DATA ADDED SQL");
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
        private bool ValidateCompanyName(string compName)
        {
            bool flag = false;
            for (int i = 0; i < compName.Length; i++)
            {
                if (compName[i] >= 'a' && compName[i] <= 'z' || compName[i] >= 'A' && compName[i] <= 'Z' || compName[i] == ' ')
                    flag = true;
                else
                    return false;
            }

            return flag;
        }
        private bool ValidateMedicineID(string id)
        {
            bool flag = false;
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] >= 'a' && id[i] <= 'z' || id[i] >= 'A' && id[i] <= 'Z' || id[i] >= '0' && id[i] <= '9')
                    flag = true;
                else
                    return false;
            }

            return flag;
        }
        private bool ValidateChemicalName(string chemName)
        {
            bool flag = false;
            for (int i = 0; i < chemName.Length; i++)
            {
                if (chemName[i] >= 'a' && chemName[i] <= 'z' || chemName[i] >= 'A' && chemName[i] <= 'Z' || chemName[i] >= '0' && chemName[i] <= '9' || chemName[i] == ' ' || chemName[i] == ')' || chemName[i] == '(' || chemName[i] == '.')
                    flag = true;
                else
                    return false;
            }

            return flag;
        }
        private void AddDataInList()
        {
            string name;
            string id;
            string cName;
            string comp;
            int mPrice;
            DateTime mDate;
            DateTime eDate;
            int stk;
            string sats;
            //get data into local variables from the textBoxes, DateTimePicker etc
            name = textBox1.Text;
            id = textBox4.Text;
            cName = textBox3.Text;
            comp = textBox2.Text;
            mPrice = Int32.Parse(textBox6.Text);
            stk = Int32.Parse(textBox7.Text);
            mDate = dateTimePicker2.Value;
            eDate = dateTimePicker1.Value;
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                sats = radioButton1.Text;
            else
                sats = radioButton2.Text;
            //Set the values to he original attributes
            med = new Medicine();
            if (ValidateName(name))
                med.MedicineName = name;
            if (ValidateMedicineID(id))
                med.MedicineID = id;
            if (ValidateChemicalName(cName))
                med.ChemicalName = cName;
            if (ValidateCompanyName(comp))
                med.Company = comp;
            med.MarketPrice = mPrice;
            med.Stock = stk;
            med.ManufacturingDate = mDate;
            med.ExpiryDate = eDate;
            //add to List
            medList.Add(med);
            MessageBox.Show("DATA ADDED List");
        }
    }
}
