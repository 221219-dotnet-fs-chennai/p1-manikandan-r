using System;

namespace UI_Console
{
    internal interface IMenu
    {
        /// <summary>
        /// Display different menus in the console for user
        /// </summary>
        void Display();

        /// <summary>
        /// user has to pick a choice from the above displayed menu
        /// </summary>
        /// <returns>returns the user choice</returns>
        string UserChoice();
    }
}
