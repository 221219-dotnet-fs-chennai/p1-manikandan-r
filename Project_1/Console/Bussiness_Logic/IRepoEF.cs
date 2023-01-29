using System;
using Models;

namespace Bussiness_Logic
{
    public interface IRepoEF
    {
        TrainerDetail GetAllTrainers(string userId);
        TrainerEducation GetAllEducation(string userId);
        TrainerSkill GetAllSkills(string userId);
        TrainerCompany GetAllCompanies(string userId);

        public void InsertData(Models.TrainerDetail trainer, TrainerEducation education, TrainerSkill skill, TrainerCompany company);
        public bool login(string eMail);
        public void UpdateTrainer(string tableName, string columnName, string newValue, string userID);

        public void DeleteTrainer(string userID);
    }
}
