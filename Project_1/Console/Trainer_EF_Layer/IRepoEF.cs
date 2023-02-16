using System;
using Models;
using Trainer_EF_Layer.Entities;

namespace Trainer_EF_Layer
{
    public interface IRepoEF
    {
        Entities.TrainerDetail GetAllTrainers(string userId);
        Education GetAllEducation(string userId);
        Skill GetAllSkills(string userId);
        Company GetAllCompanies(string userId);
        public IEnumerable<AllTrainerDetails> GetAllTrainerDetails();
        public Entities.TrainerDetail AddTrainer(Entities.TrainerDetail trainer);

        public Education AddEducation(Education education);

        public Skill AddSkill(Skill skill);

        public Company AddCompany(Company company);

        public bool login(string eMail, string pass);
        Entities.TrainerDetail UpdateTrainer(Entities.TrainerDetail trainer);
        Education UpdateEducation(Education education);
        Skill UpdateSkill(Skill skill);
        Company UpdateCompany(Company company);
        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill);
        public bool DeleteTrainer(string userID, string pass);
        bool ForgetPassword(string email, string phonenum, string pass);
    }
}
