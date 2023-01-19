using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="skill"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        IEnumerable<Trainer> TrainerFilter(string city, string skill, string company);
    }
}
