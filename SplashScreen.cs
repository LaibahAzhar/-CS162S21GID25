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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.Black;
           // DataRetrieveFromMedicineDataBase();
           // DataRetrieveFromStaffDataBase();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(2);
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                Login log = new Login();
                
                log.Show();
               
                this.Hide();
            }
        }
      /**  public void DataRetrieveFromMedicineDataBase()
        {
            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                Medicine med = new Medicine();

                string query = "SELECT * FROM MedicineTable";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    med = new Medicine();
                    med.MedicineName = dt.Rows[i]["MedicineName"].ToString();
                    med.MedicineID = dt.Rows[i]["MedicineID"].ToString();
                    med.ChemicalName = dt.Rows[i]["ChemicalName"].ToString();
                    med.Stock = Int32.Parse(dt.Rows[i]["Stock"].ToString());
                    med.ManufacturingDate = DateTime.Parse(dt.Rows[i]["ManufacturingDate"].ToString());
                    med.ExpiryDate = DateTime.Parse(dt.Rows[i]["ExpiryDate"].ToString());
                    med.MarketPrice = Int32.Parse(dt.Rows[i]["MarketPrice"].ToString());
                    med.Company = dt.Rows[i]["Company"].ToString();
                    med.Status = dt.Rows[i]["Status"].ToString();
                    med.GetList().Add(med);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ocurred");
            }
        }
        public void DataRetrieveFromStaffDataBase()
        {
            try
            {
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                Staff st = new Staff();

                string query = "SELECT * FROM StaffTable";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    st.Name = dt.Rows[i]["Name"].ToString();
                    st.CNIC = dt.Rows[i]["CNICnmbr"].ToString();
                    st.mail = dt.Rows[i]["Email"].ToString();
                    st.Salary = Int32.Parse(dt.Rows[i]["Salary"].ToString());
                    st.Bonus = Int32.Parse(dt.Rows[i]["Bonus"].ToString());
                    st.Workhr = Int32.Parse(dt.Rows[i]["WorkingHrs"].ToString());
                    st.Contact = dt.Rows[i]["ContactNmbr"].ToString();
                    st.Dob = DateTime.Parse(dt.Rows[i]["DOB"].ToString());
                    st.Job = dt.Rows[i]["Job"].ToString();
                    st.GetList().Add(st);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ocurred");
            }
        } **/
    }
}
