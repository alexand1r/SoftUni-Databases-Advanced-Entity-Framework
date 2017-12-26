using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.InitialSetup
{
    class InitialSetup
    {
        static void Main(string[] args)
        {
            SqlConnection connection;
            connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;");

            connection.Open();
            using (connection)
            {
                //createDbCommand.ExecuteNonQuery();
                createDatabase(connection);
            }
        }

        private static void createDatabase(SqlConnection connection)
        {
            string query = File.ReadAllText(@"C:\softuni\Databases Advanced - Entity Framework\homework\FetchingResultsWithADONet\1.InitialSetup\Setup.sql");
            string sqlCreateDb = "CREATE DATABASE MinionsDB";
            SqlCommand createDbCommand = new SqlCommand(sqlCreateDb, connection);
            SqlCommand createTablesAndInsertData = new SqlCommand(query, connection);
            Console.WriteLine(createTablesAndInsertData.ExecuteNonQuery());
        }
    }
}
