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

       // public string Userid { get; set; }
        public string Companyname { get; set; }
        public string Field { get; set; }
        public string Experience { get; set; }
        

        public string GetTrainerCompany()
        {
            return $@"
Work Details:
Last or current working company: {Companyname}, Field: {Field}, Overall Experience: {Experience}";
        }
    }
}
