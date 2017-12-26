using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.RemoveVillain
{
    class RemoveVillain
    {
        static void Main(string[] args)
        {
            SqlConnection connection;
            connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;");

            connection.Open();
            using (connection)
            {
                int villainId = int.Parse(Console.ReadLine());
                string sqlVillainName = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\5.RemoveVillain\VillainName.sql");
                SqlCommand findVillainNameCommand = new SqlCommand(sqlVillainName, connection);
                SqlParameter villainIdParam = new SqlParameter("@villainId", villainId);
                findVillainNameCommand.Parameters.Add(villainIdParam);
                var villainName = findVillainNameCommand.ExecuteScalar();
             
                if (villainName != null)
                {
                    string deleteVillain = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\5.RemoveVillain\DeleteVillain.sql");
                    SqlCommand deleteVillainCommand = new SqlCommand(deleteVillain, connection);
                    SqlParameter villainIdParam2 = new SqlParameter("@villainId", villainId);
                    deleteVillainCommand.Parameters.Add(villainIdParam2);

                    deleteVillainCommand.ExecuteNonQuery();
                    Console.WriteLine($"{villainName} was deleted");

                    string unmasterMinions = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\5.RemoveVillain\UnmasterMinions.sql");
                    SqlCommand unmasterMinionsCommand = new SqlCommand(unmasterMinions, connection);
                    SqlParameter villainIdParam3 = new SqlParameter("@villainId", villainId);
                    unmasterMinionsCommand.Parameters.Add(villainIdParam3);

                    var minionsUpdated = unmasterMinionsCommand.ExecuteNonQuery();
                    Console.WriteLine($"{minionsUpdated} minions released");
                }
                else
                {
                    Console.WriteLine("No such villain was found");
                }
            }
        }
    }
}
