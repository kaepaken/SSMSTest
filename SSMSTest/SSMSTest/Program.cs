using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=(LocalDB)\\LocalDBDemo;" +
                                       "Initial Catalog=StudentTracker;");
                SqlCommand cmd = new SqlCommand("Select * from Students");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                Console.WriteLine("Connection Open");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(reader.GetOrdinal("Name")));
                }

                Console.ReadLine();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
