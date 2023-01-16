// get details from user

using Data;
using System.Text.RegularExpressions;

namespace UI_Console
{
    internal class SignUp : IMenu
    {
        internal static Trainer trainer = new Trainer();

        public SignUp(Trainer trainer_1)
        {
            trainer = trainer_1;
        }
        public SignUp()
        {

        }
        
        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IRepo repo = new SqlRepo(conStr);

        public void Display()
        {
            Console.WriteLine("\n-------USER DETAILS-------\n");
            Console.WriteLine("NOTE: * fields are mandatory\n");
            Console.WriteLine("[00] Clear");
            Console.WriteLine("[0] Trainer Menu");
            Console.WriteLine("[1] Save");
            Console.WriteLine("[2] Email ID*            : " + trainer.Emailid);
            Console.WriteLine("[3] Password*            : " + trainer.Password);
            Console.WriteLine("[4] Firstname*           : " + trainer.Firstname);
            Console.WriteLine("[5] Lastname*            : " + trainer.Lastname);
            Console.WriteLine("[6] Age*                 : " + trainer.Age);
            Console.WriteLine("[7] Gender*              : " + trainer.Gender);
            Console.WriteLine("[8] Phone number*        : " + trainer.Phonenumber);
            Console.WriteLine("[9] City*                : " + trainer.City);
            Console.WriteLine("[10] UG Collage name*    : " + trainer.Ug_collage);
            Console.WriteLine("[11] UG Stream*          : " + trainer.Ug_stream);
            Console.WriteLine("[12] UG Percentage*      : " + trainer.Ug_percentage);
            Console.WriteLine("[13] UG Year*            : " + trainer.Ug_year);
            Console.WriteLine("[14] PG Collage name     : " + trainer.Pg_collage);
            Console.WriteLine("[15] PG Stream           : " + trainer.Pg_stream);
            Console.WriteLine("[16] PG Percentage       : " + trainer.Pg_percentage);
            Console.WriteLine("[17] PG Year             : " + trainer.Pg_year);
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
            Console.Write("Enter your choice: ");
            string userchoice = Console.ReadLine();

            switch (userchoice)
            {
                case "00":
                    trainer = new Trainer();
                    return "TrainerMenu";
                case "0":
                    return "TrainerMenu";
                case "1":
                    try
                    {
                        Log.Logger.Information("Adding trainer details");
                        repo.Insertion(trainer);
                        Log.Logger.Information("Successfully added trainer details");
                    }
                    catch (System.Exception ex) 
                    {
                        Log.Logger.Information($"Failed to add trainer details {ex.Message}");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                    return "TrainerMenu";
                case "2":
                    Console.Write("Enter your Email ID: ");
                    trainer.Emailid = Console.ReadLine();
                    return "Signup";
                case "3":
                    Console.Write("Enter your Password: ");
                    trainer.Password = Console.ReadLine();
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
                    Console.Write("Enter your Age: ");
                    trainer.Age = Convert.ToInt32(Console.ReadLine());
                    return "Signup";
                case "7":
                    Console.Write("Enter your Gender: ");
                    trainer.Gender = Console.ReadLine();
                    return "Signup";
                case "8":
                    Console.Write("Enter your Phone number: ");
                    string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

                    string phone_number = Console.ReadLine();

                    if (Regex.IsMatch(phone_number, pattern))
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
                    Console.Write("Enter your UG year: ");
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
                    Console.Write("Enter your PG year: ");
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