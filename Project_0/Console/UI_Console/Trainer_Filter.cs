using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class Trainer_Filter : IMenu
    {
        Trainer trainerFilter = new Trainer();

        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IRepo repo = new SqlRepo(conStr);

        static string cityFilter;
        static string skillFilter;
        static string companyFilter;
        public Trainer_Filter(Trainer trainer)
        {
            trainerFilter = trainer;
        }
        public void Display()
        {
            Console.WriteLine("----------TRAINER'S FILTER----------");
            Console.WriteLine("\nChoose a filter and type details then Choose [1] to search");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Search");
            Console.WriteLine("[2] Filter by City       : " + cityFilter);
            Console.WriteLine("[3] Filter by Skill      : " + skillFilter);
            Console.WriteLine("[4] Filter by Company    : " + companyFilter);
        }

        public string UserChoice()
        {
            Console.WriteLine("\n---------------------------");
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "0":
                    return "GetTrainers";
                case "1":
                    return "GetTrainerbyFilter";
                case "2":
                    Console.Write("Enter City name to filter: ");
                    cityFilter = Console.ReadLine();
                    Console.WriteLine("Enter to continue");
                    return "GetTrainerbyFilter";
                case "3":
                    Console.Write("Enter Skill name to filter: ");
                    skillFilter = Console.ReadLine();
                    Console.WriteLine("Enter to continue");
                    return "GetTrainerbyFilter";
                case "4":
                    Console.Write("Enter Company name to filter: ");
                    companyFilter = Console.ReadLine();
                    Console.WriteLine("Enter to continue");
                    return "GetTrainerbyFilter";
                default:
                    Console.WriteLine("Wrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "GetTrainerbyFilter";
            }
        }
    }
}
