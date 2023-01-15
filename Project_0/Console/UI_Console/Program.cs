﻿global using Serilog;
using Data;
using System;
using System.Data.SqlClient;

namespace UI_Console
{
    public class MainFile
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"..\..\..\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();

            Log.Logger.Information("-------Program starts-------");

            bool value = true;
            bool value_2 = true;
            bool value_3 = true;

            IMenu menu = new Menu();
            IMenu trainerMenu = new TrainerMenu();
            IMenu userlogin = new UserMenu();

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

                    case "User":
                        Log.Logger.Information("User select general user login");
                        value_2 = true;

                        menu = new UserMenu();

                        while (value_2)
                        {
                            Console.Clear();
                            menu.Display();
                            string userChoice = menu.UserChoice();

                            switch (userChoice)
                            {
                                case "Menu":
                                    menu = new Menu();
                                    value_2 = false;
                                    break;
                                case "UserLogin":
                                    menu = new UserLogin();
                                    break;
                                case "UserMenu":
                                    menu = new UserMenu();
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice! Try again...");
                                    Console.WriteLine("Enter to Continue...");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;

                    case "Trainer":

                        Log.Logger.Information("User select trainer");
                        value_3 = true;

                        menu = new TrainerMenu();

                        while (value_3)
                        {
                            Console.Clear();
                            menu.Display();
                            string trainerChoice = menu.UserChoice();

                            switch (trainerChoice)
                            {
                                case "Login":
                                    Log.Logger.Information("User select trainer login");
                                    LogIn trainerLogin = new LogIn();
                                    trainerLogin.login();
                                    break;
                                case "Signup":
                                    Log.Logger.Information("User select trainer signup");
                                    menu = new SignUp();
                                    break;
                                case "MainMenu":
                                    Log.Logger.Information("User select Main menu");
                                    menu = new Menu();
                                    value_3 = false;
                                    break;
                                case "TrainerMenu":
                                    Log.Logger.Information("User select trainer menu");
                                    menu = new TrainerMenu();
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
