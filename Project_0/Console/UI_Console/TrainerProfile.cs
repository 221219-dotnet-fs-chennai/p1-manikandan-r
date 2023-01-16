using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    class TrainerProfile : IMenu
    {
        Trainer trainerProfile = new Trainer();

        public TrainerProfile(Trainer trainer)
        {
            trainerProfile = trainer;
        }
        public void Display()
        {
            Console.WriteLine("\n-------TRAINER PROFILE-------\n");
            Console.WriteLine("NOTE: * fields are mandatory\n");
            Console.WriteLine("[1] Save");
            Console.WriteLine("[2] Email ID*            : " + trainerProfile.Emailid);
            Console.WriteLine("[3] Password*            : " + trainerProfile.Password);
            Console.WriteLine("[4] Firstname*           : " + trainerProfile.Firstname);
            Console.WriteLine("[5] Lastname*            : " + trainerProfile.Lastname);
            Console.WriteLine("[6] Age*                 : " + trainerProfile.Age);
            Console.WriteLine("[7] Gender*              : " + trainerProfile.Gender);
            Console.WriteLine("[8] Phone number*        : " + trainerProfile.Phonenumber);
            Console.WriteLine("[9] City*                : " + trainerProfile.City);
            Console.WriteLine("[10] UG Collage name*    : " + trainerProfile.Ug_collage);
            Console.WriteLine("[11] UG Stream*          : " + trainerProfile.Ug_stream);
            Console.WriteLine("[12] UG Percentage*      : " + trainerProfile.Ug_percentage);
            Console.WriteLine("[13] UG Year*            : " + trainerProfile.Ug_year);
            Console.WriteLine("[14] PG Collage name     : " + trainerProfile.Pg_collage);
            Console.WriteLine("[15] PG Stream           : " + trainerProfile.Pg_stream);
            Console.WriteLine("[16] PG Percentage       : " + trainerProfile.Pg_percentage);
            Console.WriteLine("[17] PG Year             : " + trainerProfile.Pg_year);
            Console.WriteLine("[18] Skill 1*            : " + trainerProfile.Skill_1);
            Console.WriteLine("[19] Skill 2*            : " + trainerProfile.Skill_2);
            Console.WriteLine("[20] Skill 3             : " + trainerProfile.Skill_3);
            Console.WriteLine("[21] Company name        : " + trainerProfile.Companyname);
            Console.WriteLine("[22] Field of working    : " + trainerProfile.Field);
            Console.WriteLine("[23] Overall experience  : " + trainerProfile.Experience);
        }

        public string UserChoice()
        {
            Console.WriteLine("Good job");
            return "";
        }

        public void ShowProfile()
        {

        }
    }
}
