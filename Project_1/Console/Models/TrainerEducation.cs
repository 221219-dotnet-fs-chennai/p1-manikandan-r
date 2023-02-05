using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainerEducation
    {
        public TrainerEducation()
        {
        }

       // public string Userid { get; set; }
        public string Ug_collage { get; set; } = null!;

        public string Ug_stream { get; set; } = null!;

        public string Ug_percentage { get; set; } = null!;
        public string Ug_year { get; set; } = null!;

        public string Pg_collage { get; set; }

        public string Pg_stream { get; set; } 

        public string Pg_percentage { get; set; } 

        public string Pg_year { get; set; }

        public string GetTrainerEducations()
        {
            return $@"
UG Education Details:
UG college name: {Ug_collage}, UG stream: {Ug_stream}, UG percentage: {Ug_percentage}, UG passed out year: {Ug_year}";
        }
    }
}
