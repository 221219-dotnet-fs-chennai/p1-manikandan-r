using TEF = Trainer_EF_Layer.Entities;
using Models;
using Trainer_EF_Layer.Entities;

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

        public void InsertData(TEF.TrainerDetail trainer, Education education, Skill skill, Company company)
        {
            string[] emailarr = trainer.EmailId.Split("@");
            trainer.UserId = emailarr[0];
            education.UserId = trainer.UserId;
            skill.UserId = trainer.UserId;
            company.UserId = trainer.UserId;

            context.TrainerDetails.Add(trainer);
            context.Educations.Add(education);
            context.Skills.Add(skill);
            context.Companies.Add(company);

            context.SaveChanges();

            Console.WriteLine("Data Added Successfully");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }
    
        public bool login(string eMail)
        {
            var result = context.TrainerDetails;
            var query = result.FirstOrDefault(val => val.EmailId == eMail);

            if (query != null)
            {
                Console.Write("Enter you password: ");
                string password = Console.ReadLine();

                if (query.Password == password)
                {
                    Console.WriteLine("Login Success...");
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong Password");
                    Console.WriteLine("Enter to continue...");
                    Console.ReadLine();
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No data found in this email\nCheck your credentails or Signup First");
                Console.ReadLine();
                return false;
            }
        }

        public void UpdateTrainer(string tableName, string columnName, string newValue, string userID)
        {
            string[] emailarr = userID.Split("@");
            string userId = emailarr[0];

            if (tableName == "TrainerDetails")
            {
                var train = context.TrainerDetails;
                var query1 = from t in train
                             where t.UserId == userID
                             select t;

                switch(columnName)
                {
                    case "Password":
                        foreach(var val in query1)
                        {
                            val.Password = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Age":
                        foreach (var val in query1)
                        {
                            val.Age = int.Parse(newValue);
                        }
                        context.SaveChanges();
                        break;
                    case "Phone_Number":
                        foreach (var val in query1)
                        {
                            val.PhoneNumber = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "City":
                        foreach (var val in query1)
                        {
                            val.City = newValue;
                        }
                        context.SaveChanges();
                        break;
                }
            }
            else if(tableName == "Education")
            {
                var edu = context.Educations;
                var query2 = from e in edu
                             where e.UserId == userID
                             select e;

                switch(columnName)
                {
                    case "Ug_collage":
                        foreach(var val in query2)
                        {
                            val.UgCollage = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Ug_stream":
                        foreach (var val in query2)
                        {
                            val.UgStream = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Ug_Percentage":
                        foreach (var val in query2)
                        {
                            val.UgPercentage = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Ug_year":
                        foreach (var val in query2)
                        {
                            val.UgYear = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Pg_collage":
                        foreach (var val in query2)
                        {
                            val.PgCollage = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Pg_stream":
                        foreach (var val in query2)
                        {
                            val.PgStream = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Pg_Percentage":
                        foreach (var val in query2)
                        {
                            val.PgPercentage = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Pg_year":
                        foreach (var val in query2)
                        {
                            val.PgYear = newValue;
                        }
                        context.SaveChanges();
                        break;
                }
            }
            else if(tableName == "Skill")
            {
                var ski = context.Skills;
                var query3 = from s in ski
                             where s.UserId == userID
                             select s;

                switch(columnName)
                {
                    case "Skill_1":
                        foreach(var val in query3)
                        {
                            val.Skill1 = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Skill_2":
                        foreach (var val in query3)
                        {
                            val.Skill2 = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Skill_3":
                        foreach (var val in query3)
                        {
                            val.Skill3 = newValue;
                        }
                        context.SaveChanges();
                        break;
                }
            }
            else if(tableName == "Company")
            {
                var comp = context.Companies;
                var query4 = from c in comp
                             where c.UserId == userID
                             select c;

                switch(columnName)
                {
                    case "Company_Name":
                        foreach(var val in query4)
                        {
                            val.CompanyName = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Field":
                        foreach (var val in query4)
                        {
                            val.Field = newValue;
                        }
                        context.SaveChanges();
                        break;
                    case "Overall_Experience":
                        foreach (var val in query4)
                        {
                            val.OverallExperience = newValue;
                        }
                        context.SaveChanges();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Table not exist");
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadLine();
            }
        }

        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill)
        {
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

        public void DeleteTrainer(string EmailID)
        {
            var delete = context.TrainerDetails;
            var value = delete.FirstOrDefault(val => val.EmailId == EmailID);

            if (value != null)
            {
                context.TrainerDetails.Remove(value);
                context.SaveChanges();
                Console.WriteLine("\nThank You For using 'Trainer Picker'");
                Console.WriteLine("\nProfile Deleted Successfully...");
                Console.WriteLine("\nPress Enter to Continue");
                Console.ReadLine();
            }
        }
    }
}

