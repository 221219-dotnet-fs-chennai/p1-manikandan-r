using System;
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

        /// <summary>
        /// It get city, skill and/or company form user and use LINQ to filter data 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="skill"></param>
        /// <param name="company"></param>
        /// <returns>It will return the respective filtered data by user choice</returns>
        IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill);

    }
}
