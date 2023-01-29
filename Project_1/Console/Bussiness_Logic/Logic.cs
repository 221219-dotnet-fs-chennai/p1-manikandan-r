
using Models;


namespace Bussiness_Logic
{
    public class Logic : ILogic
    {

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

        public IEnumerable<AllTrainerDetails> TrainerFilter(string city, string skill, string company)
        {
            if (city == "ex: chennai or delhi" && skill == "ex: python or java" && company == "ex: micosoft or infosys")
            {
                Console.WriteLine("You Didn't choose any filter\n");
                return newrepo.GetAllTrainerDetails().ToList();
            }
            else if (city != "ex: chennai or delhi" && skill == "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_1 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.City.ToLower() == city
                              select trainer;
                return query_1.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_2 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill
                              select trainer;
                return query_2.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_3 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.Companyname.ToLower() == company
                              select trainer;
                return query_3.ToList();
            }
            else if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company == "ex: micosoft or infosys")
            {
                var query_4 = from trainer in newrepo.GetAllTrainerDetails()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.City.ToLower() == city)
                              select trainer;
                return query_4.ToList();
            }
            else if (city != "ex: chennai or delhi" && skill == "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_5 = from trainer in newrepo.GetAllTrainerDetails()
                              where trainer.City.ToLower() == city && trainer.Companyname.ToLower() == company
                              select trainer;
                return query_5.ToList();
            }
            else if (city == "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_6 = from trainer in newrepo.GetAllTrainerDetails()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.Companyname.ToLower() == company)
                              select trainer;
                return query_6.ToList();
            }
            if (city != "ex: chennai or delhi" && skill != "ex: python or java" && company != "ex: micosoft or infosys")
            {
                var query_7 = from trainer in newrepo.GetAllTrainerDetails()
                              where (trainer.Skill_1.ToLower() == skill || trainer.Skill_2.ToLower() == skill || trainer.Skill_3.ToLower() == skill) && (trainer.Companyname.ToLower() == company) && (trainer.City.ToLower() == city)
                              select trainer;
                return query_7.ToList();
            }

            return newrepo.GetAllTrainerDetails().ToList();
        }
    }
}
