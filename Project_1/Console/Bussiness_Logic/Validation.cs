using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bussiness_Logic
{
    public class Validation
    {
        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,7}$";

            if (Regex.IsMatch(email, emailPattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phonenumber)
        {
            string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

            if (phonenumber.Length <= 15 && Regex.IsMatch(phonenumber, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
