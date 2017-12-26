using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.MinionNames
{
    class MinionNames
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;");

            connection.Open();
            
            using (connection)
            {
                int villainId = int.Parse(Console.ReadLine());
                string query = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\3.MinionNames\GetNames.sql");
                SqlCommand findVillainNameCommand = new SqlCommand(query, connection);
                SqlParameter villainIdParam = new SqlParameter("@villainId", villainId);
                findVillainNameCommand.Parameters.Add(villainIdParam);
               
                var villName = findVillainNameCommand.ExecuteScalar();
                if (villName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                } else
                {
                    Console.WriteLine($"Villain: {villName}");

                    string sqlMinions = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\3.MinionNames\GetMinions.sql");
                    SqlCommand findMinions = new SqlCommand(sqlMinions, connection);
                    SqlParameter villainIdParam2 = new SqlParameter("@villainId", villainId);
                    findMinions.Parameters.Add(villainIdParam2);
                    SqlDataReader reader = findMinions.ExecuteReader();

                    using (reader)
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("{0}. {1} {2}", reader[0], reader[1], reader[2]);
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}. {1} {2}", reader[0], reader[1], reader[2]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }

            }
        }
    }
}
