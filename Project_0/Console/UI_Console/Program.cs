using System;
using System.Data.SqlClient;

namespace UI_Console
{
    public class MainFile
    {
        static void Main(string[] args)
        {
            bool value = true;

            IMenu menu = new Menu();

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
                    case "Login":
                        LogIn login = new LogIn();
                        login.login();
                        break;
                    case "Signup":
                        menu = new SignUp();
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
