using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ChangeTownNameCasing
{
    class ChangeTownNameCasing
    {
        static void Main(string[] args)
        {

            SqlConnection connection;
            connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;");

            connection.Open();
            using (connection)
            {

                string country = Console.ReadLine().Trim();
                string query = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\5.ChangeTownNameCasing\Update.sql");
                SqlCommand updateTownsCommand = new SqlCommand(query, connection);
                SqlParameter countryParam = new SqlParameter("@country", country);
                updateTownsCommand.Parameters.Add(countryParam);

                int rowsAffected = updateTownsCommand.ExecuteNonQuery();
                if (rowsAffected <= 0)
                {
                    Console.WriteLine($"{rowsAffected} town names were affected.");
                    string query2 = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\5.ChangeTownNameCasing\SelectTowns.sql");
                    SqlCommand findTowns = new SqlCommand(query2, connection);
                    SqlParameter countryParam2 = new SqlParameter("@country", country);
                    findTowns.Parameters.Add(countryParam2);
                    SqlDataReader reader = findTowns.ExecuteReader();
                    List<string> towns = new List<string>();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            towns.Add(reader["TownName"].ToString());
                        }
                    }
                    Console.WriteLine("[" + String.Join(", ", towns) + "]");

                } else
                {
                    Console.WriteLine($"{rowsAffected} town names were affected.");
                }
            }

        }
    }
}
