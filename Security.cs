using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace dashboard
{
    class Security : Staffs
    {
        override
public void AddDataInList(Staffs s)
        {
            staffList.Add(s);
        }
public void AddDataInDataBase(Staffs s)
        {
            SqlConnection con = new SqlConnection(Configuration.conection);
           
            try
            {
                con.Open();

                string insertCommand = "INSERT INTO StaffTable (Name,CNICnmbr,Email,Salary,Bonus,WorkingHrs,ContactNmbr,DOB,Job) VALUES (@Name,@CNICnmbr,@Email,@Salary,@Bonus,@WorkingHrs,@ContactNmbr,@DOB,@Job)";
                using (SqlCommand cmd = new SqlCommand(insertCommand, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", s.StaffName);
                    cmd.Parameters.AddWithValue("@CNICnmbr", s.CNIC);
                    cmd.Parameters.AddWithValue("@Email", s.mail);
                    cmd.Parameters.AddWithValue("@Salary", s.Salary);
                    cmd.Parameters.AddWithValue("@Bonus", s.Bonus);
                    cmd.Parameters.AddWithValue("@WorkingHrs", s.Workhr);
                    cmd.Parameters.AddWithValue("@ContactNmbr", s.Contact);
                    cmd.Parameters.AddWithValue("@DOB", s.Dob);
                    cmd.Parameters.AddWithValue("@Job", s.Job);
                    //cmd.Parameters.AddWithValue("@UserName", userName);
                    //cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        override
            public void AddDataInDataBase( Pharmasist p)
        {

        }
        override
           public void AddDataInDataBase( Accountants a)
        {

        }
    }
}
