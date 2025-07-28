using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Encrypt=False;"; 

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Connecting to database...");
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {                           // Get + Type                     // Column Number (0 is Guid, 0 is Title)
                        Console.WriteLine($"{reader.GetGuid(0)} -  {reader.GetString(1)}");
                        // old model of creation db connection
                    }
                }
            }
            //     connection.Open();
            //     // INSERT
            //     // UPDATE
            //     connection.Close();
            //     connection.Dispose();
            // }
        }
    }
}