using System;

namespace UI_Console
{
    internal class Menu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to Trainer Picker :)...\nSelect an option to proceed.");
            Console.Write("Press [1] to User\nPress [2] to Trainer\nPress [3] to Exit\n> ");
        }

        public string UserChoice()
        {
            string login_signup = (Console.ReadLine());

            switch (login_signup)
            {
                case "1":
                    return "User";
                case "2":
                    return "Trainer";
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
