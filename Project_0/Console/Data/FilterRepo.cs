using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FilterRepo : IFilter
    {
        IRepo repo;

        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");
        public FilterRepo(string conStr)
        {
            repo = new SqlRepo(conStr);
        }
        public IEnumerable<Trainer> TrainerFilter(string city, string skill, string company)
        {
            if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                Console.WriteLine("You Didn't choose any filter\n");
                return repo.GetAllTrainersDisconnected().ToList();
            }
            else if (city != "ex: chennai or delhi" && skill == "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_1 = from r in repo.GetAllTrainersDisconnected()
                              where r.City.ToLower() == city
                              select r;
                return query_1.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_2 = from r in repo.GetAllTrainersDisconnected()
                              where r.Skill_1.ToLower() == skill || r.Skill_2.ToLower() == skill || r.Skill_3.ToLower() == skill
                              select r;
                return query_2.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_3 = from r in repo.GetAllTrainersDisconnected()
                              where r.Companyname.ToLower() == company
                              select r;
                return query_3.ToList();
            }
            else if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_4 = from r in repo.GetAllTrainersDisconnected()
                              where (r.Skill_1.ToLower() == skill || r.Skill_2.ToLower() == skill || r.Skill_3.ToLower() == skill) && (r.City.ToLower() == city)
                              select r;
                return query_4.ToList();
            }
            else if(city != "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_5 = from r in repo.GetAllTrainersDisconnected()
                              where r.City.ToLower() == city && r.Companyname.ToLower() == company
                              select r;
                return query_5.ToList();
            }
            else if(city == "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_6 = from r in repo.GetAllTrainersDisconnected()
                              where (r.Skill_1.ToLower() == skill || r.Skill_2.ToLower() == skill || r.Skill_3.ToLower() == skill) && (r.Companyname.ToLower() == company)
                              select r;
                return query_6.ToList();
            }
            else
            {
                Console.WriteLine();
            }

            return repo.GetAllTrainersDisconnected().ToList();
        }
    }
}
