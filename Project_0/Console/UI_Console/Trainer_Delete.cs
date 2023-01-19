using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class TrainerDelete : SignUp, IMenu
    {

        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IRepo repo = new SqlRepo(conStr);

        public new void Display()
        {
            Console.WriteLine("---------------DELETE PARTICULAR FIELD-----------------");
            Console.WriteLine("\nNote: You can delete below details only");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Age                      : " + trainer.Age);
            Console.WriteLine("[2] Phone Number             : " + trainer.Phonenumber);
            Console.WriteLine("[3] City                     : " + trainer.City);
            Console.WriteLine("[4] UG college name          : " + trainer.Ug_collage);
            Console.WriteLine("[5] UG stream                : " + trainer.Ug_stream);
            Console.WriteLine("[6] UG percentage            : " + trainer.Ug_percentage);
            Console.WriteLine("[7] UG year                  : " + trainer.Ug_year);
            Console.WriteLine("[8] PG college name          : " + trainer.Pg_collage);
            Console.WriteLine("[9] PG stream                : " + trainer.Pg_stream);
            Console.WriteLine("[10] PG percentage           : " + trainer.Pg_percentage);
            Console.WriteLine("[11] PG year                 : " + trainer.Pg_year);
            Console.WriteLine("[12] Skill 1                 : " + trainer.Skill_1);
            Console.WriteLine("[13] Skill 2                 : " + trainer.Skill_2);
            Console.WriteLine("[14] Skill 3                 : " + trainer.Skill_3);
            Console.WriteLine("[15] Company name            : " + trainer.Companyname);
            Console.WriteLine("[16] Field                   : " + trainer.Field);
            Console.WriteLine("[17] Overall Experience      : " + trainer.Experience);
        }

        public new string UserChoice()
        {
            string[] emailArr = trainer.Emailid.Split("@");
            string userId = emailArr[0];

            Console.WriteLine("\n--------------------------");
            Console.Write("\nEnter your choice: ");
            string userChoice = Console.ReadLine();
            Console.WriteLine();

            switch (userChoice)
            {
                case "0":
                    return "TrainerProfile";
                case "1":
                    repo.UpdateTrainer("TrainerDetails", "Age", "0", userId);
                    trainer.Age = 0;
                    Console.WriteLine("\nAge deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "2":
                    repo.UpdateTrainer("TrainerDetails", "Phone_Number", " ", userId);
                    trainer.Phonenumber = " ";
                    Console.WriteLine("\nPhone number deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "3":
                    repo.UpdateTrainer("TrainerDetails", "City", " ", userId);
                    trainer.City = " ";
                    Console.WriteLine("\nCity deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "4":
                    repo.UpdateTrainer("Education", "Ug_collage", " ", userId);
                    trainer.Ug_collage = " ";
                    Console.WriteLine("\nUG college name deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "5":
                    repo.UpdateTrainer("Education", "Ug_stream", " ", userId);
                    trainer.Ug_stream = " ";
                    Console.WriteLine("\nUG stream deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "6":
                    repo.UpdateTrainer("Education", "Ug_Percentage", " ", userId);
                    trainer.Ug_percentage = " ";
                    Console.WriteLine("\nUG percentage deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "7":
                    repo.UpdateTrainer("Education", "Ug_year", " ", userId);
                    trainer.Ug_year = " ";
                    Console.WriteLine("\nUG year deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "8":
                    repo.UpdateTrainer("Education", "Pg_collage", " ", userId);
                    trainer.Pg_collage = " ";
                    Console.WriteLine("\nPG college name deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "9":
                    repo.UpdateTrainer("Education", "Pg_stream", " ", userId);
                    trainer.Pg_stream = " ";
                    Console.WriteLine("\nPG stream deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "10":
                    repo.UpdateTrainer("Education", "Pg_Percentage", " ", userId);
                    trainer.Pg_percentage = " ";
                    Console.WriteLine("\nPG percentage deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "11":
                    repo.UpdateTrainer("Education", "Pg_year", " ", userId);
                    trainer.Pg_year = " ";
                    Console.WriteLine("\nUG year deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "12":
                    repo.UpdateTrainer("Skill", "Skill_1", " ", userId);
                    trainer.Skill_1 = " ";
                    Console.WriteLine("\nSkill 1 deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "13":
                    repo.UpdateTrainer("Skill", "Skill_2", " ", userId);
                    trainer.Skill_2 = " ";
                    Console.WriteLine("\nSkill 2 deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "14":
                    repo.UpdateTrainer("Skill", "Skill_3", " ", userId);
                    trainer.Skill_3 = " ";
                    Console.WriteLine("\nSkill 3 deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "15":
                    repo.UpdateTrainer("Company", "Company_Name", " ", userId);
                    trainer.Companyname = " ";
                    Console.WriteLine("\nCompany name deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "16":
                    repo.UpdateTrainer("Company", "Field", " ", userId);
                    trainer.Field = " ";
                    Console.WriteLine("\nCompany Field deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                case "17":
                    repo.UpdateTrainer("Company", "Overall_Experience", " ", userId);
                    trainer.Experience = " ";
                    Console.WriteLine("\nOverall Experience deleted successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerDelete";
                default:
                    Console.WriteLine("Wrong Choice try again");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerProfile";
            }
        }
    }
}
