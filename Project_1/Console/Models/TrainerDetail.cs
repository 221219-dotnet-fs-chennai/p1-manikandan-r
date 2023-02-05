using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainerDetail
    {
        public TrainerDetail()
        {

        }

        //public string Userid { get; set; }
        public string Emailid { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public string City { get; set; } = null!;

        public string GetTrainerDetails()
        {
            return $@"
===================================================={Firstname.ToUpper()} {Lastname.ToUpper()}============================================================

Personal Details:
Email: {Emailid}, Firstname: {Firstname}, Lastname: {Lastname}, Age: {Age}, Gender: {Gender}, Phonenumber: {Phonenumber}, City: {City}";
        }
    }
}
