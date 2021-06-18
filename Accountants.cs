using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace dashboard
{
    class Accountants : Staffs, LoginAccess
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
            staffList.Add(s);
        }
        override
public void AddDataInDataBase( Accountants a)
        {
            SqlConnection con = new SqlConnection(Configuration.conection);

            try
            {

                con.Open();
                string insertCommand = "INSERT INTO StaffTable (Name,CNICnmbr,Email,Salary,Bonus,WorkingHrs,ContactNmbr,DOB,Job) VALUES (@Name,@CNICnmbr,@Email,@Salary,@Bonus,@WorkingHrs,@ContactNmbr,@DOB,@Job)";
                
                using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                {
                   
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", a.StaffName);
                    cmd.Parameters.AddWithValue("@CNICnmbr", a.CNIC);
                    cmd.Parameters.AddWithValue("@Email", a.mail);
                    cmd.Parameters.AddWithValue("@Salary", a.Salary);
                    cmd.Parameters.AddWithValue("@Bonus", a.Bonus);
                    cmd.Parameters.AddWithValue("@WorkingHrs", a.Workhr);
                    cmd.Parameters.AddWithValue("@ContactNmbr", a.Contact);
                    cmd.Parameters.AddWithValue("@DOB", (a.Dob).ToString());
                    cmd.Parameters.AddWithValue("@Job", a.Job);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            SqlConnection com = new SqlConnection(Configuration.conection);
            try
            {
                
                com.Open();
                DateTime t = new DateTime();
                string insertComman = "INSERT INTO StaffLoginTable (UserName,Password) VALUES (@UserName,@Password)";

                using (SqlCommand cnn = new SqlCommand(insertComman, com))
                {

                    cnn.Parameters.Clear();
                    cnn.Parameters.AddWithValue("@UserName", a.UserName);
                    cnn.Parameters.AddWithValue("@Password", a.Password);

                    cnn.ExecuteNonQuery();

       
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                com.Close();
            }
        }
        override
            public void AddDataInDataBase(Pharmasist p)
        {

        }
    }
}
