using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class UserLogin: IMenu
    {
        private static User user = new User();
        IRepo repo = new SqlRepo();
        SqlRepo sql = new SqlRepo();
        public void Display()
        {
            Console.WriteLine("\n----------USER LOGIN----------\n");
            Console.WriteLine("[0] for User Menu");
            Console.WriteLine("[1] for Email ID             : ", user.UserMailId);
            Console.WriteLine("[2] for Password             : ", user.UserPassword);
            Console.WriteLine("[3] for get all trainer");

        }

        public string UserChoice()
        {
            Console.WriteLine("--------------------------");
            Console.Write("Enter your choice: ");
            string userchoice = Console.ReadLine();

            switch (userchoice)
            {
                case "0":
                    return "UserMenu";
                case "1":
                    Console.Write("Enter your Email ID: ");
                    user.UserMailId = Console.ReadLine();
                    return "UserLogin";
                case "2":
                    Console.Write("Enter your Password: ");
                    user.UserPassword = Console.ReadLine();
                    return "UserLogin";
                case "3":
                    //var listofDummies = sql.GetDummies();
                    //foreach (var val in listofDummies)
                    //{
                    //    Console.WriteLine(val.returnDummy());
                    //}

                    var listoftrainers = repo.GetAllTrainers();
                    foreach (var val in listoftrainers)
                    {
                        Console.WriteLine(val.TrainerDetails());
                    }
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    return "UserLogin";

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
