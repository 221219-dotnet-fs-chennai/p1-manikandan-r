using Trainer_EF_Layer.Entities;
using Models;

namespace Trainer_EF_Layer
{
    public class TrainerEFRepo : IRepoEF<Entities.TrainerDetail>, IRepoEF_E<Entities.Education>, IRepoEF_S<Entities.Skill>, IRepoEF_C<Entities.Company>
    {
        TrainerDbContext context = new TrainerDbContext();

        public List<Entities.TrainerDetail> GetAllTrainers()
        {
            return context.TrainerDetails.ToList();
        }

        public List<Entities.Education> GetAllEducation()
        {
            return context.Educations.ToList();
        }

        public List<Entities.Skill> GetAllSkills()
        {
            return context.Skills.ToList();
        }

        public List<Entities.Company> GetAllCompanies()
        {
            return context.Companies.ToList();
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
        public void InsertData(Entities.TrainerDetail trainer, Entities.Education education, Entities.Skill skill, Entities.Company company)
        {
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
    }
}


