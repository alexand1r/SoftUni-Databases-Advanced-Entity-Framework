using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.IncreaseMinionsAge
{
    class IncreaseMinionsAge
    {
        static void Main(string[] args)
        {
            SqlConnection connection;
            connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true;");

            connection.Open();
            using (connection)
            {
                var digits = Console.ReadLine().Split(' ').ToArray();
                foreach (var digit in digits)
                {
                    ChangeAge(connection, int.Parse(digit));
                    ChangeName(connection, int.Parse(digit));
                }

                PrintMinions(connection);
            }
        }

        private static void PrintMinions(SqlConnection connection)
        {
            string sqlFindNames = "SELECT Name From Minions";
            SqlCommand getMinionNames = new SqlCommand(sqlFindNames, connection);

            SqlDataReader reader = getMinionNames.ExecuteReader();
            List<string> names = new List<string>();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["Name"].ToString());
                }
            }
        }

        private static void ChangeName(SqlConnection connection, int minionId)
        {
            string sqlChangeName = @"
                        UPDATE Minions 
                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, Len(Name))
                        WHERE Id=@minionId";
            SqlCommand changeAge = new SqlCommand(sqlChangeName, connection);
            SqlParameter minionIdParam = new SqlParameter("@minionId", minionId);
            changeAge.Parameters.Add(minionIdParam);
            changeAge.ExecuteNonQuery();
        }

        private static void ChangeAge(SqlConnection connection, int minionId)
        {
            string sqlChangeAge = "UPDATE Minions SET Age+=1 WHERE Id=@minionId";
            SqlCommand changeAge = new SqlCommand(sqlChangeAge, connection);
            SqlParameter ageParam = new SqlParameter("@minionId", minionId);
            changeAge.Parameters.Add(ageParam);
            changeAge.ExecuteNonQuery();
        }
    }
}
