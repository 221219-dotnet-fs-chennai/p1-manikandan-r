using Trainer_EF_Layer;
using Models;


namespace Bussiness_Logic
{
    public class Logic : ILogic
    {
        Mapper map = new Mapper();

        TrainerEFRepo newrepo = new TrainerEFRepo();

        public bool captchaReturn()
        {
            Random rand = new Random();

            string[] captchas = { "UYW7B2", "NBA82G", "PQ1ZX7", "IGTDYJ", "BVATFH", "LPQTAZ",
"PQJAYD", "AYUZVB", "VYAFJL", "MQNZYR", "KL187A", "Z72B98", "WLC69A", "BVA39S", "BAYPWH", "N4YU0C", "K8O7Q5",
"TAZLND", "8BA62F" };
            int index = rand.Next(captchas.Length);
            int i = 7;
            string captcha = captchas[index];

            Console.WriteLine("\n-----------------------------------------HUMAN VERIFICATION----------------------------------------\n");
            Console.WriteLine(@"Instruction!! 
After reading this instruction press enter. A captcha will shown for 7 seconds, Remember the captcha and 
type the captcha after 7 seconds completed. If you fail You redirected to Main Menu again");
            Console.Write("\nPress Enter to Continue...");
            Console.ReadLine();
            Console.Clear();

            while (i >= 1)
            {
                Console.WriteLine("\n-----------------------------------------HUMAN VERIFICATION----------------------------------------\n");
                Console.WriteLine($"\nTime left: {i}");
                Console.WriteLine($"\nYour captcha to remember: {captchas[index]}");
                Thread.Sleep(1000);
                Console.Clear();
                i--;
            }

            Console.Clear();
            Console.WriteLine("\n-----------------------------------------HUMAN VERIFICATION----------------------------------------\n");
            Console.Write("\nEnter the captcha: ");
            string? captchaByUser = Console.ReadLine();

            if (captcha == captchaByUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTrainer(string EmailID, string pass)
        {
            return newrepo.DeleteTrainer(EmailID, pass);
        }

        public TrainerCompany GetAllCompanies(string userId)
        {
            return map.MapCompany(newrepo.GetAllCompanies(userId));
        }

        public TrainerEducation GetAllEducation(string userId)
        {
            return map.MapEducation(newrepo.GetAllEducation(userId));
        }

        public TrainerSkill GetAllSkills(string userId)
        {
            return map.MapSkill(newrepo.GetAllSkills(userId));
        }

        public TrainerDetail GetAllTrainers(string userId)
        {
            return map.MapTrainer(newrepo.GetAllTrainers(userId));
        }

        public IEnumerable<AllTrainerDetails> GetAllTrainerDetails()
        {
            return newrepo.GetAllTrainerDetails();
        }

        public bool AddTrainer(Models.TrainerDetail trainer, string Email)
        {
            return newrepo.AddTrainer(map.mapTrainer(trainer), Email);
        }

        public bool AddEducation(TrainerEducation education, string Email)
        {
            return newrepo.AddEducation(map.mapEducation(education), Email);
        }

        public bool AddSkill(TrainerSkill skill, string Email)
        {
            return newrepo.AddSkill(map.mapSkill(skill), Email);
        }

        public bool AddCompany(TrainerCompany company, string Email)
        {
            return newrepo.AddCompany(map.mapCompany(company), Email);
        }


        public bool login(string eMail, string pass)
        {
            return newrepo.login(eMail, pass);
        }

        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill)
        {
            return newrepo.TrainerFilter(city, skill);
        }

        public bool UpdateTrainer(string tableName, string columnName, string newValue, string userID)
        {
            return newrepo.UpdateTrainer(tableName, columnName, newValue, userID);
        }
    }
}
