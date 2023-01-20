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

        static string conStr = File.ReadAllText("../../../../Data/ConnectionString.txt");
        public FilterRepo(string conStr)
        {
            repo = new SqlRepo(conStr);
        }
        public IEnumerable<Trainer> TrainerFilter(string city, string skill, string company)
        {
            if (city == "ex: chennai or delhi" && skill == "ex: python or java" && company == "ex: micosoft or infosys")
            {
                Console.WriteLine("You Didn't choose any filter\n");
                return repo.GetAllTrainersDisconnected().ToList();
            }
            else if (city != "ex: chennai or delhi" && skill == "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_1 = from trainer in repo.GetAllTrainersDisconnected()
                              where trainer.City.ToLower() == city
                              select trainer;
                return query_1.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_2 = from trainer in repo.GetAllTrainersDisconnected()
                              where trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill
                              select trainer;
                return query_2.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_3 = from trainer in repo.GetAllTrainersDisconnected()
                              where trainer.Companyname.ToLower() == company
                              select trainer;
                return query_3.ToList();
            }
            else if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_4 = from trainer in repo.GetAllTrainersDisconnected()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.City.ToLower() == city)
                              select trainer;
                return query_4.ToList();
            }
            else if(city != "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_5 = from trainer in repo.GetAllTrainersDisconnected()
                              where trainer.City.ToLower() == city && trainer.Companyname.ToLower() == company
                              select trainer;
                return query_5.ToList();
            }
            else if(city == "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_6 = from trainer in repo.GetAllTrainersDisconnected()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.Companyname.ToLower() == company)
                              select trainer;
                return query_6.ToList();
            }
            if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_7 = from trainer in repo.GetAllTrainersDisconnected()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.Companyname.ToLower() == company) && (trainer.City.ToLower() == city)
                              select trainer;
                return query_7.ToList();
            }

            return repo.GetAllTrainersDisconnected().ToList();
        }
    }
}
