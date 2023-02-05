using Models;
using TrainerData = Trainer_EF_Layer.Entities;

namespace Bussiness_Logic
{
    public class Mapper
    {
        // model to entitity
        public TrainerData.TrainerDetail mapTrainer(TrainerDetail valm)
        {
            return new TrainerData.TrainerDetail()
            {
               //UserId = valm.Userid,
                EmailId = valm.Emailid,
                Password = valm.Password,
                Firstname = valm.Firstname,
                Lastname = valm.Lastname,
                Age = valm.Age,
                Gender = valm.Gender,
                PhoneNumber = valm.Phonenumber,
                City = valm.City
            };
        }

        public TrainerData.Education mapEducation(TrainerEducation vale)
        {
            return new TrainerData.Education()
            {
                //UserId = vale.Userid,
                UgCollage = vale.Ug_collage,
                UgStream = vale.Ug_stream,
                UgPercentage = vale.Ug_percentage,
                UgYear = vale.Ug_year,
                PgCollage = vale.Pg_collage,
                PgStream = vale.Pg_stream,
                PgPercentage = vale.Pg_percentage,
                PgYear = vale.Pg_year,
            };
        }

        public TrainerData.Skill mapSkill(TrainerSkill vals)
        {
            return new TrainerData.Skill()
            {
               // UserId = vals.Userid,
                Skill1 = vals.Skill_1,
                Skill2 = vals.Skill_2,
                Skill3 = vals.Skill_3,
            };
        }

        public TrainerData.Company mapCompany(TrainerCompany valc)
        {
            return new TrainerData.Company()
            {
               // UserId = valc.Userid,
                CompanyName = valc.Companyname,
                Field = valc.Field,
                OverallExperience = valc.Experience,
            };
        }


        // entitity to model
        public TrainerDetail MapTrainer(TrainerData.TrainerDetail val)
        {
            return new Models.TrainerDetail()
            {
                Emailid = val.EmailId,
                Firstname = val.Firstname,
                Lastname = val.Lastname,
                Age = val.Age,
                Gender = val.Gender,
                Phonenumber = val.PhoneNumber,
                City= val.City,
            };
        }
        
        public TrainerEducation MapEducation(TrainerData.Education val)
        {
            return new TrainerEducation()
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


        public TrainerSkill MapSkill(TrainerData.Skill val)
        {
            return new TrainerSkill()
            {
                Skill_1 = val.Skill1,
                Skill_2 = val.Skill2,
                Skill_3 = val.Skill3,
            };
        }
    
        public TrainerCompany MapCompany(TrainerData.Company val)
        {
            return new TrainerCompany()
            {
                Companyname = val.CompanyName,
                Field = val.Field,
                Experience = val.OverallExperience,
            };
        }
    }
}
