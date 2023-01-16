using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Data
{
    public class SqlRepo : IRepo
    {
        private readonly string connectionString;

        public SqlRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Trainer Insertion(Trainer trainer)
        {
            String[] userID_array = trainer.Emailid.Split("@");
            string User_ID = userID_array[0];
            trainer.Userid = User_ID;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query_1 = @"insert into TrainerDetails(User_ID, Email_ID, Password, Firstname, Lastname, Age, Gender, Phone_Number, City) values (@User_ID, @Email_ID, @Password, @Fname, @Lname, @Age, @gender, @Phone_number, @City)";
            SqlCommand command_1 = new SqlCommand(query_1, connection);

            command_1.Parameters.AddWithValue("@User_ID", trainer.Userid);
            command_1.Parameters.AddWithValue("@Email_ID", trainer.Emailid);
            command_1.Parameters.AddWithValue("@Password", trainer.Password);
            command_1.Parameters.AddWithValue("@Fname", trainer.Firstname);
            command_1.Parameters.AddWithValue("@Lname", trainer.Lastname);
            command_1.Parameters.AddWithValue("@Age", Convert.ToInt32(trainer.Age));
            command_1.Parameters.AddWithValue("@gender", trainer.Gender);
            command_1.Parameters.AddWithValue("@Phone_number", trainer.Phonenumber);
            command_1.Parameters.AddWithValue("@City", trainer.City);

            command_1.ExecuteNonQuery();


            string query_2 = @"insert into Education(User_ID, Ug_collage, Ug_stream, Ug_Percentage, Ug_year, Pg_collage, Pg_stream, Pg_Percentage, Pg_year) values (@User_ID, @Ug_collage, @Ug_stream, @Ug_Percentage, @Ug_year, @Pg_collage, @Pg_stream, @Pg_Percentage, @Pg_year)";
            SqlCommand command_2 = new SqlCommand(query_2, connection);

            command_2.Parameters.AddWithValue("@User_ID", trainer.Userid);
            command_2.Parameters.AddWithValue("@Ug_collage", trainer.Ug_collage);
            command_2.Parameters.AddWithValue("@Ug_stream", trainer.Ug_stream);
            command_2.Parameters.AddWithValue("@Ug_Percentage", trainer.Ug_percentage);
            command_2.Parameters.AddWithValue("@Ug_year", trainer.Ug_year);
            

            if (string.IsNullOrEmpty(trainer.Pg_collage))
            {
                command_2.Parameters.AddWithValue("@Pg_collage", "Null");
            }
            else
            {
                command_2.Parameters.AddWithValue("@Pg_collage", trainer.Pg_collage);
            }
            if (string.IsNullOrEmpty(trainer.Pg_stream))
            {
                command_2.Parameters.AddWithValue("@Pg_stream", "Null");
            }
            else
            {
                command_2.Parameters.AddWithValue("@Pg_stream", trainer.Pg_stream);
            }
            if (string.IsNullOrEmpty(trainer.Pg_percentage))
            {
                command_2.Parameters.AddWithValue("@Pg_Percentage", "Null");
            }
            else
            {
                command_2.Parameters.AddWithValue("@Pg_Percentage", trainer.Pg_percentage);
            }
            if (string.IsNullOrEmpty(trainer.Pg_year))
            {
                command_2.Parameters.AddWithValue("@Pg_year", "Null");
            }
            else
            {
                command_2.Parameters.AddWithValue("@Pg_year", trainer.Pg_year);
            }

            command_2.ExecuteNonQuery();

            string query_3 = @"insert into Skill(User_ID, Skill_1, Skill_2, Skill_3) values(@User_ID, @Skill_1, @Skill_2, @Skill_3)";
            SqlCommand command_3 = new SqlCommand(query_3, connection);

            command_3.Parameters.AddWithValue("@User_ID", trainer.Userid);
            command_3.Parameters.AddWithValue("@Skill_1", trainer.Skill_1);
            command_3.Parameters.AddWithValue("@Skill_2", trainer.Skill_2);
            
            if (string.IsNullOrEmpty(trainer.Skill_3))
            {
                command_3.Parameters.AddWithValue("@Skill_3", "Null");
            }
            else
            {
                command_3.Parameters.AddWithValue("@Skill_3", trainer.Skill_3);
            }

            command_3.ExecuteNonQuery();

            string query_4 = @"insert into Company(User_ID, Company_Name, Field, Overall_Experience) values (@User_ID, @Company_Name, @Field, @Overall_Experience)";
            SqlCommand command_4 = new SqlCommand(query_4, connection);

            command_4.Parameters.AddWithValue("@User_ID", trainer.Userid);

            if (string.IsNullOrEmpty(trainer.Companyname))
            {
                command_4.Parameters.AddWithValue("@Company_Name", "Null");
            }
            else
            {
                command_4.Parameters.AddWithValue("@Company_Name", trainer.Companyname);
            }
            if (string.IsNullOrEmpty(trainer.Field))
            {
                command_4.Parameters.AddWithValue("@Field", "Null");
            }
            else
            {
                command_4.Parameters.AddWithValue("@Field", trainer.Field);
            }
            if (string.IsNullOrEmpty(trainer.Experience))
            {
                command_4.Parameters.AddWithValue("@Overall_Experience", "Null");
            }
            else
            {
                command_4.Parameters.AddWithValue("@Overall_Experience", trainer.Experience);
            }

            command_4.ExecuteNonQuery();

            Console.WriteLine("row(s) added successfully");
            Console.ReadLine();

            return trainer;
        }

        public List<Trainer> GetAllTrainers()
        {
            List<Trainer> trainer = new List<Trainer>();

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                string query_5 = @"Select TrainerDetails.User_ID, TrainerDetails.Email_ID, TrainerDetails.Firstname, TrainerDetails.Lastname, TrainerDetails.Age, TrainerDetails.Gender, TrainerDetails.Phone_Number, TrainerDetails.City, 
Education.Ug_collage, Education.Ug_stream, Education.Ug_Percentage, Education.Ug_year, Education.Pg_collage, Education.Pg_stream, Education.Pg_Percentage, Education.Pg_year,
Skill.Skill_1, Skill.Skill_2, Skill.Skill_3,
Company.Company_Name, Company.Field, Company.Overall_Experience From TrainerDetails
join Education on TrainerDetails.User_ID = Education.User_ID
join Skill on Education.User_ID = Skill.User_ID
join Company on Skill.User_ID = Company.User_ID;";

                SqlCommand command = new SqlCommand(query_5, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trainer.Add(new Trainer()
                    {
                        Userid = reader.GetString(0),
                        Emailid = reader.GetString(1),
                        Firstname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        Age = reader.GetInt32(4),
                        Gender = reader.GetString(5),
                        Phonenumber = reader.GetString(6),
                        City = reader.GetString(7),
                        Ug_collage = reader.GetString(8),
                        Ug_stream = reader.GetString(9),
                        Ug_percentage = reader.GetString(10),
                        Ug_year = reader.GetString(11),
                        Pg_collage = reader.GetString(12),
                        Pg_stream = reader.GetString(13),
                        Pg_percentage = reader.GetString(14),
                        Pg_year = reader.GetString(15),
                        Skill_1 = reader.GetString(16),
                        Skill_2 = reader.GetString(17),
                        Skill_3 = reader.GetString(18),
                        Companyname = reader.GetString(19),
                        Field = reader.GetString(20),
                        Experience = reader.GetString(21)
                    });
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw;
            }
            return trainer;
        }

        public List<Trainer> GetAllTrainersDisconnected()
        {
            List<Trainer> trainer = new List<Trainer>();

            SqlConnection con = new SqlConnection(connectionString);

            string query_6 = @"Select TrainerDetails.User_ID, TrainerDetails.Email_ID, TrainerDetails.Firstname, TrainerDetails.Lastname, TrainerDetails.Age, TrainerDetails.Gender, TrainerDetails.Phone_Number, TrainerDetails.City, 
Education.Ug_collage, Education.Ug_stream, Education.Ug_Percentage, Education.Ug_year, Education.Pg_collage, Education.Pg_stream, Education.Pg_Percentage, Education.Pg_year,
Skill.Skill_1, Skill.Skill_2, Skill.Skill_3,
Company.Company_Name, Company.Field, Company.Overall_Experience From TrainerDetails
join Education on TrainerDetails.User_ID = Education.User_ID
join Skill on Education.User_ID = Skill.User_ID
join Company on Skill.User_ID = Company.User_ID;";

            SqlDataAdapter adapter = new SqlDataAdapter(query_6, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dtTrainer = ds.Tables[0];

            foreach (DataRow row in dtTrainer.Rows)
            {
                trainer.Add(new Trainer()
                {
                    Userid = (string)row[0],
                    Emailid = (string)row[1],
                    Firstname = (string)row[2],
                    Lastname = (string)row[3],
                    Age = (int)row[4],
                    Gender = (string)row[5],
                    Phonenumber = (string)row[6],
                    City = (string)row[7],
                    Ug_collage = (string)row[8],
                    Ug_stream = (string)row[9],
                    Ug_percentage = (string)row[10],
                    Ug_year = (string)row[11],
                    Pg_collage = (string)row[12],
                    Pg_stream = (string)row[13],
                    Pg_percentage = (string)row[14],
                    Pg_year = (string)row[15],
                    Skill_1 = (string)row[16],
                    Skill_2 = (string)row[17],
                    Skill_3 = (string)row[18],
                    Companyname = (string)row[19],
                    Field = (string)row[20],
                    Experience = (string)row[21]
                });
            }

            return trainer;
        }
    }
}
