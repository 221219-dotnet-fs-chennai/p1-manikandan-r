using Bussiness_Logic;
using UI_Console;

internal class LogIn : SignUp, IMenu
{

    Bussiness_Logic.ILogic repo = new Logic();
    public new void Display()
    {
        Console.WriteLine("\n-------LOGIN PAGE------\n");
        Console.WriteLine("[0] for Trainer Menu");
        Console.WriteLine("[1] to Proceed Login");
    }

    public new string UserChoice()
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
                string EMail = Console.ReadLine();
                bool ans = repo.login(EMail);
                if (ans)
                {
                    SignUp trainerLogin = new SignUp(repo.GetAllTrainers(EMail), repo.GetAllEducation(EMail), repo.GetAllSkills(EMail), repo.GetAllCompanies(EMail));
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