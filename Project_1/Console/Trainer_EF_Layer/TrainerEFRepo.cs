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
    }


}
