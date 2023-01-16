using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    class TrainerProfile : IMenu
    {
        Trainer trainerProfile = new Trainer();

        public TrainerProfile(Trainer trainer)
        {
            trainerProfile = trainer;
        }
        public void Display()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Welcome {trainerProfile.Firstname} {trainerProfile.Lastname}");
            Console.WriteLine("Choose below options to perform actions");
            Console.WriteLine("[0] to Back");
            Console.WriteLine("[1] View Profile");
            Console.WriteLine("[2] Update Profile");
            Console.WriteLine("[3] Delete Profile");
        }

        public string UserChoice()
        {
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();
            
            switch(userChoice)
            {
                case "0":
                    return "Login";
                case "1":
                    ShowProfile();
                    Console.ReadLine();
                    return "TrainerProfile";
                case "2":
                    return "TrainerUpdate";
                case "3":
                    Console.WriteLine("code is under development");
                    Console.ReadLine();
                    return "TrainerProfile";
                default:
                    Console.WriteLine("Wrong choice try again");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return "TrainerProfile";
            }
        }

        public void ShowProfile()
        {
            Console.Clear();

            Console.WriteLine($"\n-------{trainerProfile.Firstname.ToUpper()} {trainerProfile.Lastname.ToUpper()} PROFILE-------\n");
            Console.WriteLine("Email ID             : " + trainerProfile.Emailid);
            Console.WriteLine("Password             : " + trainerProfile.Password);
            Console.WriteLine("Firstname            : " + trainerProfile.Firstname);
            Console.WriteLine("Lastname             : " + trainerProfile.Lastname);
            Console.WriteLine("Age                  : " + trainerProfile.Age);
            Console.WriteLine("Gender               : " + trainerProfile.Gender);
            Console.WriteLine("Phone number         : " + trainerProfile.Phonenumber);
            Console.WriteLine("City                 : " + trainerProfile.City);
            Console.WriteLine("UG Collage name      : " + trainerProfile.Ug_collage);
            Console.WriteLine("UG Stream            : " + trainerProfile.Ug_stream);
            Console.WriteLine("UG Percentage        : " + trainerProfile.Ug_percentage);
            Console.WriteLine("UG Year              : " + trainerProfile.Ug_year);
            Console.WriteLine("PG Collage name      : " + trainerProfile.Pg_collage);
            Console.WriteLine("PG Stream            : " + trainerProfile.Pg_stream);
            Console.WriteLine("PG Percentage        : " + trainerProfile.Pg_percentage);
            Console.WriteLine("PG Year              : " + trainerProfile.Pg_year);
            Console.WriteLine("Skill 1              : " + trainerProfile.Skill_1);
            Console.WriteLine("Skill 2              : " + trainerProfile.Skill_2);
            Console.WriteLine("Skill 3              : " + trainerProfile.Skill_3);
            Console.WriteLine("Company name         : " + trainerProfile.Companyname);
            Console.WriteLine("Field of working     : " + trainerProfile.Field);
            Console.WriteLine("Overall experience   : " + trainerProfile.Experience);
        }
    }
}
