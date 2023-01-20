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

        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IRepo repo = new SqlRepo(conStr);
        public TrainerProfile(Trainer trainerSignup)
        {
            trainerProfile = trainerSignup;
        }
        public void Display()
        {
            Log.Logger.Information($"{trainerProfile.Firstname} {trainerProfile.Lastname} trainer logged in");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Welcome {trainerProfile.Firstname} {trainerProfile.Lastname} :)");
            Console.WriteLine("\nChoose below options to perform actions:-");
            Console.WriteLine("[0] Logout");
            Console.WriteLine("[1] View Profile");
            Console.WriteLine("[2] Update/Edit Profile");
            Console.WriteLine("[3] Delete Particular Field");
            Console.WriteLine("[4] Delete Profile");
        }

        public string UserChoice()
        {
            Console.WriteLine("\n--------------------------");
            Console.Write("\nEnter your choice: ");
            string userChoice = Console.ReadLine();
            
            switch(userChoice)
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
                            string email = trainerProfile.Emailid;

                            Log.Logger.Information($"{trainerProfile.Firstname} {trainerProfile.Lastname} profile deleted");
                            Console.WriteLine("\nThank You For using 'Trainer Picker'");
                            string[] emailArr = email.Split("@");
                            string userId = emailArr[0];
                            repo.DeleteTrainer(userId);
                            Console.WriteLine("\nProfile Deleted Successfully...");
                            Console.WriteLine("\nPress Enter to Continue");
                            Console.ReadLine();
                            return "TrainerMenu";
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
            Log.Logger.Information($"display {trainerProfile.Firstname} {trainerProfile.Lastname} profile");
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
