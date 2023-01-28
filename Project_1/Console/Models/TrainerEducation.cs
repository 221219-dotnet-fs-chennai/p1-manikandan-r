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

        string ug_collage;
        string ug_stream;
        string ug_percentage;
        string ug_year;
        string pg_collage;
        string pg_stream;
        string pg_percentage;
        string pg_year;

        public string Ug_collage
        {
            get { return ug_collage; }
            set { ug_collage = value; }
        }

        public string Ug_stream
        {
            get { return ug_stream; }
            set { ug_stream = value; }
        }

        public string Ug_percentage
        {
            get { return ug_percentage; }
            set { ug_percentage = value; }
        }

        public string Ug_year
        {
            get { return ug_year; }
            set { ug_year = value; }
        }

        public string Pg_collage
        {
            get { return pg_collage; }
            set { pg_collage = value; }
        }

        public string Pg_stream
        {
            get { return pg_stream; }
            set { pg_stream = value; }
        }

        public string Pg_percentage
        {
            get { return pg_percentage; }
            set { pg_percentage = value; }
        }

        public string Pg_year
        {
            get { return pg_year; }
            set { pg_year = value; }
        }

        public string GetTrainerEducations()
        {
            return $@"
UG Education Details:
UG college name: {Ug_collage}, UG stream: {Ug_stream}, UG percentage: {Ug_percentage}, UG passed out year: {Ug_year}";
        }
    }
}
