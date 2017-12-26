using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.IncreaseAgeStoredProcedure
{
    class IncreaseAgeStoredProcedure
    {
        static void Main(string[] args)
        {
            SqlConnection connection;
            connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true;");

            connection.Open();
            using (connection)
            {
                int id = int.Parse(Console.ReadLine());
                string query = "EXEC dbo.usp_GetOlder @Id";
                SqlCommand getOlderCommand = new SqlCommand(query, connection);
                SqlParameter mId = new SqlParameter("@Id", id);
                getOlderCommand.Parameters.Add(mId);

                getOlderCommand.ExecuteNonQuery();

                string sqlShowMinion = "SELECT Name, Age FROM Minions WHERE Id = @Id";
                SqlCommand showMinionCommand = new SqlCommand(sqlShowMinion, connection);
                SqlParameter mId2 = new SqlParameter("@Id", id);
                showMinionCommand.Parameters.Add(mId2);

                SqlDataReader reader = showMinionCommand.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                    else
                    {
                        Console.WriteLine("NO MINION WAS UPDATED.");
                    }
                }
            }
        }
    }
}

//CREATE PROCEDURE usp_GetOlder (@MinionId INT) 
//AS
//BEGIN 
//	BEGIN TRANSACTION

//	DECLARE @Id INT = (SELECT Id FROM Minions WHERE Id = @MinionId);
//	IF @Id IS NULL
//		BEGIN
//			ROLLBACK;
//			RAISERROR('Invalid Id', 16, 1);
//			RETURN;
//		END
//	ELSE
//		BEGIN
//			UPDATE Minions
//			SET Age += 1
//			WHERE Id = @MinionId
//		END
//	COMMIT;
//END 
