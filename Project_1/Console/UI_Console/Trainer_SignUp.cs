﻿// get details from user

using System.Text.RegularExpressions;
using Models;
using Trainer_EF_Layer;
using Trainer_EF_Layer.Entities;

namespace UI_Console
{
    internal class SignUp : IMenu
    {
        internal static Trainer_EF_Layer.Entities.TrainerDetail trainer = new Trainer_EF_Layer.Entities.TrainerDetail();
        internal static Education education = new Education();
        internal static Skill skill = new Skill();
        internal static Company company = new Company();

        public SignUp()
        {

        }

        public SignUp(Trainer_EF_Layer.Entities.TrainerDetail train, Education edu, Skill ski, Company comp)
        {
            trainer = train;
            education = edu;
            skill = ski;
            company = comp;
        }

        TrainerEFRepo repo = new TrainerEFRepo();


        static string pass = "";

        public void Display()
        {
            Console.WriteLine("\n--------------------------SIGNUP PAGE--------------------------\n");
            Console.WriteLine("NOTE: * fields are mandatory\n");
            Console.WriteLine("[00] Clear");
            Console.WriteLine("[0] Trainer Menu");
            Console.WriteLine("[1] Submit Details");
            Console.WriteLine("[2] Email ID*            : " + trainer.EmailId);
            Console.WriteLine("[3] Password*            : " + pass);
            Console.WriteLine("[4] Firstname*           : " + trainer.Firstname);
            Console.WriteLine("[5] Lastname*            : " + trainer.Lastname);
            Console.WriteLine("[6] Age*                 : " + trainer.Age);
            Console.WriteLine("[7] Gender*              : " + trainer.Gender);
            Console.WriteLine("[8] Phone number*        : " + trainer.PhoneNumber);
            Console.WriteLine("[9] City*                : " + trainer.City);
            Console.WriteLine("[10] UG Collage name*    : " + education.UgCollage);
            Console.WriteLine("[11] UG Stream*          : " + education.UgStream);
            Console.WriteLine("[12] UG Percentage*      : " + education.UgPercentage);
            Console.WriteLine("[13] UG Passed out Year* : " + education.UgYear);
            Console.WriteLine("[14] PG Collage name     : " + education.PgCollage);
            Console.WriteLine("[15] PG Stream           : " + education.PgStream);
            Console.WriteLine("[16] PG Percentage       : " + education.PgPercentage);
            Console.WriteLine("[17] PG Passed out Year  : " + education.PgYear);
            Console.WriteLine("[18] Skill 1*            : " + skill.Skill1);
            Console.WriteLine("[19] Skill 2*            : " + skill.Skill2);
            Console.WriteLine("[20] Skill 3             : " + skill.Skill3);
            Console.WriteLine("[21] Company name        : " + company.CompanyName);
            Console.WriteLine("[22] Field of working    : " + company.Field);
            Console.WriteLine("[23] Overall experience  : " + company.OverallExperience);
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
                    trainer = new Trainer_EF_Layer.Entities.TrainerDetail();
                    education = new Education();
                    skill = new Skill();
                    company = new Company();
                    pass = "";
                    return "TrainerMenu";
                case "0":
                    return "TrainerMenu";
                case "1":
                    try
                    {
                        Log.Logger.Information("Adding trainer details");
                        repo.InsertData(trainer, education, skill, company);
                        trainer = new Trainer_EF_Layer.Entities.TrainerDetail();
                        education = new Education();
                        skill = new Skill();
                        company = new Company();
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
                        return "Signup";
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
                            trainer.EmailId = email_id;
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

                    string[] emailarr = trainer.EmailId.Split("@");
                    trainer.UserId = emailarr[0];
                    education.UserId = trainer.UserId;
                    skill.UserId = trainer.UserId;
                    company.UserId = trainer.UserId;

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
                    catch (Exception ex)
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
                        trainer.PhoneNumber = phone_number;
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
                    education.UgCollage = Console.ReadLine();
                    return "Signup";
                case "11":
                    Console.Write("Enter your UG stream: ");
                    education.UgStream = Console.ReadLine();
                    return "Signup";
                case "12":
                    Console.Write("Enter your UG percentage: ");
                    education.UgPercentage = Console.ReadLine();
                    return "Signup";
                case "13":
                    Console.Write("Enter your UG passed out year: ");
                    string Ug_year = Console.ReadLine();
                    try
                    {
                        if (int.Parse(Ug_year) <= 2022)
                        {
                            education.UgYear = Ug_year.ToString();
                            return "Signup";
                        }
                        else
                        {
                            Console.WriteLine("\nNote: Passed out year must be less than or equal to 2022!");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nYear must be in numbers!!");
                        Console.WriteLine("Enter to continue");
                        Console.ReadLine();
                        return "Signup";
                    }
                    return "Signup";

                case "14":
                    Console.Write("Enter your PG collage name: ");
                    education.PgCollage = Console.ReadLine();
                    return "Signup";
                case "15":
                    Console.Write("Enter your PG stream: ");
                    education.PgStream = Console.ReadLine();
                    return "Signup";
                case "16":
                    Console.Write("Enter your PG percentage: ");
                    education.PgPercentage = Console.ReadLine();
                    return "Signup";
                case "17":
                    Console.Write("Enter your PG passed out year: ");
                    education.PgYear = Console.ReadLine();
                    return "Signup";
                case "18":
                    Console.Write("Enter your 1st skill: ");
                    skill.Skill1 = Console.ReadLine();
                    return "Signup";
                case "19":
                    Console.Write("Enter your 2nd skill: ");
                    skill.Skill2 = Console.ReadLine();
                    return "Signup";
                case "20":
                    Console.Write("Enter your 3rd skill: ");
                    skill.Skill3 = Console.ReadLine();
                    return "Signup";
                case "21":
                    Console.Write("Enter your current or last working company: ");
                    company.CompanyName = Console.ReadLine();
                    return "Signup";
                case "22":
                    Console.Write("Enter your field: ");
                    company.Field = Console.ReadLine();
                    return "Signup";
                case "23":
                    Console.Write("Enter your overall experience: ");
                    company.OverallExperience = Console.ReadLine();
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