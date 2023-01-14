﻿// user details

namespace ClassLib
{
    public class User
    {
        string emailid;
        string password;
        string firstName;
        string lastName;
        byte age;
        string gender;
        int phonenumber;
        string city;

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
        public byte Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public int Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string UserString()
        {
            return $"{Emailid} {Firstname} {Lastname} {Age} {Gender} {Phonenumber} {City}";
        }
    }

    public class Education
    {
        string ug_collage;
        string ug_stream;
        int ug_percentage;
        int ug_year;
        string pg_collage;
        string pg_stream;
        int pg_percentage;
        int pg_year;

        public string Ug_collage
        {
            get { return ug_collage; }
            set { ug_collage = value; }
        }

        public string Ug_stream
        {
            get { return ug_stream; }
            set { ug_stream = value; }
        }

        public int Ug_percentage
        {
            get { return ug_percentage; }
            set { ug_percentage = value; }
        }

        public int Ug_year
        {
            get { return ug_year; }
            set { ug_year = value; }
        }

        public string Pg_collage
        {
            get { return pg_collage; }
            set { pg_collage = value; }
        }

        public string Pg_stream
        {
            get { return pg_stream; }
            set { pg_stream = value; }
        }

        public int Pg_percentage
        {
            get { return pg_percentage; }
            set { pg_percentage = value; }
        }

        public int Pg_year
        {
            get { return pg_year; }
            set { pg_year = value; }
        }

        public string EducationString()
        {
            return $"{Ug_collage} {Ug_stream} {Ug_percentage} {Ug_year} {Pg_collage} {Pg_stream} {Pg_percentage} {Pg_year}";
        }
    }

    public class Skills
    {
        string skill_1;
        string skill_2;
        string skill_3;

        public string Skill_1
        {
            get { return skill_1; }
            set { skill_1 = value; }
        }
        public string Skill_2
        {
            get { return skill_2; }
            set { skill_2 = value; }
        }
        public string Skill_3
        {
            get { return skill_3; }
            set { skill_3 = value; }
        }

        public string SkillString()
        {
            return $"{Skill_1}, {Skill_2}, {Skill_3}";
        }
    }

    public class Work
    {
        string companyName;
        string field;
        string experience;

        public string Comapnyname
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

        public string CompanyString()
        {
            return $"{Comapnyname} {Field} {Experience}";
        }
    }
}
