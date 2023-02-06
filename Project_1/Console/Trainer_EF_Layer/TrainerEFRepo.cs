using TEF = Trainer_EF_Layer.Entities;
using Models;
using Trainer_EF_Layer.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Trainer_EF_Layer
{
    public class TrainerEFRepo : IRepoEF
    {
        TrainerDbContext context = new TrainerDbContext();

        public TEF.TrainerDetail GetAllTrainers(string EMail)
        {
            string[] emailarr = EMail.Split("@");
            string userId = emailarr[0];

            var trainers = context.TrainerDetails;
            var query1 = from trainer in trainers
                         where trainer.UserId == userId
                         select trainer;
            TEF.TrainerDetail trainerDetail = new TEF.TrainerDetail();
            foreach (var trainer in query1)
            {
                trainerDetail = new TEF.TrainerDetail()
                {
                    EmailId = trainer.EmailId,
                    Firstname = trainer.Firstname,
                    Lastname = trainer.Lastname,
                    Age = trainer.Age,
                    Gender = trainer.Gender,
                    PhoneNumber = trainer.PhoneNumber,
                    City = trainer.City,
                };
            }
            return trainerDetail;
        }

        public Education GetAllEducation(string EMail)
        {
            string[] emailarr = EMail.Split("@");
            string userId = emailarr[0];

            var trainers = context.Educations;
            var query2 = from education in trainers
                         where education.UserId == userId
                         select education;
            TEF.Education trainerEducation = new TEF.Education();
            foreach(var education in query2)
            {
                trainerEducation = new TEF.Education()
                {
                    UgCollage = education.UgCollage,
                    UgStream = education.UgStream,
                    UgPercentage = education.UgPercentage,
                    UgYear = education.UgYear,
                    PgCollage = education.PgCollage,
                    PgStream = education.PgStream,
                    PgPercentage = education.PgPercentage,
                    PgYear = education.PgYear,
                };
            }
            return trainerEducation;
        }

        public Skill GetAllSkills(string EMail)
        {
            string[] emailarr = EMail.Split("@");
            string userId = emailarr[0];

            var trainers = context.Skills;
            var query3 = from skill in trainers
                         where skill.UserId == userId
                         select skill;
            TEF.Skill trainerSkill = new TEF.Skill();
            foreach(var skill in query3)
            {
                trainerSkill = new TEF.Skill()
                {
                    Skill1 = skill.Skill1,
                    Skill2 = skill.Skill2,
                    Skill3 = skill.Skill3,
                };
            }
            return trainerSkill;
        }

        public Company GetAllCompanies(string EMail)
        {
            string[] emailarr = EMail.Split("@");
            string userId = emailarr[0];

            var trainers = context.Companies;
            var query4 = from company in trainers
                         where company.UserId == userId
                         select company;
            TEF.Company trainerCompany = new TEF.Company();
            foreach(var company in query4)
            {
                trainerCompany = new TEF.Company()
                {
                    CompanyName = company.CompanyName,
                    Field = company.Field,
                    OverallExperience = company.OverallExperience,
                };
            }
            return trainerCompany;
        }

        public IEnumerable<AllTrainerDetails> GetAllTrainerDetails()
        {
            var trainer = context.TrainerDetails;
            var education = context.Educations;
            var skill = context.Skills;
            var company = context.Companies;

            var alldetails = (from t in trainer
                              join e in education on t.UserId equals e.UserId
                              join s in skill on e.UserId equals s.UserId
                              join c in company on s.UserId equals c.UserId
                              select new AllTrainerDetails()
                              {
                                  Emailid = t.EmailId,
                                  Firstname = t.Firstname,
                                  Lastname = t.Lastname,
                                  Age = t.Age,
                                  Gender = t.Gender,
                                  Phonenumber = t.PhoneNumber,
                                  City = t.City,
                                  Ug_collage = e.UgCollage,
                                  Ug_stream = e.UgStream,
                                  Ug_percentage = e.UgPercentage,
                                  Ug_year = e.UgYear,
                                  Pg_collage = e.PgCollage,
                                  Pg_stream = e.PgStream,
                                  Pg_percentage = e.PgPercentage,
                                  Pg_year = e.PgYear,
                                  Skill_1 = s.Skill1,
                                  Skill_2 = s.Skill2,
                                  Skill_3 = s.Skill3,
                                  Companyname = c.CompanyName,
                                  Field = c.Field,
                                  Experience = c.OverallExperience
                              });
            return alldetails.ToList();
        }

        public bool AddTrainer(TEF.TrainerDetail trainer, string Email)
        {
            string[] emailarr = Email.Split("@");
            trainer.UserId = emailarr[0];
           
            context.TrainerDetails.Add(trainer);
            context.SaveChanges();

            Console.WriteLine("Trainer data Added Successfully");
            return true;
        }

        public bool AddEducation(Education education, string Email)
        {
            string[] emailarr = Email.Split("@");
            education.UserId = emailarr[0];
            

            context.Educations.Add(education);
            context.SaveChanges();

            Console.WriteLine("Trainer education Added Successfully");
            return true;
        }

        public bool AddSkill(Skill skill, string Email)
        {
            string[] emailarr = Email.Split("@");
            skill.UserId = emailarr[0];

            context.Skills.Add(skill);
            context.SaveChanges();

            Console.WriteLine("Trainer skill Added Successfully");
            return true;
        }

        public bool AddCompany(Company company, string Email)
        {
            string[] emailarr = Email.Split("@");
            company.UserId = emailarr[0];

            context.Companies.Add(company);
            context.SaveChanges();

            Console.WriteLine("Trainer company Added Successfully");
            return true;
        }

        public bool login(string eMail, string pass)
        {
            var result = context.TrainerDetails;
            var query = result.FirstOrDefault(val => val.EmailId == eMail);

            if (query != null)
            {
                var query1 = result.FirstOrDefault(val => val.Password == pass);
                if (query1 != null)
                {
                    Console.WriteLine("Login Success...");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nWrong Password!! Try again...");
                    Console.WriteLine("Enter to continue...");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("\nNo data found in this email\nCheck your credentails or Signup First");
                return false;
            }
        }


        public Entities.TrainerDetail UpdateTrainer(Entities.TrainerDetail trainer)
        {
            context.TrainerDetails.Update(trainer);
            context.SaveChanges();

            return trainer;
        }

        public Education UpdateEducation(Education education)
        {
            context.Educations.Update(education);
            context.SaveChanges();

            return education;
        }

        public Skill UpdateSkill(Skill skill)
        {
            context.Skills.Update(skill);  
            context.SaveChanges();

            return skill;
        }

        public Company UpdateCompany(Company company)
        {
            context.Companies.Update(company);
            context.SaveChanges();

            return company;
        }

        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill)
        {
            city = city.ToLower();
            skill = skill.ToLower();

            if (city == "ex: chennai or delhi" && skill == "ex: python or java")
            {
                Console.WriteLine("You Didn't choose any filter\n");
                return GetAllTrainerDetails().ToList();
            }
            else if (city != "ex: chennai or delhi" && skill == "ex: python or java")
            {
                var query_1 = from trainer in GetAllTrainerDetails()
                              where trainer.City.ToLower() == city
                              select trainer;
                return query_1.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill != "ex: python or java")
            {
                var query_2 = from trainer in GetAllTrainerDetails()
                              where trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill
                              select trainer;
                return query_2.ToList();
            }
            else if (city != "ex: chennai or delhi" && skill != "ex: python or java")
            {
                var query_3 = from trainer in GetAllTrainerDetails()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.City.ToLower() == city)
                              select trainer;
                return query_3.ToList();
            }

            return GetAllTrainerDetails().ToList();
        }

        public bool DeleteTrainer(string EmailID, string pass)
        {
            var delete = context.TrainerDetails;
            var value = delete.FirstOrDefault(val => val.EmailId == EmailID);

            if (value != null)
            {
                var query1 = delete.FirstOrDefault(val => val.Password == pass);
                if (query1 != null)
                {
                    context.TrainerDetails.Remove(value);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

    }
}

