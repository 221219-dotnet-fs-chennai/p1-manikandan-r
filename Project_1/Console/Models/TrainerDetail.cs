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

        string userid;
        string emailid;
        string password;
        string firstName;
        string lastName;
        int age;
        string gender;
        string phonenumber;
        string city;

        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        public string Emailid
        {
            get { return emailid; }
            set { emailid = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Firstname
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Lastname
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string GetTrainerDetails()
        {
            return $@"
===================================================={Firstname.ToUpper()} {Lastname.ToUpper()}============================================================

Personal Details:
Email: {Emailid}, Firstname: {Firstname}, Lastname: {Lastname}, Age: {Age}, Gender: {Gender}, Phonenumber: {Phonenumber}, City: {City}";
        }
    }
}
