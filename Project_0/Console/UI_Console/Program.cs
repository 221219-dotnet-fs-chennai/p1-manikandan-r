using System;
using System.Data.SqlClient;

namespace UI_Console
{
    public class MainFile
    {
        static void Main(string[] args)
        {
            bool value = true;
            bool value_2 = true;

            IMenu menu = new Menu();
            IMenu trainerMenu = new TrainerMenu();

            while (value)
            {
                Console.Clear();
                menu.Display();

                string reply = menu.UserChoice();

                switch (reply)
                {
                    case "Menu":
                        menu = new Menu();
                        break;
                    case "User":
                        LogIn login = new LogIn();
                        login.login();
                        break;
                    case "Trainer":

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
                                    LogIn trainerLogin = new LogIn();
                                    trainerLogin.login();
                                    break;
                                case "Signup":
                                    menu = new SignUp();
                                    break;
                                case "MainMenu":
                                    menu = new Menu();
                                    value_2 = false;
                                    break;
                                case "TrainerMenu":
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
                        value = false;
                        break;
                    default:
                        Console.WriteLine("DataBase Does not exist");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
            //SqlRepo sql = new SqlRepo();
            //sql.Add();
            //sql.Insert();
        }
    }
}
