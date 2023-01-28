
namespace UI_Console
{
    public class TrainerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("\n----------TRAINER'S MENU----------\n");
            Console.WriteLine("[0] to Main Menu");
            Console.WriteLine("[1] to Login");
            Console.WriteLine("[2] to Signup");
        }

        public string UserChoice()
        {
            Console.WriteLine("\n--------------------------");
            Console.Write("\nEnter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "Login";
                case "2":
                    return "Signup"; 
                default:
                    Console.WriteLine("Wrong Choice! Try again...");
                    Console.WriteLine("Enter to Continue...");
                    Console.ReadLine();
                    return "TrainerMenu";
            }
        }
    }
}
