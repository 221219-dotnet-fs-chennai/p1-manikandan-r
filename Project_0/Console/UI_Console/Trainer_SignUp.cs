// get details from user

using Data;
using System.Text.RegularExpressions;

namespace UI_Console
{
    internal class SignUp : IMenu
    {
        internal static Trainer trainer = new Trainer();

        public SignUp(Trainer trainerLogin)
        {
            trainer = trainerLogin;
        }
        public SignUp()
        {

        }
        
        static string conStr = File.ReadAllText("../../../../Data/ConnectionString.txt");

        IRepo repo = new SqlRepo(conStr);

        static string pass = "";

        public void Display()
        {
            Console.WriteLine("\n--------------------------SIGNUP PAGE--------------------------\n");
            Console.WriteLine("NOTE: * fields are mandatory\n");
            Console.WriteLine("[00] Clear");
            Console.WriteLine("[0] Trainer Menu");
            Console.WriteLine("[1] Submit Details");
            Console.WriteLine("[2] Email ID*            : " + trainer.Emailid);
            Console.WriteLine("[3] Password*            : " + pass);
            Console.WriteLine("[4] Firstname*           : " + trainer.Firstname);
            Console.WriteLine("[5] Lastname*            : " + trainer.Lastname);
            Console.WriteLine("[6] Age*                 : " + trainer.Age);
            Console.WriteLine("[7] Gender*              : " + trainer.Gender);
            Console.WriteLine("[8] Phone number*        : " + trainer.Phonenumber);
            Console.WriteLine("[9] City*                : " + trainer.City);
            Console.WriteLine("[10] UG Collage name*    : " + trainer.Ug_collage);
            Console.WriteLine("[11] UG Stream*          : " + trainer.Ug_stream);
            Console.WriteLine("[12] UG Percentage*      : " + trainer.Ug_percentage);
            Console.WriteLine("[13] UG Passed out Year* : " + trainer.Ug_year);
            Console.WriteLine("[14] PG Collage name     : " + trainer.Pg_collage);
            Console.WriteLine("[15] PG Stream           : " + trainer.Pg_stream);
            Console.WriteLine("[16] PG Percentage       : " + trainer.Pg_percentage);
            Console.WriteLine("[17] PG Passed out Year  : " + trainer.Pg_year);
            Console.WriteLine("[18] Skill 1*            : " + trainer.Skill_1);
            Console.WriteLine("[19] Skill 2*            : " + trainer.Skill_2);
            Console.WriteLine("[20] Skill 3             : " + trainer.Skill_3);
            Console.WriteLine("[21] Company name        : " + trainer.Companyname);
            Console.WriteLine("[22] Field of working    : " + trainer.Field);
            Console.WriteLine("[23] Overall experience  : " + trainer.Experience);
        }
        public string UserChoice()
        {
            Console.WriteLine("--------------------------");
            Console.Write("\nEnter your choice: ");
            string userchoice = Console.ReadLine();
            Console.WriteLine();

            switch (userchoice)
            {
                case "00":
                    trainer = new Trainer();
                    pass = "";
                    return "TrainerMenu";
                case "0":
                    return "TrainerMenu";
                case "1":
                    try
                    {
                        Log.Logger.Information("Adding trainer details");
                        repo.Insertion(trainer);
                        trainer = new Trainer();
                        pass = "";
                        Log.Logger.Information("Successfully added trainer details");
                    }
                    catch (System.Exception ex) 
                    {
                        Log.Logger.Information($"Failed to add trainer details {ex.Message}");
                        Console.WriteLine("\nFields Cannot be Empty! Fill Mandotory details!!");
                        Console.WriteLine("            Or             ");
                        Console.WriteLine("The Email already Exist");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                    }
                    return "TrainerMenu";
                case "2":
                    Console.Write("Enter your Email ID: ");
                    string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,7}$";

                    string email_id = Console.ReadLine();
                    try
                    {
                        if (Regex.IsMatch(email_id, emailPattern))
                        {
                            trainer.Emailid = email_id;
                        }
                        else
                        {
                            Console.WriteLine("Check your Email ID\nWrong pattern try again...");
                            Console.ReadLine();
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Check your Email ID\nWrong pattern try again...");
                        Console.ReadLine();
                    }

                    return "Signup";
                case "3":
                    Console.Write("Enter your Password: ");
                    string password = Console.ReadLine();

                    if (password.Length >= 8)
                    {
                        Console.Write("Enter Password again: ");
                        string password_1 = Console.ReadLine();
                        if (password == password_1)
                        {
                            pass = "";
                            trainer.Password = password;
                            for (int i = 0; i < password.Length; i++)
                            {
                                pass += "*";
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nPassword Does not match...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nWarning: Password length must be greater or equal to 8!!");
                        Console.ReadLine();
                    }
                    return "Signup";
                case "4":
                    Console.Write("Enter your Firstname: ");
                    trainer.Firstname = Console.ReadLine();
                    return "Signup";
                case "5":
                    Console.Write("Enter your Lastname: ");
                    trainer.Lastname = Console.ReadLine();
                    return "Signup";  
                case "6":
                    try
                    {
                        Console.Write("Enter your Age: ");
                        trainer.Age = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(Exception ex)
                    {
                        Log.Logger.Information("Age value entered in numbers it throws exception");
                        Console.WriteLine("Age should be in numbers!!");
                        Console.ReadLine();
                    }
                    return "Signup";
                case "7":
                    Console.Write("Enter your Gender: ");
                    trainer.Gender = Console.ReadLine();
                    return "Signup";
                case "8":
                    Console.Write("Enter your Phone number: ");
                    string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

                    string phone_number = Console.ReadLine();

                    if (phone_number.Length <= 15 && Regex.IsMatch(phone_number, pattern))
                    {
                        trainer.Phonenumber = phone_number;
                    }
                    else
                    {
                        Console.WriteLine("Wrong pattern try again...");
                        Console.ReadLine();
                    }
                    return "Signup";
                case "9":
                    Console.Write("Enter you City: ");
                    trainer.City = Console.ReadLine();
                    return "Signup";
                case "10":
                    Console.Write("Enter your UG collage name: ");
                    trainer.Ug_collage = Console.ReadLine();
                    return "Signup";
                case "11":
                    Console.Write("Enter your UG stream: ");
                    trainer.Ug_stream = Console.ReadLine();
                    return "Signup";
                case "12":
                    Console.Write("Enter your UG percentage: ");
                    trainer.Ug_percentage = Console.ReadLine();
                    return "Signup";
                case "13":
                    Console.Write("Enter your UG passed out year: ");
                    trainer.Ug_year = Console.ReadLine();
                    return "Signup";
                case "14":
                    Console.Write("Enter your PG collage name: ");
                    trainer.Pg_collage = Console.ReadLine();
                    return "Signup";
                case "15":
                    Console.Write("Enter your PG stream: ");
                    trainer.Pg_stream = Console.ReadLine();
                    return "Signup";
                case "16":
                    Console.Write("Enter your PG percentage: ");
                    trainer.Pg_percentage = Console.ReadLine();
                    return "Signup";
                case "17":
                    Console.Write("Enter your PG passed out year: ");
                    trainer.Pg_year = Console.ReadLine();
                    return "Signup";
                case "18":
                    Console.Write("Enter your 1st skill: ");
                    trainer.Skill_1 = Console.ReadLine();
                    return "Signup";
                case "19":
                    Console.Write("Enter your 2nd skill: ");
                    trainer.Skill_2 = Console.ReadLine();
                    return "Signup";
                case "20":
                    Console.Write("Enter your 3rd skill: ");
                    trainer.Skill_3 = Console.ReadLine();
                    return "Signup";
                case "21":
                    Console.Write("Enter your current or last working company: ");
                    trainer.Companyname = Console.ReadLine();
                    return "Signup";
                case "22":
                    Console.Write("Enter your field: ");
                    trainer.Field = Console.ReadLine();
                    return "Signup";
                case "23":
                    Console.Write("Enter your overall experience: ");
                    trainer.Experience = Console.ReadLine();
                    return "Signup";
                default:
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Wrong choice, Try again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "Signup";
            }
        }
    }
}