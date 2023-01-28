using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainerSkill
    {
        public TrainerSkill() 
        {
        }

        string userid;
        string skill_1;
        string skill_2;
        string skill_3;


        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        public string Skill_1
        {
            get { return skill_1; }
            set { skill_1 = value; }
        }
        public string Skill_2
        {
            get { return skill_2; }
            set { skill_2 = value; }
        }
        public string Skill_3
        {
            get { return skill_3; }
            set { skill_3 = value; }
        }

        public string GetTrainerSkills()
        {
            return $@"
Skills:
Skill 1: {Skill_1}, Skill 2: {Skill_2}, Skill 3: {Skill_3}";
        }
    }
}
