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
        static string conStr = File.ReadAllText("../../../../Data/ConnectionString.txt");

        IRepo repo = new SqlRepo(conStr);

        static string pass = "";

        public new void Display()
        {
            Console.WriteLine("---------------UPDATE PAGE-----------------");
            Console.WriteLine("\nNote: You can update below details only");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Password                 : " + pass);
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
            Console.WriteLine();

            switch (userChoice)
            {
                case "0":
                    Log.Logger.Information($"{trainer.Firstname} {trainer.Lastname} trainer updated his profile");
                    return "TrainerProfile";
                case "1":
                    Console.Write("Enter new password: ");
                    string password = Console.ReadLine();

                    if (password.Length >= 8)
                    {
                        Console.Write("Enter Password again: ");
                        string password_1 = Console.ReadLine();
                        if (password == password_1)
                        {
                            trainer.Password = password;
                            repo.UpdateTrainer("TrainerDetails", "Password", trainer.Password, userId);
                            for (int i = 0; i < password.Length; i++)
                            {
                                pass += "*";
                            }
                            Console.WriteLine("\nPassword Updated Successfully");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nPassword Does not match...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        trainer.Password = "";
                        Console.WriteLine("\nWarning: Password length must be greater or equal to 8!!");
                        Console.ReadLine();
                    }
                    return "TrainerUpdate";
                case "2":
                    Console.Write("Enter Age: ");
                    trainer.Age = Convert.ToInt32(Console.ReadLine());
                    repo.UpdateTrainer("TrainerDetails", "Age", (trainer.Age).ToString(), userId);
                    Console.WriteLine("\nAge updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "3":
                    Console.Write("Enter new Phone Number: ");
                    trainer.Phonenumber = Console.ReadLine();
                    repo.UpdateTrainer("TrainerDetails", "Phone_Number", trainer.Phonenumber, userId);
                    Console.WriteLine("\nPhone number updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "4":
                    Console.Write("Enter new city: ");
                    trainer.City = Console.ReadLine();
                    repo.UpdateTrainer("TrainerDetails", "City", trainer.City, userId);
                    Console.WriteLine("\nCity updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "5":
                    Console.Write("Enter UG collage name: ");
                    trainer.Ug_collage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_collage", trainer.Ug_collage, userId);
                    Console.WriteLine("\nUG college name updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "6":
                    Console.Write("Enter UG Stream: ");
                    trainer.Ug_stream = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_stream", trainer.Ug_stream, userId);
                    Console.WriteLine("\nUG stream updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "7":
                    Console.Write("Enter UG percentage: ");
                    trainer.Ug_percentage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_Percentage", trainer.Ug_percentage, userId);
                    Console.WriteLine("\nUG percentage updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "8":
                    Console.Write("Enter UG year: ");
                    trainer.Ug_year = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Ug_year", trainer.Ug_year, userId);
                    Console.WriteLine("\nUG year updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "9":
                    Console.Write("Enter PG collage name: ");
                    trainer.Pg_collage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_collage", trainer.Pg_collage, userId);
                    Console.WriteLine("\nPG college name updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "10":
                    Console.Write("Enter PG Stream: ");
                    trainer.Pg_stream = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_stream", trainer.Pg_stream, userId);
                    Console.WriteLine("\nPG stream updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "11":
                    Console.Write("Enter PG percentage: ");
                    trainer.Pg_percentage = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_Percentage", trainer.Pg_percentage, userId);
                    Console.WriteLine("\nPG percentage updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "12":
                    Console.Write("Enter PG year: ");
                    trainer.Pg_year = Console.ReadLine();
                    repo.UpdateTrainer("Education", "Pg_year", trainer.Pg_year, userId);
                    Console.WriteLine("\nPG year updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "13":
                    Console.Write("Enter your skill 1: ");
                    trainer.Skill_1 = Console.ReadLine();
                    repo.UpdateTrainer("Skill", "Skill_1", trainer.Skill_1, userId);
                    Console.WriteLine("\nSkill 1 updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "14":
                    Console.Write("Enter your skill 2: ");
                    trainer.Skill_2 = Console.ReadLine();
                    repo.UpdateTrainer("Skill", "Skill_2", trainer.Skill_2, userId);
                    Console.WriteLine("\nSkill 2 updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "15":
                    Console.Write("Enter your skill 3: ");
                    trainer.Skill_3 = Console.ReadLine();
                    repo.UpdateTrainer("Skill", "Skill_3", trainer.Skill_3, userId);
                    Console.WriteLine("\nSkill 3 updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "16":
                    Console.Write("Enter company name: ");
                    trainer.Companyname = Console.ReadLine();
                    repo.UpdateTrainer("Company", "Company_Name", trainer.Companyname, userId);
                    Console.WriteLine("\nCompany name updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "17":
                    Console.Write("Enter your field of working: ");
                    trainer.Field = Console.ReadLine();
                    repo.UpdateTrainer("Company", "Field", trainer.Field, userId);
                    Console.WriteLine("\nCompany Field updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerUpdate";
                case "18":
                    Console.Write("Enter your overall experience: ");
                    trainer.Experience = Console.ReadLine();
                    repo.UpdateTrainer("Company", "Overall_Experience", trainer.Experience, userId);
                    Console.WriteLine("\nOverall Experience updated successfully");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
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
