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

        // public string Userid { get; set; }
        public string Skill_1 { get; set;  } = null!;
        public string Skill_2 { get; set; } = null!;
        public string Skill_3 { get; set; }

        public string GetTrainerSkills()
        {
            return $@"
Skills:
Skill 1: {Skill_1}, Skill 2: {Skill_2}, Skill 3: {Skill_3}";
        }
    }
}
