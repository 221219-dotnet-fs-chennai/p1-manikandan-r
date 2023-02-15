using Trainer_EF_Layer;
using Models;
using Trainer_EF_Layer.Entities;

namespace Bussiness_Logic
{
    public class Logic : ILogic
    {
        Validation vali;

        Mapper map = new Mapper();

        TrainerEFRepo newrepo = new TrainerEFRepo();
        public Logic(Validation vali)
        {
            this.vali = vali;
        }

        public Logic()
        {

        }

        public bool captchaReturn()
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
type the captcha after 7 seconds completed. If you fail You redirected to Main Menu again");
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

        public bool DeleteTrainer(string EmailID, string pass)
        {
            return newrepo.DeleteTrainer(EmailID, pass);
        }

        public TrainerCompany GetAllCompanies(string userId)
        {
            return map.MapCompany(newrepo.GetAllCompanies(userId));
        }

        public TrainerEducation GetAllEducation(string userId)
        {
            return map.MapEducation(newrepo.GetAllEducation(userId));
        }

        public TrainerSkill GetAllSkills(string userId)
        {
            return map.MapSkill(newrepo.GetAllSkills(userId));
        }

        public Models.TrainerDetail GetAllTrainers(string userId)
        {
            return map.MapTrainer(newrepo.GetAllTrainers(userId));
        }

        public IEnumerable<AllTrainerDetails> GetAllTrainerDetails()
        {
            return newrepo.GetAllTrainerDetails();
        }

        public bool AddTrainer(Models.TrainerDetail trainer, string Email)
        {
            return newrepo.AddTrainer(map.mapTrainer(trainer), Email);
        }

        public bool AddEducation(TrainerEducation education, string Email)
        {
            return newrepo.AddEducation(map.mapEducation(education), Email);
        }

        public bool AddSkill(TrainerSkill skill, string Email)
        {
            return newrepo.AddSkill(map.mapSkill(skill), Email);
        }

        public bool AddCompany(TrainerCompany company, string Email)
        {
            return newrepo.AddCompany(map.mapCompany(company), Email);
        }


        public bool login(string eMail, string pass)
        {
            return newrepo.login(eMail, pass);
        }

        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill)
        {
            return newrepo.TrainerFilter(city, skill);
        }

        public Models.TrainerDetail UpdateTrainer(Models.TrainerDetail trainer, string email)
        {
            string[] emailarr = email.Split("@");
            string userId = emailarr[0];

            var train = vali.TrainerByUserID(userId);

            if (train != null)
            {
                if (trainer.Userid != "string" && train.UserId != trainer.Userid)
                {
                    train.UserId = trainer.Userid;
                }
                if (trainer.Emailid != "string" && train.EmailId != trainer.Emailid)
                {
                    train.EmailId = trainer.Emailid;
                }
                if (trainer.Password != "string" && train.Password != trainer.Password)
                {
                    train.Password = trainer.Password;
                }
                if (trainer.Firstname != "string" && train.Firstname != trainer.Firstname)
                {
                    train.Firstname = trainer.Firstname;
                }
                if (trainer.Lastname != "string" && train.Lastname != trainer.Lastname)
                {
                    train.Lastname = trainer.Lastname;
                }
                if (trainer.Age != 0 && train.Age != trainer.Age)
                {
                    train.Age = trainer.Age;
                }
                if (trainer.Gender != "string" && train.Gender != trainer.Gender)
                {
                    train.Gender = trainer.Gender;
                }
                if (trainer.Phonenumber != "string" && train.PhoneNumber != trainer.Phonenumber)
                {
                    train.PhoneNumber = trainer.Phonenumber;
                }
                if (trainer.City != "string" && train.City != trainer.City)
                {
                    train.City = trainer.City;
                }
            }

            return map.MapTrainer(newrepo.UpdateTrainer(train));
        }

        public TrainerEducation UpdateEducation(TrainerEducation education, string email)
        {
            string[] emailarr = email.Split("@");
            string userId = emailarr[0];

            var edu = vali.TrainerEduByUserID(userId);

            if (edu != null)
            {
                if (education.Userid != "string" && edu.UserId != education.Userid)
                {
                    edu.UserId = education.Userid;
                }
                if (education.Ug_collage != "string" && edu.UgCollage != education.Ug_collage)
                {
                    edu.UgCollage = education.Ug_collage;
                }
                if (education.Ug_stream != "string" && edu.UgStream != education.Ug_stream)
                {
                    edu.UgStream = education.Ug_stream;
                }
                if (education.Ug_percentage != "string" && edu.UgPercentage != education.Ug_percentage)
                {
                    edu.UgPercentage = education.Ug_percentage;
                }
                if (education.Ug_year != "string" && edu.UgYear != education.Ug_year)
                {
                    edu.UgYear = education.Ug_year;
                }
                if (education.Pg_collage != "string" && edu.PgCollage != education.Pg_collage)
                {
                    edu.PgCollage = education.Pg_collage;
                }
                if (education.Pg_stream != "string" && edu.PgStream != education.Pg_stream)
                {
                    edu.PgStream = education.Pg_stream;
                }
                if (education.Pg_percentage != "string" && edu.PgPercentage != education.Pg_percentage)
                {
                    edu.PgPercentage = education.Pg_percentage;
                }
                if (education.Pg_year != "string" && edu.PgYear != education.Pg_year)
                {
                    edu.PgYear = education.Pg_year;
                }
            }

            return map.MapEducation(newrepo.UpdateEducation(edu));
        }

        public TrainerSkill UpdateSkill(TrainerSkill skill, string email)
        {
            string[] emailarr = email.Split("@");
            string userId = emailarr[0];

            var ski = vali.TrainerBySkillUserID(userId);

            if(ski != null)
            {
                if(skill.Userid != "string" && ski.UserId != skill.Userid)
                {
                    ski.UserId = skill.Userid;
                }
                if(skill.Skill_1 != "string" && ski.Skill1 != skill.Skill_1)
                {
                    ski.Skill1= skill.Skill_1;
                }
                if(skill.Skill_2 != "string" && ski.Skill2 != skill.Skill_2)
                {
                    ski.Skill2= skill.Skill_2;
                }
                if(skill.Skill_3 != "string" && ski.Skill3 != skill.Skill_3)
                {
                    ski.Skill3= skill.Skill_3;
                }
            }

            return map.MapSkill(newrepo.UpdateSkill(ski));
        }

        public TrainerCompany UpdateCompany(TrainerCompany company, string email)
        {
            string[] emailarr = email.Split("@");
            string userId = emailarr[0];

            var comp = vali.TraiinerbyComUserID(userId);

            if(comp != null)
            {
                if(company.Userid != "string" && comp.UserId != company.Userid)
                {
                    comp.UserId = company.Userid;
                }
                if(company.Companyname != "string" && comp.CompanyName != company.Companyname)
                {
                    comp.CompanyName = company.Companyname;
                }
                if(company.Field != "string" && comp.Field != company.Field)
                {
                    comp.Field = company.Field;
                }
                if(company.Experience != "string" && comp.OverallExperience != company.Experience)
                {
                    comp.OverallExperience = company.Experience;
                }
            }

            return map.MapCompany(newrepo.UpdateCompany(comp));
        }

        public bool ForgetPassword(string email, string phonenum, string pass)
        {
            return newrepo.ForgetPassword(email, phonenum, pass);
        }

    }
}
