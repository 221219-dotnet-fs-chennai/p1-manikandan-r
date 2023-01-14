using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class Menu : IMenu
    {
        public void Display()
        {
            Console.Write("Press 1 to Login\nPress 2 to SignUp\nPress 3 to Exit\n> ");
        }

        public string UserChoice()
        {
            string login_signup = (Console.ReadLine());

            return login_signup;
        }
    }
}
