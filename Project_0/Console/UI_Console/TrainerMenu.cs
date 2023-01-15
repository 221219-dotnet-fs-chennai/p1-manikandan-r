
namespace UI_Console
{
    public class TrainerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("[1] to Login");
            Console.WriteLine("[2] to Signup");
            Console.WriteLine("[3] to Main Menu");
        }

        public string UserChoice()
        {
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    return "Login";
                case "2":
                    return "Signup";
                case "3":
                    return "MainMenu";    
                default:
                    Console.WriteLine("Wrong Choice! Try again...");
                    Console.WriteLine("Enter to Continue...");
                    Console.ReadLine();
                    return "TrainerMenu";
            }
        }
    }
}
