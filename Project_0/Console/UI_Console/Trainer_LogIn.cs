
using Data;
using UI_Console;

public class LogIn : IMenu
{
    static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

    IRepo repo = new SqlRepo(conStr);
    public void Display()
    {
        Console.WriteLine("-------LOGIN PAGE------");
        Console.WriteLine("[0] for Trainer Menu");
        Console.WriteLine("[1] to proceed Login");
    }

    public string UserChoice()
    {
        Console.Write("Enter your choice: ");
        string userChoice = Console.ReadLine();

        switch(userChoice)
        {
            case "0":
                return "TrainerMenu";
            case "1":
                Console.Write("Enter your Email ID: ");
                string eMail = Console.ReadLine();
                bool ans = repo.login(eMail);
                if (ans)
                {
                    SignUp trainerLogin = new SignUp(repo.GetAllTrainer(eMail));
                    return "TrainerProfile";
                }
                else
                {
                    Console.WriteLine("Account not found");
                    Console.ReadLine();
                    return "Login";
                }

            default:
                Console.WriteLine("Wrong choice try again...");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return "TrainerLogin";
        }
    }
}