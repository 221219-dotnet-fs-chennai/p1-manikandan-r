using Bussiness_Logic;

namespace UI_Console
{
    internal class Menu : IMenu
    {
        ILogic repo = new Logic();
        public void Display()
        {
            Console.WriteLine("\nWelcome to Trainer Picker :)...\n\nSelect an option to proceed...");
            Console.Write("\nPress [0] to Exit\nPress [1] to Get Trainers List\nPress [2] to Trainer Login or Signup");
        }

        public string UserChoice()
        {
            Console.WriteLine("\n--------------------------------------");
            Console.Write("\nEnter your choice: ");
            string login_signup = Console.ReadLine();

            switch (login_signup)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    bool answer = repo.captchaReturn();

                    if (answer)
                    {
                        Console.WriteLine("\nCaptcha matched ;), Welcome Human...");
                        Console.Write("\nPress Enter to Continue...");
                        Console.ReadLine();
                        return "GetTrainers";
                    }
                    else
                    {
                        Console.WriteLine("\nCaptcha not matched :|, Aliens not allowed!!...");
                        Console.Write("\nPress Enter to Continue...");
                        Console.ReadLine();
                        return "Menu";
                    }
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
