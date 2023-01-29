using Bussiness_Logic;
using Trainer_EF_Layer;
using UI_Console;

internal class LogIn : SignUp, IMenu
{

    IRepoEF repo = new TrainerEFRepo();
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
                    string[] emailarr = EMail.Split("@");
                    string eMail = emailarr[0];
                    SignUp trainerLogin = new SignUp(repo.GetAllTrainers(eMail), repo.GetAllEducation(eMail), repo.GetAllSkills(eMail), repo.GetAllCompanies(eMail));
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