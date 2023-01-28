using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainerCompany
    {
        public TrainerCompany() 
        {
        }

        string userid;
        string companyName;
        string field;
        string experience;


        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        public string Companyname
        {
            get { return companyName; }
            set { companyName = value; }
        }
        public string Field
        {
            get { return field; }
            set { field = value; }
        }
        public string Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        

        public string GetTrainerCompany()
        {
            return $@"
Work Details:
Last or current working company: {Companyname}, Field: {Field}, Overall Experience: {Experience}";
        }
    }
}
