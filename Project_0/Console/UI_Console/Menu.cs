using System;

namespace UI_Console
{
    internal class Menu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("\nWelcome to Trainer Picker :)...\n\nSelect an option to proceed...");
            Console.Write("\nPress [0] to Exit\nPress [1] to Get Trainers List\nPress [2] to Trainer Login or Signup");
        }

        public string UserChoice()
        {
            Console.WriteLine("\n--------------------------------------");
            Console.Write("\nEnter your choice: ");
            string login_signup = Console.ReadLine();

            switch (login_signup)
            {
                case "0":
                    return "Exit";
                case "1":
                    Console.Clear();
                    bool answer = captchaReturn();

                    if (answer)
                    {
                        Console.WriteLine("\nCaptcha matched ;), You're a Human...");
                        Console.Write("\nPress Enter to Continue...");
                        Console.ReadLine();
                        return "GetTrainers";
                    }
                    else
                    {
                        Console.WriteLine("\nCaptcha not matched :|, You're a Alien!!...");
                        Console.Write("\nPress Enter to Continue...");
                        Console.ReadLine();
                        return "Menu";
                    }
                case "2":
                    return "Trainer";
                default:
                    Console.WriteLine("Wrong choice, Try Again!");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                    return "Menu";
            }
        }

        static bool captchaReturn()
        {
            Random rand = new Random();

            string[] captchas = { "UYW7B2", "NBA82G", "PQ1ZX7", "IGTDYJ", "BVATFH", "LPQTAZ",
"PQJAYD", "AYUZVB", "VYAFJL", "MQNZYR", "KL187A", "Z72B98", "WLC69A", "BVA39S", "BAYPWH", "N4YU0C", "K8O7Q5",
"TAZLND", "8BA62F" };
            int index = rand.Next(captchas.Length);
            int i = 7;
            string captcha = captchas[index];

            Console.WriteLine("\n-----------------------------------------HUMAN VERIFICATION----------------------------------------\n");
            Console.WriteLine(@"Instruction!! 
After reading this instruction press enter. A captcha will shown for 7 seconds, Remember the captcha and 
type the captcha after 7 seconds completed. If you fail You redirected to Trainers Menu again");
            Console.Write("\nPress Enter to Continue...");
            Console.ReadLine();
            Console.Clear();

            while (i >= 1)
            {
                Console.WriteLine("\n-----------------------------------------HUMAN VERIFICATION----------------------------------------\n");
                Console.WriteLine($"\nTime left: {i}");
                Console.WriteLine($"\nYour captcha to remember: {captchas[index]}");
                Thread.Sleep(1000);
                Console.Clear();
                i--;
            }

            Console.Clear();
            Console.WriteLine("\n-----------------------------------------HUMAN VERIFICATION----------------------------------------\n");
            Console.Write("\nEnter the captcha: ");
            string? captchaByUser = Console.ReadLine();

            if (captcha == captchaByUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
