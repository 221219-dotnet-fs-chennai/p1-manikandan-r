using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class TrainerUpdate : SignUp, IMenu
    {
        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IRepo repo = new SqlRepo(conStr);
        public new void Display()
        {
            Console.WriteLine("---------------UPDATE PAGE-----------------");
            Console.WriteLine("Note: You can update below details only\n");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Password                 : " + trainer.Password);
            Console.WriteLine("[2] Age                      : " + trainer.Age);
            Console.WriteLine("[3] Phone Number             : " + trainer.Phonenumber);
            Console.WriteLine("[4] City                     : " + trainer.City);
            Console.WriteLine("[5] UG college name          : " + trainer.Ug_collage);
            Console.WriteLine("[6] UG stream                : " + trainer.Ug_stream);
            Console.WriteLine("[7] UG percentage            : " + trainer.Ug_percentage);
            Console.WriteLine("[8] UG year                  : " + trainer.Ug_year);
            Console.WriteLine("[9] PG college name          : " + trainer.Pg_collage);
            Console.WriteLine("[10] PG stream               : " + trainer.Pg_stream);
            Console.WriteLine("[11] PG percentage           : " + trainer.Pg_percentage);
            Console.WriteLine("[12] PG year                 : " + trainer.Pg_year);
            Console.WriteLine("[13] Skill 1                 : " + trainer.Skill_1);
            Console.WriteLine("[14] Skill 2                 : " + trainer.Skill_2);
            Console.WriteLine("[15] Skill 3                 : " + trainer.Skill_3);
            Console.WriteLine("[16] Company name            : " + trainer.Companyname);
            Console.WriteLine("[17] Field                   : " + trainer.Field);
            Console.WriteLine("[18] Overall Experience      : " + trainer.Experience);
        }

        public new string UserChoice()
        {
            string[] emailArr = trainer.Emailid.Split("@");
            string userId = emailArr[0];

            Console.WriteLine("\n--------------------------");
            Console.Write("\nEnter your choice: ");
            string userChoice = Console.ReadLine();
            
            switch(userChoice)
            {
                case "0":
                    Log.Logger.Information($"{trainer.Firstname} {trainer.Lastname} trainer updated his profile");
                    return "TrainerProfile";
                case "1":
                    Console.Write("Enter new password: ");
                    trainer.Password = Console.ReadLine();
                    repo.UpdateTrainer("TrainerDetails", "Password", trainer.Password, userId);
                    return "TrainerUpdate";
                case "2":
                    Console.Write("Enter Age: ");
                    trainer.Age = Convert.ToInt32(Console.ReadLine());
                    repo.UpdateTrainer("TrainerDetails", "Age", (trainer.Age).ToString(), userId);
                    return "TrainerUpdate";
                case "3":
                    Console.Write("Enter new Phone Number: ");
                    trainer.Phonenumber = Console.ReadLine();
                    repo.UpdateTrainer("TrainerDetails", "Phone_Number", trainer.Phonenumber, userId);
                    return "TrainerUpdate";
                case "4":
                    Console.Write("Enter new city: ");
                    trainer.City = Console.ReadLine();
                    repo.UpdateTrainer("TrainerDetails", "City", trainer.City, userId);
                    return "TrainerUpdate";
                case "5":
                    Console.Write("Enter UG collage name: ");
                    trainer.Ug_collage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_collage", trainer.Ug_collage, userId);
                    return "TrainerUpdate";
                case "6":
                    Console.Write("Enter UG Stream: ");
                    trainer.Ug_stream = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_stream", trainer.Ug_stream, userId);
                    return "TrainerUpdate";
                case "7":
                    Console.Write("Enter UG percentage: ");
                    trainer.Ug_percentage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_Percentage", trainer.Ug_percentage, userId);
                    return "TrainerUpdate";
                case "8":
                    Console.Write("Enter UG year: ");
                    trainer.Ug_year = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_year", trainer.Ug_year, userId);
                    return "TrainerUpdate";
                case "9":
                    Console.Write("Enter PG collage name: ");
                    trainer.Pg_collage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_collage", trainer.Pg_collage, userId);
                    return "TrainerUpdate";
                case "10":
                    Console.Write("Enter PG Stream: ");
                    trainer.Pg_stream = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_stream", trainer.Pg_stream, userId);
                    return "TrainerUpdate";
                case "11":
                    Console.Write("Enter PG percentage: ");
                    trainer.Pg_percentage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_Percentage", trainer.Pg_percentage, userId);
                    return "TrainerUpdate";
                case "12":
                    Console.Write("Enter PG year: ");
                    trainer.Pg_year = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_year", trainer.Pg_year, userId);
                    return "TrainerUpdate";
                case "13":
                    Console.Write("Enter your skill 1: ");
                    trainer.Skill_1 = Console.ReadLine();
                    repo.UpdateTrainer("Skill", "Skill_1", trainer.Skill_1, userId);
                    return "TrainerUpdate";
                case "14":
                    Console.Write("Enter your skill 2: ");
                    trainer.Skill_2 = Console.ReadLine();
                    repo.UpdateTrainer("Skill", "Skill_2", trainer.Skill_2, userId);
                    return "TrainerUpdate";
                case "15":
                    Console.Write("Enter your skill 3: ");
                    trainer.Skill_3 = Console.ReadLine();
                    repo.UpdateTrainer("Skill", "Skill_3", trainer.Skill_3, userId);
                    return "TrainerUpdate";
                case "16":
                    Console.Write("Enter company name: ");
                    trainer.Companyname = Console.ReadLine();
                    repo.UpdateTrainer("Company", "Company_Name", trainer.Companyname, userId);
                    return "TrainerUpdate";
                case "17":
                    Console.Write("Enter your field of working: ");
                    trainer.Field = Console.ReadLine();
                    repo.UpdateTrainer("Company", "Field", trainer.Field, userId);
                    return "TrainerUpdate";
                case "18":
                    Console.Write("Enter your overall experience: ");
                    trainer.Experience = Console.ReadLine();
                    repo.UpdateTrainer("Company", "Overall_Experience", trainer.Experience, userId);
                    return "TrainerUpdate";
                default:
                    Console.WriteLine("Wrong Choice try again");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerProfile";
            }
        }
    }
}
