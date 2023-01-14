// get details from user

using Data;
public class LogIn
{
    public void login()
    {
        Console.WriteLine("Code is not Completed :|...");
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }
}
internal class SignUp
{
    private static User user = new User();
    private static Education education = new Education();
    private static Skills skill = new Skills();
    private static Work company = new Work();

    public void displayDetails()
    {
        Console.Clear();

        Console.WriteLine("\n-------USER DETAILS-------\n");
        Console.WriteLine("Email ID: " + user.Emailid);
        Console.WriteLine("Firstname: " + user.Firstname);
        Console.WriteLine("Lastname: " + user.Lastname);
        Console.WriteLine("Age: " + user.Age);
        Console.WriteLine("Gender: " + user.Gender);
        Console.WriteLine("Phone number: " + user.Phonenumber);
        Console.WriteLine("City: " + user.City);

        Console.ReadLine();
    }
    public string userDetails()
    {
        Console.Clear();

        Console.WriteLine("\n-------USER DETAILS-------\n");
        Console.Write("Enter your Email ID: ");
        user.Emailid = Console.ReadLine();
        Console.Write("Enter your Password: ");
        user.Password = Console.ReadLine();
        Console.Write("Enter your Firstname: ");
        user.Firstname = Console.ReadLine();
        Console.Write("Enter your Lastname: ");
        user.Lastname = Console.ReadLine();
        Console.Write("Enter your Age: ");
        user.Age = Convert.ToByte(Console.ReadLine());
        Console.Write("Enter your Gender: ");
        user.Gender = Console.ReadLine();
        Console.Write("Enter your Phone number: ");
        user.Phonenumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter you City: ");
        user.City = Console.ReadLine();
        Console.WriteLine("Press Enter to Next...");
        Console.ReadLine();

        return "User details added Successfully";
    }

    public string eduDetails()
    {
        Console.Clear();

        Console.WriteLine("\n-------EDUCATION DETAILS-------\n");
        Console.Write("Enter your UG collage name: ");
        education.Ug_collage = Console.ReadLine();
        Console.Write("Enter your UG stream: ");
        education.Ug_stream = Console.ReadLine();
        Console.Write("Enter your UG percentage: ");
        education.Ug_percentage = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your UG year: ");
        education.Ug_year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your PG collage name: ");
        education.Pg_collage = Console.ReadLine();
        Console.Write("Enter your PG stream: ");
        education.Pg_stream = Console.ReadLine();
        Console.Write("Enter your PG percentage: ");
        education.Pg_percentage = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your PG year: ");
        education.Pg_year = Convert.ToInt32(Console.ReadLine());

        return "Education details added Successfully";
    }

    public string skillDetails()
    {
        Console.Clear();

        Console.WriteLine("\n-------USER SKILLS-------\n");
        Console.Write("Enter your 1st skill: ");
        skill.Skill_1 = Console.ReadLine();
        Console.Write("Enter your 2nd skill: ");
        skill.Skill_2 = Console.ReadLine();
        Console.Write("Enter your 3rd skill: ");
        skill.Skill_3 = Console.ReadLine();

        return "User skills added Successfully";
    }

    public string companyDetails()
    {
        Console.Clear();

        Console.WriteLine("\n-------WORK DETAILS-------\n");
        Console.Write("Enter your current or last working company: ");
        company.Comapnyname = Console.ReadLine();
        Console.Write("Enter you field: ");
        company.Field = Console.ReadLine();
        Console.Write("Enter your overall experience: ");
        company.Experience = Console.ReadLine();

        return "Company details entered successfully";
    }
}
