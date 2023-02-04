using Bussiness_Logic;

namespace UI_Console
{
    public class GetTrainers : IMenu
    {
        ILogic repo = new Logic();

        public void Display()
        {
            Console.WriteLine("\n----------GET TRAINER'S----------\n");
            Console.WriteLine("\n[0] Main Menu\n[1] Get all trainers\n[2] Get trainers by filter");
        }

        public string UserChoice()
        {
            Console.WriteLine("\n---------------------------");
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "Menu";
                case "1":
                    Console.Clear();
                    Console.WriteLine("\n--------------------------------------------------------TRAINERS LIST----------------------------------------------------------\n");

                    Log.Logger.Information("Getting all trainers");

                    var details = repo.GetAllTrainerDetails();

                    foreach (var val in details)
                    {
                        Console.WriteLine(val.DisplayTrainerDetails());
                    }

                    //var details1 = repo1.GetTrainers();

                    //foreach(var val1 in details1)
                    //{
                    //    Console.WriteLine(val1.DisplayTrainerDetails());
                    //}

                    Log.Logger.Information("Reading trainers from database");
                    Log.Logger.Information("Reading traines Ends");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    return "GetTrainers";
                case "2":
                    return "GetTrainerbyFilter";
                default:
                    Console.WriteLine("\nWrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "GetTrainers";
            }
        }
    }
}
