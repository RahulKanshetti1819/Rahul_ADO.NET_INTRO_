using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        // Connection string to your SQL Server database
        string connectionString = "Data Source=myServerAddress;Initial Catalog=myDatabase;User ID=myUsername;Password=myPassword";

        // Create a SqlConnection object to connect to the database
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Open the database connection
                connection.Open();

                // Define the trader information to be inserted
                string traderName = "John Doe";
                int age = 30;
                string city = "New York";

                // Define the SQL insert query
                string sqlInsertQuery = "INSERT INTO Traders (Name, Age, City) VALUES (@Name, @Age, @City)";

                // Create a SqlCommand object with the insert query and connection
                using (SqlCommand command = new SqlCommand(sqlInsertQuery, connection))
                {
                    // Add parameters to the command to avoid SQL injection
                    command.Parameters.AddWithValue("@Name", traderName);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@City", city);

                    // Execute the insert command
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Trader information inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert trader information.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
