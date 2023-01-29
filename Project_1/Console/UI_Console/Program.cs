global using Serilog;
using Trainer_EF_Layer.Entities;
using System;
using System.Data.SqlClient;
using Models;

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
                        Log.Logger.Information("User choose get trainers");
                        menu = new GetTrainers();
                        break;

                    case "GetTrainerbyFilter":
                        menu = new Trainer_Filter();
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
                                    trainer = new Models.TrainerDetail();
                                    education = new TrainerEducation();
                                    skill = new TrainerSkill();
                                    company = new TrainerCompany();
                                    Log.Logger.Information("User select trainer login");
                                    menu = new LogIn();
                                    break;
                                case "Signup":
                                    Log.Logger.Information("User select trainer signup");
                                    menu = new SignUp();
                                    break;
                                case "MainMenu":
                                    menu = new Menu();
                                    value_2 = false;
                                    break;
                                case "TrainerMenu":
                                    menu = new TrainerMenu();
                                    break;
                                case "TrainerProfile":
                                    menu = new TrainerProfile(trainer, education, skill, company);
                                    break;
                                case "TrainerUpdate":
                                    menu = new TrainerUpdate();
                                    break;
                                case "TrainerDelete":
                                    menu = new TrainerDelete();
                                    break;
                                default:
                                    Console.WriteLine("\nWrong Choice! Try again...");
                                    Console.WriteLine("Enter to Continue...");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;

                    case "Exit":
                        Console.WriteLine("\nThank for using 'Trainer Picker'");
                        Log.Logger.Information("-------Program ends-------");
                        Log.CloseAndFlush();
                        value = false;
                        break;

                    default:
                        Console.WriteLine("\nDataBase Does not exist");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
