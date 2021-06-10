using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace dashboard
{
    class Validators
    {
		//Validators
        public bool ValidateName(string name)
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
        public bool ValidateCompanyName(string compName)
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
        public bool ValidateMedicineID(string id)
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
        public bool ValidateChemicalName(string chemName)
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
      

        public bool ValidateMail(string mail)
        {
            var email = new MailAddress(mail);
            bool isValidEmail = email.Host.Contains(".");
            if (!isValidEmail)
                return false;
            else
                return true;
        }

        public bool ValidateSalary(int sal)
        {
            if (sal >= 20000 && sal <= 200000)
                return true;
            else
                return false;
        }

        public bool ValidateBonus(int bon)
        {
            if (bon >= 1000 && bon <= 30000)
                return true;
            else
                return false;
        }
        public bool ValidateWorkHrs(int work)
        {
            if (work >= 1 && work <= 15)
                return true;
            else
                return false;
        }
    }
}
