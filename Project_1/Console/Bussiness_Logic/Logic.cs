using Trainer_EF_Layer;
using Models;
using Trainer_EF_Layer.Entities;
using Microsoft.IdentityModel.Tokens;

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

        public Models.TrainerDetail AddTrainer(Models.TrainerDetail trainer)
        {
            return map.MapTrainer(newrepo.AddTrainer(map.mapTrainer(trainer)));
        }

        public TrainerEducation AddEducation(TrainerEducation education)
        {
            return map.MapEducation(newrepo.AddEducation(map.mapEducation(education)));
        }

        public TrainerSkill AddSkill(TrainerSkill skill)
        {
            return map.MapSkill(newrepo.AddSkill(map.mapSkill(skill)));
        }

        public TrainerCompany AddCompany(TrainerCompany company)
        {
            return map.MapCompany(newrepo.AddCompany(map.mapCompany(company)));
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

            Console.WriteLine(trainer.Userid);
            Console.WriteLine(trainer.Emailid);
            Console.WriteLine(trainer.Password);
            Console.WriteLine(trainer.Firstname);
            Console.WriteLine(trainer.Lastname);
            Console.WriteLine(trainer.Age);
            Console.WriteLine(trainer.Gender);
            Console.WriteLine(trainer.Phonenumber);
            Console.WriteLine(trainer.City);

            if (train != null)
            {
                train.UserId = trainer.Userid;
                train.EmailId = trainer.Emailid;
                train.Password = trainer.Password;
                train.Firstname = trainer.Firstname;
                train.Lastname = trainer.Lastname;
                train.Age = trainer.Age;
                train.Gender = trainer.Gender;
                train.PhoneNumber = trainer.Phonenumber;
                train.City = trainer.City;
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
                edu.UserId = education.Userid;
                edu.UgCollage = education.Ug_collage;
                edu.UgStream = education.Ug_stream;
                edu.UgPercentage = education.Ug_percentage;
                edu.UgYear = education.Ug_year;
                edu.PgCollage = education.Pg_collage;
                edu.PgStream = education.Pg_stream;
                edu.PgPercentage = education.Pg_percentage;
                edu.PgYear = education.Pg_year;
            }

            return map.MapEducation(newrepo.UpdateEducation(edu));
        }

        public TrainerSkill UpdateSkill(TrainerSkill skill, string email)
        {
            string[] emailarr = email.Split("@");
            string userId = emailarr[0];

            var ski = vali.TrainerBySkillUserID(userId);

            if (ski != null)
            {
                    ski.UserId = skill.Userid;
                    ski.Skill1 = skill.Skill_1;
                    ski.Skill2 = skill.Skill_2;
                    ski.Skill3 = skill.Skill_3;
            }

            return map.MapSkill(newrepo.UpdateSkill(ski));
        }

        public TrainerCompany UpdateCompany(TrainerCompany company, string email)
        {
            string[] emailarr = email.Split("@");
            string userId = emailarr[0];

            var comp = vali.TraiinerbyComUserID(userId);

            if (comp != null)
            {
                    comp.UserId = company.Userid;
                    comp.CompanyName = company.Companyname;
                    comp.Field = company.Field;
                    comp.OverallExperience = company.Experience;
            }

            return map.MapCompany(newrepo.UpdateCompany(comp));
        }

        public bool ForgetPassword(string email, string phonenum, string pass)
        {
            return newrepo.ForgetPassword(email, phonenum, pass);
        }

    }
}
