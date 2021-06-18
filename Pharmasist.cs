using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace dashboard
{
    class Pharmasist : Staffs, LoginAccess
    {
        private string userName;
        private string password;
        public string UserName
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        override
        public void AddDataInList(Staffs s)
        {

        }
        override
        public void AddDataInDataBase(Pharmasist p)
        {
            SqlConnection con = new SqlConnection(Configuration.conection); 
            try
                {
                    con.Open();

                    string insertCommand = "INSERT INTO StaffLoginTable (UserName,Password) VALUES (@UserName,@Password)";
                    using (SqlCommand cnn = new SqlCommand(insertCommand, con))
                    {
                        cnn.Parameters.Clear();
                        cnn.Parameters.AddWithValue("@UserName", p.UserName);
                        cnn.Parameters.AddWithValue("@Password", p.Password);

                        cnn.ExecuteNonQuery();
                    }
                   con.Close();
                }
                catch (Exception ex)
             {
                 string message = ex.Message;
             }
            SqlConnection com = new SqlConnection(Configuration.conection);
            try
            {
                com.Open();

                string insertCommand = "INSERT INTO StaffTable (Name,CNICnmbr,Email,Salary,Bonus,WorkingHrs,ContactNmbr,DOB,Job) VALUES (@Name,@CNICnmbr,@Email,@Salary,@Bonus,@WorkingHrs,@ContactNmbr,@DOB,@Job)";
                using (SqlCommand cmd = new SqlCommand(insertCommand, com))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", p.StaffName);
                    cmd.Parameters.AddWithValue("@CNICnmbr", p.CNIC);
                    cmd.Parameters.AddWithValue("@Email", p.mail);
                    cmd.Parameters.AddWithValue("@Salary", p.Salary);
                    cmd.Parameters.AddWithValue("@Bonus", p.Bonus);
                    cmd.Parameters.AddWithValue("@WorkingHrs", p.Workhr);
                    cmd.Parameters.AddWithValue("@ContactNmbr", p.Nmber);
                    cmd.Parameters.AddWithValue("@DOB", (p.Dob).ToString());
                    cmd.Parameters.AddWithValue("@Job", p.Job);
               //     cmd.Parameters.AddWithValue("@UserName", userName);
               //     cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();

                   
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            com.Close();
        }
        override
          public void AddDataInDataBase( Accountants a)
        {

        }
    }
}
