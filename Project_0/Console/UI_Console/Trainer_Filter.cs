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
        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IFilter repo = new FilterRepo(conStr);

        static string cityFilter = "ex: chennai or delhi";
        static string skillFilter = "ex: python or java";
        static string companyFilter = "ex: micosoft or infosys";

        public void Display()
        {
            Console.WriteLine("----------TRAINER'S FILTER----------");
            Console.WriteLine("\nInstructions:-");
            Console.WriteLine("Choose a filter by respective number and type data");
            Console.WriteLine("Then type [1] and hit enter to search (you can choose multiple filters)\n");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Search");
            Console.WriteLine("[2] Filter by City       : " + cityFilter);
            Console.WriteLine("[3] Filter by Skill      : " + skillFilter);
            Console.WriteLine("[4] Filter by Company    : " + companyFilter);
        }

        public string UserChoice()
        {
            Console.WriteLine("\n---------------------------");
            Console.Write("\nEnter your choice: ");
            string userChoice = Console.ReadLine();
            Console.WriteLine();

            switch (userChoice)
            {
                case "0":
                    return "GetTrainers";
                case "1":
                    Console.WriteLine("\n--------------------------------------------------------TRAINERS LIST----------------------------------------------------------\n");
                    var listOfTrainerByFilter = repo.TrainerFilter(cityFilter.ToLower(), skillFilter.ToLower(), companyFilter.ToLower());
                    foreach (var trainer in listOfTrainerByFilter)
                    {
                        Console.WriteLine(trainer.TrainerDetails());
                    }
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    cityFilter = "ex: chennai or delhi";
                    skillFilter = "ex: python or java";
                    companyFilter = "ex: micosoft or infosys";
                    return "GetTrainers";
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
                    Console.WriteLine("\nWrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "GetTrainerbyFilter";
            }
        }
    }
}
