using Bussiness_Logic;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    class TrainerProfile : IMenu
    {
        Bussiness_Logic.ILogic repo = new Logic();

        internal static Models.TrainerDetail trainer = new Models.TrainerDetail();
        internal static TrainerEducation education = new TrainerEducation();
        internal static TrainerSkill skill = new TrainerSkill();
        internal static TrainerCompany company = new TrainerCompany();

        public TrainerProfile(Models.TrainerDetail train, TrainerEducation edu, TrainerSkill ski, TrainerCompany comp)
        {
            trainer = train;
            education = edu;
            skill = ski;
            company = comp;
        }

        public void Display()
        {
            Log.Logger.Information($"{trainer.Firstname} {trainer.Lastname} trainer logged in");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Welcome {trainer.Firstname} {trainer.Lastname} :)");
            Console.WriteLine("\nChoose below options to perform actions:-");
            Console.WriteLine("[0] Logout");
            Console.WriteLine("[1] View Profile");
            Console.WriteLine("[2] Update/Edit Profile");
            Console.WriteLine("[3] Delete Particular Field");
            Console.WriteLine("[4] Delete Profile");
        }

        public new string UserChoice()
        {
            Console.WriteLine("\n--------------------------");
            Console.Write("\nEnter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "Login";
                case "1":
                    ShowProfile();
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerProfile";
                case "2":
                    return "TrainerUpdate";
                case "3":
                    return "TrainerDelete";
                case "4":
                    Console.Clear();
                    Console.WriteLine("\n-------DELETE PAGE------\n");
                    Console.WriteLine("\nNote: It will delete your entire profile");
                    Console.WriteLine("\nAre you Sure?");
                    Console.WriteLine("[0] for Back");
                    Console.WriteLine("[1] Proceed to delete");
                    Console.WriteLine("\n---------------------------");
                    Console.Write("\nEnter your choice: ");
                    string userChoice_1 = Console.ReadLine();

                    switch (userChoice_1)
                    {
                        case "0":
                            return "TrainerProfile";
                        case "1":
                            string email = trainer.Emailid;

                            Log.Logger.Information($"{trainer.Firstname} {trainer.Lastname} profile deleted");                            
                            repo.DeleteTrainer(email);
                            return "Login";
                        default:
                            Console.WriteLine("Wrong Choice try again");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            return "TrainerProfile";
                    }
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
            Log.Logger.Information($"display {trainer.Firstname} {trainer.Lastname} profile");
            Console.WriteLine($"\n-------{trainer.Firstname.ToUpper()} {trainer.Lastname.ToUpper()} PROFILE-------\n");
            Console.WriteLine("Email ID             : " + trainer.Emailid);
            Console.WriteLine("Firstname            : " + trainer.Firstname);
            Console.WriteLine("Lastname             : " + trainer.Lastname);
            Console.WriteLine("Age                  : " + trainer.Age);
            Console.WriteLine("Gender               : " + trainer.Gender);
            Console.WriteLine("Phone number         : " + trainer.Phonenumber);
            Console.WriteLine("City                 : " + trainer.City);
            Console.WriteLine("UG Collage name      : " + education.Ug_collage);
            Console.WriteLine("UG Stream            : " + education.Ug_stream);
            Console.WriteLine("UG Percentage        : " + education.Ug_percentage);
            Console.WriteLine("UG Year              : " + education.Ug_year);
            Console.WriteLine("PG Collage name      : " + education.Pg_collage);
            Console.WriteLine("PG Stream            : " + education.Pg_stream);
            Console.WriteLine("PG Percentage        : " + education.Pg_percentage);
            Console.WriteLine("PG Year              : " + education.Pg_year);
            Console.WriteLine("Skill 1              : " + skill.Skill_1);
            Console.WriteLine("Skill 2              : " + skill.Skill_2);
            Console.WriteLine("Skill 3              : " + skill.Skill_3);
            Console.WriteLine("Company name         : " + company.Companyname);
            Console.WriteLine("Field of working     : " + company.Field);
            Console.WriteLine("Overall experience   : " + company.Experience);
        }
    }
}
