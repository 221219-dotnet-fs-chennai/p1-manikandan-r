﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Bussiness_Logic
{
    public interface ILogic
    {
        IEnumerable<TrainerDetail> GetTrainers();

        IEnumerable<TrainerEducation> GetEducations();
        IEnumerable<TrainerSkill> GetSkills();

        IEnumerable<TrainerCompany> GetCompanies();

        /// <summary>
        /// It get city, skill and/or company form user and use LINQ to filter data 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="skill"></param>
        /// <param name="company"></param>
        /// <returns>It will return the respective filtered data by user choice</returns>
        // IEnumerable<TrainerDetail> TrainerFilter(string city, string skill, string company);
    }
}