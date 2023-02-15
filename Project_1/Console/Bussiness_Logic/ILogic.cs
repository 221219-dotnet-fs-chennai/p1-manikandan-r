﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Trainer_EF_Layer.Entities;

namespace Bussiness_Logic
{
    public interface ILogic
    {
        /// <summary>
        /// Captcha verification
        /// </summary>
        /// <returns>return true if the captcha is right else false</returns>
        public bool captchaReturn();


        Models.TrainerDetail GetAllTrainers(string userId);
        TrainerEducation GetAllEducation(string userId);
        TrainerSkill GetAllSkills(string userId);
        TrainerCompany GetAllCompanies(string userId);

        public IEnumerable<AllTrainerDetails> GetAllTrainerDetails();

        public bool AddTrainer(Models.TrainerDetail trainer, string Email);

        public bool AddEducation(TrainerEducation education, string Email);

        public bool AddSkill(TrainerSkill skill, string Email);

        public bool AddCompany(TrainerCompany company, string Email);

        public bool login(string eMail, string pass);

        Models.TrainerDetail UpdateTrainer(Models.TrainerDetail trainer, string email);
        TrainerEducation UpdateEducation(TrainerEducation education, string email);
        TrainerSkill UpdateSkill(TrainerSkill skill, string email);
        TrainerCompany UpdateCompany(TrainerCompany company, string email);
        public bool DeleteTrainer(string userID, string pass);

        /// <summary>
        /// It get city, skill and/or company form user and use LINQ to filter data 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="skill"></param>
        /// <param name="company"></param>
        /// <returns>It will return the respective filtered data by user choice</returns>
        IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill);
        bool ForgetPassword(string email, string phonenum, string pass);

    }
}
