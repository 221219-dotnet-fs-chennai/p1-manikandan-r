﻿using Data;
using System;

namespace UI_Console
{
    public class GetTrainer : IMenu
    {
        static string conStr = File.ReadAllText("../../../../text_files/connectionString.txt");
        IRepo repo = new SqlRepo(conStr);

        public void Display()
        {
            Console.WriteLine("[0] to Main Menu\n[1] to Get all trainers\n");
        }

        public string UserChoice()
        {
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "0":
                    return "Menu";
                case "1":
                    Console.WriteLine("\n----------TRAINERS LIST----------\n");

                    Log.Logger.Information("Getting all trainers");
                    var listoftrainers = repo.GetAllTrainersDisconnected();
                    Log.Logger.Information($"Got list of {listoftrainers.Count} trainers");
                    Log.Logger.Information("Reading trainers from database");

                    foreach (var val in listoftrainers)
                    {
                        Console.WriteLine(val.TrainerDetails());
                    }
                    Log.Logger.Information("Reading traines Ends");
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    return "GetTrainers";

                default:
                    Console.WriteLine("Wrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "GetTrainers";

            }
        }
    }
}
