using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class Trainer_delete: SignUp
    {
        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IRepo repo = new SqlRepo(conStr);
        public void Dispaly()
        {
            Console.WriteLine("\n-------DELETE PAGE------\n");
            Console.WriteLine("Are you Sure?");
            Console.WriteLine("[0] for Back");
            Console.WriteLine("[1] proceed to delete");
        }

        public string UserChoice()
        {
            Console.WriteLine("---------------------------");
            Console.Write("\nEnter your choice: ");
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "0":
                    return "TrainerProfile";
                case "1":
                    Console.WriteLine("Thank You For using 'Trainer Picker'");
                    string[] emailArr = trainer.Emailid.Split("@");
                    string userId = emailArr[0];
                    repo.DeleteTrainer(userId);
                    Console.WriteLine("Profile Deleted Successfully...");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "TrainerProfile";
                default:
                    Console.WriteLine("Wrong Choice try again");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return "TrainerProfile";
            }
        }
    }
}
