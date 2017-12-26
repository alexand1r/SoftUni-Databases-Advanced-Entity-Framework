using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.PrintAllMinionNames
{
    class PrintAllMinionNames
    {
        static void Main(string[] args)
        {
            SqlConnection connection;
            connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true;");

            connection.Open();
            using (connection)
            {
                string sqlFindNames = "SELECT Name From Minions";
                SqlCommand getMinionNames = new SqlCommand(sqlFindNames, connection);

                SqlDataReader reader = getMinionNames.ExecuteReader();
                List<string> names = new List<string>();
                using (reader)
                {
                    while (reader.Read()) {
                        names.Add(reader["Name"].ToString());
                    }
                }

                for (int i = 1; i < names.Count; i++)
                {
                    Console.WriteLine(names[i - 1]);
                    Console.WriteLine(names[names.Count - i]);
                }
            }
        }
    }
}
