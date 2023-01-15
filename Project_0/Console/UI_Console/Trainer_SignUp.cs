// get details from user

using Data;

namespace UI_Console
{
    internal class SignUp : IMenu
    {
        private static Trainer trainer = new Trainer();
        private static Education education = new Education();
        private static Skills skill = new Skills();
        private static Work company = new Work();

        public void Display()
        {
            Console.WriteLine("\n-------USER DETAILS-------\n");
            Console.WriteLine("[0] Trainer Menu");
            Console.WriteLine("[2] Email ID             : " + trainer.Emailid);
            Console.WriteLine("[3] Password             : " + trainer.Password);
            Console.WriteLine("[4] Firstname            : " + trainer.Firstname);
            Console.WriteLine("[5] Lastname             : " + trainer.Lastname);
            Console.WriteLine("[6] Age                  : " + trainer.Age);
            Console.WriteLine("[7] Gender               : " + trainer.Gender);
            Console.WriteLine("[8] Phone number         : " + trainer.Phonenumber);
            Console.WriteLine("[9] City                 : " + trainer.City);
            Console.WriteLine("[10] UG Collage name     : " + education.Ug_collage);
            Console.WriteLine("[11] UG Stream           : " + education.Ug_stream);
            Console.WriteLine("[12] UG Percentage       : " + education.Ug_percentage);
            Console.WriteLine("[13] UG Year             : " + education.Ug_year);
            Console.WriteLine("[14] PG Collage name     : " + education.Pg_collage);
            Console.WriteLine("[15] PG Stream           : " + education.Pg_stream);
            Console.WriteLine("[16] PG Percentage       : " + education.Pg_percentage);
            Console.WriteLine("[17] UG Year             : " + education.Pg_year);
            Console.WriteLine("[18] Skill 1             : " + skill.Skill_1);
            Console.WriteLine("[19] Skill 2             : " + skill.Skill_2);
            Console.WriteLine("[20] Skill 3             : " + skill.Skill_3);
            Console.WriteLine("[21] Company name        : " + company.Comapnyname);
            Console.WriteLine("[22] Field of working    : " + company.Field);
            Console.WriteLine("[23] Overall experience  : " + company.Experience);
        }
        public string UserChoice()
        {
            Console.WriteLine("------------------------------");
            Console.Write("Enter your choice: ");
            string userchoice = Console.ReadLine();

            switch (userchoice)
            {
                case "0":
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
                    trainer.Age = Convert.ToByte(Console.ReadLine());
                    return "Signup";
                case "7":
                    Console.Write("Enter your Gender: ");
                    trainer.Gender = Console.ReadLine();
                    return "Signup";
                case "8":
                    Console.Write("Enter your Phone number: ");
                    trainer.Phonenumber = (Console.ReadLine());
                    return "Signup";
                case "9":
                    Console.Write("Enter you City: ");
                    trainer.City = Console.ReadLine();
                    return "Signup";
                case "10":
                    Console.Write("Enter your UG collage name: ");
                    education.Ug_collage = Console.ReadLine();
                    return "Signup";
                case "11":
                    Console.Write("Enter your UG stream: ");
                    education.Ug_stream = Console.ReadLine();
                    return "Signup";
                case "12":
                    Console.Write("Enter your UG percentage: ");
                    education.Ug_percentage = Convert.ToDouble(Console.ReadLine());
                    return "Signup";
                case "13":
                    Console.Write("Enter your UG year: ");
                    education.Ug_year = (Console.ReadLine());
                    return "Signup";
                case "14":
                    Console.Write("Enter your PG collage name: ");
                    education.Pg_collage = Console.ReadLine();
                    return "Signup";
                case "15":
                    Console.Write("Enter your PG stream: ");
                    education.Pg_stream = Console.ReadLine();
                    return "Signup";
                case "16":
                    Console.Write("Enter your PG percentage: ");
                    education.Pg_percentage = Convert.ToDouble(Console.ReadLine());
                    return "Signup";
                case "17":
                    Console.Write("Enter your PG year: ");
                    education.Pg_year = (Console.ReadLine());
                    return "Signup";
                case "18":
                    Console.Write("Enter your 1st skill: ");
                    skill.Skill_1 = Console.ReadLine();
                    return "Signup";
                case "19":
                    Console.Write("Enter your 2nd skill: ");
                    skill.Skill_2 = Console.ReadLine();
                    return "Signup";
                case "20":
                    Console.Write("Enter your 3rd skill: ");
                    skill.Skill_3 = Console.ReadLine();
                    return "Signup";
                case "21":
                    Console.Write("Enter your current or last working company: ");
                    company.Comapnyname = Console.ReadLine();
                    return "Signup";
                case "22":
                    Console.Write("Enter your field: ");
                    company.Field = Console.ReadLine();
                    return "Signup";
                case "23":
                    Console.Write("Enter your overall experience: ");
                    company.Experience = Console.ReadLine();
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