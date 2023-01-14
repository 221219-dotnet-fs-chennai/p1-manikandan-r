using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Data;

namespace UI_Console
{
    public class MainFile
    {
        public static void back()
        {
            SignUp signup = new SignUp();

            Console.Write("Press 0 to back: ");
            string backOption = Console.ReadLine();
            if (backOption == "0")
            {
                signup.displayDetails();
            }
        }
        static void Main(string[] args)
        {
            bool value = true;

            Menu menu = new Menu();

            while (value)
            {
                Console.Clear();
                menu.Display();
                string reply = menu.UserChoice();

                switch (reply)
                {
                    case "1":
                        LogIn login = new LogIn();
                        login.login();
                        break;
                    case "2":
                        SignUp signup = new SignUp();
                        signup.userDetails();
                        signup.eduDetails();
                        back();
                        signup.skillDetails();
                        signup.companyDetails();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        value = false;
                        break;
                    default:
                        Console.WriteLine("You entered wrong number!");
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
