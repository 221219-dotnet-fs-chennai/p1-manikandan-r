using System;

namespace UI_Console
{
    public class UserMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("[0] to Main Menu\n[1] to Login\n");
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
                    return "UserLogin";
                default:
                    Console.WriteLine("Wrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "userMenu";

            }
        }
    }
}
