using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dashboard
{
    public partial class EdtngEmp : UserControl
    {

        public EdtngEmp()
        {
            InitializeComponent();

            AutoCompleteText();
        }

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
                while (reader.Read())
                {
                    string sName = reader.GetString("Name");
                    conString.Add(sName);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            textBox2.AutoCompleteCustomSource = conString;
        }
        public void setValues()
        {
            try
            {
                string sName = textBox2.Text;
                SqlConnection con = new SqlConnection(Configuration.conection);
                con.Open();
                string query = "SELECT * FROM StaffTable where Name = '" + sName + "'";

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
                    textBox3.Text = (read["Job"].ToString());

                }
                con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
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
            textBox3.Text = null;

        }

        private void textbox2_TextChanged(object sender, EventArgs e)
        {
            string sName = textBox2.Text;
            SqlConnection con = new SqlConnection(Configuration.conection);
            con.Open();
            string query = "SELECT * FROM StaffTable where Name = '" + sName + "'";

            SqlCommand sda = new SqlCommand(query, con);

            if (!(textBox2.Text == sName))
            {
                setNullValuesToTextBoxes();
            }
            else
            {
                setValues();
            }
            con.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            int bons;
            int slry;
            int whrs;
            string conNmbr;

            bons = Int32.Parse(textBox6.Text);
            slry = Int32.Parse(textBox7.Text);
            whrs = Int32.Parse(textBox8.Text);
            conNmbr = maskedTextBox2.Text;

            SqlConnection con = new SqlConnection(Configuration.conection);
            try
            {
                con.Open();
                string insertCommand = "UPDATE StaffTable SET (Salary,Bonus,WorkingHrs,ContacNmbr) VALUES (@Salary,@Bonus,@WorkingHrs,@ContacNmbr) where '" + textBox1.Text + "'";
                using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Salary", slry);
                    cmd.Parameters.AddWithValue("@Bonus", bons);
                    cmd.Parameters.AddWithValue("@WorkingHrs", whrs);
                    cmd.Parameters.AddWithValue("@ContactNmbr", conNmbr);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            setNullValuesToTextBoxes();
        }
        private void label3_Click_1(object sender, EventArgs e)
        {

        }


    }
}
