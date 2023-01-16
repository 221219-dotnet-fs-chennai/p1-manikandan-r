using System;

namespace UI_Console
{
    internal class Menu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("\nWelcome to Trainer Picker :)...\nSelect an option to proceed.");
            Console.Write("\nPress [0] to Exit\nPress [1] to Get Trainers List\nPress [2] to Trainer\n> ");
        }

        public string UserChoice()
        {
            string login_signup = Console.ReadLine();

            switch (login_signup)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "GetTrainers";
                case "2":
                    return "Trainer";
                default:
                    Console.WriteLine("Wrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "Menu";
            }
        }
    }
}
