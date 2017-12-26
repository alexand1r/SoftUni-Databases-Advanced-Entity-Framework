using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.VillainNames
{
    class VillainNames
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;");

            connection.Open();
            
            using (connection)
            {
                GetVillainNameAndCountOfMinions(connection);
            }
        }

        private static void GetVillainNameAndCountOfMinions(SqlConnection connection)
        {
            string query = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\2.VillainNames\GetNames.sql");
            SqlCommand FindNames = new SqlCommand(query, connection);
            SqlDataReader reader = FindNames.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string villainName = (string)reader["Name"];
                    int MinionsCount = (int)reader["MinionsCount"];
                    Console.WriteLine($"{villainName} {MinionsCount}");
                }
            }
        }
    }
}
