using System;
using System.Data.SqlClient;
using Models;

namespace MyAdoNetAPP
{
    public class Program
    {
        public static void Main(String[] args)
        {

            Console.WriteLine("Start LINe");
            String connectionString = "User ID=sa;password=YourPassword123!;server=localhost;Trusted_Connection=False;Persist Security Info=False;Encrypt=False";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine("Success fully established database connection");
                String Query = "select * from Medicine";
                using(SqlCommand cmd = new SqlCommand(Query,conn))
                {
                    cmd.ExecuteReader();
                }
            }
        
        }
    }
}

















