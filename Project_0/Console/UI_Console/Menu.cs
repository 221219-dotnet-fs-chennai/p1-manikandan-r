using System;

namespace UI_Console
{
    internal class Menu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome :)\nSelect an option to proceed.");
            Console.Write("Press 1 to Login\nPress 2 to SignUp\nPress 3 to Exit\n> ");
        }

        public string UserChoice()
        {
            string login_signup = (Console.ReadLine());

            switch (login_signup)
            {
                case "1":
                    return "Login";
                case "2":
                    return "Signup";
                case "3":
                    return "Exit";
                default:
                    Console.WriteLine("Wrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "Menu";
            }
        }
    }
}
