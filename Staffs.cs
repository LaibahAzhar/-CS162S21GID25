using System;
using System.Collections.Generic;
using System.Text;

namespace dashboard
{
    abstract class Staffs
    {
        public Staffs()
        {
            staffList = new List<Staffs>();
        }
        static protected List<Staffs> staffList;
        protected string staffName;
        protected string cnicNmbr;
        protected string email;
        protected DateTime dob;
        protected int salary;
        protected int bonus;
        protected int workHrs;
        protected string contact;
        protected string job;
        protected string username;
        protected string password;

      
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
        public string Username
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        abstract public void AddDataInList(Staffs s);
        abstract public void AddDataInDataBase( Pharmasist p);
        abstract public void AddDataInDataBase( Accountants a);
    }
}
