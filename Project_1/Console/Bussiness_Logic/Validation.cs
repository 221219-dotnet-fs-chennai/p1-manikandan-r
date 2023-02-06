
using System.Text.RegularExpressions;
using Trainer_EF_Layer.Entities;

namespace Bussiness_Logic
{
    public class Validation
    {
        TrainerDbContext context;
        public Validation(TrainerDbContext _contect)
        {
            context= _contect;  
        }
        public Validation()
        {

        }

        public Trainer_EF_Layer.Entities.TrainerDetail TrainerByUserID(string userid)
        {
            return context.TrainerDetails.Where(id => id.UserId == userid).FirstOrDefault();
        }

        public Education TrainerEduByUserID(string userid)
        {
            return context.Educations.Where(id => id.UserId == userid).FirstOrDefault();
        }

        public Skill TrainerBySkillUserID(string userid)
        {
            return context.Skills.Where(id => id.UserId == userid).FirstOrDefault();
        }

        public Company TraiinerbyComUserID(string userid)
        {
            return context.Companies.Where(id => id.UserId == userid).FirstOrDefault();
        }
        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,7}$";

            if (Regex.IsMatch(email, emailPattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phonenumber)
        {
            string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

            if (phonenumber.Length <= 15 && Regex.IsMatch(phonenumber, pattern))
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
