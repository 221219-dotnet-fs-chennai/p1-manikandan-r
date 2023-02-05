﻿using System;
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
        public bool AddTrainer(Entities.TrainerDetail trainer, string Email);

        public bool AddEducation(Education education, string Email);

        public bool AddSkill(Skill skill, string Email);

        public bool AddCompany(Company company, string Email);

        public bool login(string eMail, string pass);
        public bool UpdateTrainer(string tableName, string columnName, string newValue, string userID);

        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill);
        public bool DeleteTrainer(string userID, string pass);
    }
}
