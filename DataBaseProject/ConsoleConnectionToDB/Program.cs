using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleConnectionToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.; Initial Catalog=TestDatabaseProject; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();

                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"SELECT * FROM Students where iD = {1}";

                    SqlDataReader reader = command.ExecuteReaderAsync().Result;

                    if (reader.HasRows)
                    {
                        reader.ReadAsync();
                        Console.WriteLine(reader.GetString(1));
                        //reader.GetInt32(0);
                        //reader.GetString(1);
                    }

                    reader.Close();

                    command.CommandText = "INSERT INTO table_name (FName, LName) VALUES(value1, value2)";

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();

                        throw ex;
                    }
                    catch (Exception exRollback)
                    {
                        throw exRollback;
                    }
                }
            }

            Console.ReadKey();

        }
    }
}
