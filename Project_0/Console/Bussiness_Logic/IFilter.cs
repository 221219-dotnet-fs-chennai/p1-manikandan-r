using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Bussiness_Logic
{
    public interface IFilter
    {
        /// <summary>
        /// It get city, skill and/or company form user and use LINQ to filter data 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="skill"></param>
        /// <param name="company"></param>
        /// <returns>It will return the respective filtered data by user choice</returns>
        IEnumerable<Trainer> TrainerFilter(string city, string skill, string company);
    }
}
