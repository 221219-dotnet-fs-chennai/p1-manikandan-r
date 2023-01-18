
using Data;
using UI_Console;

public class LogIn : IMenu
{
    static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

    IRepo repo = new SqlRepo(conStr);
    public void Display()
    {
        Console.WriteLine("\n-------LOGIN PAGE------\n");
        Console.WriteLine("[0] for Trainer Menu");
        Console.WriteLine("[1] to Proceed Login");
    }

    public string UserChoice()
    {
        Console.WriteLine("\n---------------------------");
        Console.Write("\nEnter your choice: ");
        string userChoice = Console.ReadLine();

        switch(userChoice)
        {
            case "0":
                return "TrainerMenu";
            case "1":
                Console.Write("\nEnter your Email ID: ");
                string eMail = Console.ReadLine();
                bool ans = repo.login(eMail);
                if (ans)
                {
                    SignUp trainerLogin = new SignUp(repo.GetAllTrainer(eMail));
                    return "TrainerProfile";
                }
                else
                {
                    return "Login";
                }

            default:
                Console.WriteLine("\nWrong choice try again...");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return "Login";
        }
    }
}