
using Models;
using Trainer_EF_Layer.Entities;
using TEF = Trainer_EF_Layer;


namespace Bussiness_Logic
{
    public class Logic : ILogic
    {
        IRepoEF<TEF.Entities.TrainerDetail> repo;
        IRepoEF_E<Education> repo1;
        IRepoEF_S<Skill> repo2;
        IRepoEF_C<Company> repo3;

        TEF.TrainerEFRepo newrepo = new TEF.TrainerEFRepo();

        public Logic()
        {
            repo = new TEF.TrainerEFRepo();
            repo1 = new TEF.TrainerEFRepo();
            repo2 = new TEF.TrainerEFRepo();
            repo3 = new TEF.TrainerEFRepo();
        }

        public IEnumerable<Models.TrainerDetail> GetTrainers()
        {
            return Mapper.Map(repo.GetAllTrainers());
        }

        public IEnumerable<Models.TrainerEducation> GetEducations()
        {
            return Mapper.Map(repo1.GetAllEducation());
        }

        public IEnumerable<TrainerSkill> GetSkills()
        {
            return Mapper.Map(repo2.GetAllSkills());
        }

        public IEnumerable<TrainerCompany> GetCompanies()
        {
            return Mapper.Map(repo3.GetAllCompanies());
        }

        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill, string company)
        {
            if (city == "ex: chennai or delhi" && skill == "ex: python or java" && company == "ex: micosoft or infosys")
            {
                Console.WriteLine("You Didn't choose any filter\n");
                return newrepo.GetAllTrainerDetails().ToList();
            }
            else if (city != "ex: chennai or delhi" && skill == "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_1 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.City.ToLower() == city
                              select trainer;
                return query_1.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_2 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill
                              select trainer;
                return query_2.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_3 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.Companyname.ToLower() == company
                              select trainer;
                return query_3.ToList();
            }
            else if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_4 = from trainer in newrepo.GetAllTrainerDetails()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.City.ToLower() == city)
                              select trainer;
                return query_4.ToList();
            }
            else if (city != "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_5 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.City.ToLower() == city && trainer.Companyname.ToLower() == company
                              select trainer;
                return query_5.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_6 = from trainer in newrepo.GetAllTrainerDetails()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.Companyname.ToLower() == company)
                              select trainer;
                return query_6.ToList();
            }
            if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_7 = from trainer in newrepo.GetAllTrainerDetails()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.Companyname.ToLower() == company) && (trainer.City.ToLower() == city)
                              select trainer;
                return query_7.ToList();
            }

            return newrepo.GetAllTrainerDetails().ToList();
        }
    }
}
