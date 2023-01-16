global using Serilog;
using Data;
using System;
using System.Data.SqlClient;

namespace UI_Console
{
    internal class MainFile: SignUp
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"..\..\..\..\Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();

            Log.Logger.Information("-------Program starts-------");

            bool value = true;
            bool value_2 = true;
            bool value_3 = true;

            IMenu menu = new Menu();

            while (value)
            {
                Console.Clear();
                menu.Display();

                string reply = menu.UserChoice();

                switch (reply)
                {
                    case "Menu":
                        Log.Logger.Information("Display menu to the user");
                        menu = new Menu();
                        break;

                    case "GetTrainers":
                        menu = new GetTrainer();
                        break;

                    case "Trainer":

                        Log.Logger.Information("User select trainer");
                        value_2 = true;

                        menu = new TrainerMenu();

                        while (value_2)
                        {
                            Console.Clear();
                            menu.Display();
                            string trainerChoice = menu.UserChoice();

                            switch (trainerChoice)
                            {
                                case "Login":
                                    trainer = new Trainer();
                                    Log.Logger.Information("User select trainer login");
                                    menu = new LogIn();
                                    break;
                                case "Signup":
                                    Log.Logger.Information("User select trainer signup");
                                    menu = new SignUp();
                                    break;
                                case "MainMenu":
                                    Log.Logger.Information("User select Main menu");
                                    menu = new Menu();
                                    value_2 = false;
                                    break;
                                case "TrainerMenu":
                                    Log.Logger.Information("User select trainer menu");
                                    menu = new TrainerMenu();
                                    break;
                                case "TrainerProfile":
                                    menu = new TrainerProfile(trainer);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice! Try again...");
                                    Console.WriteLine("Enter to Continue...");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;

                    case "Exit":
                        Console.WriteLine("Exiting...");
                        Log.Logger.Information("-------Program ends-------");
                        Log.CloseAndFlush();
                        value = false;
                        break;

                    default:
                        Console.WriteLine("DataBase Does not exist");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
