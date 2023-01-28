using TrainerData = Trainer_EF_Layer.Entities;

namespace Bussiness_Logic
{
    public class Mapper
    {
        public static Models.TrainerDetail Map(TrainerData.TrainerDetail val)
        {
            return new Models.TrainerDetail()
            {
                Emailid = val.EmailId,
                Firstname= val.Firstname,
                Lastname= val.Lastname,
                Age= val.Age,
                Gender= val.Gender,
                Phonenumber = val.PhoneNumber,
                City= val.City,
            };
        }
        public static IEnumerable<Models.TrainerDetail> Map(IEnumerable<TrainerData.TrainerDetail> trainers) 
        {
            return trainers.Select(Map);
        }

        public static Models.TrainerEducation Map(TrainerData.Education val)
        {
            return new Models.TrainerEducation()
            {
                Ug_collage = val.UgCollage,
                Ug_stream = val.UgStream,
                Ug_percentage = val.UgPercentage,
                Ug_year = val.UgYear,
                Pg_collage = val.PgCollage,
                Pg_stream = val.PgStream,
                Pg_percentage = val.PgPercentage,
                Pg_year = val.PgYear,
            };
        }

        public static IEnumerable<Models.TrainerEducation> Map(IEnumerable<TrainerData.Education> trainers)
        {
            return trainers.Select(Map);
        }

        public static Models.TrainerSkill Map(TrainerData.Skill val)
        {
            return new Models.TrainerSkill()
            {
                Skill_1 = val.Skill1,
                Skill_2 = val.Skill2,
                Skill_3 = val.Skill3,
            };
        }
    
        public static IEnumerable<Models.TrainerSkill> Map(IEnumerable<TrainerData.Skill> trainers)
        {
            return trainers.Select(Map);
        } 

        public static Models.TrainerCompany Map(TrainerData.Company val)
        {
            return new Models.TrainerCompany()
            {
                Companyname = val.CompanyName,
                Field = val.Field,
                Experience = val.OverallExperience,
            };
        }
    
        public static IEnumerable<Models.TrainerCompany> Map(IEnumerable<TrainerData.Company> trainers)
        {
            return trainers.Select(Map);
        }
    }
}
