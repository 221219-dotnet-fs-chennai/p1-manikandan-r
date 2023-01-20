
using Data;
using UI_Console;

internal class LogIn : SignUp, IMenu
{
    static string conStr = File.ReadAllText("../../../../Data/ConnectionString.txt");

    IRepo repo = new SqlRepo(conStr);
    public new void Display()
    {
        Console.WriteLine("\n-------LOGIN PAGE------\n");
        Console.WriteLine("[0] for Trainer Menu");
        Console.WriteLine("[1] to Proceed Login");
        Console.WriteLine("[2] Forgot password");
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
            case "2":
                Console.Write("\nEnter your Email ID: ");
                string passResetEmail = Console.ReadLine();
                bool ans2 = repo.forgetPassword(passResetEmail);
                if (ans2)
                {
                    string[] emailArr = passResetEmail.Split("@");
                    string userId = emailArr[0];

                    Console.Write("\nEnter new password: ");
                    string password = Console.ReadLine();

                    if (password.Length >= 8)
                    {
                        Console.Write("Enter Password again: ");
                        string password_1 = Console.ReadLine();
                        if (password == password_1)
                        {
                            trainer.Password = password;
                            repo.UpdateTrainer("TrainerDetails", "Password", trainer.Password, userId);
                            Console.WriteLine("\nPassword Updated Successfully");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nPassword Does not match...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        trainer.Password = "";
                        Console.WriteLine("\nWarning: Password length must be greater or equal to 8!!");
                        Console.ReadLine();
                    }
                }

                return "Login";

            default:
                Console.WriteLine("\nWrong choice try again...");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return "Login";
        }
    }
}