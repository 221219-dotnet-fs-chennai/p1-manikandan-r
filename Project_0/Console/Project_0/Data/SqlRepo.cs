using System;
using System.Data.SqlClient;

namespace UI_Console
{
    public class SqlRepo
    {
        public string Add()
        {
            string connectionString = "Server=LAPTOP-G6S85J4G; Database=testing; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "insert into ctedb(product_id, product_name, price) values (7001, 'Power Bank', 499)";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Added Successfully");
            
            connection.Close();

            return "Done";
        }

        public string Insert()
        {
            string connectionString = "Server=LAPTOP-G6S85J4G; Database=testing; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select product_id, product_name, price from ctedb";
            SqlCommand command = new SqlCommand(query, connection);
            // execute it
            SqlDataReader reader = command.ExecuteReader();
            // process the output
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}, {reader.GetInt32(2)}");
            }
            reader.Close();
            return "Done....";
        }
    }
}
